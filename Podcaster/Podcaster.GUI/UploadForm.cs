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

namespace Podcaster
{
    public partial class UploadForm : Form
    {
        private KLIKPodcast kPodcast;

        private delegate void SetProgressStyleCallback(ProgressBarStyle pbs);
        private delegate void SetProgressMaximumCallback(int max);
        private delegate void SetProgressValueCallback(int value);
        private delegate void CloseDialogCallback();

        private bool bCancelClose
        {
            get
            {
                return !kPodcast.UploadingPodcast;
            }
        }

        public UploadForm(KLIKPodcast kp)
        {
            this.kPodcast = kp;
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = bCancelClose;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void UploadForm_Load(object sender, EventArgs e)
        {
            UploadIcon.Visible = true;

            UploadProgress.MarqueeAnimationSpeed = 30;
            UploadProgress.Style = ProgressBarStyle.Marquee;

            kPodcast.OnBytesSent += new KLIKPodcast.SentBytes(kPodcast_OnBytesSent);
            kPodcast.OnUploadComplete += new KLIKPodcast.UploadComplete(kPodcast_OnUploadComplete);
        }

        private void kPodcast_OnUploadComplete()
        {
            this.CloseDialog();
        }

        private void kPodcast_OnBytesSent(long bytesSent, long totalBytes)
        {
            SetProgressStyle(ProgressBarStyle.Continuous);
            SetProgressMaximum((int)totalBytes);
            SetProgressValue((int)bytesSent);
        }

        private void SetProgressStyle(ProgressBarStyle pbs)
        {
            if (UploadProgress.InvokeRequired)
            {
                SetProgressStyleCallback sps = new SetProgressStyleCallback(SetProgressStyle);
                this.Invoke(sps, pbs);
            }
            else
            {
                UploadProgress.Style = pbs;
            }
        }

        private void SetProgressMaximum(int max)
        {
            if (UploadProgress.InvokeRequired)
            {
                SetProgressMaximumCallback spm = new SetProgressMaximumCallback(SetProgressMaximum);
                this.Invoke(spm, max);
            }
            else
            {
                UploadProgress.Maximum = max;
            }
        }

        private void SetProgressValue(int value)
        {
            if (UploadProgress.InvokeRequired)
            {
                SetProgressValueCallback spv = new SetProgressValueCallback(SetProgressValue);
                this.Invoke(spv, value);
            }
            else
            {
                UploadProgress.Value = value;
            }
        }

        private void CloseDialog()
        {
            if (this.InvokeRequired)
            {
                CloseDialogCallback cdc = new CloseDialogCallback(CloseDialog);
                this.Invoke(cdc);
            }
            else
            {
                this.Close();
            }
        }

        private void UploadIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }
    }
}
