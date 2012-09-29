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
    public partial class ChooseShow : Form
    {
        private MainForm mf;

        public ChooseShow(MainForm mf)
        {
            this.mf = mf;
            this.Owner = mf;

            InitializeComponent();
            this.ShowDialog(mf);
        }

        private void ChooseShow_Load(object sender, EventArgs e)
        {
            // Load the shows...
            KLIKShow.ListShows(this.Shows);
        }

        private void TheCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChooseShow_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            mf.BigButton.Enabled = true;
        }

        private void StartShowButton_Click(object sender, EventArgs e)
        {
            // Init a new podcast class...
            KLIKPodcast kp = new KLIKPodcast((DataRowView)Shows.SelectedItem);
            mf.kCurrentPodcast = kp;

            // Start the show at the business level...
            kp.StartShow();

            // Do our GUI stuff...
            if (kp.kShow.kSkill == ShowPermissions.Advanced)
            {
                // Create an advanced controller form...
                AdvancedController ac = new AdvancedController(this.mf, kp);
                ac.Show();
                mf.Hide();
            }
            else
            {
                // Update the MainForm
                mf.UpdateStatus();
            }

            // Close this form...
            this.Close();
        }
    }
}
