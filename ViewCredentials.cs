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
using System.Xml;

namespace Microsys.EAI.BizTalkUtilities
{
    public partial class ViewCredentials : Form
    {

        public TreeView biztalkSource;
        public TreeView biztalkTarget;

        public ViewCredentials()
        {
            InitializeComponent();
        }

        private void AddRow(DataTable credentialsTable, string column1, string column2, string column3, string column4, string column5, string column6, string column7)
        {
            DataRow row = credentialsTable.NewRow();

            row[0] = column1;
            row[1] = column2;
            row[2] = column3;
            row[3] = column4;
            row[4] = column5;
            row[5] = column6;
            row[6] = column7;

            credentialsTable.Rows.Add(row);
        }

        private void ViewCredentials_Load(object sender, EventArgs e)
        {

            DataTable credentialsTable = new DataTable();

            credentialsTable.Columns.Add("System");
            credentialsTable.Columns.Add("Application");
            credentialsTable.Columns.Add("Object Type");
            credentialsTable.Columns.Add("Adapter");
            credentialsTable.Columns.Add("Object Name");
            credentialsTable.Columns.Add("User Name");
            credentialsTable.Columns.Add("Address");

            foreach (TreeNode node in biztalkSource.Nodes)
            {
                ViewCredentialsRecursive(node, credentialsTable, "Source");
            }

            foreach (TreeNode node in biztalkTarget.Nodes)
            {
                ViewCredentialsRecursive(node, credentialsTable, "Target");
            }

            CredentialsTree.DataSource = credentialsTable;

        }

        private void ViewCredentialsRecursive(TreeNode node, DataTable credentialsTable, string systemName)
        {

            BizTalkObject bizTalkObject = (BizTalkObject)node.Tag;

            switch (bizTalkObject.ObjectType)
            {

                case BizTalkObjectType.SendPort:

                    SendPort currentSpt = (SendPort)bizTalkObject.NativeObject;

                    if (currentSpt.PrimaryTransport != null && !string.IsNullOrEmpty(currentSpt.PrimaryTransport.TransportTypeData))
                    {

                        string userName = GetUserName(currentSpt.PrimaryTransport.TransportTypeData);

                        if (!string.IsNullOrEmpty(userName))
                        {
                            AddRow(credentialsTable, systemName, currentSpt.Application.Name, "Send Port (Primary Transport)", currentSpt.PrimaryTransport.TransportType.Name, currentSpt.Name, userName, currentSpt.PrimaryTransport.Address);
                        }

                    }

                    if (currentSpt.SecondaryTransport != null && !string.IsNullOrEmpty(currentSpt.SecondaryTransport.TransportTypeData))
                    {

                        string userName = GetUserName(currentSpt.SecondaryTransport.TransportTypeData);

                        if (!string.IsNullOrEmpty(userName))
                        {
                            AddRow(credentialsTable, systemName, currentSpt.Application.Name, "Send Port (Secondary Transport)", currentSpt.SecondaryTransport.TransportType.Name, currentSpt.Name, userName, currentSpt.PrimaryTransport.Address);
                        }

                    }

                    break;

                case BizTalkObjectType.ReceiveLocation:

                    ReceiveLocation currentRlc = (ReceiveLocation)bizTalkObject.NativeObject;

                    if (!string.IsNullOrEmpty(currentRlc.TransportTypeData))
                    {

                        string userName = GetUserName(currentRlc.TransportTypeData);

                        if (!string.IsNullOrEmpty(userName))
                        {
                            AddRow(credentialsTable, systemName, currentRlc.ReceivePort.Application.Name, "Receive Location", currentRlc.TransportType.Name, currentRlc.Name, userName, currentRlc.Address);
                        }

                    }

                    
                    break;
            }

            foreach (TreeNode childNode in node.Nodes)
            {
                ViewCredentialsRecursive(childNode, credentialsTable, systemName);
            }

        }

        private string GetUserName(string transportTypeData)
        {

            string returnValue = string.Empty;

            try
            {

                if (!transportTypeData.ToLower().Contains("user"))
                {
                    return returnValue;
                }

                XmlDocument transportTypeDataXml = new XmlDocument();
                transportTypeDataXml.LoadXml(transportTypeData.ToLower());

                XmlNode userNameNode = transportTypeDataXml.SelectSingleNode("/customprops/username");

                if (userNameNode != null)
                {
                    returnValue = userNameNode.InnerText;
                }
                else
                {

                    XmlNode adapterConfigNode = transportTypeDataXml.SelectSingleNode("/customprops/adapterconfig");
                    
                    XmlDocument adapterConfigXml = new XmlDocument();
                    adapterConfigXml.LoadXml(adapterConfigNode.InnerText.ToLower());

                    userNameNode = adapterConfigXml.SelectSingleNode("/config/username");

                    if (userNameNode != null)
                    {
                        returnValue = userNameNode.InnerText;
                    }
                    else
                    {
                        userNameNode = adapterConfigXml.SelectSingleNode("/config/user");

                        if (userNameNode != null)
                        {
                            returnValue = userNameNode.InnerText;
                        }
                    }
                }

            }
            catch {}

            return returnValue;
        }

    }
}
