namespace Podcaster
{
    partial class UploadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadForm));
            this.UploadIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.UploadProgress = new System.Windows.Forms.ProgressBar();
            this.UploadLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UploadIcon
            // 
            this.UploadIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("UploadIcon.Icon")));
            this.UploadIcon.Text = "KLIK Podcast Uploader";
            this.UploadIcon.Visible = true;
            this.UploadIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UploadIcon_MouseDoubleClick);
            // 
            // UploadProgress
            // 
            this.UploadProgress.Location = new System.Drawing.Point(12, 12);
            this.UploadProgress.Name = "UploadProgress";
            this.UploadProgress.Size = new System.Drawing.Size(432, 33);
            this.UploadProgress.TabIndex = 0;
            // 
            // UploadLabel
            // 
            this.UploadLabel.AutoSize = true;
            this.UploadLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadLabel.Location = new System.Drawing.Point(12, 48);
            this.UploadLabel.Name = "UploadLabel";
            this.UploadLabel.Size = new System.Drawing.Size(84, 17);
            this.UploadLabel.TabIndex = 1;
            this.UploadLabel.Text = "Uploading...";
            // 
            // UploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 73);
            this.Controls.Add(this.UploadLabel);
            this.Controls.Add(this.UploadProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UploadForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KLIK Uploader";
            this.Load += new System.EventHandler(this.UploadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon UploadIcon;
        private System.Windows.Forms.ProgressBar UploadProgress;
        private System.Windows.Forms.Label UploadLabel;
    }
}