using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.BizTalk.ExplorerOM;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.IO;
using System.Xml.Linq;

namespace Microsys.EAI.BizTalkUtilities
{

    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            Welcome welcome = new Welcome();
            welcome.ShowDialog();

            tableLayoutPanel.SetColumnSpan(statusStrip, 3);

            try
            {

                string fileName = Path.Combine(Path.GetTempPath(), "Servers.bin");

                if (File.Exists(fileName))
                {
                    using (StreamReader stream = new StreamReader(fileName))
                    {
                        while (stream.Peek() >= 0)
                        {
                            string line = stream.ReadLine();

                            txtSource.Items.Add(line);
                            txtTarget.Items.Add(line);
                        }

                        if (txtSource.Items.Count > 0)
                        {
                            txtSource.SelectedIndex = 0;
                            txtTarget.SelectedIndex = 0;
                        }

                        stream.Close();
                    }
                }

                if (txtSource.Items.Count == 0)
                {
                    using (RegistryKey bizTalkAdminKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\BizTalk Server\3.0\Administration"))
                    {
                        if (bizTalkAdminKey != null)
                        {
                            string server = (string)bizTalkAdminKey.GetValue("MgmtDBServer", ".");
                            string database = (string)bizTalkAdminKey.GetValue("MgmtDBName", "BizTalkMgmtDb");

                            txtSource.Text = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;", server, database);
                            txtTarget.Text = txtSource.Text;
                        }
                    }
                }

            }
            catch
            {
                txtSource.Text = "Data Source=localhost;Initial Catalog=BizTalkMgmtDb;Integrated Security=SSPI;";
            }

        }

