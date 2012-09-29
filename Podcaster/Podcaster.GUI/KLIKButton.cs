using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Podcaster
{
    public partial class KLIKButton : Button
    {
        private Timer Dragger;

        private int offsetY;
        private int offsetX;
        private int oldTop;
        private int oldLeft;

        public KLIKButton() : base()
        {
            Dragger = new Timer();
            Dragger.Interval = 10;
            Dragger.Tick += new EventHandler(Dragger_Tick);

            this.FlatAppearance.BorderSize = 0;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            oldLeft = this.TopLevelControl.Left;
            oldTop = this.TopLevelControl.Top;

            offsetX = mevent.X + this.Left;
            offsetY = mevent.Y + this.Top;

            Dragger.Start();
        }

        private void Dragger_Tick(object sender, EventArgs e)
        {
            this.TopLevelControl.Top = Cursor.Position.Y - offsetY;
            this.TopLevelControl.Left = Cursor.Position.X - offsetX;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            Dragger.Stop();

            int calcTop = Math.Abs(oldTop - this.TopLevelControl.Top);
            int calcLeft = Math.Abs(oldLeft - this.TopLevelControl.Left);

            if (calcTop < 3 &&
                calcLeft < 3)
            {
                this.PerformClick();
            }
        }
    }
}
