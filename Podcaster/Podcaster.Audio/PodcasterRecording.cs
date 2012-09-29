using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass;
using Un4seen.Bass.AddOn;
using Un4seen.Bass.Misc;

using Podcaster.Core;

namespace Podcaster.Audio
{
    /// <summary>
    /// Enumeration representing different options for stereophonic sound
    /// </summary>
    public enum StereoMode
    {
        Mono,
        Stereo,
        JointStereo
    }

    /// <summary>
    /// Represents a sound recorder
    /// </summary>
    public class PodcasterRecording : IRecorder
    {
        private RECORDPROC _myRecProc;
        private int _recHandle;
        private EncoderLAME lame;

        /// <summary>
        /// Initialize recording for this application (default sound card) (on application load)
        /// </summary>
        /// <returns>Successful</returns>
        public static bool RecordInit()
        {
            return RecordInit(-1);
        }

        /// <summary>
        /// Initialize recording for this application (given sound card name)
        /// </summary>
        /// <param name="strDevice">Name of sound card</param>
        /// <returns>Successful</returns>
        public static bool RecordInit(string strDevice)
        {
            for (int x = 0; x < Bass.BASS_RecordGetDeviceCount(); x++)
            {
                if (Bass.BASS_RecordGetDeviceInfo(x).name.Contains(strDevice))
                {
                    return Bass.BASS_RecordInit(x);
                }
            }
            return false;
        }

        /// <summary>
        /// Initialize recording for this applciation (on application load)
        /// </summary>
        /// <param name="nDevice">Device ID</param>
        /// <returns>Successful</returns>
        public static bool RecordInit(int nDevice)
        {
            return Bass.BASS_RecordInit(nDevice);
        }

        /// <summary>
        /// Create a new recording with standard 128kbps stereo settings
        /// </summary>
        /// <param name="strFileName">File name to record to</param>
        public PodcasterRecording(string strFileName) : this(strFileName, 44100, 2, 128, StereoMode.JointStereo) { }

        /// <summary>
        /// Create a new recording with custom settings
        /// </summary>
        /// <param name="strFileName">File Name</param>
        /// <param name="samplerate">Sample rate</param>
        /// <param name="channels">Channels</param>
        /// <param name="bitrate">Bitrate</param>
        /// <param name="stereomode">Stereo mode</param>
        public PodcasterRecording(string strFileName, int samplerate, int channels, int bitrate, StereoMode stereomode)
        {
            if (!strFileName.ToLower().EndsWith(".mp3"))
            {
                // TODO: implement other codecs
                throw new Exception("Currently, Podcaster only works with MP3 files");
            }

            _myRecProc = new RECORDPROC(RecordAudio);
            _recHandle = Bass.BASS_RecordStart(samplerate, channels, BASSFlag.BASS_RECORD_PAUSE, _myRecProc, IntPtr.Zero);

            lame = new EncoderLAME(_recHandle);
            lame.InputFile = null;
            lame.OutputFile = strFileName;
            lame.LAME_Bitrate = bitrate;

            switch (stereomode)
            {
                case StereoMode.JointStereo:
                    lame.LAME_Mode = EncoderLAME.LAMEMode.JointStereo;
                    break;
                case StereoMode.Mono:
                    lame.LAME_Mode = EncoderLAME.LAMEMode.Mono;
                    break;
                default:
                    lame.LAME_Mode = EncoderLAME.LAMEMode.Stereo;
                    break;
            }

            lame.LAME_TargetSampleRate = samplerate;
            lame.LAME_Quality = EncoderLAME.LAMEQuality.Quality;
        }

        // Message loop for recording audio.
        // TODO: implement volume metering for advanced view.
        private unsafe bool RecordAudio(int handle, IntPtr buffer, int length, IntPtr user)
        {
            return true;
        }

        /// <summary>
        /// Start recording
        /// </summary>
        public void StartRecording()
        {
            lame.Start(null, IntPtr.Zero, false);
            Bass.BASS_ChannelPlay(_recHandle, false);
        }

        /// <summary>
        /// Pause recording
        /// </summary>
        public void PauseRecording()
        {
            lame.Pause(true);
        }

        /// <summary>
        /// Resume recording
        /// </summary>
        public void ResumeRecording()
        {
            lame.Pause(false);
        }

        /// <summary>
        /// Stop recording
        /// </summary>
        public void StopRecording()
        {
            Bass.BASS_ChannelStop(_recHandle);
            lame.Stop();
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~PodcasterRecording()
        {
            StopRecording();
        }

        /// <summary>
        /// Free BASS (on application exit)
        /// </summary>
        public static void Free()
        {
            Bass.BASS_Stop();
            Bass.BASS_Free();
        }
    }
}
