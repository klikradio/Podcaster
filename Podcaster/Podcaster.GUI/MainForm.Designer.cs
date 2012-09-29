namespace Podcaster
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.OnAirFlashTimer = new System.Windows.Forms.Timer(this.components);
            this.DurationTimerLabel = new Podcaster.KLIKTimerDraggableLabel();
            this.ChangeSongButton = new Podcaster.KLIKButton();
            this.iPodButton = new Podcaster.KLIKButton();
            this.BigButton = new Podcaster.KLIKButton();
            this.SuspendLayout();
            // 
            // OnAirFlashTimer
            // 
            this.OnAirFlashTimer.Interval = 750;
            this.OnAirFlashTimer.Tick += new System.EventHandler(this.OnAirFlashTimer_Tick);
            // 
            // DurationTimerLabel
            // 
            this.DurationTimerLabel.BackColor = System.Drawing.Color.Black;
            this.DurationTimerLabel.CountingColor = System.Drawing.Color.Lime;
            this.DurationTimerLabel.Font = new System.Drawing.Font("Digital-7", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DurationTimerLabel.Interval = 1000;
            this.DurationTimerLabel.Location = new System.Drawing.Point(15, 196);
            this.DurationTimerLabel.Name = "DurationTimerLabel";
            this.DurationTimerLabel.PausedColor = System.Drawing.Color.Yellow;
            this.DurationTimerLabel.Size = new System.Drawing.Size(160, 70);
            this.DurationTimerLabel.TabIndex = 4;
            this.DurationTimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChangeSongButton
            // 
            this.ChangeSongButton.BackColor = System.Drawing.Color.Blue;
            this.ChangeSongButton.FlatAppearance.BorderSize = 0;
            this.ChangeSongButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeSongButton.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeSongButton.ForeColor = System.Drawing.Color.White;
            this.ChangeSongButton.Location = new System.Drawing.Point(12, 237);
            this.ChangeSongButton.Name = "ChangeSongButton";
            this.ChangeSongButton.Size = new System.Drawing.Size(163, 71);
            this.ChangeSongButton.TabIndex = 3;
            this.ChangeSongButton.Text = "Change Song";
            this.ChangeSongButton.UseVisualStyleBackColor = false;
            this.ChangeSongButton.Click += new System.EventHandler(this.ChangeSongButton_Click);
            // 
            // iPodButton
            // 
            this.iPodButton.BackColor = System.Drawing.Color.DarkRed;
            this.iPodButton.FlatAppearance.BorderSize = 0;
            this.iPodButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iPodButton.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iPodButton.ForeColor = System.Drawing.Color.White;
            this.iPodButton.Location = new System.Drawing.Point(12, 160);
            this.iPodButton.Name = "iPodButton";
            this.iPodButton.Size = new System.Drawing.Size(163, 71);
            this.iPodButton.TabIndex = 2;
            this.iPodButton.Text = "OFF AIR";
            this.iPodButton.UseVisualStyleBackColor = false;
            this.iPodButton.Click += new System.EventHandler(this.iPodButton_Click);
            // 
            // BigButton
            // 
            this.BigButton.BackColor = System.Drawing.Color.Green;
            this.BigButton.FlatAppearance.BorderSize = 0;
            this.BigButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BigButton.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BigButton.ForeColor = System.Drawing.Color.White;
            this.BigButton.Location = new System.Drawing.Point(12, 12);
            this.BigButton.Name = "BigButton";
            this.BigButton.Size = new System.Drawing.Size(163, 142);
            this.BigButton.TabIndex = 1;
            this.BigButton.Text = "START\r\nSHOW";
            this.BigButton.UseVisualStyleBackColor = false;
            this.BigButton.Click += new System.EventHandler(this.BigButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 325);
            this.Controls.Add(this.DurationTimerLabel);
            this.Controls.Add(this.ChangeSongButton);
            this.Controls.Add(this.iPodButton);
            this.Controls.Add(this.BigButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "KLIK Podcaster";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public KLIKButton BigButton;
        public KLIKButton iPodButton;
        public KLIKButton ChangeSongButton;
        private System.Windows.Forms.Timer OnAirFlashTimer;
        private KLIKTimerDraggableLabel DurationTimerLabel;
    }
}

