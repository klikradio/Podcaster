using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Podcaster
{
    public class KLIKTimerLabel : KLIKLabel
    {
        private Timer thisTimer;
        private int nCurrentTime = 0;

        private Color _pausedColor = Color.Yellow;
        private Color _countingColor = Color.Lime;

        public int Interval
        {
            get
            {
                return thisTimer.Interval;
            }
            set
            {
                thisTimer.Interval = value;
            }
        }

        public Color PausedColor
        {
            get
            {
                return _pausedColor;
            }
            set
            {
                _pausedColor = value;
            }
        }

        public Color CountingColor
        {
            get
            {
                return _countingColor;
            }
            set
            {
                _countingColor = value;
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
        }

        public KLIKTimerLabel() : this(false)
        {
        }

        protected KLIKTimerLabel(bool bDraggable) : base(bDraggable)
        {
            base.Text = "0:00:00";
            base.ForeColor = _pausedColor;

            thisTimer = new Timer();
            thisTimer.Tick += new EventHandler(thisTimer_Tick);
        }

        public void Start()
        {
            thisTimer.Start();
            base.ForeColor = _countingColor;
        }

        public void Stop()
        {
            thisTimer.Stop();
            base.ForeColor = _pausedColor;
        }

        public void Toggle()
        {
            if (thisTimer.Enabled)
            {
                Stop();
            }
            else
            {
                Start();
            }
        }

        private void thisTimer_Tick(object sender, EventArgs e)
        {
            nCurrentTime++;

            int nSeconds = nCurrentTime;
            int nMinutes = 0;
            int nHours = 0;

            if (nSeconds > 59)
            {
                nMinutes = nSeconds / 60;
                nSeconds = nSeconds % 60;

                if (nMinutes > 59)
                {
                    nHours = nMinutes / 60;
                    nMinutes = nMinutes % 60;
                }
            }

            base.Text = String.Format("{0}:{1:00}:{2:00}", nHours, nMinutes, nSeconds);
        }

        public void Clear()
        {
            nCurrentTime = 0;
        }
    }

    public class KLIKTimerDraggableLabel : KLIKTimerLabel
    {
        public KLIKTimerDraggableLabel()
            : base(true)
        {
        }
    }
}
