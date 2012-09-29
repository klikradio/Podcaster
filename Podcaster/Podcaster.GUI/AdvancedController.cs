using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Podcaster.Business;
using Podcaster.Core;

namespace Podcaster
{
    public partial class AdvancedController : Form
    {
        private KLIKPodcast kCurrentPodcast;
        private MainForm mf;

        public bool bAllowClose = false;

        private delegate void AddSongCallback(ListViewItem lvi);
        private delegate void OnAirCallback();

        public AdvancedController(MainForm mf, KLIKPodcast kPodcast)
        {
            this.mf = mf;
            this.kCurrentPodcast = kPodcast;

            InitializeComponent();
        }

        private void AdvancedController_Load(object sender, EventArgs e)
        {
            SongLog.View = View.Details;

            ColumnHeader c = new ColumnHeader();
            c.Text = "Time";
            c.Width = 75;
            SongLog.Columns.Add(c);

            c = new ColumnHeader();
            c.Text = "Artist";
            c.Width = 200;
            SongLog.Columns.Add(c);

            c = new ColumnHeader();
            c.Text = "Title";
            c.Width = 200;
            SongLog.Columns.Add(c);

            c = new ColumnHeader();
            c.Text = "Source";
            c.Width = 75;
            SongLog.Columns.Add(c);

            kCurrentPodcast.OnPause += new PauseRecording(Controller_OnPause);
            kCurrentPodcast.OnResume += new ResumeRecording(Controller_OnResume);
            kCurrentPodcast.OnSongPlayed += new SongPlayedEvent(kCurrentPodcast_OnSongPlayed);

            AutoControl.ForeColor = Color.Green;

            TotalLength.Start();
            PausedTime.Start();
            PodcastLength.Stop();

            attachControllerToolStripMenuItem.DropDownItems.Clear();

            Thread t = new Thread(new ThreadStart(LoadTimers));
            t.Start();
        }

        private void LoadTimers()
        {
            foreach (string s in PluginLoader.ListPlugins("ITimer"))
            {
                attachControllerToolStripMenuItem.DropDownItems.Add(s, null, attachControllerToolStripMenuItem_Click);
            }
        }

        #region Controller Interactions
        private void kCurrentPodcast_OnSongPlayed(SongPlayed sp)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = kCurrentPodcast.dStarted.AddSeconds(sp.TimeFromBeginning).ToShortTimeString();
            lvi.SubItems.Add(sp.Artist);
            lvi.SubItems.Add(sp.Title);
            lvi.SubItems.Add(sp.strSource);

            AddSong(lvi);
        }

        private void Controller_OnResume()
        {
            SetOnAir();
        }

        private void Controller_OnPause()
        {
            SetOffAir();
        }

        private void SetOnAir()
        {
            if (RecordingLamp.InvokeRequired)
            {
                OnAirCallback oac = new OnAirCallback(SetOnAir);
                this.Invoke(oac);
            }
            else
            {
                RecordingLamp.BackColor = Color.Red;
                RecordingLamp.Text = "ON AIR";

                PodcastLength.Start();
                PausedTime.Stop();
            }
        }

        private void SetOffAir()
        {
            if (RecordingLamp.InvokeRequired)
            {
                OnAirCallback oac = new OnAirCallback(SetOffAir);
                this.Invoke(oac);
            }
            else
            {
                RecordingLamp.BackColor = Color.DarkGreen;
                RecordingLamp.Text = "CLEAR";

                PodcastLength.Stop();
                PausedTime.Start();
            }
        }

        private void AddSong(ListViewItem lvi)
        {
            if (SongLog.InvokeRequired)
            {
                AddSongCallback d = new AddSongCallback(AddSong);
                this.Invoke(d, new object[] { lvi });
            }
            else
            {
                SongLog.Items.Insert(0, lvi);
            }
        }
        #endregion

        #region Deck Control
        private void AutoControl_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoControl.Checked)
            {
                AutoControl.ForeColor = Color.Green;
            }
            else
            {
                AutoControl.ForeColor = Color.Red;
            }
            kCurrentPodcast.AcceptCommands = AutoControl.Checked;
        }

        private void RecordButton_Click(object sender, EventArgs e)
        {
            kCurrentPodcast.ResumeShow();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            kCurrentPodcast.PauseShow();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to end your show?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                ShowInfo si = new ShowInfo(this.mf, this.kCurrentPodcast);
                si.ac = this;
                si.Show();
            }
        }

        private void UpdateAndPause_Click(object sender, EventArgs e)
        {
            UpdateSong_Click(sender, e);
            kCurrentPodcast.PauseShow();
        }

        private void UpdateSong_Click(object sender, EventArgs e)
        {
            // Send information to streaming media servers...
            SongPlayed kte = new SongPlayed(kCurrentPodcast, DateTime.Now, UpdateArtist.Text, UpdateTitle.Text, "Manual");
            // kte.UpdateServers();
            kCurrentPodcast.LogSong(kte);

            UpdateArtist.Text = "";
            UpdateTitle.Text = "";
        }
        #endregion


        private void AdvancedController_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            e.Cancel = !bAllowClose;
        }

        private ITimer ExternalTimer;

        #region Auxiliary Timers
        private void attachControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem)
            {
                ToolStripItem tsi = (ToolStripItem)sender;
                ExternalTimer = (ITimer)PluginLoader.LoadPlugin(tsi.Text, "ITimer");

                ExternalTimer.OnPause += new PauseTimer(ExternalTimer_OnPause);
                ExternalTimer.OnStart += new StartTimer(ExternalTimer_OnStart);
            }
        }

        private void ExternalTimer_OnStart()
        {
            AuxTimer1.Start();
        }

        private void ExternalTimer_OnPause()
        {
            AuxTimer1.Stop();
        }
        #endregion
    }
}