        private void Collect(ref TreeView biztalkTree, string connectionString)
        {

            BtsCatalogExplorer catalog = new BtsCatalogExplorer();
            catalog.ConnectionString = connectionString;

            BizTalkObject biztalkObject;
            TreeNode node;
            int i = 0;

            biztalkTree.Nodes.Clear();

            sourceReport.Visible = false;
            targetReport.Visible = false;
            attributeReport.Visible = false;

            System.Windows.Forms.Application.DoEvents();

            #region Application

            // Applications Folder
            biztalkObject = new BizTalkObject(BizTalkObjectType.Folder, false);
            node = new TreeNode();

            node.Text = "Applications";
            node.Tag = biztalkObject;
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;

            biztalkTree.Nodes.Add(node);

            foreach (Microsoft.BizTalk.ExplorerOM.Application application in catalog.Applications)
            {

                if (application.Name != "BizTalk.System")
                {

                    #region Application

                    // Application
                    biztalkObject = new BizTalkObject(BizTalkObjectType.Application, false);
                    node = new TreeNode();

                    node.Text = application.Name;
                    node.Tag = biztalkObject;
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;

                    biztalkTree.Nodes[0].Nodes.Add(node);

                    #endregion

                    #region Receive Port & Receive Location

                    // Receive Ports Folder
                    biztalkObject = new BizTalkObject(BizTalkObjectType.Folder, false);
                    node = new TreeNode();

                    node.Text = "Receive Ports";
                    node.Tag = biztalkObject;
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;

                    biztalkTree.Nodes[0].Nodes[i].Nodes.Add(node);

                    // Receive Ports
                    int j = 0;

                    foreach (ReceivePort receivePort in application.ReceivePorts)
                    {

                        IList<string> inboundTransforms = new List<string>();
                        IList<string> outboundTransforms = new List<string>();

                        if (receivePort.InboundTransforms != null)
                        {
                            foreach (Transform map in receivePort.InboundTransforms)
                            {
                                inboundTransforms.Add(map.FullName);
                            }
                        }
                        if (receivePort.OutboundTransforms != null)
                        {
                            foreach (Transform map in receivePort.OutboundTransforms)
                            {
                                outboundTransforms.Add(map.FullName);
                            }
                        }

                        biztalkObject = new BizTalkObject(BizTalkObjectType.ReceivePort, true, receivePort, inboundTransforms, outboundTransforms);
                        node = new TreeNode();

                        node.Text = receivePort.Name;
                        node.Tag = biztalkObject;
                        node.ImageIndex = 0;
                        node.SelectedImageIndex = 0;

                        biztalkTree.Nodes[0].Nodes[i].Nodes[0].Nodes.Add(node);

                        // Receive Locations
                        foreach (ReceiveLocation receiveLocation in receivePort.ReceiveLocations)
                        {
                            biztalkObject = new BizTalkObject(BizTalkObjectType.ReceiveLocation, true, receiveLocation);
                            node = new TreeNode();

                            node.Text = receiveLocation.Name;
                            node.Tag = biztalkObject;
                            node.ImageIndex = 3;
                            node.SelectedImageIndex = 3;

                            biztalkTree.Nodes[0].Nodes[i].Nodes[0].Nodes[j].Nodes.Add(node);
                        }

                        j++;
                    }

                    #endregion

                    #region Send Port Group

                    // Send Port Groups Folder
                    biztalkObject = new BizTalkObject(BizTalkObjectType.Folder, false);
                    node = new TreeNode();

                    node.Text = "Send Port Groups";
                    node.Tag = biztalkObject;
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;

                    biztalkTree.Nodes[0].Nodes[i].Nodes.Add(node);

                    // Send Port Groups
                    foreach (SendPortGroup sendPortGroup in application.SendPortGroups)
                    {
                        biztalkObject = new BizTalkObject(BizTalkObjectType.SendPortGroup, true, sendPortGroup);
                        node = new TreeNode();

                        node.Text = sendPortGroup.Name;
                        node.Tag = biztalkObject;
                        node.ImageIndex = 2;
                        node.SelectedImageIndex = 2;

                        biztalkTree.Nodes[0].Nodes[i].Nodes[1].Nodes.Add(node);
                    }

                    #endregion

                    #region Send Port

                    // Send Ports Folder
                    biztalkObject = new BizTalkObject(BizTalkObjectType.Folder, false);
                    node = new TreeNode();

                    node.Text = "Send Ports";
                    node.Tag = biztalkObject;
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;

                    biztalkTree.Nodes[0].Nodes[i].Nodes.Add(node);

                    // Send Ports
                    foreach (SendPort sendPort in application.SendPorts)
                    {

                        IList<string> inboundTransforms = new List<string>();
                        IList<string> outboundTransforms = new List<string>();

                        if (sendPort.InboundTransforms != null)
                        {
                            foreach (Transform map in sendPort.InboundTransforms)
                            {
                                inboundTransforms.Add(map.FullName);
                            }
                        }
                        if (sendPort.OutboundTransforms != null)
                        {
                            foreach (Transform map in sendPort.OutboundTransforms)
                            {
                                outboundTransforms.Add(map.FullName);
                            }
                        }

                        biztalkObject = new BizTalkObject(BizTalkObjectType.SendPort, true, sendPort, inboundTransforms, outboundTransforms);
                        node = new TreeNode();

                        node.Text = sendPort.Name;
                        node.Tag = biztalkObject;
                        node.ImageIndex = 2;
                        node.SelectedImageIndex = 2;

                        biztalkTree.Nodes[0].Nodes[i].Nodes[2].Nodes.Add(node);
                    }

                    #endregion

                    #region Orchestration

                    // Orchestrations Folder
                    biztalkObject = new BizTalkObject(BizTalkObjectType.Folder, false);
                    node = new TreeNode();

                    node.Text = "Orchestrations";
                    node.Tag = biztalkObject;
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;

                    biztalkTree.Nodes[0].Nodes[i].Nodes.Add(node);

                    // Orchestrations
                    foreach (BtsOrchestration orchestration in application.Orchestrations)
                    {

                        IList<string> ports = new List<string>();

                        if (orchestration.Ports != null)
                        {
                            foreach (OrchestrationPort port in orchestration.Ports)
                            {

                                if (port.ReceivePort != null)
                                {
                                    ports.Add(string.Concat(port.Name, "|", port.ReceivePort.Name));
                                }
                                else if (port.SendPort != null)
                                {
                                    ports.Add(string.Concat(port.Name, "|", port.SendPort.Name));
                                }
                                else if (port.SendPortGroup != null)
                                {
                                    ports.Add(string.Concat(port.Name, "|", port.SendPortGroup.Name));
                                }
                                else
                                {
                                    ports.Add(string.Concat(port.Name, "|unbound"));
                                }

                            }
                        }

                        biztalkObject = new BizTalkObject(BizTalkObjectType.Orchestration, false, orchestration, ports);

                        node = new TreeNode();

                        node.Text = orchestration.FullName;
                        node.Tag = biztalkObject;
                        node.ImageIndex = 6;
                        node.SelectedImageIndex = 6;

                        biztalkTree.Nodes[0].Nodes[i].Nodes[3].Nodes.Add(node);

                    }

                    #endregion

                    i++;

                }

            }

            #endregion

            #region Host

            // Host Folder
            biztalkObject = new BizTalkObject(BizTalkObjectType.Folder, false);
            node = new TreeNode();

            node.Text = "Hosts";
            node.Tag = biztalkObject;
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;

            biztalkTree.Nodes.Add(node);

            // Host
            foreach (Microsoft.BizTalk.ExplorerOM.Host host in catalog.Hosts)
            {

                biztalkObject = new BizTalkObject(BizTalkObjectType.Host, false);
                node = new TreeNode();

                node.Text = host.Name;
                node.Tag = biztalkObject;
                node.ImageIndex = 5;
                node.SelectedImageIndex = 5;

                biztalkTree.Nodes[1].Nodes.Add(node);

            }

            #endregion

        }

