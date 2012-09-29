using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Podcaster.Core
{
    public delegate void ResumeRecording();
    public delegate void PauseRecording();
    public delegate void LogSong(SongInfo sp);
    public delegate void SongPlayedEvent(SongPlayed sp);

    public interface IController
    {
        event ResumeRecording OnResume;
        event PauseRecording OnPause;
        event LogSong OnLogSong;
        void SetParameter(string key, string value);
        void Start();
        void Close();
    }
}
