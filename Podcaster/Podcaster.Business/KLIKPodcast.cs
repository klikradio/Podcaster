using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Text.RegularExpressions;

using Podcaster.Audio;
using Podcaster.Utilities;
using Podcaster.Core;

namespace Podcaster.Business
{
    /// <summary>
    /// Represents a single podcast entity
    /// </summary>
    public class KLIKPodcast : PodcastInfo
    {
        #region Private Properties
        /// <summary>
        /// A thread for handling our "end show" routines in the background
        /// </summary>
        private Thread EndShowThread;
        /// <summary>
        /// FTP client
        /// </summary>
        private FTPClient ftp;
        /// <summary>
        /// Are we currently uploading?
        /// </summary>
        private bool bUploading = true;
        /// <summary>
        /// The size of the podcast file
        /// </summary>
        private int podcastSize;
        /// <summary>
        /// Should we post this podcast to the feed?
        /// </summary>
        private bool bPostToFeed;
        /// <summary>
        /// Title entries
        /// </summary>
        private TitleEntries TitleEntries = new TitleEntries();
        /// <summary>
        /// Store our edited show file name
        /// </summary>
        private string strEditShow;
        /// <summary>
        /// Pause event to store with the controller
        /// </summary>
        private PauseRecording onPauseEvent;
        /// <summary>
        /// Resume event to store with the controller
        /// </summary>
        private ResumeRecording onResumeEvent;
        /// <summary>
        /// LogSong event to store with the controller
        /// </summary>
        private Core.LogSong logSongEvent;
        #endregion

