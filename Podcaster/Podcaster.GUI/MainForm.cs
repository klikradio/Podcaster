using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Podcaster.Core;
using Podcaster.Business;

namespace Podcaster
{
    public partial class MainForm : Form, IPodcasterForm
    {
        public KLIKPodcast kCurrentPodcast;

        private Font OnAirFont = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private Font OffAirFont = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        private delegate void ResumePodcastCallback();
        private delegate void PausePodcastCallback();

        private PauseRecording thisPauseEvent;
        private ResumeRecording thisResumeEvent;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Width = BigButton.Width;
            this.Height = BigButton.Height;
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;

            BigButton.Top = 0;
            BigButton.Left = 0;

            iPodButton.Visible = false;
            ChangeSongButton.Visible = false;
            DurationTimerLabel.Visible = false;
        }

        #region Methods and Events for Intermediate Mode
        /// <summary>
        /// Load the change song form
        /// </summary>
        private void ChangeSongDialog()
        {
            ChangeSong cs = new ChangeSong(kCurrentPodcast, DateTime.Now);
            cs.ShowDialog(this);
        }

        private void iPodButton_Click(object sender, EventArgs e)
        {
            if (iPodButton.Text.Contains("ON"))
            {
                // Pause the recording in the BLL
                kCurrentPodcast.PauseShow();

                // Stop accepting commands from the controller
                kCurrentPodcast.AcceptCommands = false;

                // GUI stuff for turning on the iPod...
                ChangeSongDialog();

                ChangeSongButton.Visible = true;
                DurationTimerLabel.Visible = false;
                PausePodcast();
            }
            else
            {
                if (ChangeSongButton.Visible)
                {
                    // Resume the recording in the BLL
                    kCurrentPodcast.ResumeShow();

                    // Resume accepting commands from the controller
                    kCurrentPodcast.AcceptCommands = true;

                    // GUI stuff for turning off the iPod...
                    ResumePodcast();
                    ChangeSongButton.Visible = false;
                    DurationTimerLabel.Visible = true;
                }
                else
                {
                    MessageBox.Show(this, "The controller has disabled recording because a song is playing.", "Sorry...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void ChangeSongButton_Click(object sender, EventArgs e)
        {
            // Show the "change song" form...
            ChangeSongDialog();
        }

        private void OnAirFlashTimer_Tick(object sender, EventArgs e)
        {
            if (iPodButton.BackColor == Color.DarkRed)
            {
                iPodButton.BackColor = Color.Red;
            }
            else
            {
                iPodButton.BackColor = Color.DarkRed;
            }
        }

        private void kCurrentPodcast_OnResume()
        {
            ResumePodcast();
        }

        private void kCurrentPodcast_OnPause()
        {
            PausePodcast();
        }

        private void ResumePodcast()
        {
            if (iPodButton.InvokeRequired)
            {
                ResumePodcastCallback pc = new ResumePodcastCallback(ResumePodcast);
                this.Invoke(pc);
            }
            else
            {
                iPodButton.BackColor = Color.DarkRed;
                iPodButton.Font = OnAirFont;
                iPodButton.Text = "ON AIR";
                OnAirFlashTimer.Start();
                DurationTimerLabel.Start();
            }
        }

        private void PausePodcast()
        {
            if (iPodButton.InvokeRequired)
            {
                PausePodcastCallback pc = new PausePodcastCallback(PausePodcast);
                this.Invoke(pc);
            }
            else
            {
                OnAirFlashTimer.Stop();
                DurationTimerLabel.Stop();
                iPodButton.BackColor = Color.Green;
                iPodButton.Font = OffAirFont;
                iPodButton.Text = "OFF AIR";
            }
        }
        #endregion

        /// <summary>
        /// Update the form's status to display what's going on
        /// </summary>
        public void UpdateStatus()
        {
            if (kCurrentPodcast == null)
            {
                BigButton.Text = "START\nSHOW";
                BigButton.BackColor = Color.DarkGreen;
                BigButton.Height = this.Height;
                iPodButton.Visible = false;
                BigButton.Enabled = true;

                this.Width = BigButton.Width;
                this.Height = BigButton.Height;
                this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
                BigButton.Top = 0;
                BigButton.Left = 0;

                ChangeSongButton.Visible = false;
                DurationTimerLabel.Visible = false;
            }
            else
            {
                if (BigButton.Text.Contains("START"))
                {
                    BigButton.Text = "STOP\nSHOW";
                    BigButton.BackColor = Color.Red;

                    if (kCurrentPodcast.kShow.kSkill == ShowPermissions.Intermediate)
                    {
                        this.Left -= this.Width;
                        this.Width *= 2;
                        BigButton.Left = this.Width / 2;

                        iPodButton.Left = 0;
                        iPodButton.Top = 0;
                        iPodButton.Height = this.Height / 2;
                        iPodButton.Width = this.Width / 2;
                        iPodButton.Visible = true;
                        iPodButton.BackColor = Color.DarkRed;
                        iPodButton.Font = OnAirFont;
                        iPodButton.Text = "ON AIR";

                        DurationTimerLabel.Left = 0;
                        DurationTimerLabel.Top = this.Height / 2;
                        DurationTimerLabel.Width = this.Width / 2;
                        DurationTimerLabel.Height = this.Height / 2;
                        DurationTimerLabel.Visible = true;

                        ChangeSongButton.Left = 0;
                        ChangeSongButton.Top = this.Height / 2;
                        ChangeSongButton.Visible = false;

                        thisPauseEvent = new PauseRecording(kCurrentPodcast_OnPause);
                        thisResumeEvent = new ResumeRecording(kCurrentPodcast_OnResume);

                        this.kCurrentPodcast.OnPause += thisPauseEvent;
                        this.kCurrentPodcast.OnResume += thisResumeEvent;

                        OnAirFlashTimer.Start();

                        DurationTimerLabel.Clear();
                        DurationTimerLabel.Start();
                    }

                    BigButton.Enabled = true;
                }
                    /*
                else
                {
                    // Is this even possible...?
                    BigButton.Text = "START\nSHOW";
                    BigButton.BackColor = Color.DarkGreen;
                    BigButton.Height = this.Height;
                    iPodButton.Visible = false;
                    BigButton.Enabled = true;
                } */
            }
        }

        private void BigButton_Click(object sender, EventArgs e)
        {
            BigButton.Enabled = false;

            if (BigButton.Text.Contains("START"))
            {
                new ChooseShow(this);
            }
            else
            {
                ShowInfo si = new ShowInfo(this, kCurrentPodcast);
                si.ShowDialog(this);
            }
        }
    }
}
