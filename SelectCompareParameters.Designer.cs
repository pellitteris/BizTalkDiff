namespace Microsys.EAI.BizTalkUtilities
{
    partial class SelectCompareParameters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectCompareParameters));
            this.groupSendPort = new System.Windows.Forms.GroupBox();
            this.checkSptMaps = new System.Windows.Forms.CheckBox();
            this.checkSptPipeline = new System.Windows.Forms.CheckBox();
            this.checkSptFilter = new System.Windows.Forms.CheckBox();
            this.checkSptHost = new System.Windows.Forms.CheckBox();
            this.checkSptAddress = new System.Windows.Forms.CheckBox();
            this.compareButton = new System.Windows.Forms.Button();
            this.groupSendPortGroup = new System.Windows.Forms.GroupBox();
            this.checkSptgFilter = new System.Windows.Forms.CheckBox();
            this.groupReceivePort = new System.Windows.Forms.GroupBox();
            this.checkRptMaps = new System.Windows.Forms.CheckBox();
            this.checkRptEnableRouting = new System.Windows.Forms.CheckBox();
            this.groupReceiveLocation = new System.Windows.Forms.GroupBox();
            this.checkRlcHost = new System.Windows.Forms.CheckBox();
            this.checkRlcPipeline = new System.Windows.Forms.CheckBox();
            this.checkRlcAddress = new System.Windows.Forms.CheckBox();
            this.groupOrchestration = new System.Windows.Forms.GroupBox();
            this.checkOrcBindings = new System.Windows.Forms.CheckBox();
            this.checkOrcHost = new System.Windows.Forms.CheckBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.Help = new System.Windows.Forms.ToolStripStatusLabel();
            this.clearButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.checkSptAddressFileMask = new System.Windows.Forms.CheckBox();
            this.checkRlcAddressFileMask = new System.Windows.Forms.CheckBox();
            this.groupSendPort.SuspendLayout();
            this.groupSendPortGroup.SuspendLayout();
            this.groupReceivePort.SuspendLayout();
            this.groupReceiveLocation.SuspendLayout();
            this.groupOrchestration.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupSendPort
            // 
            this.groupSendPort.Controls.Add(this.checkSptAddressFileMask);
            this.groupSendPort.Controls.Add(this.checkSptMaps);
            this.groupSendPort.Controls.Add(this.checkSptPipeline);
            this.groupSendPort.Controls.Add(this.checkSptFilter);
            this.groupSendPort.Controls.Add(this.checkSptHost);
            this.groupSendPort.Controls.Add(this.checkSptAddress);
            this.groupSendPort.Location = new System.Drawing.Point(12, 12);
            this.groupSendPort.Name = "groupSendPort";
            this.groupSendPort.Size = new System.Drawing.Size(200, 177);
            this.groupSendPort.TabIndex = 0;
            this.groupSendPort.TabStop = false;
            this.groupSendPort.Text = "Send Port";
            // 
            // checkSptMaps
            // 
            this.checkSptMaps.AutoSize = true;
            this.checkSptMaps.Location = new System.Drawing.Point(16, 140);
            this.checkSptMaps.Name = "checkSptMaps";
            this.checkSptMaps.Size = new System.Drawing.Size(52, 17);
            this.checkSptMaps.TabIndex = 5;
            this.checkSptMaps.Text = "Maps";
            this.checkSptMaps.UseVisualStyleBackColor = true;
            // 
            // checkSptPipeline
            // 
            this.checkSptPipeline.AutoSize = true;
            this.checkSptPipeline.Location = new System.Drawing.Point(16, 118);
            this.checkSptPipeline.Name = "checkSptPipeline";
            this.checkSptPipeline.Size = new System.Drawing.Size(63, 17);
            this.checkSptPipeline.TabIndex = 4;
            this.checkSptPipeline.Text = "Pipeline";
            this.checkSptPipeline.UseVisualStyleBackColor = true;
            // 
            // checkSptFilter
            // 
            this.checkSptFilter.AutoSize = true;
            this.checkSptFilter.Location = new System.Drawing.Point(16, 96);
            this.checkSptFilter.Name = "checkSptFilter";
            this.checkSptFilter.Size = new System.Drawing.Size(83, 17);
            this.checkSptFilter.TabIndex = 3;
            this.checkSptFilter.Text = "Filter Clause";
            this.checkSptFilter.UseVisualStyleBackColor = true;
            // 
            // checkSptHost
            // 
            this.checkSptHost.AutoSize = true;
            this.checkSptHost.Location = new System.Drawing.Point(16, 74);
            this.checkSptHost.Name = "checkSptHost";
            this.checkSptHost.Size = new System.Drawing.Size(48, 17);
            this.checkSptHost.TabIndex = 2;
            this.checkSptHost.Text = "Host";
            this.checkSptHost.UseVisualStyleBackColor = true;
            // 
            // checkSptAddress
            // 
            this.checkSptAddress.AutoSize = true;
            this.checkSptAddress.Location = new System.Drawing.Point(16, 30);
            this.checkSptAddress.Name = "checkSptAddress";
            this.checkSptAddress.Size = new System.Drawing.Size(64, 17);
            this.checkSptAddress.TabIndex = 0;
            this.checkSptAddress.Text = "Address";
            this.checkSptAddress.UseVisualStyleBackColor = true;
            // 
            // compareButton
            // 
            this.compareButton.Location = new System.Drawing.Point(959, 200);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(75, 23);
            this.compareButton.TabIndex = 100;
            this.compareButton.Text = "Compare";
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // groupSendPortGroup
            // 
            this.groupSendPortGroup.Controls.Add(this.checkSptgFilter);
            this.groupSendPortGroup.Location = new System.Drawing.Point(218, 12);
            this.groupSendPortGroup.Name = "groupSendPortGroup";
            this.groupSendPortGroup.Size = new System.Drawing.Size(200, 177);
            this.groupSendPortGroup.TabIndex = 1;
            this.groupSendPortGroup.TabStop = false;
            this.groupSendPortGroup.Text = "Send Port Group";
            // 
            // checkSptgFilter
            // 
            this.checkSptgFilter.AutoSize = true;
            this.checkSptgFilter.Location = new System.Drawing.Point(16, 30);
            this.checkSptgFilter.Name = "checkSptgFilter";
            this.checkSptgFilter.Size = new System.Drawing.Size(83, 17);
            this.checkSptgFilter.TabIndex = 10;
            this.checkSptgFilter.Text = "Filter Clause";
            this.checkSptgFilter.UseVisualStyleBackColor = true;
            // 
            // groupReceivePort
            // 
            this.groupReceivePort.Controls.Add(this.checkRptMaps);
            this.groupReceivePort.Controls.Add(this.checkRptEnableRouting);
            this.groupReceivePort.Location = new System.Drawing.Point(424, 12);
            this.groupReceivePort.Name = "groupReceivePort";
            this.groupReceivePort.Size = new System.Drawing.Size(200, 177);
            this.groupReceivePort.TabIndex = 1;
            this.groupReceivePort.TabStop = false;
            this.groupReceivePort.Text = "Receive Port";
            // 
            // checkRptMaps
            // 
            this.checkRptMaps.AutoSize = true;
            this.checkRptMaps.Location = new System.Drawing.Point(14, 53);
            this.checkRptMaps.Name = "checkRptMaps";
            this.checkRptMaps.Size = new System.Drawing.Size(52, 17);
            this.checkRptMaps.TabIndex = 21;
            this.checkRptMaps.Text = "Maps";
            this.checkRptMaps.UseVisualStyleBackColor = true;
            // 
            // checkRptEnableRouting
            // 
            this.checkRptEnableRouting.AutoSize = true;
            this.checkRptEnableRouting.Location = new System.Drawing.Point(14, 30);
            this.checkRptEnableRouting.Name = "checkRptEnableRouting";
            this.checkRptEnableRouting.Size = new System.Drawing.Size(179, 17);
            this.checkRptEnableRouting.TabIndex = 20;
            this.checkRptEnableRouting.Text = "Enable routing fo failed message";
            this.checkRptEnableRouting.UseVisualStyleBackColor = true;
            // 
            // groupReceiveLocation
            // 
            this.groupReceiveLocation.Controls.Add(this.checkRlcAddressFileMask);
            this.groupReceiveLocation.Controls.Add(this.checkRlcHost);
            this.groupReceiveLocation.Controls.Add(this.checkRlcPipeline);
            this.groupReceiveLocation.Controls.Add(this.checkRlcAddress);
            this.groupReceiveLocation.Location = new System.Drawing.Point(630, 12);
            this.groupReceiveLocation.Name = "groupReceiveLocation";
            this.groupReceiveLocation.Size = new System.Drawing.Size(200, 177);
            this.groupReceiveLocation.TabIndex = 2;
            this.groupReceiveLocation.TabStop = false;
            this.groupReceiveLocation.Text = "Receive Location";
            // 
            // checkRlcHost
            // 
            this.checkRlcHost.AutoSize = true;
            this.checkRlcHost.Location = new System.Drawing.Point(15, 96);
            this.checkRlcHost.Name = "checkRlcHost";
            this.checkRlcHost.Size = new System.Drawing.Size(48, 17);
            this.checkRlcHost.TabIndex = 33;
            this.checkRlcHost.Text = "Host";
            this.checkRlcHost.UseVisualStyleBackColor = true;
            // 
            // checkRlcPipeline
            // 
            this.checkRlcPipeline.AutoSize = true;
            this.checkRlcPipeline.Location = new System.Drawing.Point(15, 74);
            this.checkRlcPipeline.Name = "checkRlcPipeline";
            this.checkRlcPipeline.Size = new System.Drawing.Size(63, 17);
            this.checkRlcPipeline.TabIndex = 32;
            this.checkRlcPipeline.Text = "Pipeline";
            this.checkRlcPipeline.UseVisualStyleBackColor = true;
            // 
            // checkRlcAddress
            // 
            this.checkRlcAddress.AutoSize = true;
            this.checkRlcAddress.Location = new System.Drawing.Point(15, 30);
            this.checkRlcAddress.Name = "checkRlcAddress";
            this.checkRlcAddress.Size = new System.Drawing.Size(64, 17);
            this.checkRlcAddress.TabIndex = 30;
            this.checkRlcAddress.Text = "Address";
            this.checkRlcAddress.UseVisualStyleBackColor = true;
            // 
            // groupOrchestration
            // 
            this.groupOrchestration.Controls.Add(this.checkOrcBindings);
            this.groupOrchestration.Controls.Add(this.checkOrcHost);
            this.groupOrchestration.Location = new System.Drawing.Point(836, 12);
            this.groupOrchestration.Name = "groupOrchestration";
            this.groupOrchestration.Size = new System.Drawing.Size(200, 177);
            this.groupOrchestration.TabIndex = 3;
            this.groupOrchestration.TabStop = false;
            this.groupOrchestration.Text = "Orchestration";
            // 
            // checkOrcBindings
            // 
            this.checkOrcBindings.AutoSize = true;
            this.checkOrcBindings.Location = new System.Drawing.Point(15, 53);
            this.checkOrcBindings.Name = "checkOrcBindings";
            this.checkOrcBindings.Size = new System.Drawing.Size(66, 17);
            this.checkOrcBindings.TabIndex = 41;
            this.checkOrcBindings.Text = "Bindings";
            this.checkOrcBindings.UseVisualStyleBackColor = true;
            // 
            // checkOrcHost
            // 
            this.checkOrcHost.AutoSize = true;
            this.checkOrcHost.Location = new System.Drawing.Point(15, 30);
            this.checkOrcHost.Name = "checkOrcHost";
            this.checkOrcHost.Size = new System.Drawing.Size(48, 17);
            this.checkOrcHost.TabIndex = 40;
            this.checkOrcHost.Text = "Host";
            this.checkOrcHost.UseVisualStyleBackColor = true;
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Help});
            this.statusBar.Location = new System.Drawing.Point(0, 234);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1046, 22);
            this.statusBar.TabIndex = 101;
            // 
            // Help
            // 
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(614, 17);
            this.Help.Text = "By default will be verified the existence of objects. In addition it is possible " +
    "to compare the existing attributes values.";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(797, 200);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 96;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(716, 200);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(75, 23);
            this.selectButton.TabIndex = 95;
            this.selectButton.Text = "Select All";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(878, 200);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 97;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // checkSptAddressFileMask
            // 
            this.checkSptAddressFileMask.AutoSize = true;
            this.checkSptAddressFileMask.Location = new System.Drawing.Point(16, 52);
            this.checkSptAddressFileMask.Name = "checkSptAddressFileMask";
            this.checkSptAddressFileMask.Size = new System.Drawing.Size(112, 17);
            this.checkSptAddressFileMask.TabIndex = 1;
            this.checkSptAddressFileMask.Text = "Address File Mask";
            this.checkSptAddressFileMask.UseVisualStyleBackColor = true;
            // 
            // checkRlcAddressFileMask
            // 
            this.checkRlcAddressFileMask.AutoSize = true;
            this.checkRlcAddressFileMask.Location = new System.Drawing.Point(15, 52);
            this.checkRlcAddressFileMask.Name = "checkRlcAddressFileMask";
            this.checkRlcAddressFileMask.Size = new System.Drawing.Size(112, 17);
            this.checkRlcAddressFileMask.TabIndex = 31;
            this.checkRlcAddressFileMask.Text = "Address File Mask";
            this.checkRlcAddressFileMask.UseVisualStyleBackColor = true;
            // 
            // SelectCompareParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 256);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.groupOrchestration);
            this.Controls.Add(this.groupReceiveLocation);
            this.Controls.Add(this.groupReceivePort);
            this.Controls.Add(this.groupSendPortGroup);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.groupSendPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectCompareParameters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Compare Parameters";
            this.Load += new System.EventHandler(this.SelectCompareParameters_Load);
            this.groupSendPort.ResumeLayout(false);
            this.groupSendPort.PerformLayout();
            this.groupSendPortGroup.ResumeLayout(false);
            this.groupSendPortGroup.PerformLayout();
            this.groupReceivePort.ResumeLayout(false);
            this.groupReceivePort.PerformLayout();
            this.groupReceiveLocation.ResumeLayout(false);
            this.groupReceiveLocation.PerformLayout();
            this.groupOrchestration.ResumeLayout(false);
            this.groupOrchestration.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSendPort;
        private System.Windows.Forms.CheckBox checkSptAddress;
        private System.Windows.Forms.Button compareButton;
        private System.Windows.Forms.GroupBox groupSendPortGroup;
        private System.Windows.Forms.CheckBox checkSptgFilter;
        private System.Windows.Forms.GroupBox groupReceivePort;
        private System.Windows.Forms.GroupBox groupReceiveLocation;
        private System.Windows.Forms.CheckBox checkRlcAddress;
        private System.Windows.Forms.GroupBox groupOrchestration;
        private System.Windows.Forms.CheckBox checkOrcHost;
        private System.Windows.Forms.CheckBox checkSptPipeline;
        private System.Windows.Forms.CheckBox checkSptFilter;
        private System.Windows.Forms.CheckBox checkSptHost;
        private System.Windows.Forms.CheckBox checkRptEnableRouting;
        private System.Windows.Forms.CheckBox checkRlcPipeline;
        private System.Windows.Forms.CheckBox checkRlcHost;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel Help;
        private System.Windows.Forms.CheckBox checkSptMaps;
        private System.Windows.Forms.CheckBox checkRptMaps;
        private System.Windows.Forms.CheckBox checkOrcBindings;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox checkSptAddressFileMask;
        private System.Windows.Forms.CheckBox checkRlcAddressFileMask;
    }
}