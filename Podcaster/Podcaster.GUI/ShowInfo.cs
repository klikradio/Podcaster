using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Podcaster.Business;
using Podcaster.Core;

namespace Podcaster
{
    public partial class ShowInfo : Form
    {
        private KLIKPodcast kp;
        private MainForm mf;

        public ShowInfo(MainForm mf, KLIKPodcast kp)
        {
            if (kp == null || mf == null)
            {
                throw new Exception("Podcast or MainForm was null");
            }

            this.mf = mf;
            this.kp = kp;
            InitializeComponent();
        }

        public AdvancedController ac;

        private void TheCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowInfo_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            mf.BigButton.Enabled = true;
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            if (EpisodeTitle.Text.Trim().Equals("") ||
                Description.Text.Trim().Equals(""))
            {
                MessageBox.Show("Episode title and description are required.", "Sorry...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                kp.EndShow(EpisodeTitle.Text, Description.Text, !IgnoreShow.Checked);

                if (!IgnoreShow.Checked)
                {
                    UploadForm uf = new UploadForm(kp);
                    uf.Show();
                }

                if (ac != null)
                {
                    ac.bAllowClose = true;
                    ac.Close();
                }

                mf.kCurrentPodcast = null;
                mf.UpdateStatus();
                mf.Show();

                this.Close();
            }
        }
    }
}
