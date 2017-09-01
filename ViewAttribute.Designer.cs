namespace Microsys.EAI.BizTalkUtilities
{
    partial class ViewAttribute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAttribute));
            this.AttributeDetails = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // AttributeDetails
            // 
            this.AttributeDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AttributeDetails.Location = new System.Drawing.Point(0, 0);
            this.AttributeDetails.MinimumSize = new System.Drawing.Size(20, 20);
            this.AttributeDetails.Name = "AttributeDetails";
            this.AttributeDetails.Size = new System.Drawing.Size(798, 394);
            this.AttributeDetails.TabIndex = 0;
            // 
            // ViewAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 394);
            this.Controls.Add(this.AttributeDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewAttribute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attribute Detail";
            this.Load += new System.EventHandler(this.ViewAttribute_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser AttributeDetails;



    }
}