using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Podcaster.Core;
using Podcaster.Business;

namespace Podcaster
{
    public partial class ChangeSong : Form
    {
        private DateTime dtPressed;
        private KLIKPodcast kCurrentPodcast;

        public ChangeSong(KLIKPodcast kp, DateTime dt)
        {
            this.kCurrentPodcast = kp;
            this.dtPressed = dt;

            InitializeComponent();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            // Send information to streaming media servers...
            SongPlayed kte = new SongPlayed(kCurrentPodcast, dtPressed, Artist.Text, Title.Text, "Manual");
            kCurrentPodcast.LogSong(kte, true);
            this.Close();
        }
    }
}
