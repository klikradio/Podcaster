using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Podcaster.Core
{
    public delegate void StartTimer();
    public delegate void PauseTimer();

    public interface ITimer
    {
        Color GetPausedColor();
        Color GetCountingColor();
        event StartTimer OnStart;
        event PauseTimer OnPause;
    }
}
