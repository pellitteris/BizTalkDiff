namespace Microsys.EAI.BizTalkUtilities
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
            this.biztalkSourceActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyItemNameSourceActions = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOnlyDifferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.biztalkTarget = new System.Windows.Forms.TreeView();
            this.biztalkTargetActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyItemNameTargetActions = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTarget = new System.Windows.Forms.Label();
            this.Invert = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.sourceReport = new System.Windows.Forms.ToolStripStatusLabel();
            this.targetReport = new System.Windows.Forms.ToolStripStatusLabel();
            this.attributeReport = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTarget = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSource = new System.Windows.Forms.ComboBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.biztalkSource = new System.Windows.Forms.TreeView();
            this.panelActions = new System.Windows.Forms.Panel();
            this.linkModifyBlock = new System.Windows.Forms.LinkLabel();
            this.linkViewCredentials = new System.Windows.Forms.LinkLabel();
            this.linkCompare = new System.Windows.Forms.LinkLabel();
            this.lnkCollect = new System.Windows.Forms.LinkLabel();
            this.biztalkSourceActions.SuspendLayout();
            this.biztalkTargetActions.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // biztalkSourceActions
            // 
            this.biztalkSourceActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alignToolStripMenuItem,
            this.findToolStripMenuItem,
            this.compareToolStripMenuItem,
            this.viewDetailsToolStripMenuItem,
            this.copyItemNameSourceActions,
            this.viewOnlyDifferencesToolStripMenuItem});
            this.biztalkSourceActions.Name = "biztalkSourceActions";
            this.biztalkSourceActions.Size = new System.Drawing.Size(228, 136);
            this.biztalkSourceActions.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.biztalkSourceActions_ItemClicked);
            // 
            // alignToolStripMenuItem
            // 
            this.alignToolStripMenuItem.Name = "alignToolStripMenuItem";
            this.alignToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.alignToolStripMenuItem.Text = "Create on Target";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.findToolStripMenuItem.Text = "Find on Target";
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.compareToolStripMenuItem.Text = "Compare";
            // 
            // viewDetailsToolStripMenuItem
            // 
            this.viewDetailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.viewDetailsToolStripMenuItem.Name = "viewDetailsToolStripMenuItem";
            this.viewDetailsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.viewDetailsToolStripMenuItem.Text = "View Details";
            // 
            // copyItemNameSourceActions
            // 
            this.copyItemNameSourceActions.Name = "copyItemNameSourceActions";
            this.copyItemNameSourceActions.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyItemNameSourceActions.Size = new System.Drawing.Size(227, 22);
            this.copyItemNameSourceActions.Text = "Copy Item Name";
            // 
            // viewOnlyDifferencesToolStripMenuItem
            // 
            this.viewOnlyDifferencesToolStripMenuItem.Name = "viewOnlyDifferencesToolStripMenuItem";
            this.viewOnlyDifferencesToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.viewOnlyDifferencesToolStripMenuItem.Text = "View Only Different Branches";
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "Default");
            this.iconList.Images.SetKeyName(1, "Application");
            this.iconList.Images.SetKeyName(2, "SendPort");
            this.iconList.Images.SetKeyName(3, "ReceiveLocation");
            this.iconList.Images.SetKeyName(4, "Collect");
            this.iconList.Images.SetKeyName(5, "Host");
            this.iconList.Images.SetKeyName(6, "Services");
            this.iconList.Images.SetKeyName(7, "Compare");
            this.iconList.Images.SetKeyName(8, "key");
            // 
            // biztalkTarget
            // 
            this.biztalkTarget.ContextMenuStrip = this.biztalkTargetActions;
            this.biztalkTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.biztalkTarget.ImageIndex = 0;
            this.biztalkTarget.ImageList = this.iconList;
            this.biztalkTarget.Location = new System.Drawing.Point(551, 80);
            this.biztalkTarget.Name = "biztalkTarget";
            this.biztalkTarget.SelectedImageIndex = 0;
            this.biztalkTarget.Size = new System.Drawing.Size(514, 410);
            this.biztalkTarget.TabIndex = 4;
            // 
            // biztalkTargetActions
            // 
            this.biztalkTargetActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyItemNameTargetActions});
            this.biztalkTargetActions.Name = "biztalkTargetActions";
            this.biztalkTargetActions.Size = new System.Drawing.Size(207, 26);
            this.biztalkTargetActions.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.biztalkTargetActions_ItemClicked);
            // 
            // copyItemNameTargetActions
            // 
            this.copyItemNameTargetActions.Name = "copyItemNameTargetActions";
            this.copyItemNameTargetActions.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyItemNameTargetActions.Size = new System.Drawing.Size(206, 22);
            this.copyItemNameTargetActions.Text = "Copy Item Name";
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(8, 6);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(38, 13);
            this.lblTarget.TabIndex = 4;
            this.lblTarget.Text = "Target";
            // 
            // Invert
            // 
            this.Invert.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Invert.BackgroundImage")));
            this.Invert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Invert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Invert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Invert.ForeColor = System.Drawing.SystemColors.Control;
            this.Invert.Location = new System.Drawing.Point(522, 32);
            this.Invert.Name = "Invert";
            this.Invert.Size = new System.Drawing.Size(23, 23);
            this.Invert.TabIndex = 5;
            this.Invert.UseVisualStyleBackColor = true;
            this.Invert.Click += new System.EventHandler(this.Invert_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.statusStrip, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.panel2, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.biztalkTarget, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.Invert, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.biztalkSource, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.panelActions, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1068, 518);
            this.tableLayoutPanel.TabIndex = 6;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceReport,
            this.targetReport,
            this.attributeReport});
            this.statusStrip.Location = new System.Drawing.Point(0, 496);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(519, 22);
            this.statusStrip.TabIndex = 10;
            this.statusStrip.Text = "statusBar";
            // 
            // sourceReport
            // 
            this.sourceReport.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.sourceReport.Name = "sourceReport";
            this.sourceReport.Size = new System.Drawing.Size(4, 17);
            this.sourceReport.Visible = false;
            // 
            // targetReport
            // 
            this.targetReport.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.targetReport.Name = "targetReport";
            this.targetReport.Size = new System.Drawing.Size(4, 17);
            this.targetReport.Visible = false;
            // 
            // attributeReport
            // 
            this.attributeReport.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.attributeReport.Name = "attributeReport";
            this.attributeReport.Size = new System.Drawing.Size(4, 17);
            this.attributeReport.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTarget);
            this.panel2.Controls.Add(this.lblTarget);
            this.panel2.Location = new System.Drawing.Point(551, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 33);
            this.panel2.TabIndex = 7;
            // 
            // txtTarget
            // 
            this.txtTarget.FormattingEnabled = true;
            this.txtTarget.Location = new System.Drawing.Point(53, 3);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(444, 21);
            this.txtTarget.Sorted = true;
            this.txtTarget.TabIndex = 5;
            this.txtTarget.Leave += new System.EventHandler(this.txtSourceTarget_Leave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSource);
            this.panel1.Controls.Add(this.lblSource);
            this.panel1.Location = new System.Drawing.Point(3, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 33);
            this.panel1.TabIndex = 7;
            // 
            // txtSource
            // 
            this.txtSource.FormattingEnabled = true;
            this.txtSource.Location = new System.Drawing.Point(52, 3);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(444, 21);
            this.txtSource.Sorted = true;
            this.txtSource.TabIndex = 2;
            this.txtSource.Text = "Data Source=localhost;Initial Catalog=BizTalkMgmtDb;Integrated Security=SSPI;";
            this.txtSource.Leave += new System.EventHandler(this.txtSourceTarget_Leave);
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(4, 6);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(41, 13);
            this.lblSource.TabIndex = 1;
            this.lblSource.Text = "Source";
            // 
            // biztalkSource
            // 
            this.biztalkSource.ContextMenuStrip = this.biztalkSourceActions;
            this.biztalkSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.biztalkSource.ImageIndex = 0;
            this.biztalkSource.ImageList = this.iconList;
            this.biztalkSource.Location = new System.Drawing.Point(3, 80);
            this.biztalkSource.Name = "biztalkSource";
            this.biztalkSource.SelectedImageIndex = 0;
            this.biztalkSource.Size = new System.Drawing.Size(513, 410);
            this.biztalkSource.TabIndex = 8;
            this.biztalkSource.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.biztalkSource_MouseDoubleClick);
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.linkModifyBlock);
            this.panelActions.Controls.Add(this.linkViewCredentials);
            this.panelActions.Controls.Add(this.linkCompare);
            this.panelActions.Controls.Add(this.lnkCollect);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActions.Location = new System.Drawing.Point(3, 3);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(513, 23);
            this.panelActions.TabIndex = 9;
            // 
            // linkModifyBlock
            // 
            this.linkModifyBlock.BackColor = System.Drawing.SystemColors.Control;
            this.linkModifyBlock.Image = ((System.Drawing.Image)(resources.GetObject("linkModifyBlock.Image")));
            this.linkModifyBlock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkModifyBlock.Location = new System.Drawing.Point(372, 0);
            this.linkModifyBlock.Name = "linkModifyBlock";
            this.linkModifyBlock.Size = new System.Drawing.Size(120, 23);
            this.linkModifyBlock.TabIndex = 4;
            this.linkModifyBlock.TabStop = true;
            this.linkModifyBlock.Text = "Modify in Block";
            this.linkModifyBlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkModifyBlock.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkModifyBlock_LinkClicked);
            // 
            // linkViewCredentials
            // 
            this.linkViewCredentials.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkViewCredentials.ImageIndex = 8;
            this.linkViewCredentials.ImageList = this.iconList;
            this.linkViewCredentials.Location = new System.Drawing.Point(246, 0);
            this.linkViewCredentials.Name = "linkViewCredentials";
            this.linkViewCredentials.Size = new System.Drawing.Size(120, 23);
            this.linkViewCredentials.TabIndex = 3;
            this.linkViewCredentials.TabStop = true;
            this.linkViewCredentials.Text = "View Credentials";
            this.linkViewCredentials.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkViewCredentials.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkViewCredentials_LinkClicked);
            // 
            // linkCompare
            // 
            this.linkCompare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkCompare.ImageIndex = 7;
            this.linkCompare.ImageList = this.iconList;
            this.linkCompare.Location = new System.Drawing.Point(131, 0);
            this.linkCompare.Name = "linkCompare";
            this.linkCompare.Size = new System.Drawing.Size(109, 23);
            this.linkCompare.TabIndex = 2;
            this.linkCompare.TabStop = true;
            this.linkCompare.Text = "Compare";
            this.linkCompare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkCompare.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCompare_LinkClicked);
            // 
            // lnkCollect
            // 
            this.lnkCollect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkCollect.ImageIndex = 4;
            this.lnkCollect.ImageList = this.iconList;
            this.lnkCollect.Location = new System.Drawing.Point(9, 0);
            this.lnkCollect.Name = "lnkCollect";
            this.lnkCollect.Size = new System.Drawing.Size(109, 23);
            this.lnkCollect.TabIndex = 1;
            this.lnkCollect.TabStop = true;
            this.lnkCollect.Text = "Start Collect";
            this.lnkCollect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkCollect.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCollect_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 518);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BizTalk Utilities";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.biztalkSourceActions.ResumeLayout(false);
            this.biztalkTargetActions.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView biztalkTarget;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.ContextMenuStrip biztalkSourceActions;
        private System.Windows.Forms.ToolStripMenuItem alignToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ImageList iconList;
        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDetailsToolStripMenuItem;
        private System.Windows.Forms.Button Invert;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.LinkLabel lnkCollect;
        private System.Windows.Forms.TreeView biztalkSource;
        private System.Windows.Forms.ComboBox txtSource;
        private System.Windows.Forms.ComboBox txtTarget;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.LinkLabel linkCompare;
        private System.Windows.Forms.LinkLabel linkViewCredentials;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel sourceReport;
        private System.Windows.Forms.ToolStripStatusLabel targetReport;
        private System.Windows.Forms.ToolStripStatusLabel attributeReport;
        private System.Windows.Forms.ToolStripMenuItem copyItemNameSourceActions;
        private System.Windows.Forms.ContextMenuStrip biztalkTargetActions;
        private System.Windows.Forms.ToolStripMenuItem copyItemNameTargetActions;
        private System.Windows.Forms.ToolStripMenuItem viewOnlyDifferencesToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkModifyBlock;

    }
}