        #region Public Properties
        /// <summary>
        /// Full show recording object
        /// </summary>
        public PodcasterRecording FullShow;
        /// <summary>
        /// Edited show recording object
        /// </summary>
        public PodcasterRecording EditedShow;
        /// <summary>
        /// Is this podcast accepting commands from the controller?
        /// </summary>
        public bool AcceptCommands = true;
        /// <summary>
        /// Event fired when a song is played
        /// </summary>
        public event SongPlayedEvent OnSongPlayed;
        /// <summary>
        /// Event fired when the podcast is resumed
        /// </summary>
        public event ResumeRecording OnResume;
        /// <summary>
        /// Event fired when the podcast is paused
        /// </summary>
        public event PauseRecording OnPause;
        /// <summary>
        /// Get the size of the podcast file
        /// </summary>
        public int podcastFileSize { get { return podcastSize; } }
        /// <summary>
        /// Are we currently uploading the podcast?
        /// </summary>
        public bool UploadingPodcast { get { return bUploading; } }
        /// <summary>
        /// Upload bytes to FTP server
        /// </summary>
        /// <param name="bytesSent">Number of bytes</param>
        /// <param name="totalBytes">Total number of bytes</param>
        public delegate void SentBytes(long bytesSent, long totalBytes);
        /// <summary>
        /// Fired on bytes sent
        /// </summary>
        public event SentBytes OnBytesSent;
        /// <summary>
        /// Upload complete delegate
        /// </summary>
        public delegate void UploadComplete();
        /// <summary>
        /// Fired when the upload is complete
        /// </summary>
        public event UploadComplete OnUploadComplete;
        /// <summary>
        /// Bytes uploaded to the FTP server
        /// </summary>
        public int PodcastBytesSent
        {
            get
            {
                try
                {
                    if (ftp != null)
                    {
                        return (int)ftp.bytesSent;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch
                {
                    return 0;
                }
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// This constructor is not available from outside the class
        /// </summary>
        private KLIKPodcast()
        {
            this.dStarted = DateTime.Now;

            FullShow = new PodcasterRecording("full.mp3", 44100, 2, 192, StereoMode.JointStereo);
            EditedShow = new PodcasterRecording("edit.mp3", 44100, 1, 64, StereoMode.Mono);

            onPauseEvent = new PauseRecording(Controller_OnPause);
            onResumeEvent = new ResumeRecording(Controller_OnResume);
            logSongEvent = new LogSong(Controller_OnLogSong);

            foreach (IController ic in CoreInstances.Controllers)
            {
                ic.OnPause += onPauseEvent;
                ic.OnResume += onResumeEvent;
                ic.OnLogSong += logSongEvent;
            }
        }
        /// <summary>
        /// Construct a podcast from a DataRowView object
        /// </summary>
        /// <param name="kShow">DataRowView to convert</param>
        public KLIKPodcast(DataRowView kShow) : this()
        {
            this.kShow = CoreInstances.Database.GetShow(kShow);
        }
        /// <summary>
        /// Construct a podcast from a KLIKShow object
        /// </summary>
        /// <param name="kShow">KLIKShow which will own this podcast</param>
        public KLIKPodcast(KLIKShow kShow) : this()
        {
            this.kShow = kShow;
        }
        #endregion

        #region Methods

        #region Event Handlers

        /// <summary>
        /// Log a song played from the controller
        /// </summary>
        /// <param name="sp">Info on the song played</param>
        private void Controller_OnLogSong(SongInfo sp)
        {
            this.LogSong(new SongPlayed(this, DateTime.Now, sp));
        }

        /// <summary>
        /// Controller says to resume recording
        /// </summary>
        private void Controller_OnResume()
        {
            if (AcceptCommands)
            {
                this.ResumeShow();
            }
        }

        /// <summary>
        /// Controller says to pause recording
        /// </summary>
        private void Controller_OnPause()
        {
            if (AcceptCommands)
            {
                this.PauseShow();
            }
        }

        #endregion

        #region Recording Controls

        /// <summary>
        /// Start recording this podcast
        /// </summary>
        public void StartShow()
        {
            foreach (string key in CoreInstances.Commands.Keys)
            {
                CoreInstances.Commands[key].RunCommand(this, ActionCalled.ShowStart);
            }

            FullShow.StartRecording();
            EditedShow.StartRecording();

            if (kShow.kSkill == ShowPermissions.Advanced)
            {
                EditedShow.PauseRecording();
            }
        }

        /// <summary>
        /// Resume recording this podcast
        /// </summary>
        public void ResumeShow()
        {
            // TODO Logic for on-show-resume plug-in events

            EditedShow.ResumeRecording();
            if (OnResume != null)
            {
                OnResume();
            }
        }

        /// <summary>
        /// Pause this podcast
        /// </summary>
        public void PauseShow()
        {
            // TODO Logic for on-show-pause plug-in events

            EditedShow.PauseRecording();
            if (OnPause != null)
            {
                OnPause();
            }
        }

        /// <summary>
        /// Stop recording this podcast
        /// </summary>
        public void EndShow(string strTitle, string strDescription, bool bPostToFeed)
        {
            this.strTitle = strTitle;
            this.strDescription = strDescription;
            this.bPostToFeed = bPostToFeed;
            this.dEnded = DateTime.Now;

            FullShow.StopRecording();
            EditedShow.StopRecording();

            EndShowThread = new Thread(new ThreadStart(DoEndShow));
            EndShowThread.Start();
        }

        /// <summary>
        /// Log a song for this podcast
        /// </summary>
        /// <param name="kte">Title entry to log</param>
        public void LogSong(SongPlayed kte)
        {
            // TODO Logic for on-song events

            TitleEntries.Add(kte);

            if (OnSongPlayed != null)
            {
                OnSongPlayed(kte);
            }
        }

        /// <summary>
        /// Log a song for this podcast
        /// </summary>
        /// <param name="kte">Title entry to log</param>
        /// <param name="bUpdate">Update servers?</param>
        public void LogSong(SongPlayed kte, bool bUpdate)
        {
            if (bUpdate)
            {
                for (int x = 0; x < CoreInstances.Cnfg.Servers.Count; x++)
                {
                    CoreInstances.Cnfg.Servers[x].UpdateSong(kte.Artist, kte.Title);
                }
            }
            LogSong(kte);
        }
        #endregion

        #region Show End Logic

        /// <summary>
        /// End Show background thread
        /// </summary>
        private void DoEndShow()
        {
            foreach (string key in CoreInstances.Commands.Keys)
            {
                CoreInstances.Commands[key].RunCommand(this, ActionCalled.ShowStop);
            }

            Thread.Sleep(1000);

            #region Name Parsing and File Moving
            try
            {
                strEditShow = ParseVariables(CoreInstances.Cnfg.EditedShow, true);
                PodcasterUtilities.VerifyDirectoryExists(strEditShow);
                if (File.Exists(strEditShow))
                {
                    // TODO: File already exists...
                }
                else
                {
                    if (File.Exists("edit.mp3"))
                    {
                        File.Move("edit.mp3", strEditShow);
                    }
                    else
                    {
                        MessageBox.Show("The edited show file was apparently not recorded.", "Weird", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                PodcasterUtilities.KLIKException(ex);
            }

            try
            {
                string strFullShow = ParseVariables(CoreInstances.Cnfg.FullShow, true);
                PodcasterUtilities.VerifyDirectoryExists(strFullShow);
                if (File.Exists(strFullShow))
                {
                    // TODO: File already exists...
                }
                else
                {
                    if (File.Exists("full.mp3"))
                    {
                        File.Move("full.mp3", strFullShow);
                    }
                }
            }
            catch (Exception ex)
            {
                PodcasterUtilities.KLIKException(ex);
            }

            try
            {
                string strTitleStream = ParseVariables(CoreInstances.Cnfg.TitleStream, true);
                PodcasterUtilities.VerifyDirectoryExists(strTitleStream);
                if (File.Exists(strTitleStream))
                {
                    // TODO: File already exists...
                }
                else
                {
                    TitleEntries.SaveXMLFile(strTitleStream);
                }
            }
            catch (Exception ex)
            {
                PodcasterUtilities.KLIKException(ex);
            }
            #endregion

            // Upload MP3 file...
            if (bPostToFeed && !CoreInstances.Cnfg.PodcastFTPHost.Equals(""))
            {
                ftp = new FTPClient(CoreInstances.Cnfg.PodcastFTPHost,
                                    CoreInstances.Cnfg.PodcastFTPUsername,
                                    CoreInstances.Cnfg.PodcastFTPPassword);
                ftp.OnBytesSent += new FTPClient.BytesSent(ftp_OnBytesSent);
                ftp.OnUploadComplete += new FTPClient.UploadComplete(ftp_OnUploadComplete);
                ftp.Login();
                ftp.ChangeDir(CoreInstances.Cnfg.PodcastFTPDirectory);
                ftp.BinaryMode = true;

                AsyncCallback async = new AsyncCallback(UploadCallback);
                ftp.BeginUpload(strEditShow, async);

                FileInfo fi = new FileInfo(strEditShow);
                podcastSize = (int)fi.Length;
            }
            else
            {
                bUploading = false;
            }

            foreach (IController ic in CoreInstances.Controllers)
            {
                ic.OnPause -= onPauseEvent;
                ic.OnResume -= onResumeEvent;
                ic.OnLogSong -= logSongEvent;
            }
        }

        /// <summary>
        /// Called when bytes are sent from the FTP client
        /// </summary>
        /// <param name="bytesSent">Number of bytes sent</param>
        /// <param name="totalBytes">Total number of bytes</param>
        private void ftp_OnBytesSent(long bytesSent, long totalBytes)
        {
            if (OnBytesSent != null)
            {
                OnBytesSent(bytesSent, totalBytes);
            }
        }

        /// <summary>
        /// Called when the upload is complete
        /// </summary>
        private void ftp_OnUploadComplete()
        {
            if (OnUploadComplete != null)
            {
                OnUploadComplete();
            }
        }

        /// <summary>
        /// Called once the file is done uploading.
        /// </summary>
        /// <param name="results">Async results</param>
        private void UploadCallback(IAsyncResult results)
        {
            bUploading = false;
            ftp.Close();

            string strFileName = strEditShow;
            if (strFileName.Contains("\\"))
            {
                strFileName = strFileName.Substring(strFileName.LastIndexOf("\\") + 1);
            }

            try
            {
                CoreInstances.Database.InsertPodcast(this, strFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #endregion
    }
}
