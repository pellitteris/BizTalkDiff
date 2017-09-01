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

namespace Microsys.EAI.BizTalkUtilities
{
    public partial class Details : Form
    {

        public BizTalkObject SourceObject;
        public BizTalkObject TargetObject;

        public Details(BizTalkObject sourceObject, BizTalkObject targetObject)
        {
            TargetObject = targetObject;
            SourceObject = sourceObject;

            InitializeComponent();
        }

        private void AddRow(DataTable details, string column1, string column2, string column3)
        {
            DataRow row = details.NewRow();

            row[0] = column1;
            row[1] = column2;
            row[2] = column3;
            details.Rows.Add(row);
        }

        private void Details_Load(object sender, EventArgs e)
        {

            try
            {

                DataTable details = new DataTable();

                details.Columns.Add("Attribute");
                details.Columns.Add("Source");
                details.Columns.Add("Destination");

                DataColumn dc = new DataColumn("Different", typeof(bool), "IIf( Trim([Source]) = Trim([Destination]) Or [Destination] is null, false, true )");
                details.Columns.Add(dc);

                switch (SourceObject.ObjectType)
                {

                    case BizTalkObjectType.ReceivePort:

                        ReceivePort sourceRpt = (ReceivePort)SourceObject.NativeObject;
                        ReceivePort targetRpt = null;

                        if (TargetObject != null)
                        {
                            targetRpt = (ReceivePort)TargetObject.NativeObject;
                        }

                        this.Text = string.Format("Receive Port Details: {0}", sourceRpt.Name);

                        AddRow(details, "Name", sourceRpt.Name, (targetRpt != null ? targetRpt.Name : ""));
                        AddRow(details, "Authentication", sourceRpt.Authentication.ToString(), (targetRpt != null ? targetRpt.Authentication.ToString() : ""));
                        AddRow(details, "Custom Data", sourceRpt.CustomData, (targetRpt != null ? targetRpt.CustomData : ""));
                        AddRow(details, "Description", sourceRpt.Description, (targetRpt != null ? targetRpt.Description : ""));
                        AddRow(details, "Is Two Way", sourceRpt.IsTwoWay.ToString(), (targetRpt != null ? targetRpt.IsTwoWay.ToString() : ""));
                        AddRow(details, "Primary Receive Location", sourceRpt.PrimaryReceiveLocation.Name, (targetRpt != null ? targetRpt.PrimaryReceiveLocation.Name : ""));
                        AddRow(details, "Route Failed Message", sourceRpt.RouteFailedMessage.ToString(), (targetRpt != null ? targetRpt.RouteFailedMessage.ToString() : ""));
                        AddRow(details, "Send Pipeline", (sourceRpt.SendPipeline != null ? sourceRpt.SendPipeline.FullName : ""), (targetRpt != null && targetRpt.SendPipeline != null ? targetRpt.SendPipeline.FullName : ""));
                        AddRow(details, "Tracking", sourceRpt.Tracking.ToString(), (targetRpt != null ? targetRpt.Tracking.ToString() : ""));
                        AddRow(details, "Inbound Maps", JoinMapsArray(SourceObject.InboundTransformsList), (targetRpt != null ? JoinMapsArray(TargetObject.InboundTransformsList) : ""));
                        AddRow(details, "Outbound Maps", JoinMapsArray(SourceObject.OutboundTransformsList), (targetRpt != null ? JoinMapsArray(TargetObject.OutboundTransformsList) : ""));

                        break;

                    case BizTalkObjectType.ReceiveLocation:

                        ReceiveLocation sourceRlc = (ReceiveLocation)SourceObject.NativeObject;
                        ReceiveLocation targetRlc = null;

                        if (TargetObject != null)
                        {
                            targetRlc = (ReceiveLocation)TargetObject.NativeObject;
                        }

                        this.Text = string.Format("Receive Location Details: {0}", sourceRlc.Name);

                        AddRow(details, "Name", sourceRlc.Name, (targetRlc != null ? targetRlc.Name : ""));
                        AddRow(details, "Description", sourceRlc.Description, (targetRlc != null ? targetRlc.Description : ""));
                        AddRow(details, "Address", sourceRlc.Address, (targetRlc != null ? targetRlc.Address : ""));
                        AddRow(details, "Transport Type", sourceRlc.TransportType.Name, (targetRlc != null ? targetRlc.TransportType.Name : ""));
                        AddRow(details, "Transport Type Data", sourceRlc.TransportTypeData, (targetRlc != null ? targetRlc.TransportTypeData : ""));
                        AddRow(details, "Enable", sourceRlc.Enable.ToString(), (targetRlc != null ? targetRlc.Enable.ToString() : ""));
                        AddRow(details, "Is Primary", sourceRlc.IsPrimary.ToString(), (targetRlc != null ? targetRlc.IsPrimary.ToString() : ""));
                        AddRow(details, "Receive Handler", sourceRlc.ReceiveHandler.Name, (targetRlc != null ? targetRlc.ReceiveHandler.Name : ""));
                        AddRow(details, "Receive Pipeline", sourceRlc.ReceivePipeline.FullName, (targetRlc != null ? targetRlc.ReceivePipeline.FullName : ""));
                        AddRow(details, "Receive Pipeline Data", sourceRlc.ReceivePipelineData, (targetRlc != null ? targetRlc.ReceivePipelineData : ""));
                        AddRow(details, "Send Pipeline", (sourceRlc.SendPipeline != null ? sourceRlc.SendPipeline.FullName : ""), (targetRlc != null && targetRlc.SendPipeline != null ? targetRlc.SendPipeline.FullName : ""));
                        AddRow(details, "Send Pipeline Data", sourceRlc.SendPipelineData, (targetRlc != null ? targetRlc.SendPipelineData : ""));
                        AddRow(details, "Custom Data", sourceRlc.CustomData, (targetRlc != null ? targetRlc.CustomData : ""));
                        AddRow(details, "Public Address", sourceRlc.PublicAddress, (targetRlc != null ? targetRlc.PublicAddress : ""));
                        AddRow(details, "Start Date Enabled", sourceRlc.StartDateEnabled.ToString(), (targetRlc != null ? targetRlc.StartDateEnabled.ToString() : ""));
                        AddRow(details, "Star tDate", sourceRlc.StartDate.ToShortDateString(), (targetRlc != null ? targetRlc.StartDate.ToShortDateString() : ""));
                        AddRow(details, "End Date Enabled", sourceRlc.EndDateEnabled.ToString(), (targetRlc != null ? targetRlc.EndDateEnabled.ToString() : ""));
                        AddRow(details, "End Date", sourceRlc.EndDate.ToShortDateString(), (targetRlc != null ? targetRlc.EndDate.ToShortDateString() : ""));
                        AddRow(details, "Service Window Enabled", sourceRlc.ServiceWindowEnabled.ToString(), (targetRlc != null ? targetRlc.ServiceWindowEnabled.ToString() : ""));
                        AddRow(details, "From Time", sourceRlc.FromTime.ToShortTimeString(), (targetRlc != null ? targetRlc.FromTime.ToShortTimeString() : ""));
                        AddRow(details, "To Time", sourceRlc.ToTime.ToShortTimeString(), (targetRlc != null ? targetRlc.ToTime.ToShortTimeString() : ""));

                        break;

                    case BizTalkObjectType.SendPort:

                        SendPort sourceSpt = (SendPort)SourceObject.NativeObject;
                        SendPort targetSpt = null;

                        if (TargetObject != null)
                        {
                            targetSpt = (SendPort)TargetObject.NativeObject;
                        }

                        this.Text = string.Format("Send Port Details: {0}", sourceSpt.Name);

                        AddRow(details, "Name", sourceSpt.Name, (targetSpt != null ? targetSpt.Name : ""));
                        AddRow(details, "Description", sourceSpt.Description, (targetSpt != null ? targetSpt.Description : ""));
                        AddRow(details, "Filter", sourceSpt.Filter, (targetSpt != null ? targetSpt.Filter : ""));
                        AddRow(details, "Is Dynamic", sourceSpt.IsDynamic.ToString(), (targetSpt != null ? targetSpt.IsDynamic.ToString() : ""));
                        AddRow(details, "Is Two Way", sourceSpt.IsTwoWay.ToString(), (targetSpt != null ? targetSpt.IsTwoWay.ToString() : ""));
                        AddRow(details, "Ordered Delivery", sourceSpt.OrderedDelivery.ToString(), (targetSpt != null ? targetSpt.OrderedDelivery.ToString() : ""));
                        AddRow(details, "Primary Transport Address", (sourceSpt.PrimaryTransport != null ? sourceSpt.PrimaryTransport.Address : ""), (targetSpt != null && targetSpt.PrimaryTransport != null ? targetSpt.PrimaryTransport.Address : ""));
                        AddRow(details, "Primary Transport Type", (sourceSpt.PrimaryTransport != null && sourceSpt.PrimaryTransport.TransportType != null ? sourceSpt.PrimaryTransport.TransportType.Name : ""), (targetSpt != null && targetSpt.PrimaryTransport != null && targetSpt.PrimaryTransport.TransportType != null ? targetSpt.PrimaryTransport.TransportType.Name : ""));
                        AddRow(details, "Primary Transport Type Data", (sourceSpt.PrimaryTransport != null ? sourceSpt.PrimaryTransport.TransportTypeData : ""), (targetSpt != null && targetSpt.PrimaryTransport != null ? targetSpt.PrimaryTransport.TransportTypeData : ""));
                        AddRow(details, "Primary Transport Host", (sourceSpt.PrimaryTransport != null ? sourceSpt.PrimaryTransport.SendHandler.Name : ""), (targetSpt != null && targetSpt.PrimaryTransport != null ? targetSpt.PrimaryTransport.SendHandler.Name : ""));
                        AddRow(details, "Priority", sourceSpt.Priority.ToString(), (targetSpt != null ? targetSpt.Priority.ToString() : ""));
                        AddRow(details, "Send Pipeline", (sourceSpt.SendPipeline != null ? sourceSpt.SendPipeline.FullName : ""), (targetSpt != null && targetSpt.SendPipeline != null ? targetSpt.SendPipeline.FullName : ""));
                        AddRow(details, "Send Pipeline Data", sourceSpt.SendPipelineData, (targetSpt != null ? targetSpt.SendPipelineData : ""));
                        AddRow(details, "Receive Pipeline", (sourceSpt.ReceivePipeline != null ? sourceSpt.ReceivePipeline.FullName : ""), (targetSpt != null && targetSpt.ReceivePipeline != null ? targetSpt.ReceivePipeline.FullName : ""));
                        AddRow(details, "Receive Pipeline Data", sourceSpt.ReceivePipelineData, (targetSpt != null ? targetSpt.ReceivePipelineData : ""));
                        AddRow(details, "Route Failed Message", sourceSpt.RouteFailedMessage.ToString(), (targetSpt != null ? targetSpt.RouteFailedMessage.ToString() : ""));
                        AddRow(details, "Secondary Transport Address", (sourceSpt.SecondaryTransport != null ? sourceSpt.SecondaryTransport.Address : ""), (targetSpt != null && targetSpt.SecondaryTransport != null ? targetSpt.SecondaryTransport.Address : ""));
                        AddRow(details, "Secondary Transport Type", (sourceSpt.SecondaryTransport != null && sourceSpt.SecondaryTransport.TransportType != null ? sourceSpt.SecondaryTransport.TransportType.Name : ""), (targetSpt != null && targetSpt.SecondaryTransport != null && targetSpt.SecondaryTransport.TransportType != null ? targetSpt.SecondaryTransport.TransportType.Name : ""));
                        AddRow(details, "Secondary Transport Type Data", (sourceSpt.SecondaryTransport != null ? sourceSpt.SecondaryTransport.TransportTypeData : ""), (targetSpt != null && targetSpt.SecondaryTransport != null ? targetSpt.SecondaryTransport.TransportTypeData : ""));
                        AddRow(details, "Secondary Transport Host", (sourceSpt.SecondaryTransport != null && sourceSpt.SecondaryTransport.SendHandler != null ? sourceSpt.SecondaryTransport.SendHandler.Name : ""), (targetSpt != null && targetSpt.SecondaryTransport != null && targetSpt.SecondaryTransport.SendHandler != null ? targetSpt.SecondaryTransport.SendHandler.Name : ""));
                        AddRow(details, "Custom Data", sourceSpt.CustomData, (targetSpt != null ? targetSpt.CustomData : ""));
                        AddRow(details, "Status", sourceSpt.Status.ToString(), (targetSpt != null ? targetSpt.Status.ToString() : ""));
                        AddRow(details, "Stop Sending On Failure", sourceSpt.StopSendingOnFailure.ToString(), (targetSpt != null ? targetSpt.StopSendingOnFailure.ToString() : ""));
                        AddRow(details, "Tracking", sourceSpt.Tracking.ToString(), (targetSpt != null ? targetSpt.Tracking.ToString() : ""));
                        AddRow(details, "Inbound Maps", JoinMapsArray(SourceObject.InboundTransformsList), (targetSpt != null ? JoinMapsArray(TargetObject.InboundTransformsList) : ""));
                        AddRow(details, "Outbound Maps", JoinMapsArray(SourceObject.OutboundTransformsList), (targetSpt != null ? JoinMapsArray(TargetObject.OutboundTransformsList) : ""));

                        break;

                    case BizTalkObjectType.SendPortGroup:

                        SendPortGroup sourceSptg = (SendPortGroup)SourceObject.NativeObject;
                        SendPortGroup targetSptg = null;

                        if (TargetObject != null)
                        {
                            targetSptg = (SendPortGroup)TargetObject.NativeObject;
                        }

                        this.Text = string.Format("Send Port Group Details: {0}", sourceSptg.Name);

                        AddRow(details, "Name", sourceSptg.Name, (targetSptg != null ? targetSptg.Name : ""));
                        AddRow(details, "Filter", sourceSptg.Filter, (targetSptg != null ? targetSptg.Filter : ""));
                        AddRow(details, "Status", sourceSptg.Status.ToString(), (targetSptg != null ? targetSptg.Status.ToString() : ""));

                        string sourceSptgMember = string.Empty;

                        foreach (var sendPortMember in sourceSptg.SendPorts)
                        {
                            sourceSptgMember = sourceSptgMember + ((SendPort)sendPortMember).Name + "; \n\r";
                        }

                        string targetSptgMember = string.Empty;

                        if (targetSptg != null)
                        {
                            foreach (var sendPortMember in targetSptg.SendPorts)
                            {
                                targetSptgMember = targetSptgMember + ((SendPort)sendPortMember).Name + "; \n\r";
                            }
                        }

                        AddRow(details, "SendPorts", sourceSptgMember, (targetSptg != null ? targetSptgMember : ""));

                        break;

                    case BizTalkObjectType.Orchestration:

                        BtsOrchestration sourcePrc = (BtsOrchestration)SourceObject.NativeObject;
                        BtsOrchestration targetPrc = null;

                        if (TargetObject != null)
                        {
                            targetPrc = (BtsOrchestration)TargetObject.NativeObject;
                        }

                        this.Text = string.Format("Orchestration Details: {0}", sourcePrc.FullName);

                        AddRow(details, "Name", sourcePrc.FullName, (targetPrc != null ? targetPrc.FullName : ""));
                        AddRow(details, "Assembly", sourcePrc.AssemblyQualifiedName, (targetPrc != null ? targetPrc.AssemblyQualifiedName : ""));
                        AddRow(details, "Host", (sourcePrc.Host != null ? sourcePrc.Host.Name : ""), (targetPrc != null && targetPrc.Host != null ? targetPrc.Host.Name : ""));
                        AddRow(details, "Tracking", sourcePrc.Tracking.ToString(), (targetPrc != null ? targetPrc.Tracking.ToString() : ""));
                        AddRow(details, "Status", sourcePrc.Status.ToString(), (targetPrc != null ? targetPrc.Status.ToString() : ""));

                        string sourcePrcPort = string.Empty;
                        string targetPrcPort = string.Empty;
                        string portBinding = string.Empty;

                        foreach (OrchestrationPort port in sourcePrc.Ports)
                        {

                            if (port.ReceivePort != null)
                                portBinding = string.Format("{0} (Receive Port)", port.ReceivePort.Name);
                            else if (port.SendPort != null)
                                portBinding = string.Format("{0} (Send Port)", port.SendPort.Name);
                            else if (port.SendPortGroup != null)
                                portBinding = string.Format("{0} (Send Port Group)", port.SendPortGroup.Name);

                            sourcePrcPort = string.Concat(sourcePrcPort, port.Name, ": ", portBinding, " \n\r");
                        }

                        if (targetPrc != null)
                        {
                            foreach (OrchestrationPort port in targetPrc.Ports)
                            {

                                if (port.ReceivePort != null)
                                    portBinding = string.Format("{0} (Receive Port)", port.ReceivePort.Name);
                                else if (port.SendPort != null)
                                    portBinding = string.Format("{0} (Send Port)", port.SendPort.Name);
                                else if (port.SendPortGroup != null)
                                    portBinding = string.Format("{0} (Send Port Group)", port.SendPortGroup.Name);

                                targetPrcPort = string.Concat(targetPrcPort, port.Name, ": ", portBinding, " \n\r");
                            }
                        }

                        AddRow(details, "Port", sourcePrcPort, targetPrcPort);

                        break;

                    default:

                        MessageBox.Show("Feature not yet implemented for this object.");

                        this.Close();

                        break;
                }

                detailGrid.DataSource = details;

                try
                {
                    detailGrid.Columns[1].ToolTipText = "Double click to view attribute details";
                    detailGrid.Columns[2].ToolTipText = "Double click to view attribute details";
                }
                catch { }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void detailGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (SourceObject.ObjectType == BizTalkObjectType.Orchestration && detailGrid[0, e.RowIndex].Value.ToString().ToLower() == "port")
            {
                if (e.ColumnIndex < 2)
                {
                    OrchestrationPortDetails orchestrationPortDetails = new OrchestrationPortDetails(SourceObject);
                    orchestrationPortDetails.ShowDialog();

                }
                else
                {
                    OrchestrationPortDetails orchestrationPortDetails = new OrchestrationPortDetails(TargetObject);
                    orchestrationPortDetails.ShowDialog();
                }
            }
            else
            {
                ViewAttribute viewAttribute = new ViewAttribute(detailGrid[e.ColumnIndex, e.RowIndex].Value.ToString());
                viewAttribute.ShowDialog();
            }
        }

        private string JoinMapsArray(IList<string> maps)
        {

            string returnValue = string.Empty;

            foreach (string map in maps.OrderBy(e => e))
            {
                returnValue = string.Concat(returnValue, map, "; \n\r");
            }

            return returnValue;

        }

    }
}
