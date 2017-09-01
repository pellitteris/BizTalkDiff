namespace Microsys.EAI.BizTalkUtilities
{
    partial class ModifyBlock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyBlock));
            this.ddlApplication = new System.Windows.Forms.ComboBox();
            this.ddlSourceDestination = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblApplication = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblgwObjList = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.ddlAction = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.gwObjList = new System.Windows.Forms.DataGridView();
            this.wcfBindingElementGroup = new System.Windows.Forms.GroupBox();
            this.chkOpenTO = new System.Windows.Forms.CheckBox();
            this.chkSndTO = new System.Windows.Forms.CheckBox();
            this.chkRcvTO = new System.Windows.Forms.CheckBox();
            this.chkCloseTO = new System.Windows.Forms.CheckBox();
            this.txtSndTO = new System.Windows.Forms.TextBox();
            this.txtRcvTO = new System.Windows.Forms.TextBox();
            this.txtOpenTO = new System.Windows.Forms.TextBox();
            this.txtCloseTO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.filterGroup = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.transportOptionsGroup = new System.Windows.Forms.GroupBox();
            this.chkRoutingFailedMessages = new System.Windows.Forms.CheckBox();
            this.txtRetryInterval = new System.Windows.Forms.TextBox();
            this.txtRetryCount = new System.Windows.Forms.TextBox();
            this.ddlRoutingFailedMessages = new System.Windows.Forms.ComboBox();
            this.chkRetryInterval = new System.Windows.Forms.CheckBox();
            this.chkRetryCount = new System.Windows.Forms.CheckBox();
            this.hostOptionGroup = new System.Windows.Forms.GroupBox();
            this.chkObjectNewHost = new System.Windows.Forms.CheckBox();
            this.ddlObjectNewHost = new System.Windows.Forms.ComboBox();
            this.colChkBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colObjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdapter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gwObjList)).BeginInit();
            this.wcfBindingElementGroup.SuspendLayout();
            this.filterGroup.SuspendLayout();
            this.transportOptionsGroup.SuspendLayout();
            this.hostOptionGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddlApplication
            // 
            this.ddlApplication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlApplication.Enabled = false;
            this.ddlApplication.FormattingEnabled = true;
            this.ddlApplication.Location = new System.Drawing.Point(115, 65);
            this.ddlApplication.Name = "ddlApplication";
            this.ddlApplication.Size = new System.Drawing.Size(346, 21);
            this.ddlApplication.TabIndex = 1;
            this.ddlApplication.SelectionChangeCommitted += new System.EventHandler(this.ddlApplication_SelectionChangeCommitted);
            // 
            // ddlSourceDestination
            // 
            this.ddlSourceDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSourceDestination.FormattingEnabled = true;
            this.ddlSourceDestination.Items.AddRange(new object[] {
            "Source",
            "Target"});
            this.ddlSourceDestination.Location = new System.Drawing.Point(115, 10);
            this.ddlSourceDestination.Name = "ddlSourceDestination";
            this.ddlSourceDestination.Size = new System.Drawing.Size(132, 21);
            this.ddlSourceDestination.TabIndex = 1;
            this.ddlSourceDestination.SelectionChangeCommitted += new System.EventHandler(this.ddlSourceDestination_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select BizTalk:";
            // 
            // lblApplication
            // 
            this.lblApplication.AutoSize = true;
            this.lblApplication.Enabled = false;
            this.lblApplication.Location = new System.Drawing.Point(6, 68);
            this.lblApplication.Name = "lblApplication";
            this.lblApplication.Size = new System.Drawing.Size(95, 13);
            this.lblApplication.TabIndex = 2;
            this.lblApplication.Text = "Select Application:";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(390, 562);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblgwObjList
            // 
            this.lblgwObjList.AutoSize = true;
            this.lblgwObjList.Location = new System.Drawing.Point(12, 115);
            this.lblgwObjList.Name = "lblgwObjList";
            this.lblgwObjList.Size = new System.Drawing.Size(92, 13);
            this.lblgwObjList.TabIndex = 2;
            this.lblgwObjList.Text = "Available Objects:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(481, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "N.B: only the objects with Unenlisted/Disable state are listed. Dynamic Port are " +
    "not listed too.";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Enabled = false;
            this.lblAction.Location = new System.Drawing.Point(6, 41);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(73, 13);
            this.lblAction.TabIndex = 2;
            this.lblAction.Text = "Select Action:";
            // 
            // ddlAction
            // 
            this.ddlAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAction.Enabled = false;
            this.ddlAction.FormattingEnabled = true;
            this.ddlAction.Items.AddRange(new object[] {
            "Modify Send Port",
            "Modify Receive Location Port",
            "Modify Orchestration Host",
            "Modify Soap Send Port Timeout",
            "Modify Soap Receive Location Port Timeout"});
            this.ddlAction.Location = new System.Drawing.Point(115, 38);
            this.ddlAction.Name = "ddlAction";
            this.ddlAction.Size = new System.Drawing.Size(346, 21);
            this.ddlAction.TabIndex = 1;
            this.ddlAction.SelectedIndexChanged += new System.EventHandler(this.ddlAction_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(473, 562);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gwObjList
            // 
            this.gwObjList.AllowUserToAddRows = false;
            this.gwObjList.AllowUserToDeleteRows = false;
            this.gwObjList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gwObjList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gwObjList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChkBox,
            this.colObjectName,
            this.colHost,
            this.colAdapter});
            this.gwObjList.Location = new System.Drawing.Point(15, 131);
            this.gwObjList.Name = "gwObjList";
            this.gwObjList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gwObjList.Size = new System.Drawing.Size(533, 164);
            this.gwObjList.TabIndex = 9;
            this.gwObjList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gwObjList_DataBindingComplete);
            // 
            // wcfBindingElementGroup
            // 
            this.wcfBindingElementGroup.Controls.Add(this.chkOpenTO);
            this.wcfBindingElementGroup.Controls.Add(this.chkSndTO);
            this.wcfBindingElementGroup.Controls.Add(this.chkRcvTO);
            this.wcfBindingElementGroup.Controls.Add(this.chkCloseTO);
            this.wcfBindingElementGroup.Controls.Add(this.txtSndTO);
            this.wcfBindingElementGroup.Controls.Add(this.txtRcvTO);
            this.wcfBindingElementGroup.Controls.Add(this.txtOpenTO);
            this.wcfBindingElementGroup.Controls.Add(this.txtCloseTO);
            this.wcfBindingElementGroup.Controls.Add(this.label2);
            this.wcfBindingElementGroup.Enabled = false;
            this.wcfBindingElementGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wcfBindingElementGroup.Location = new System.Drawing.Point(15, 473);
            this.wcfBindingElementGroup.Name = "wcfBindingElementGroup";
            this.wcfBindingElementGroup.Size = new System.Drawing.Size(533, 85);
            this.wcfBindingElementGroup.TabIndex = 10;
            this.wcfBindingElementGroup.TabStop = false;
            this.wcfBindingElementGroup.Text = "Standard Binding Element Settings";
            // 
            // chkOpenTO
            // 
            this.chkOpenTO.AutoSize = true;
            this.chkOpenTO.Location = new System.Drawing.Point(16, 43);
            this.chkOpenTO.Name = "chkOpenTO";
            this.chkOpenTO.Size = new System.Drawing.Size(88, 17);
            this.chkOpenTO.TabIndex = 2;
            this.chkOpenTO.Text = "openTimeout";
            this.chkOpenTO.UseVisualStyleBackColor = true;
            this.chkOpenTO.CheckedChanged += new System.EventHandler(this.chkOpenTO_CheckedChanged);
            // 
            // chkSndTO
            // 
            this.chkSndTO.AutoSize = true;
            this.chkSndTO.Location = new System.Drawing.Point(216, 43);
            this.chkSndTO.Name = "chkSndTO";
            this.chkSndTO.Size = new System.Drawing.Size(87, 17);
            this.chkSndTO.TabIndex = 2;
            this.chkSndTO.Text = "sendTimeout";
            this.chkSndTO.UseVisualStyleBackColor = true;
            this.chkSndTO.CheckedChanged += new System.EventHandler(this.chkSndTO_CheckedChanged);
            // 
            // chkRcvTO
            // 
            this.chkRcvTO.AutoSize = true;
            this.chkRcvTO.Location = new System.Drawing.Point(216, 18);
            this.chkRcvTO.Name = "chkRcvTO";
            this.chkRcvTO.Size = new System.Drawing.Size(112, 17);
            this.chkRcvTO.TabIndex = 2;
            this.chkRcvTO.Text = "receiveTimeout (*)";
            this.chkRcvTO.UseVisualStyleBackColor = true;
            this.chkRcvTO.CheckedChanged += new System.EventHandler(this.chkRcvTO_CheckedChanged);
            // 
            // chkCloseTO
            // 
            this.chkCloseTO.AutoSize = true;
            this.chkCloseTO.Location = new System.Drawing.Point(16, 18);
            this.chkCloseTO.Name = "chkCloseTO";
            this.chkCloseTO.Size = new System.Drawing.Size(89, 17);
            this.chkCloseTO.TabIndex = 2;
            this.chkCloseTO.Text = "closeTimeout";
            this.chkCloseTO.UseVisualStyleBackColor = true;
            this.chkCloseTO.CheckedChanged += new System.EventHandler(this.chkCloseTO_CheckedChanged);
            // 
            // txtSndTO
            // 
            this.txtSndTO.Enabled = false;
            this.txtSndTO.Location = new System.Drawing.Point(338, 40);
            this.txtSndTO.MaxLength = 8;
            this.txtSndTO.Name = "txtSndTO";
            this.txtSndTO.Size = new System.Drawing.Size(55, 20);
            this.txtSndTO.TabIndex = 0;
            // 
            // txtRcvTO
            // 
            this.txtRcvTO.Enabled = false;
            this.txtRcvTO.Location = new System.Drawing.Point(338, 15);
            this.txtRcvTO.MaxLength = 8;
            this.txtRcvTO.Name = "txtRcvTO";
            this.txtRcvTO.Size = new System.Drawing.Size(55, 20);
            this.txtRcvTO.TabIndex = 0;
            // 
            // txtOpenTO
            // 
            this.txtOpenTO.Enabled = false;
            this.txtOpenTO.Location = new System.Drawing.Point(122, 40);
            this.txtOpenTO.MaxLength = 8;
            this.txtOpenTO.Name = "txtOpenTO";
            this.txtOpenTO.Size = new System.Drawing.Size(55, 20);
            this.txtOpenTO.TabIndex = 0;
            // 
            // txtCloseTO
            // 
            this.txtCloseTO.Enabled = false;
            this.txtCloseTO.Location = new System.Drawing.Point(122, 15);
            this.txtCloseTO.MaxLength = 8;
            this.txtCloseTO.Name = "txtCloseTO";
            this.txtCloseTO.Size = new System.Drawing.Size(55, 20);
            this.txtCloseTO.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "(*) only the ports with WCF-Custom Adapter have this property";
            // 
            // filterGroup
            // 
            this.filterGroup.Controls.Add(this.label1);
            this.filterGroup.Controls.Add(this.ddlApplication);
            this.filterGroup.Controls.Add(this.ddlAction);
            this.filterGroup.Controls.Add(this.ddlSourceDestination);
            this.filterGroup.Controls.Add(this.lblApplication);
            this.filterGroup.Controls.Add(this.lblAction);
            this.filterGroup.Location = new System.Drawing.Point(15, 9);
            this.filterGroup.Name = "filterGroup";
            this.filterGroup.Size = new System.Drawing.Size(472, 98);
            this.filterGroup.TabIndex = 11;
            this.filterGroup.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(504, 17);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(30, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // transportOptionsGroup
            // 
            this.transportOptionsGroup.Controls.Add(this.chkRoutingFailedMessages);
            this.transportOptionsGroup.Controls.Add(this.txtRetryInterval);
            this.transportOptionsGroup.Controls.Add(this.txtRetryCount);
            this.transportOptionsGroup.Controls.Add(this.ddlRoutingFailedMessages);
            this.transportOptionsGroup.Controls.Add(this.chkRetryInterval);
            this.transportOptionsGroup.Controls.Add(this.chkRetryCount);
            this.transportOptionsGroup.Enabled = false;
            this.transportOptionsGroup.Location = new System.Drawing.Point(15, 385);
            this.transportOptionsGroup.Name = "transportOptionsGroup";
            this.transportOptionsGroup.Size = new System.Drawing.Size(533, 82);
            this.transportOptionsGroup.TabIndex = 12;
            this.transportOptionsGroup.TabStop = false;
            this.transportOptionsGroup.Text = "Transport Options";
            // 
            // chkRoutingFailedMessages
            // 
            this.chkRoutingFailedMessages.AutoSize = true;
            this.chkRoutingFailedMessages.Location = new System.Drawing.Point(255, 20);
            this.chkRoutingFailedMessages.Name = "chkRoutingFailedMessages";
            this.chkRoutingFailedMessages.Size = new System.Drawing.Size(187, 17);
            this.chkRoutingFailedMessages.TabIndex = 3;
            this.chkRoutingFailedMessages.Text = "Enable routing for failed messages";
            this.chkRoutingFailedMessages.UseVisualStyleBackColor = true;
            this.chkRoutingFailedMessages.CheckedChanged += new System.EventHandler(this.chkRoutingFailedMessages_CheckedChanged);
            // 
            // txtRetryInterval
            // 
            this.txtRetryInterval.Enabled = false;
            this.txtRetryInterval.Location = new System.Drawing.Point(158, 45);
            this.txtRetryInterval.MaxLength = 0;
            this.txtRetryInterval.Name = "txtRetryInterval";
            this.txtRetryInterval.Size = new System.Drawing.Size(55, 20);
            this.txtRetryInterval.TabIndex = 2;
            this.txtRetryInterval.Text = "0";
            // 
            // txtRetryCount
            // 
            this.txtRetryCount.Enabled = false;
            this.txtRetryCount.Location = new System.Drawing.Point(158, 16);
            this.txtRetryCount.MaxLength = 10;
            this.txtRetryCount.Name = "txtRetryCount";
            this.txtRetryCount.Size = new System.Drawing.Size(55, 20);
            this.txtRetryCount.TabIndex = 2;
            this.txtRetryCount.Text = "0";
            // 
            // ddlRoutingFailedMessages
            // 
            this.ddlRoutingFailedMessages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlRoutingFailedMessages.Enabled = false;
            this.ddlRoutingFailedMessages.FormattingEnabled = true;
            this.ddlRoutingFailedMessages.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.ddlRoutingFailedMessages.Location = new System.Drawing.Point(448, 18);
            this.ddlRoutingFailedMessages.Name = "ddlRoutingFailedMessages";
            this.ddlRoutingFailedMessages.Size = new System.Drawing.Size(55, 21);
            this.ddlRoutingFailedMessages.TabIndex = 1;
            // 
            // chkRetryInterval
            // 
            this.chkRetryInterval.AutoSize = true;
            this.chkRetryInterval.Location = new System.Drawing.Point(17, 47);
            this.chkRetryInterval.Name = "chkRetryInterval";
            this.chkRetryInterval.Size = new System.Drawing.Size(136, 17);
            this.chkRetryInterval.TabIndex = 2;
            this.chkRetryInterval.Text = "Retry interval (minutes):";
            this.chkRetryInterval.UseVisualStyleBackColor = true;
            this.chkRetryInterval.CheckedChanged += new System.EventHandler(this.chkRetryInterval_CheckedChanged);
            // 
            // chkRetryCount
            // 
            this.chkRetryCount.AutoSize = true;
            this.chkRetryCount.Location = new System.Drawing.Point(17, 20);
            this.chkRetryCount.Name = "chkRetryCount";
            this.chkRetryCount.Size = new System.Drawing.Size(84, 17);
            this.chkRetryCount.TabIndex = 2;
            this.chkRetryCount.Text = "Retry count:";
            this.chkRetryCount.UseVisualStyleBackColor = true;
            this.chkRetryCount.CheckedChanged += new System.EventHandler(this.chkRetryCount_CheckedChanged);
            // 
            // hostOptionGroup
            // 
            this.hostOptionGroup.Controls.Add(this.chkObjectNewHost);
            this.hostOptionGroup.Controls.Add(this.ddlObjectNewHost);
            this.hostOptionGroup.Location = new System.Drawing.Point(15, 318);
            this.hostOptionGroup.Name = "hostOptionGroup";
            this.hostOptionGroup.Size = new System.Drawing.Size(533, 60);
            this.hostOptionGroup.TabIndex = 14;
            this.hostOptionGroup.TabStop = false;
            this.hostOptionGroup.Text = "Host Options";
            // 
            // chkObjectNewHost
            // 
            this.chkObjectNewHost.AutoSize = true;
            this.chkObjectNewHost.Enabled = false;
            this.chkObjectNewHost.Location = new System.Drawing.Point(17, 23);
            this.chkObjectNewHost.Name = "chkObjectNewHost";
            this.chkObjectNewHost.Size = new System.Drawing.Size(82, 17);
            this.chkObjectNewHost.TabIndex = 15;
            this.chkObjectNewHost.Text = "Select new:";
            this.chkObjectNewHost.UseVisualStyleBackColor = true;
            this.chkObjectNewHost.CheckedChanged += new System.EventHandler(this.chkObjectNewHost_CheckedChanged);
            // 
            // ddlObjectNewHost
            // 
            this.ddlObjectNewHost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlObjectNewHost.Enabled = false;
            this.ddlObjectNewHost.FormattingEnabled = true;
            this.ddlObjectNewHost.Location = new System.Drawing.Point(158, 21);
            this.ddlObjectNewHost.Name = "ddlObjectNewHost";
            this.ddlObjectNewHost.Size = new System.Drawing.Size(345, 21);
            this.ddlObjectNewHost.TabIndex = 14;
            // 
            // colChkBox
            // 
            this.colChkBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colChkBox.FillWeight = 25F;
            this.colChkBox.HeaderText = "";
            this.colChkBox.Name = "colChkBox";
            this.colChkBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colChkBox.Width = 34;
            // 
            // colObjectName
            // 
            this.colObjectName.FillWeight = 92.89647F;
            this.colObjectName.HeaderText = "Object Name";
            this.colObjectName.Name = "colObjectName";
            this.colObjectName.ReadOnly = true;
            // 
            // colHost
            // 
            this.colHost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colHost.FillWeight = 152.51F;
            this.colHost.HeaderText = "Host";
            this.colHost.Name = "colHost";
            this.colHost.ReadOnly = true;
            this.colHost.Width = 54;
            // 
            // colAdapter
            // 
            this.colAdapter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAdapter.FillWeight = 86.48289F;
            this.colAdapter.HeaderText = "Adapter";
            this.colAdapter.Name = "colAdapter";
            this.colAdapter.ReadOnly = true;
            this.colAdapter.Width = 69;
            // 
            // ModifyBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 589);
            this.Controls.Add(this.hostOptionGroup);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.transportOptionsGroup);
            this.Controls.Add(this.filterGroup);
            this.Controls.Add(this.wcfBindingElementGroup);
            this.Controls.Add(this.gwObjList);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblgwObjList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModifyBlock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify Settings in Block";
            ((System.ComponentModel.ISupportInitialize)(this.gwObjList)).EndInit();
            this.wcfBindingElementGroup.ResumeLayout(false);
            this.wcfBindingElementGroup.PerformLayout();
            this.filterGroup.ResumeLayout(false);
            this.filterGroup.PerformLayout();
            this.transportOptionsGroup.ResumeLayout(false);
            this.transportOptionsGroup.PerformLayout();
            this.hostOptionGroup.ResumeLayout(false);
            this.hostOptionGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlApplication;
        private System.Windows.Forms.ComboBox ddlSourceDestination;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblApplication;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblgwObjList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.ComboBox ddlAction;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView gwObjList;
        private System.Windows.Forms.GroupBox wcfBindingElementGroup;
        private System.Windows.Forms.TextBox txtSndTO;
        private System.Windows.Forms.TextBox txtRcvTO;
        private System.Windows.Forms.TextBox txtOpenTO;
        private System.Windows.Forms.TextBox txtCloseTO;
        private System.Windows.Forms.GroupBox filterGroup;
        private System.Windows.Forms.GroupBox transportOptionsGroup;
        private System.Windows.Forms.TextBox txtRetryInterval;
        private System.Windows.Forms.TextBox txtRetryCount;
        private System.Windows.Forms.CheckBox chkRoutingFailedMessages;
        private System.Windows.Forms.CheckBox chkOpenTO;
        private System.Windows.Forms.CheckBox chkSndTO;
        private System.Windows.Forms.CheckBox chkRcvTO;
        private System.Windows.Forms.CheckBox chkCloseTO;
        private System.Windows.Forms.CheckBox chkRetryInterval;
        private System.Windows.Forms.CheckBox chkRetryCount;
        private System.Windows.Forms.ComboBox ddlRoutingFailedMessages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox hostOptionGroup;
        private System.Windows.Forms.CheckBox chkObjectNewHost;
        private System.Windows.Forms.ComboBox ddlObjectNewHost;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChkBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdapter;
    }
}