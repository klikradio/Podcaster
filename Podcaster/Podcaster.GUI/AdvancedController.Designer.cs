namespace Podcaster
{
    partial class AdvancedController
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedController));
            this.UpdateSongGroupBox = new System.Windows.Forms.GroupBox();
            this.UpdateAndPause = new System.Windows.Forms.Button();
            this.UpdateSong = new System.Windows.Forms.Button();
            this.UpdateTitle = new System.Windows.Forms.TextBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.UpdateArtist = new System.Windows.Forms.TextBox();
            this.ArtistLabel = new System.Windows.Forms.Label();
            this.RecordingLamp = new System.Windows.Forms.Label();
            this.RecordButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.SongLog = new System.Windows.Forms.ListView();
            this.AutoControl = new System.Windows.Forms.CheckBox();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.PodcastLabel = new System.Windows.Forms.Label();
            this.NotRecordedLabel = new System.Windows.Forms.Label();
            this.ControllersMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.attachControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.AuxTimer1Label = new System.Windows.Forms.Label();
            this.AuxTimer1 = new Podcaster.KLIKTimerLabel();
            this.PausedTime = new Podcaster.KLIKTimerLabel();
            this.PodcastLength = new Podcaster.KLIKTimerLabel();
            this.TotalLength = new Podcaster.KLIKTimerLabel();
            this.detachControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateSongGroupBox.SuspendLayout();
            this.ControllersMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdateSongGroupBox
            // 
            this.UpdateSongGroupBox.Controls.Add(this.UpdateAndPause);
            this.UpdateSongGroupBox.Controls.Add(this.UpdateSong);
            this.UpdateSongGroupBox.Controls.Add(this.UpdateTitle);
            this.UpdateSongGroupBox.Controls.Add(this.TitleLabel);
            this.UpdateSongGroupBox.Controls.Add(this.UpdateArtist);
            this.UpdateSongGroupBox.Controls.Add(this.ArtistLabel);
            this.UpdateSongGroupBox.Location = new System.Drawing.Point(296, 12);
            this.UpdateSongGroupBox.Name = "UpdateSongGroupBox";
            this.UpdateSongGroupBox.Size = new System.Drawing.Size(328, 115);
            this.UpdateSongGroupBox.TabIndex = 0;
            this.UpdateSongGroupBox.TabStop = false;
            this.UpdateSongGroupBox.Text = "Update Song";
            // 
            // UpdateAndPause
            // 
            this.UpdateAndPause.Location = new System.Drawing.Point(156, 75);
            this.UpdateAndPause.Name = "UpdateAndPause";
            this.UpdateAndPause.Size = new System.Drawing.Size(115, 30);
            this.UpdateAndPause.TabIndex = 5;
            this.UpdateAndPause.Text = "Update and Pause";
            this.UpdateAndPause.UseVisualStyleBackColor = true;
            this.UpdateAndPause.Click += new System.EventHandler(this.UpdateAndPause_Click);
            // 
            // UpdateSong
            // 
            this.UpdateSong.Location = new System.Drawing.Point(56, 75);
            this.UpdateSong.Name = "UpdateSong";
            this.UpdateSong.Size = new System.Drawing.Size(94, 30);
            this.UpdateSong.TabIndex = 4;
            this.UpdateSong.Text = "Update";
            this.UpdateSong.UseVisualStyleBackColor = true;
            this.UpdateSong.Click += new System.EventHandler(this.UpdateSong_Click);
            // 
            // UpdateTitle
            // 
            this.UpdateTitle.Location = new System.Drawing.Point(45, 49);
            this.UpdateTitle.Name = "UpdateTitle";
            this.UpdateTitle.Size = new System.Drawing.Size(277, 20);
            this.UpdateTitle.TabIndex = 3;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(6, 52);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(30, 13);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "Title:";
            // 
            // UpdateArtist
            // 
            this.UpdateArtist.Location = new System.Drawing.Point(45, 23);
            this.UpdateArtist.Name = "UpdateArtist";
            this.UpdateArtist.Size = new System.Drawing.Size(277, 20);
            this.UpdateArtist.TabIndex = 1;
            // 
            // ArtistLabel
            // 
            this.ArtistLabel.AutoSize = true;
            this.ArtistLabel.Location = new System.Drawing.Point(6, 26);
            this.ArtistLabel.Name = "ArtistLabel";
            this.ArtistLabel.Size = new System.Drawing.Size(33, 13);
            this.ArtistLabel.TabIndex = 0;
            this.ArtistLabel.Text = "Artist:";
            // 
            // RecordingLamp
            // 
            this.RecordingLamp.BackColor = System.Drawing.Color.Green;
            this.RecordingLamp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RecordingLamp.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordingLamp.ForeColor = System.Drawing.Color.White;
            this.RecordingLamp.Location = new System.Drawing.Point(12, 19);
            this.RecordingLamp.Name = "RecordingLamp";
            this.RecordingLamp.Size = new System.Drawing.Size(278, 47);
            this.RecordingLamp.TabIndex = 1;
            this.RecordingLamp.Text = "CLEAR";
            this.RecordingLamp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RecordButton
            // 
            this.RecordButton.Image = ((System.Drawing.Image)(resources.GetObject("RecordButton.Image")));
            this.RecordButton.Location = new System.Drawing.Point(113, 78);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(39, 39);
            this.RecordButton.TabIndex = 2;
            this.RecordButton.UseVisualStyleBackColor = true;
            this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Image = ((System.Drawing.Image)(resources.GetObject("PauseButton.Image")));
            this.PauseButton.Location = new System.Drawing.Point(158, 78);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(39, 39);
            this.PauseButton.TabIndex = 3;
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Image = ((System.Drawing.Image)(resources.GetObject("StopButton.Image")));
            this.StopButton.Location = new System.Drawing.Point(203, 78);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(39, 39);
            this.StopButton.TabIndex = 4;
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // SongLog
            // 
            this.SongLog.Location = new System.Drawing.Point(134, 133);
            this.SongLog.Name = "SongLog";
            this.SongLog.Size = new System.Drawing.Size(490, 310);
            this.SongLog.TabIndex = 5;
            this.SongLog.UseCompatibleStateImageBehavior = false;
            // 
            // AutoControl
            // 
            this.AutoControl.Appearance = System.Windows.Forms.Appearance.Button;
            this.AutoControl.Checked = true;
            this.AutoControl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoControl.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoControl.Location = new System.Drawing.Point(45, 78);
            this.AutoControl.Name = "AutoControl";
            this.AutoControl.Size = new System.Drawing.Size(62, 39);
            this.AutoControl.TabIndex = 6;
            this.AutoControl.Text = "AUTO";
            this.AutoControl.UseVisualStyleBackColor = true;
            this.AutoControl.CheckedChanged += new System.EventHandler(this.AutoControl_CheckedChanged);
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalLabel.Location = new System.Drawing.Point(12, 133);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(40, 11);
            this.TotalLabel.TabIndex = 10;
            this.TotalLabel.Text = "TOTAL";
            // 
            // PodcastLabel
            // 
            this.PodcastLabel.AutoSize = true;
            this.PodcastLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PodcastLabel.Location = new System.Drawing.Point(12, 189);
            this.PodcastLabel.Name = "PodcastLabel";
            this.PodcastLabel.Size = new System.Drawing.Size(68, 11);
            this.PodcastLabel.TabIndex = 11;
            this.PodcastLabel.Text = "PODCASTED";
            // 
            // NotRecordedLabel
            // 
            this.NotRecordedLabel.AutoSize = true;
            this.NotRecordedLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotRecordedLabel.Location = new System.Drawing.Point(12, 244);
            this.NotRecordedLabel.Name = "NotRecordedLabel";
            this.NotRecordedLabel.Size = new System.Drawing.Size(89, 11);
            this.NotRecordedLabel.TabIndex = 12;
            this.NotRecordedLabel.Text = "NOT RECORDED";
            // 
            // ControllersMenu
            // 
            this.ControllersMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detachControllerToolStripMenuItem,
            this.attachControllerToolStripMenuItem});
            this.ControllersMenu.Name = "ControllersMenu";
            this.ControllersMenu.ShowImageMargin = false;
            this.ControllersMenu.Size = new System.Drawing.Size(143, 48);
            // 
            // attachControllerToolStripMenuItem
            // 
            this.attachControllerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.attachControllerToolStripMenuItem.Name = "attachControllerToolStripMenuItem";
            this.attachControllerToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.attachControllerToolStripMenuItem.Text = "Attach Controller";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "#1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "#2";
            // 
            // AuxTimer1Label
            // 
            this.AuxTimer1Label.AutoSize = true;
            this.AuxTimer1Label.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuxTimer1Label.Location = new System.Drawing.Point(12, 296);
            this.AuxTimer1Label.Name = "AuxTimer1Label";
            this.AuxTimer1Label.Size = new System.Drawing.Size(82, 11);
            this.AuxTimer1Label.TabIndex = 15;
            this.AuxTimer1Label.Text = "AUX TIMER 1";
            // 
            // AuxTimer1
            // 
            this.AuxTimer1.BackColor = System.Drawing.Color.Black;
            this.AuxTimer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AuxTimer1.ContextMenuStrip = this.ControllersMenu;
            this.AuxTimer1.CountingColor = System.Drawing.Color.Lime;
            this.AuxTimer1.Font = new System.Drawing.Font("Digital-7", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuxTimer1.Interval = 1000;
            this.AuxTimer1.Location = new System.Drawing.Point(12, 307);
            this.AuxTimer1.Name = "AuxTimer1";
            this.AuxTimer1.PausedColor = System.Drawing.Color.Yellow;
            this.AuxTimer1.Size = new System.Drawing.Size(116, 36);
            this.AuxTimer1.TabIndex = 14;
            this.AuxTimer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PausedTime
            // 
            this.PausedTime.BackColor = System.Drawing.Color.Black;
            this.PausedTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PausedTime.CountingColor = System.Drawing.Color.Lime;
            this.PausedTime.Font = new System.Drawing.Font("Digital-7", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PausedTime.Interval = 1000;
            this.PausedTime.Location = new System.Drawing.Point(12, 255);
            this.PausedTime.Name = "PausedTime";
            this.PausedTime.PausedColor = System.Drawing.Color.Red;
            this.PausedTime.Size = new System.Drawing.Size(116, 36);
            this.PausedTime.TabIndex = 9;
            this.PausedTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PodcastLength
            // 
            this.PodcastLength.BackColor = System.Drawing.Color.Black;
            this.PodcastLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PodcastLength.CountingColor = System.Drawing.Color.Lime;
            this.PodcastLength.Font = new System.Drawing.Font("Digital-7", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PodcastLength.Interval = 1000;
            this.PodcastLength.Location = new System.Drawing.Point(12, 200);
            this.PodcastLength.Name = "PodcastLength";
            this.PodcastLength.PausedColor = System.Drawing.Color.Red;
            this.PodcastLength.Size = new System.Drawing.Size(116, 36);
            this.PodcastLength.TabIndex = 8;
            this.PodcastLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotalLength
            // 
            this.TotalLength.BackColor = System.Drawing.Color.Black;
            this.TotalLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TotalLength.CountingColor = System.Drawing.Color.Lime;
            this.TotalLength.Font = new System.Drawing.Font("Digital-7", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalLength.Interval = 1000;
            this.TotalLength.Location = new System.Drawing.Point(12, 146);
            this.TotalLength.Name = "TotalLength";
            this.TotalLength.PausedColor = System.Drawing.Color.Yellow;
            this.TotalLength.Size = new System.Drawing.Size(116, 36);
            this.TotalLength.TabIndex = 7;
            this.TotalLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // detachControllerToolStripMenuItem
            // 
            this.detachControllerToolStripMenuItem.Enabled = false;
            this.detachControllerToolStripMenuItem.Name = "detachControllerToolStripMenuItem";
            this.detachControllerToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.detachControllerToolStripMenuItem.Text = "Detach Controller";
            // 
            // AdvancedController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 455);
            this.Controls.Add(this.AuxTimer1Label);
            this.Controls.Add(this.AuxTimer1);
            this.Controls.Add(this.NotRecordedLabel);
            this.Controls.Add(this.PodcastLabel);
            this.Controls.Add(this.TotalLabel);
            this.Controls.Add(this.PausedTime);
            this.Controls.Add(this.PodcastLength);
            this.Controls.Add(this.TotalLength);
            this.Controls.Add(this.AutoControl);
            this.Controls.Add(this.SongLog);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.RecordButton);
            this.Controls.Add(this.RecordingLamp);
            this.Controls.Add(this.UpdateSongGroupBox);
            this.MaximizeBox = false;
            this.Name = "AdvancedController";
            this.Text = "Podcaster";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdvancedController_FormClosing);
            this.Load += new System.EventHandler(this.AdvancedController_Load);
            this.UpdateSongGroupBox.ResumeLayout(false);
            this.UpdateSongGroupBox.PerformLayout();
            this.ControllersMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox UpdateSongGroupBox;
        private System.Windows.Forms.Button UpdateSong;
        private System.Windows.Forms.TextBox UpdateTitle;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox UpdateArtist;
        private System.Windows.Forms.Label ArtistLabel;
        private System.Windows.Forms.Label RecordingLamp;
        private System.Windows.Forms.Button RecordButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.ListView SongLog;
        private System.Windows.Forms.CheckBox AutoControl;
        private System.Windows.Forms.Button UpdateAndPause;
        private KLIKTimerLabel TotalLength;
        private KLIKTimerLabel PodcastLength;
        private KLIKTimerLabel PausedTime;
        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.Label PodcastLabel;
        private System.Windows.Forms.Label NotRecordedLabel;
        private System.Windows.Forms.ContextMenuStrip ControllersMenu;
        private System.Windows.Forms.ToolStripMenuItem attachControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private KLIKTimerLabel AuxTimer1;
        private System.Windows.Forms.Label AuxTimer1Label;
        private System.Windows.Forms.ToolStripMenuItem detachControllerToolStripMenuItem;
    }
}