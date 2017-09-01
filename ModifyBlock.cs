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
using Microsys.EAI.BizTalkUtilities.Helper;

namespace Microsys.EAI.BizTalkUtilities
{
    public partial class ModifyBlock : Form
    {
        private const string DISPLAYMEMBER = "Name";
        private const string DISPLAYMEMBERORC = "FullName";

        public string connectionStringSource;
        public string connectionStringTarget;

        private enum Action
        {
            ModifySend = 0,
            ModifyReceiveLocation = 1,
            ModifyOrchestrationHost = 2,
            ModifySoapSendPortBindings = 3,
            ModifySoapReceiveLocationBindings = 4

        }

        BtsCatalogExplorer catalog;
        List<StandardBindingElement> standardBindingElement = ControlHelper.CreateStandardBindingElementList();

        public ModifyBlock()
        {
            InitializeComponent();
        }

        private void ddlSourceDestination_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ddlAction.SelectedIndex = -1;
            ddlAction.Enabled = true;
            lblAction.Enabled = true;
            lblApplication.Enabled = false;
            ddlApplication.DataSource = new BindingSource(null, null);
            gwObjList.DataSource = new BindingSource(null, null);
            ddlObjectNewHost.DataSource = new BindingSource(null, null);

            SetCatalogSettings();
        }

        private void ddlAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string applicationSelected = string.Empty;
                if (ddlApplication.SelectedIndex != -1)
                {
                    applicationSelected = ((Microsoft.BizTalk.ExplorerOM.Application)ddlApplication.SelectedItem).Name;
                }

                lblApplication.Enabled = false;
                ddlApplication.Enabled = false;
                btnRefresh.Enabled = false;
                chkObjectNewHost.Enabled = false;
                chkObjectNewHost.Checked = false;
                ddlObjectNewHost.Enabled = false;
                transportOptionsGroup.Enabled = false;
                ddlApplication.DataSource = new BindingSource(null, null);
                gwObjList.DataSource = new BindingSource(null, null);
                ddlObjectNewHost.DataSource = new BindingSource(null, null);
                wcfBindingElementGroup.Enabled = false;
                checkboxHeaderCheckUncheck(ref gwObjList, false);
                checkUncheckDatabindElement(wcfBindingElementGroup.Controls, false);
                checkUncheckDatabindElement(transportOptionsGroup.Controls, false);

                ddlApplication.DataSource = BizTalkHelper.GetApplicationList(ref catalog);
                ddlApplication.DisplayMember = DISPLAYMEMBER;

                if (applicationSelected != string.Empty)
                {
                    ddlApplication.SelectedIndex = ddlApplication.FindStringExact(applicationSelected);
                }

                switch (ddlAction.SelectedIndex)
                {
                    case (int)Action.ModifySend:
                        lblgwObjList.Text = "Available Send Ports:";
                        break;
                    case (int)Action.ModifySoapSendPortBindings:
                        lblgwObjList.Text = "Available Send Ports (Only Primary Transport):";
                        break;
                    case (int)Action.ModifyReceiveLocation:
                    case (int)Action.ModifySoapReceiveLocationBindings:
                        lblgwObjList.Text = "Available Receive Locations:";
                        break;
                    case (int)Action.ModifyOrchestrationHost:
                        lblgwObjList.Text = "Available Orchestrations:";
                        break;
                    default:
                        break;
                }

