namespace Podcaster
{
    partial class ShowInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.EpisodeTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.TextBox();
            this.TheCancelButton = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.IgnoreShow = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Episode Title:";
            // 
            // EpisodeTitle
            // 
            this.EpisodeTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EpisodeTitle.Location = new System.Drawing.Point(159, 12);
            this.EpisodeTitle.Name = "EpisodeTitle";
            this.EpisodeTitle.Size = new System.Drawing.Size(521, 26);
            this.EpisodeTitle.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description:";
            // 
            // Description
            // 
            this.Description.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description.Location = new System.Drawing.Point(159, 48);
            this.Description.Multiline = true;
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(521, 106);
            this.Description.TabIndex = 1;
            // 
            // TheCancelButton
            // 
            this.TheCancelButton.BackColor = System.Drawing.Color.Red;
            this.TheCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.TheCancelButton.FlatAppearance.BorderSize = 0;
            this.TheCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TheCancelButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TheCancelButton.ForeColor = System.Drawing.Color.White;
            this.TheCancelButton.Location = new System.Drawing.Point(339, 189);
            this.TheCancelButton.Name = "TheCancelButton";
            this.TheCancelButton.Size = new System.Drawing.Size(124, 42);
            this.TheCancelButton.TabIndex = 3;
            this.TheCancelButton.Text = "Cancel";
            this.TheCancelButton.UseVisualStyleBackColor = false;
            this.TheCancelButton.Click += new System.EventHandler(this.TheCancelButton_Click);
            // 
            // UploadButton
            // 
            this.UploadButton.BackColor = System.Drawing.Color.Green;
            this.UploadButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.UploadButton.FlatAppearance.BorderSize = 0;
            this.UploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UploadButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadButton.ForeColor = System.Drawing.Color.White;
            this.UploadButton.Location = new System.Drawing.Point(209, 189);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(124, 42);
            this.UploadButton.TabIndex = 2;
            this.UploadButton.Text = "Upload";
            this.UploadButton.UseVisualStyleBackColor = false;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // IgnoreShow
            // 
            this.IgnoreShow.AutoSize = true;
            this.IgnoreShow.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IgnoreShow.Location = new System.Drawing.Point(12, 161);
            this.IgnoreShow.Name = "IgnoreShow";
            this.IgnoreShow.Size = new System.Drawing.Size(643, 22);
            this.IgnoreShow.TabIndex = 5;
            this.IgnoreShow.Text = "This episode contains no conversation, and shouldn\'t be uploaded to the podcast f" +
                "eed.";
            this.IgnoreShow.UseVisualStyleBackColor = true;
            // 
            // ShowInfo
            // 
            this.AcceptButton = this.UploadButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.TheCancelButton;
            this.ClientSize = new System.Drawing.Size(692, 243);
            this.Controls.Add(this.IgnoreShow);
            this.Controls.Add(this.TheCancelButton);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EpisodeTitle);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(ShowInfo_FormClosing);
            this.Text = "Podcast Uploader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EpisodeTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.Button TheCancelButton;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.CheckBox IgnoreShow;
    }
}