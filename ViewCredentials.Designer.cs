namespace Microsys.EAI.BizTalkUtilities
{
    partial class ViewCredentials
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewCredentials));
            this.CredentialsTree = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.CredentialsTree)).BeginInit();
            this.SuspendLayout();
            // 
            // CredentialsTree
            // 
            this.CredentialsTree.AllowUserToAddRows = false;
            this.CredentialsTree.AllowUserToDeleteRows = false;
            this.CredentialsTree.AllowUserToOrderColumns = true;
            this.CredentialsTree.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CredentialsTree.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.CredentialsTree.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CredentialsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CredentialsTree.Location = new System.Drawing.Point(0, 0);
            this.CredentialsTree.Name = "CredentialsTree";
            this.CredentialsTree.ReadOnly = true;
            this.CredentialsTree.Size = new System.Drawing.Size(842, 427);
            this.CredentialsTree.TabIndex = 0;
            // 
            // ViewCredentials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 427);
            this.Controls.Add(this.CredentialsTree);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewCredentials";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Credentials";
            this.Load += new System.EventHandler(this.ViewCredentials_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CredentialsTree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CredentialsTree;
    }
}