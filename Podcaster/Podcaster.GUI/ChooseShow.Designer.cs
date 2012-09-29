namespace Podcaster
{
    partial class ChooseShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseShow));
            this.Shows = new KLIKComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StartShowButton = new System.Windows.Forms.Button();
            this.TheCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Shows
            // 
            this.Shows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Shows.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shows.FormattingEnabled = true;
            this.Shows.Location = new System.Drawing.Point(12, 50);
            this.Shows.Name = "Shows";
            this.Shows.Size = new System.Drawing.Size(610, 30);
            this.Shows.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose your show.";
            // 
            // StartShowButton
            // 
            this.StartShowButton.BackColor = System.Drawing.Color.Green;
            this.StartShowButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.StartShowButton.FlatAppearance.BorderSize = 0;
            this.StartShowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartShowButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartShowButton.ForeColor = System.Drawing.Color.White;
            this.StartShowButton.Location = new System.Drawing.Point(193, 91);
            this.StartShowButton.Name = "StartShowButton";
            this.StartShowButton.Size = new System.Drawing.Size(124, 42);
            this.StartShowButton.TabIndex = 2;
            this.StartShowButton.Text = "Start Show";
            this.StartShowButton.UseVisualStyleBackColor = false;
            this.StartShowButton.Click += new System.EventHandler(this.StartShowButton_Click);
            // 
            // TheCancelButton
            // 
            this.TheCancelButton.BackColor = System.Drawing.Color.Red;
            this.TheCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.TheCancelButton.FlatAppearance.BorderSize = 0;
            this.TheCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TheCancelButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TheCancelButton.ForeColor = System.Drawing.Color.White;
            this.TheCancelButton.Location = new System.Drawing.Point(323, 91);
            this.TheCancelButton.Name = "TheCancelButton";
            this.TheCancelButton.Size = new System.Drawing.Size(124, 42);
            this.TheCancelButton.TabIndex = 3;
            this.TheCancelButton.Text = "Cancel";
            this.TheCancelButton.UseVisualStyleBackColor = false;
            this.TheCancelButton.Click += new System.EventHandler(this.TheCancelButton_Click);
            // 
            // ChooseShow
            // 
            this.AcceptButton = this.StartShowButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.TheCancelButton;
            this.ClientSize = new System.Drawing.Size(634, 147);
            this.Controls.Add(this.TheCancelButton);
            this.Controls.Add(this.StartShowButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Shows);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KLIK Podcaster";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ChooseShow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(ChooseShow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KLIKComboBox Shows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StartShowButton;
        private System.Windows.Forms.Button TheCancelButton;
    }
}