                if (ddlApplication.Items.Count > 0)
                {
                    ddlApplication.Enabled = true;
                    lblApplication.Enabled = true;
                    ddlApplication_SelectionChangeCommitted(null, null);
                    btnRefresh.Enabled = true;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ddlApplication_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                gwObjList.DataSource = new BindingSource(null, null);
                ddlObjectNewHost.DataSource = new BindingSource(null, null);
                gwObjList.AutoGenerateColumns = false;
                wcfBindingElementGroup.Enabled = false;
                chkObjectNewHost.Enabled = false;
                chkObjectNewHost.Checked = false;
                ddlObjectNewHost.Enabled = false;
                transportOptionsGroup.Enabled = false;
                checkboxHeaderCheckUncheck(ref gwObjList, false);

                string appName = ((Microsoft.BizTalk.ExplorerOM.Application)ddlApplication.SelectedItem).Name;

                switch (ddlAction.SelectedIndex)
                {
                    case (int)Action.ModifySend:
                        gwObjList.DataSource = BizTalkHelper.GetSendPortList(ref catalog, appName, null);
                        gwObjList.Columns["colObjectName"].DataPropertyName = DISPLAYMEMBER;

                        if (gwObjList.Rows.Count > 0)
                        {
                            ddlObjectNewHost.DataSource = BizTalkHelper.GetSendHandlerNameList(ref catalog);
                            ddlObjectNewHost.DisplayMember = DISPLAYMEMBER;
                            chkObjectNewHost.Enabled = true;
                            transportOptionsGroup.Enabled = true;
                            ddlRoutingFailedMessages.SelectedIndex = 0;
                        }
                        break;
                    case (int)Action.ModifyReceiveLocation:
                        gwObjList.DataSource = BizTalkHelper.GetReceiveLocationPortList(ref catalog, appName, null);
                        gwObjList.Columns["colObjectName"].DataPropertyName = DISPLAYMEMBER;

                        if (gwObjList.Rows.Count > 0)
                        {
                            ddlObjectNewHost.DataSource = BizTalkHelper.GetReceiveLocationHandlerNameList(ref catalog);
                            ddlObjectNewHost.DisplayMember = DISPLAYMEMBER;
                            chkObjectNewHost.Enabled = true;
                        }
                        break;
                    case (int)Action.ModifyOrchestrationHost:
                        gwObjList.DataSource = BizTalkHelper.GetOrchestrationList(ref catalog, appName);
                        gwObjList.Columns["colObjectName"].DataPropertyName = DISPLAYMEMBERORC;

                        if (gwObjList.Rows.Count > 0)
                        {
                            ddlObjectNewHost.DataSource = BizTalkHelper.GetOrchestrationHostNameList(ref catalog);
                            ddlObjectNewHost.DisplayMember = DISPLAYMEMBER;
                            chkObjectNewHost.Enabled = true;
                        }
                        break;
                    case (int)Action.ModifySoapReceiveLocationBindings:
                        gwObjList.DataSource = BizTalkHelper.GetReceiveLocationPortList(ref catalog, appName, Capabilities.SupportsSoap).ToList();
                        gwObjList.Columns["colObjectName"].DataPropertyName = DISPLAYMEMBER;

                        PopulateDefaultStandardBindingElementGroup();

                        if (gwObjList.Rows.Count > 0)
                        {
                            wcfBindingElementGroup.Enabled = true;
                        }

                        break;
                    case (int)Action.ModifySoapSendPortBindings:
                        gwObjList.DataSource = BizTalkHelper.GetSendPortList(ref catalog, appName, Capabilities.SupportsSoap);
                        gwObjList.Columns["colObjectName"].DataPropertyName = DISPLAYMEMBER;

                        PopulateDefaultStandardBindingElementGroup();

                        if (gwObjList.Rows.Count > 0)
                        {
                            wcfBindingElementGroup.Enabled = true;
                        }

                        break;
                    default:
                        break;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            string newHost = "";

            try
            {
                btnApply.Enabled = false;
                btnRefresh.Enabled = false;
                filterGroup.Enabled = false;
                wcfBindingElementGroup.Enabled = false;
                gwObjList.Enabled = false;

                var checkedRows = from DataGridViewRow r in gwObjList.Rows
                                  where Convert.ToBoolean(r.Cells[0].Value) == true
                                  select r;

                if (!(checkedRows.Count() > 0))
                {
                    throw new Exception("Select at least one object.");
                }

                switch (ddlAction.SelectedIndex)
                {
                    case (int)Action.ModifySend:
                    case (int)Action.ModifyReceiveLocation:
                    case (int)Action.ModifyOrchestrationHost:
                        newHost = ddlObjectNewHost.SelectedItem.ToString();
                        break;
                    case (int)Action.ModifySoapSendPortBindings:
                    case (int)Action.ModifySoapReceiveLocationBindings:
                        if (!txtStandardBindingSettingsAreValid())
                        {
                            throw new Exception("Please enter valid values for the Standard Bindings Element. ('HH:mm:ss' or 'Infinite')");
                        }

                        standardBindingElement.SetPropertyValues("closeTimeout", txtCloseTO.Text, chkCloseTO.Checked);
                        standardBindingElement.SetPropertyValues("openTimeout", txtOpenTO.Text, chkOpenTO.Checked);
                        standardBindingElement.SetPropertyValues("receiveTimeout", txtRcvTO.Text, chkRcvTO.Checked);
                        standardBindingElement.SetPropertyValues("sendTimeout", txtSndTO.Text, chkSndTO.Checked);
                        break;
                }

                System.Windows.Forms.Application.DoEvents();
                StringBuilder messages = new StringBuilder();
                string txtTemp = string.Empty;

                foreach (var row in checkedRows)
                {
                    switch (ddlAction.SelectedIndex)
                    {
                        case (int)Action.ModifySend:
                            if (!(chkObjectNewHost.Checked
                                || chkRetryCount.Checked
                                || chkRetryInterval.Checked
                                || chkRoutingFailedMessages.Checked))
                            {
                                throw new Exception("Select at least one configuration to apply.");
                            }

                            SendPort spt = row.DataBoundItem as SendPort;
                            if (chkObjectNewHost.Checked)
                            {
                                txtTemp = spt.SetSendPortHandler(newHost, ref catalog);
                                if (txtTemp != string.Empty)
                                    messages.AppendLine(txtTemp);
                            }
                            if (chkRetryCount.Checked)
                                spt.PrimaryTransport.RetryCount = int.Parse(txtRetryCount.Text);
                            if (chkRetryInterval.Checked)
                                spt.PrimaryTransport.RetryInterval = int.Parse(txtRetryInterval.Text);
                            if (chkRoutingFailedMessages.Checked)
                                spt.RouteFailedMessage = ddlRoutingFailedMessages.SelectedItem.ToString() == "Yes" ? true : false;
                            break;
                        case (int)Action.ModifyReceiveLocation:
                            if (!(chkObjectNewHost.Checked))
                            {
                                throw new Exception("Select at least one configuration to apply.");
                            }

                            ReceiveLocation rlc = row.DataBoundItem as ReceiveLocation;

                            txtTemp = rlc.SetReceiveLocationPortHandler(newHost, ref catalog);
                            if (txtTemp != string.Empty)
                                messages.AppendLine(txtTemp);
                            break;
                        case (int)Action.ModifyOrchestrationHost:
                            if (!(chkObjectNewHost.Checked))
                            {
                                throw new Exception("Select at least one configuration to apply.");
                            }

                            BtsOrchestration orc = row.DataBoundItem as BtsOrchestration;
                            orc.SetOrchestration(newHost, ref catalog);
                            break;
                        case (int)Action.ModifySoapReceiveLocationBindings:

                            if (!(chkCloseTO.Checked
                                || chkOpenTO.Checked
                                || chkRcvTO.Checked
                                || chkSndTO.Checked))
                            {
                                throw new Exception("Select at least one configuration to apply.");
                            }

                            ReceiveLocation rlc2 = row.DataBoundItem as ReceiveLocation;
                            rlc2.SetReceiveLocationPortTransportTypeData(ref catalog, standardBindingElement);
                            break;
                        case (int)Action.ModifySoapSendPortBindings:

                            if (!(chkCloseTO.Checked
                                || chkOpenTO.Checked
                                || chkRcvTO.Checked
                                || chkSndTO.Checked))
                            {
                                throw new Exception("Select at least one configuration to apply.");
                            }

                            SendPort snd = row.DataBoundItem as SendPort;
                            snd.SetSendPortTransportTypeData(ref catalog, standardBindingElement);
                            break;
                    }
                }

                catalog.SaveChanges();

                ddlApplication_SelectionChangeCommitted(ddlApplication, null);
                ddlObjectNewHost.SelectedIndex = ddlObjectNewHost.FindStringExact(newHost);

                checkboxHeaderCheckUncheck(ref gwObjList, false);
                checkUncheckDatabindElement(wcfBindingElementGroup.Controls, false);
                checkUncheckDatabindElement(transportOptionsGroup.Controls, false);

                if (messages.ToString() != string.Empty)
                    DetailsMessageBox.Show("New changes have been applied but for some objects not. See the details below: ", messages.ToString());
                else
                    MessageBox.Show("The requested changes have been applied.", "Operation Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnApply.Enabled = true;
                btnRefresh.Enabled = true;
                filterGroup.Enabled = true;
                gwObjList.Enabled = true;
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string applicationSelected = ((Microsoft.BizTalk.ExplorerOM.Application)ddlApplication.SelectedItem).Name;
                SetCatalogSettings();

                ddlAction_SelectedIndexChanged(null, null);
                ddlApplication.SelectedIndex = ddlApplication.FindStringExact(applicationSelected);
                ddlApplication_SelectionChangeCommitted(ddlApplication, null);

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetCatalogSettings()
        {
            try
            {
                catalog = new BtsCatalogExplorer();

                switch (ddlSourceDestination.SelectedIndex)
                {
                    case 0:
                        catalog.ConnectionString = connectionStringSource;
                        break;
                    case 1:
                        catalog.ConnectionString = connectionStringTarget;
                        break;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void gwObjList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                //Remove column if not necessary
                gwObjList.Columns["colAdapter"].Visible = ddlAction.SelectedIndex == (int)Action.ModifyOrchestrationHost ? false : true;

                string hostName, transportType;
                Host host;
                SendHandler sHand; 
                ReceiveHandler rHand;

                foreach (DataGridViewRow row in gwObjList.Rows)
                {
                    hostName = null;
                    transportType = null;
                    host = null;
                    sHand = null;
                    rHand = null;

                    switch (ddlAction.SelectedIndex)
                    {
                        case (int)Action.ModifySend: // Send Port
                        case (int)Action.ModifySoapSendPortBindings:
                            sHand = ((SendPort)row.DataBoundItem).PrimaryTransport.SendHandler;
                            hostName = sHand != null ? sHand.Name : string.Empty;
                            transportType = ((SendPort)row.DataBoundItem).PrimaryTransport.TransportType.Name;
                            break;
                        case (int)Action.ModifyReceiveLocation: // Receive Location
                        case (int)Action.ModifySoapReceiveLocationBindings:
                            rHand = ((ReceiveLocation)row.DataBoundItem).ReceiveHandler;
                            hostName = rHand != null ? rHand.Name : string.Empty;
                            transportType = ((ReceiveLocation)row.DataBoundItem).TransportType.Name;
                            break;
                        case (int)Action.ModifyOrchestrationHost: //Orchestration
                            host = ((BtsOrchestration)row.DataBoundItem).Host;
                            hostName = host != null ? host.Name : string.Empty;
                            break;
                    }
                    row.Cells["colHost"].Value = hostName;
                    row.Cells["colAdapter"].Value = transportType != null ? transportType : string.Empty;
                }

                if (gwObjList.Rows.Count > 0)
                    CreateCheckBoxSelectAll(ref gwObjList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PopulateDefaultStandardBindingElementGroup()
        {
            try
            {
                txtCloseTO.Text = standardBindingElement.GetPropertyValues("closeTimeout");
                txtOpenTO.Text = standardBindingElement.GetPropertyValues("openTimeout");
                txtRcvTO.Text = standardBindingElement.GetPropertyValues("receiveTimeout");
                txtSndTO.Text = standardBindingElement.GetPropertyValues("sendTimeout");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CreateCheckBoxSelectAll(ref DataGridView dgv)
        {
            try
            {
                if (!checkboxHeaderCheckIfAlreadyExist(dgv))
                {
                    int size = 14;
                    // add checkbox header
                    Rectangle rect = dgv.GetCellDisplayRectangle(0, -1, true);

                    rect.X = rect.Location.X + (rect.Width / 4) + 2;
                    rect.Y = rect.Location.Y + (rect.Height - size) / 2 + 1;

                    CheckBox checkboxHeader = new CheckBox();
                    checkboxHeader.Name = "checkboxHeader";
                    checkboxHeader.Size = new Size(size, size);
                    checkboxHeader.Location = rect.Location;
                    checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);

                    dgv.Controls.Add(checkboxHeader);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = ((CheckBox)sender).Parent as DataGridView;

                for (int i = 0; i < dgv.RowCount; i++)
                {
                    dgv[0, i].Value = ((CheckBox)dgv.Controls.Find("checkboxHeader", true)[0]).Checked;
                }
                dgv.EndEdit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void checkboxHeaderCheckUncheck(ref DataGridView dgv, bool value)
        {
            try
            {
                if (checkboxHeaderCheckIfAlreadyExist(dgv))
                    ((CheckBox)dgv.Controls.Find("checkboxHeader", true)[0]).Checked = value;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private bool checkboxHeaderCheckIfAlreadyExist(DataGridView dgv)
        {
            try
            {
                if (dgv.Controls.Find("checkboxHeader", true).Count() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void checkUncheckDatabindElement(Control.ControlCollection cc, bool value)
        {
            foreach (Control ctrl in cc)
            {
                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Checked = value;
                }
            }
        }

        private bool txtStandardBindingSettingsAreValid()
        {
            DateTime dt;
            string txtCompare = "Infinite";

            if (chkCloseTO.Checked)
            {
                if (!DateTime.TryParse(txtCloseTO.Text, out dt) && txtCloseTO.Text != txtCompare)
                {
                    return false;
                }
            }

            if (chkOpenTO.Checked)
            {
                if (!DateTime.TryParse(txtOpenTO.Text, out dt) && txtOpenTO.Text != txtCompare)
                {
                    return false;
                }
            }

            if (chkRcvTO.Checked)
            {
                if (!DateTime.TryParse(txtRcvTO.Text, out dt) && txtRcvTO.Text != txtCompare)
                {
                    return false;
                }
            }

            if (chkSndTO.Checked)
            {
                if (!DateTime.TryParse(txtSndTO.Text, out dt) && txtSndTO.Text != txtCompare)
                {
                    return false;
                }
            }

            return true;
        }

        private void chkCloseTO_CheckedChanged(object sender, EventArgs e)
        {
            txtCloseTO.Enabled = ((CheckBox)sender).Checked;
        }

        private void chkOpenTO_CheckedChanged(object sender, EventArgs e)
        {
            txtOpenTO.Enabled = ((CheckBox)sender).Checked;
        }

        private void chkRcvTO_CheckedChanged(object sender, EventArgs e)
        {
            txtRcvTO.Enabled = ((CheckBox)sender).Checked;
        }

        private void chkSndTO_CheckedChanged(object sender, EventArgs e)
        {
            txtSndTO.Enabled = ((CheckBox)sender).Checked;
        }

        private void chkObjectNewHost_CheckedChanged(object sender, EventArgs e)
        {
            ddlObjectNewHost.Enabled = ((CheckBox)sender).Checked;
        }

        private void chkRetryCount_CheckedChanged(object sender, EventArgs e)
        {
            txtRetryCount.Enabled = ((CheckBox)sender).Checked;
        }

        private void chkRetryInterval_CheckedChanged(object sender, EventArgs e)
        {
            txtRetryInterval.Enabled = ((CheckBox)sender).Checked;
        }

        private void chkRoutingFailedMessages_CheckedChanged(object sender, EventArgs e)
        {
            ddlRoutingFailedMessages.Enabled = ((CheckBox)sender).Checked;
        }

    }
}
