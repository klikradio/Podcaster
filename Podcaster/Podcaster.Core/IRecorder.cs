using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Podcaster.Core
{
    public interface IRecorder
    {
        void StartRecording();
        void PauseRecording();
        void ResumeRecording();
        void StopRecording();
    }
}
