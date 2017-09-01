namespace Microsys.EAI.BizTalkUtilities
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.lnkClose = new System.Windows.Forms.LinkLabel();
            this.welcomePicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.welcomePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // lnkClose
            // 
            this.lnkClose.ActiveLinkColor = System.Drawing.Color.White;
            this.lnkClose.AutoSize = true;
            this.lnkClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(71)))), ((int)(((byte)(38)))));
            this.lnkClose.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkClose.ForeColor = System.Drawing.Color.White;
            this.lnkClose.LinkColor = System.Drawing.Color.White;
            this.lnkClose.Location = new System.Drawing.Point(852, 64);
            this.lnkClose.Name = "lnkClose";
            this.lnkClose.Size = new System.Drawing.Size(51, 23);
            this.lnkClose.TabIndex = 1;
            this.lnkClose.TabStop = true;
            this.lnkClose.Text = "Close";
            this.lnkClose.VisitedLinkColor = System.Drawing.Color.White;
            this.lnkClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // welcomePicture
            // 
            this.welcomePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcomePicture.Image = ((System.Drawing.Image)(resources.GetObject("welcomePicture.Image")));
            this.welcomePicture.Location = new System.Drawing.Point(0, 0);
            this.welcomePicture.Name = "welcomePicture";
            this.welcomePicture.Size = new System.Drawing.Size(950, 501);
            this.welcomePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.welcomePicture.TabIndex = 0;
            this.welcomePicture.TabStop = false;
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(950, 501);
            this.Controls.Add(this.lnkClose);
            this.Controls.Add(this.welcomePicture);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            ((System.ComponentModel.ISupportInitialize)(this.welcomePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkClose;
        private System.Windows.Forms.PictureBox welcomePicture;
    }
}