        private void lnkCollect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            try
            {
                Collect(ref biztalkSource, txtSource.Text);
                Collect(ref biztalkTarget, txtTarget.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void biztalkSourceActions_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            try
            {
                biztalkSourceActions.Close();
            }
            catch { }

            System.Windows.Forms.Application.DoEvents();

            try
            {

                if (biztalkSource.Nodes.Count > 0)
                {

                    if (biztalkSource.SelectedNode != null)
                    {

                        switch (e.ClickedItem.Name)
                        {
                            case "alignToolStripMenuItem":

                                Align(biztalkSource.SelectedNode);

                                break;

                            case "findToolStripMenuItem":

                                if (Find(biztalkSource.SelectedNode, biztalkTarget.Nodes) == null)
                                {
                                    MessageBox.Show("Object not found.");
                                }

                                break;

                            case "compareToolStripMenuItem":

                                SelectCompareParameters selectParameterForm = new SelectCompareParameters();
                                selectParameterForm.ShowDialog();

                                Compare();
                                break;

                            case "viewDetailsToolStripMenuItem":

                                if (biztalkSource.SelectedNode.Tag != null)
                                {
                                    BizTalkObject sourceObject;
                                    BizTalkObject targetObject;

                                    if (Find(biztalkSource.SelectedNode, biztalkTarget.Nodes) != null)
                                    {
                                        sourceObject = (BizTalkObject)biztalkSource.SelectedNode.Tag;
                                        targetObject = (BizTalkObject)biztalkTarget.SelectedNode.Tag;
                                    }
                                    else
                                    {
                                        sourceObject = (BizTalkObject)biztalkSource.SelectedNode.Tag;
                                        targetObject = null;
                                    }

                                    Details details = new Details(sourceObject, targetObject);
                                    details.ShowDialog();
                                }

                                break;

                            case "copyItemNameSourceActions":

                                Clipboard.SetText(biztalkSource.SelectedNode.FullPath);

                                break;

                            case "viewOnlyDifferencesToolStripMenuItem":

                                biztalkSource.CollapseAll();
                                biztalkTarget.CollapseAll();
                                ViewOnlyDifferences(biztalkSource.Nodes);
                                ViewOnlyDifferences(biztalkTarget.Nodes);

                                break;

                        }

                    }
                    else
                    {
                        MessageBox.Show("Select a node.");
                    }

                }
                else
                {
                    MessageBox.Show("Collect BizTalk information.");
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void ViewOnlyDifferences(TreeNodeCollection treeNodes)
        {
            foreach (TreeNode node in treeNodes)
            {
                if (node.BackColor == Color.OrangeRed || node.BackColor == Color.Orange)
                {
                    node.EnsureVisible();
                }

                ViewOnlyDifferences(node.Nodes);
            }
        }

        private BizTalkObject Find(TreeNode sourceSelectedNode, TreeNodeCollection targetNodes)
        {

            BizTalkObject returnValue = null;

            foreach (TreeNode node in targetNodes)
            {

                if (returnValue != null)
                    break;

                if (sourceSelectedNode.FullPath == node.FullPath)
                {
                    node.EnsureVisible();
                    biztalkTarget.SelectedNode = node;
                    biztalkTarget.Select();
                    returnValue = (BizTalkObject)node.Tag;
                }
                else
                {
                    returnValue = Find(sourceSelectedNode, node.Nodes);
                }
            }

            return returnValue;
        }

        public void Align(TreeNode sourceSelectedNode)
        {

            BizTalkObject biztalkObject = (BizTalkObject)sourceSelectedNode.Tag;

            if (biztalkObject.IsExportable == false)
            {
                MessageBox.Show("You have to select a Port, a Receive Location or a Port Group");
                return;
            }

            if (MessageBox.Show(string.Format("Are you sure you want create object '{0}' on target system ?", biztalkSource.SelectedNode.Text), "Confirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            if (Find(sourceSelectedNode, biztalkTarget.Nodes) != null)
            {
                MessageBox.Show("Target object already exist");
                return;
            }

            switch (biztalkObject.ObjectType)
            {
                case BizTalkObjectType.SendPort:
                    CreateSendPort(biztalkObject);
                    break;

                case BizTalkObjectType.SendPortGroup:
                    CreateSendPortGroup(biztalkObject);
                    break;

                case BizTalkObjectType.ReceivePort:
                    CreateReceivePort(biztalkObject);
                    break;

                case BizTalkObjectType.ReceiveLocation:

                    if (Find(sourceSelectedNode.Parent, biztalkTarget.Nodes) == null)
                    {
                        MessageBox.Show("You can creare a receive location only if target receive port already exist.");
                        return;
                    }

                    CreateReceiveLocationName(biztalkObject);
                    break;
            }

            Collect(ref biztalkTarget, txtTarget.Text);
            Find(sourceSelectedNode, biztalkTarget.Nodes);

        }

        private void CreateReceiveLocationName(BizTalkObject sourceBizTalkObject)
        {

            BtsCatalogExplorer targetCatalog = new BtsCatalogExplorer();

            try
            {
                // connect to the target BizTalk configuration database
                targetCatalog.ConnectionString = txtTarget.Text;

                ReceiveLocation sourceRlc = (ReceiveLocation)sourceBizTalkObject.NativeObject;
                ReceiveLocation targetRlc = targetCatalog.Applications[sourceRlc.ReceivePort.Application.Name].ReceivePorts[sourceRlc.ReceivePort.Name].AddNewReceiveLocation();

                targetRlc.Name = sourceRlc.Name;
                targetRlc.Address = sourceRlc.Address;
                targetRlc.CustomData = sourceRlc.CustomData;
                targetRlc.Description = sourceRlc.Description;
                targetRlc.EncryptionCert = sourceRlc.EncryptionCert;
                targetRlc.EndDate = sourceRlc.EndDate;
                targetRlc.EndDateEnabled = sourceRlc.EndDateEnabled;
                targetRlc.FragmentMessages = sourceRlc.FragmentMessages;
                targetRlc.FromTime = sourceRlc.FromTime;
                targetRlc.PublicAddress = sourceRlc.PublicAddress;

                foreach (ReceiveHandler rh in targetCatalog.ReceiveHandlers)
                {
                    if (rh.Name == sourceRlc.ReceiveHandler.Name && rh.TransportType.Name == sourceRlc.TransportType.Name)
                    {
                        targetRlc.ReceiveHandler = rh;
                        break;
                    }
                }

                targetRlc.ReceivePipeline = targetCatalog.Pipelines[sourceRlc.ReceivePipeline.FullName];
                targetRlc.ReceivePipelineData = sourceRlc.ReceivePipelineData;

                if (sourceRlc.ReceivePort.IsTwoWay)
                {
                    targetRlc.SendPipeline = targetCatalog.Pipelines[sourceRlc.SendPipeline.FullName];
                    targetRlc.SendPipelineData = sourceRlc.SendPipelineData;
                }

                targetRlc.ServiceWindowEnabled = sourceRlc.ServiceWindowEnabled;
                targetRlc.StartDate = sourceRlc.StartDate;
                targetRlc.StartDateEnabled = sourceRlc.StartDateEnabled;
                targetRlc.ToTime = sourceRlc.ToTime;
                targetRlc.TransportType = targetCatalog.ProtocolTypes[sourceRlc.TransportType.Name];
                targetRlc.TransportTypeData = sourceRlc.TransportTypeData;

                // persist changes to BizTalk configuration database
                targetCatalog.SaveChanges();

            }
            catch (Exception exc)
            {
                targetCatalog.DiscardChanges();

                MessageBox.Show(string.Concat(exc.Message, ". Check if all assemblies are deployed on destination system."));
            }

        }

        private void CreateSendPortGroup(BizTalkObject sourceBizTalkObject)
        {

            BtsCatalogExplorer targetCatalog = new BtsCatalogExplorer();

            try
            {

                // connect to the target BizTalk configuration database
                targetCatalog.ConnectionString = txtTarget.Text;

                SendPortGroup sourceSendPortGroup = (SendPortGroup)sourceBizTalkObject.NativeObject;
                SendPortGroup targetSendPortGroup = targetCatalog.Applications[sourceSendPortGroup.Application.Name].AddNewSendPortGroup();

                targetSendPortGroup.Name = sourceSendPortGroup.Name;
                targetSendPortGroup.CustomData = sourceSendPortGroup.CustomData;
                targetSendPortGroup.Description = sourceSendPortGroup.Description;
                targetSendPortGroup.Filter = sourceSendPortGroup.Filter;

                foreach (SendPort sourceSendPort in sourceSendPortGroup.SendPorts)
                {
                    targetSendPortGroup.SendPorts.Add(targetCatalog.SendPorts[sourceSendPort.Name]);
                }

                // persist changes to BizTalk configuration database
                targetCatalog.SaveChanges();

            }
            catch (Exception exc)
            {
                targetCatalog.DiscardChanges();

                MessageBox.Show(exc.Message);
            }
        }

        private void CreateReceivePort(BizTalkObject sourceBizTalkObject)
        {

            BtsCatalogExplorer targetCatalog = new BtsCatalogExplorer();

            try
            {

                // connect to the target BizTalk configuration database
                targetCatalog.ConnectionString = txtTarget.Text;

                ReceivePort sourceReceivePort = (ReceivePort)sourceBizTalkObject.NativeObject;
                ReceivePort targetReceivePort = targetCatalog.Applications[sourceReceivePort.Application.Name].AddNewReceivePort(sourceReceivePort.IsTwoWay);

                targetReceivePort.Name = sourceReceivePort.Name;
                targetReceivePort.Authentication = sourceReceivePort.Authentication;
                targetReceivePort.CustomData = sourceReceivePort.CustomData;
                targetReceivePort.Description = sourceReceivePort.Description;
                targetReceivePort.RouteFailedMessage = sourceReceivePort.RouteFailedMessage;
                targetReceivePort.Tracking = sourceReceivePort.Tracking;

                foreach (ReceiveLocation sourceReceiveLocation in sourceReceivePort.ReceiveLocations)
                {
                    ReceiveLocation targetReceiveLocation = targetReceivePort.AddNewReceiveLocation();

                    targetReceiveLocation.Name = sourceReceiveLocation.Name;
                    targetReceiveLocation.Address = sourceReceiveLocation.Address;
                    targetReceiveLocation.CustomData = sourceReceiveLocation.CustomData;
                    targetReceiveLocation.Description = sourceReceiveLocation.Description;
                    targetReceiveLocation.EncryptionCert = sourceReceiveLocation.EncryptionCert;
                    targetReceiveLocation.EndDate = sourceReceiveLocation.EndDate;
                    targetReceiveLocation.EndDateEnabled = sourceReceiveLocation.EndDateEnabled;
                    targetReceiveLocation.FragmentMessages = sourceReceiveLocation.FragmentMessages;
                    targetReceiveLocation.FromTime = sourceReceiveLocation.FromTime;
                    targetReceiveLocation.PublicAddress = sourceReceiveLocation.PublicAddress;

                    foreach (ReceiveHandler rh in targetCatalog.ReceiveHandlers)
                    {
                        if (rh.Name == sourceReceiveLocation.ReceiveHandler.Name && rh.TransportType.Name == sourceReceiveLocation.TransportType.Name)
                        {
                            targetReceiveLocation.ReceiveHandler = rh;
                            break;
                        }
                    }

                    targetReceiveLocation.ReceivePipeline = targetCatalog.Pipelines[sourceReceiveLocation.ReceivePipeline.FullName];
                    targetReceiveLocation.ReceivePipelineData = sourceReceiveLocation.ReceivePipelineData;

                    if (sourceReceivePort.IsTwoWay)
                    {
                        targetReceiveLocation.SendPipeline = targetCatalog.Pipelines[sourceReceiveLocation.SendPipeline.FullName];
                        targetReceiveLocation.SendPipelineData = sourceReceiveLocation.SendPipelineData;
                    }

                    targetReceiveLocation.ServiceWindowEnabled = sourceReceiveLocation.ServiceWindowEnabled;
                    targetReceiveLocation.StartDate = sourceReceiveLocation.StartDate;
                    targetReceiveLocation.StartDateEnabled = sourceReceiveLocation.StartDateEnabled;
                    targetReceiveLocation.ToTime = sourceReceiveLocation.ToTime;
                    targetReceiveLocation.TransportType = targetCatalog.ProtocolTypes[sourceReceiveLocation.TransportType.Name];
                    targetReceiveLocation.TransportTypeData = sourceReceiveLocation.TransportTypeData;

                    if (sourceReceiveLocation.IsPrimary)
                    {
                        targetReceivePort.PrimaryReceiveLocation = targetReceiveLocation;
                    }

                }

                foreach (Transform map in sourceReceivePort.InboundTransforms)
                {
                    targetReceivePort.InboundTransforms.Add(targetCatalog.Transforms[map.FullName]);
                }

                if (sourceReceivePort.IsTwoWay)
                {
                    foreach (Transform map in sourceReceivePort.OutboundTransforms)
                    {
                        targetReceivePort.OutboundTransforms.Add(targetCatalog.Transforms[map.FullName]);
                    }
                }

                // persist changes to BizTalk configuration database
                targetCatalog.SaveChanges();

            }
            catch (Exception exc)
            {
                targetCatalog.DiscardChanges();

                MessageBox.Show(string.Concat(exc.Message, ". Check if all assemblies are deployed on destination system."));
            }

        }

        private void CreateSendPort(BizTalkObject sourceBizTalkObject)
        {

            BtsCatalogExplorer targetCatalog = new BtsCatalogExplorer();

            try
            {

                // connect to the target BizTalk configuration database
                targetCatalog.ConnectionString = txtTarget.Text;

                SendPort sourceSendPort = (SendPort)sourceBizTalkObject.NativeObject;
                SendPort targetSendPort = targetCatalog.Applications[sourceSendPort.Application.Name].AddNewSendPort(sourceSendPort.IsDynamic, sourceSendPort.IsTwoWay);

                targetSendPort.Name = sourceSendPort.Name;
                targetSendPort.CustomData = sourceSendPort.CustomData;
                targetSendPort.Description = sourceSendPort.Description;
                targetSendPort.EncryptionCert = sourceSendPort.EncryptionCert;
                targetSendPort.Filter = sourceSendPort.Filter;

                if (!sourceSendPort.IsDynamic)
                {

                    if (sourceSendPort.InboundTransforms != null)
                    {
                        foreach (Transform map in sourceSendPort.InboundTransforms)
                        {
                            targetSendPort.InboundTransforms.Add(targetCatalog.Transforms[map.FullName]);
                        }
                    }

                    if (sourceSendPort.OutboundTransforms != null)
                    {
                        foreach (Transform map in sourceSendPort.OutboundTransforms)
                        {
                            targetSendPort.OutboundTransforms.Add(targetCatalog.Transforms[map.FullName]);
                        }
                    }

                    targetSendPort.PrimaryTransport.TransportType = targetCatalog.ProtocolTypes[sourceSendPort.PrimaryTransport.TransportType.Name];
                    targetSendPort.PrimaryTransport.TransportTypeData = sourceSendPort.PrimaryTransport.TransportTypeData;
                    targetSendPort.PrimaryTransport.Address = sourceSendPort.PrimaryTransport.Address;
                    targetSendPort.PrimaryTransport.TransportTypeData = sourceSendPort.PrimaryTransport.TransportTypeData;
                    targetSendPort.PrimaryTransport.DeliveryNotification = sourceSendPort.PrimaryTransport.DeliveryNotification;
                    targetSendPort.PrimaryTransport.FromTime = sourceSendPort.PrimaryTransport.FromTime;
                    targetSendPort.PrimaryTransport.OrderedDelivery = sourceSendPort.PrimaryTransport.OrderedDelivery;
                    targetSendPort.PrimaryTransport.RetryCount = sourceSendPort.PrimaryTransport.RetryCount;
                    targetSendPort.PrimaryTransport.RetryInterval = sourceSendPort.PrimaryTransport.RetryInterval;

                    foreach (SendHandler sh in targetCatalog.SendHandlers)
                    {
                        if (sh.Name == sourceSendPort.PrimaryTransport.SendHandler.Name && sh.TransportType.Name == sourceSendPort.PrimaryTransport.TransportType.Name)
                        {
                            targetSendPort.PrimaryTransport.SendHandler = sh;
                            break;
                        }
                    }

                    targetSendPort.PrimaryTransport.ServiceWindowEnabled = sourceSendPort.PrimaryTransport.ServiceWindowEnabled;
                    targetSendPort.PrimaryTransport.ToTime = sourceSendPort.PrimaryTransport.ToTime;

                    if (!string.IsNullOrEmpty(sourceSendPort.SecondaryTransport.Address))
                    {
                        targetSendPort.SecondaryTransport.TransportType = targetCatalog.ProtocolTypes[sourceSendPort.SecondaryTransport.TransportType.Name];
                        targetSendPort.SecondaryTransport.TransportTypeData = sourceSendPort.SecondaryTransport.TransportTypeData;
                        targetSendPort.SecondaryTransport.Address = sourceSendPort.SecondaryTransport.Address;
                        targetSendPort.SecondaryTransport.TransportTypeData = sourceSendPort.SecondaryTransport.TransportTypeData;
                        targetSendPort.SecondaryTransport.DeliveryNotification = sourceSendPort.SecondaryTransport.DeliveryNotification;
                        targetSendPort.SecondaryTransport.FromTime = sourceSendPort.SecondaryTransport.FromTime;

                        targetSendPort.SecondaryTransport.OrderedDelivery = sourceSendPort.SecondaryTransport.OrderedDelivery;
                        targetSendPort.SecondaryTransport.RetryCount = sourceSendPort.SecondaryTransport.RetryCount;
                        targetSendPort.SecondaryTransport.RetryInterval = sourceSendPort.SecondaryTransport.RetryInterval;

                        foreach (SendHandler sh in targetCatalog.SendHandlers)
                        {
                            if (sh.Name == sourceSendPort.SecondaryTransport.SendHandler.Name && sh.TransportType.Name == sourceSendPort.SecondaryTransport.TransportType.Name)
                            {
                                targetSendPort.SecondaryTransport.SendHandler = sh;
                                break;
                            }
                        }

                        targetSendPort.SecondaryTransport.ServiceWindowEnabled = sourceSendPort.SecondaryTransport.ServiceWindowEnabled;
                        targetSendPort.SecondaryTransport.ToTime = sourceSendPort.SecondaryTransport.ToTime;
                    }
                }

                targetSendPort.Priority = sourceSendPort.Priority;

                if (sourceSendPort.IsTwoWay)
                {
                    targetSendPort.ReceivePipeline = targetCatalog.Pipelines[sourceSendPort.ReceivePipeline.FullName];
                    targetSendPort.ReceivePipelineData = sourceSendPort.ReceivePipelineData;
                }

                targetSendPort.RouteFailedMessage = sourceSendPort.RouteFailedMessage;
                targetSendPort.SendPipeline = targetCatalog.Pipelines[sourceSendPort.SendPipeline.FullName];
                targetSendPort.SendPipelineData = sourceSendPort.SendPipelineData;
                targetSendPort.StopSendingOnFailure = sourceSendPort.StopSendingOnFailure;
                targetSendPort.Tracking = sourceSendPort.Tracking;

                // persist changes to BizTalk configuration database
                targetCatalog.SaveChanges();

            }
            catch (Exception exc)
            {
                targetCatalog.DiscardChanges();

                MessageBox.Show(string.Concat(exc.Message, ". Check if all assemblies are deployed on destination system."));
            }
        }

        private void Compare()
        {

            int sourceDiffCount = 0;
            int targetDiffCount = 0;
            int propertiesDiffCount = 0;

            foreach (TreeNode node in biztalkSource.Nodes)
            {
                CompareRecursive(node, biztalkTarget.Nodes, ref sourceDiffCount, true, ref propertiesDiffCount);
            }

            foreach (TreeNode node in biztalkTarget.Nodes)
            {
                CompareRecursive(node, biztalkSource.Nodes, ref targetDiffCount, false, ref propertiesDiffCount);
            }

            biztalkSource.Nodes[0].EnsureVisible();
            biztalkSource.SelectedNode = biztalkSource.Nodes[0];
            biztalkTarget.Nodes[0].EnsureVisible();
            biztalkTarget.SelectedNode = biztalkTarget.Nodes[0];

            sourceReport.Text = string.Format("{0} source items not found in the target", sourceDiffCount);
            targetReport.Text = string.Format("{0} target items not found in the source", targetDiffCount);
            attributeReport.Text = string.Format("{0} different property values", propertiesDiffCount);

            sourceReport.BackColor = (sourceDiffCount == 0 ? Color.LightGreen : Color.OrangeRed);
            sourceReport.Visible = true;

            targetReport.BackColor = (targetDiffCount == 0 ? Color.LightGreen : Color.OrangeRed);
            targetReport.Visible = true;

            attributeReport.BackColor = (propertiesDiffCount == 0 ? Color.LightGreen : Color.Orange);
            attributeReport.Visible = true;

            string message = "Found {0} items on the source system that do not exist in the target.\r\nFound {1} items on the target system that do not exist in the source.\r\nFound {2} property values.";

            System.Windows.Forms.Application.DoEvents();

            MessageBox.Show(string.Format(message, sourceDiffCount, targetDiffCount, propertiesDiffCount));

        }

        private void CompareRecursive(TreeNode node, TreeNodeCollection target, ref int diffCount, bool checkPropertiesDiff, ref int propertiesDiffCount)
        {

            BizTalkObject targetObject = Find(node, target);

            if (targetObject == null)
            {
                node.BackColor = Color.OrangeRed;
                diffCount++;
            }
            else
            {

                if (checkPropertiesDiff)
                {

                    BizTalkObject sourceObject = (BizTalkObject)node.Tag;
                    node.BackColor = Color.White;

                    switch (sourceObject.ObjectType)
                    {

                        case BizTalkObjectType.SendPort:

                            SendPort sourceSpt = (SendPort)sourceObject.NativeObject;
                            SendPort targetSpt = (SendPort)targetObject.NativeObject;

                            if (CompareParameters.SendPortCheckAddress)
                            {
                                if (sourceSpt.PrimaryTransport != null)
                                {
                                    if (targetSpt.PrimaryTransport == null || sourceSpt.PrimaryTransport.Address != targetSpt.PrimaryTransport.Address)
                                    {
                                        SetDifferenceProperties(ref node, ref propertiesDiffCount);
                                    }
                                }
                            }

                            if (CompareParameters.SendPortCheckAddressFileMask)
                            {
                                if (sourceSpt.PrimaryTransport != null && sourceSpt.PrimaryTransport.TransportType.Name == "FILE")
                                {
                                    if (targetSpt.PrimaryTransport == null || Path.GetFileName(sourceSpt.PrimaryTransport.Address) != Path.GetFileName(targetSpt.PrimaryTransport.Address))
                                    {
                                        SetDifferenceProperties(ref node, ref propertiesDiffCount);
                                    }
                                }
                            }

                            if (CompareParameters.SendPortCheckHost)
                            {
                                if (sourceSpt.PrimaryTransport != null)
                                {
                                    if (targetSpt.PrimaryTransport == null || sourceSpt.PrimaryTransport.SendHandler.Name != targetSpt.PrimaryTransport.SendHandler.Name)
                                    {
                                        SetDifferenceProperties(ref node, ref propertiesDiffCount);
                                    }
                                }
                            }

                            if (CompareParameters.SendPortCheckFilter)
                            {
                                if (!IsFiltersEquals(sourceSpt.Filter, targetSpt.Filter))
                                {
                                    SetDifferenceProperties(ref node, ref propertiesDiffCount);
                                }
                            }

                            if (CompareParameters.SendPortCheckPipeline)
                            {
                                if (sourceSpt.SendPipeline.FullName != targetSpt.SendPipeline.FullName)
                                {
                                    SetDifferenceProperties(ref node, ref propertiesDiffCount);
                                }

                                if (sourceSpt.ReceivePipeline != null)
                                {
                                    if (targetSpt.ReceivePipeline == null || sourceSpt.ReceivePipeline.FullName != targetSpt.ReceivePipeline.FullName)
                                    {
                                        SetDifferenceProperties(ref node, ref propertiesDiffCount);
                                    }
                                }
                            }

                            if (CompareParameters.SendPortCheckMaps)
                            {

                                if (AreListsDefferent(sourceObject.InboundTransformsList, targetObject.InboundTransformsList) || AreListsDefferent(sourceObject.OutboundTransformsList, targetObject.OutboundTransformsList))
                                {
                                    SetDifferenceProperties(ref node, ref propertiesDiffCount);
                                }

                            }

                            break;

                        case BizTalkObjectType.SendPortGroup:

                            SendPortGroup sourceSptg = (SendPortGroup)sourceObject.NativeObject;
                            SendPortGroup targetSptg = (SendPortGroup)targetObject.NativeObject;

                            if (CompareParameters.SendPortGroupCheckFilter)
                            {
                                if (!IsFiltersEquals(sourceSptg.Filter, targetSptg.Filter))
                                {
                                    SetDifferenceProperties(ref node, ref propertiesDiffCount);
                                }
                            }

                            break;

                        case BizTalkObjectType.ReceivePort:

                            ReceivePort sourceRpt = (ReceivePort)sourceObject.NativeObject;
                            ReceivePort targetRpt = (ReceivePort)targetObject.NativeObject;

                            if (CompareParameters.ReceivePortCheckEnableRouting)
                            {
                                if (sourceRpt.RouteFailedMessage != targetRpt.RouteFailedMessage)
                                {
                                    SetDifferenceProperties(ref node, ref propertiesDiffCount);
                                }
                            }


                            if (CompareParameters.ReceivePortCheckMaps)
                            {

                                if (AreListsDefferent(sourceObject.InboundTransformsList, targetObject.InboundTransformsList) || AreListsDefferent(sourceObject.OutboundTransformsList, targetObject.OutboundTransformsList))
                                {
                                    SetDifferenceProperties(ref node, ref propertiesDiffCount);
                                }

                            }

                            break;

                        case BizTalkObjectType.ReceiveLocation:

                            ReceiveLocation sourceRlc = (ReceiveLocation)sourceObject.NativeObject;
                            ReceiveLocation targetRlc = (ReceiveLocation)targetObject.NativeObject;

                            if (CompareParameters.ReceiveLocationCheckAddress)
                            {
                                if (sourceRlc.Address != targetRlc.Address)
                                {
                                    SetDifferenceProperties(ref node, ref propertiesDiffCount);
                                }
                            }

                            if (CompareParameters.ReceiveLocationCheckAddressFileMask)
                            {
                                if (sourceRlc.TransportType.Name == "FILE" && Path.GetFileName(sourceRlc.Address) != Path.GetFileName(targetRlc.Address))
                                {
                                    SetDifferenceProperties(ref node, ref propertiesDiffCount);
                                }
                            }

                            if (CompareParameters.ReceiveLocationCheckPipeline)
                            {
                                if (sourceRlc.ReceivePipeline.FullName != targetRlc.ReceivePipeline.FullName)
                                {
                                    SetDifferenceProperties(ref node, ref propertiesDiffCount);
                                }

                                if (sourceRlc.SendPipeline != null)
                                {
                                    if (targetRlc.SendPipeline == null || sourceRlc.SendPipeline.FullName != targetRlc.SendPipeline.FullName)
                                    {
                                        SetDifferenceProperties(ref node, ref propertiesDiffCount);
                                    }
                                }
                            }

                            if (CompareParameters.ReceiveLocationCheckHost)
                            {
                                if (sourceRlc.ReceiveHandler != null)
                                {
                                    if (targetRlc.ReceiveHandler == null || sourceRlc.ReceiveHandler.Name != targetRlc.ReceiveHandler.Name)
                                    {
                                        SetDifferenceProperties(ref node, ref propertiesDiffCount);
                                    }
                                }
                            }

                            break;

                        case BizTalkObjectType.Orchestration:

                            BtsOrchestration sourceOrc = (BtsOrchestration)sourceObject.NativeObject;
                            BtsOrchestration targetOrc = (BtsOrchestration)targetObject.NativeObject;

                            if (CompareParameters.OrchestrationCheckHost)
                            {
                                if (sourceOrc.Host != null)
                                {
                                    if (targetOrc.Host == null || sourceOrc.Host.Name != targetOrc.Host.Name)
                                    {
                                        SetDifferenceProperties(ref node, ref propertiesDiffCount);
                                    }
                                }
                            }

                            if (CompareParameters.OrchestrationCheckBindings)
                            {
                                if (AreListsDefferent(sourceObject.PortList, targetObject.PortList))
                                {
                                    SetDifferenceProperties(ref node, ref propertiesDiffCount);
                                }

                            }

                            break;
                    }

                }
            }

            foreach (TreeNode childNode in node.Nodes)
            {
                CompareRecursive(childNode, target, ref diffCount, checkPropertiesDiff, ref propertiesDiffCount);
            }

        }

        private bool IsFiltersEquals(string sourceFilter, string targetFilter)
        {

            XDocument sourceNode = null;
            XDocument targetNode = null;

            try
            {
                sourceNode = XDocument.Parse(sourceFilter.ToLower());
                var sourceStmtNode = sourceNode.Element("filter").Element("group").Elements("statement").OrderByDescending(s => (string)s.Attribute("property"));
                sourceNode = new XDocument(new XElement("group", sourceStmtNode));
            }
            catch
            {
                sourceNode = null;
            }

            try
            {
                targetNode = XDocument.Parse(targetFilter.ToLower());
                var targetStmtNode = targetNode.Element("filter").Element("group").Elements("statement").OrderByDescending(s => (string)s.Attribute("property"));
                targetNode = new XDocument(new XElement("group", targetStmtNode));
            }
            catch
            {
                targetNode = null;
            }

            if (sourceNode != null && targetNode != null)
            {
                return XNode.DeepEquals(sourceNode, targetNode);
            }
            else if (sourceNode == null && targetNode == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool AreListsDefferent(IList<string> sourceList, IList<string> targetList)
        {

            string sourceListJoin = string.Empty;
            string targetListJoin = string.Empty;

            foreach (string map in sourceList.OrderBy(e => e))
            {
                sourceListJoin = string.Concat(sourceListJoin, map, ";");
            }

            foreach (string map in targetList.OrderBy(e => e))
            {
                targetListJoin = string.Concat(targetListJoin, map, ";");
            }

            return (sourceListJoin != targetListJoin);

        }

        private void SetDifferenceProperties(ref TreeNode node, ref int propertiesCount)
        {
            node.BackColor = Color.Orange;
            propertiesCount++;
        }

        private void Invert_Click(object sender, EventArgs e)
        {
            string temp = txtSource.Text;
            txtSource.Text = txtTarget.Text;
            txtTarget.Text = temp;
        }

        private void txtSourceTarget_Leave(object sender, EventArgs e)
        {

            if (!txtSource.Items.Contains(txtSource.Text) && txtSource.Text != "")
            {
                txtSource.Items.Add(txtSource.Text);
            }

            if (!txtSource.Items.Contains(txtTarget.Text) && txtTarget.Text != "")
            {
                txtSource.Items.Add(txtTarget.Text);
            }

            if (!txtTarget.Items.Contains(txtSource.Text) && txtSource.Text != "")
            {
                txtTarget.Items.Add(txtSource.Text);
            }

            if (!txtTarget.Items.Contains(txtTarget.Text) && txtTarget.Text != "")
            {
                txtTarget.Items.Add(txtTarget.Text);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                string fileName = Path.Combine(Path.GetTempPath(), "Servers.bin");

                using (StreamWriter stream = new StreamWriter(fileName, false))
                {
                    foreach (var item in txtSource.Items)
                    {
                        stream.WriteLine(item.ToString());
                    }

                    stream.Close();
                }
            }
            catch
            {
            }

        }

        private void linkCompare_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (biztalkSource.Nodes.Count > 0)
            {
                SelectCompareParameters selectParameterForm = new SelectCompareParameters();

                if (selectParameterForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    try
                    {
                        Compare();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }

                }

            }
            else
            {
                MessageBox.Show("Collect BizTalk information.");
            }
        }

        private void linkViewCredentials_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (biztalkSource.Nodes.Count > 0)
            {
                ViewCredentials viewCredentials = new ViewCredentials();

                viewCredentials.biztalkSource = biztalkSource;
                viewCredentials.biztalkTarget = biztalkTarget;

                viewCredentials.ShowDialog();
            }
            else
            {
                MessageBox.Show("Collect BizTalk information.");
            }

        }

        private void biztalkTargetActions_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            biztalkTargetActions.Close();
            System.Windows.Forms.Application.DoEvents();

            try
            {

                if (biztalkTarget.Nodes.Count > 0)
                {

                    if (biztalkTarget.SelectedNode != null)
                    {

                        switch (e.ClickedItem.Name)
                        {

                            case "copyItemNameTargetActions":

                                Clipboard.SetText(biztalkTarget.SelectedNode.FullPath);

                                break;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Select a node.");
                    }

                }
                else
                {
                    MessageBox.Show("Collect BizTalk information.");
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void linkModifyBlock_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModifyBlock modifyBlock = new ModifyBlock();

            modifyBlock.connectionStringSource = txtSource.Text;
            modifyBlock.connectionStringTarget = txtTarget.Text;

            modifyBlock.ShowDialog();
        }

        private void biztalkSource_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ToolStripItemClickedEventArgs f = new ToolStripItemClickedEventArgs(viewDetailsToolStripMenuItem);

            biztalkSourceActions_ItemClicked(sender, f);
        }



    }


}
