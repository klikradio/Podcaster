using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Podcaster.Core;
using iTunesLib;

namespace Podcaster.iTunesController
{
    public class iTunesController : IController
    {
        private iTunesApp app;

        public event ResumeRecording OnResume;
        public event PauseRecording OnPause;
        public event LogSong OnLogSong;

        public void Start()
        {
            app = new iTunesApp();

            app.OnPlayerPlayingTrackChangedEvent += new _IiTunesEvents_OnPlayerPlayingTrackChangedEventEventHandler(app_OnPlayerPlayingTrackChangedEvent);
            app.OnPlayerPlayEvent += new _IiTunesEvents_OnPlayerPlayEventEventHandler(app_OnPlayerPlayEvent);
            app.OnPlayerStopEvent += new _IiTunesEvents_OnPlayerStopEventEventHandler(app_OnPlayerStopEvent);
        }

        private void app_OnPlayerPlayingTrackChangedEvent(object iTrack)
        {
            if (OnLogSong != null)
            {
                SongInfo si = new SongInfo(((IITTrack)iTrack).Artist, ((IITTrack)iTrack).Name, "iTunes");
                Console.WriteLine(si.Artist + " - " + si.Title);
                OnLogSong(si);
            }
        }

        private void app_OnPlayerStopEvent(object iTrack)
        {
            if (OnResume != null)
            {
                OnResume();
            }
        }

        private void app_OnPlayerPlayEvent(object iTrack)
        {
            if (OnPause != null)
            {
                OnPause();
            }
            if (OnLogSong != null)
            {
                SongInfo si = new SongInfo(((IITTrack)iTrack).Artist, ((IITTrack)iTrack).Name, "iTunes");
                Console.WriteLine(si.Artist + " - " + si.Title);
                OnLogSong(si);
            }
        }

        public void SetParameter(string key, string value)
        {
        }

        public void Close()
        {
        }
    }
}
