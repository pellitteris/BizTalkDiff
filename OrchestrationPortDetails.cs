using Microsoft.BizTalk.ExplorerOM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsys.EAI.BizTalkUtilities
{
    public partial class OrchestrationPortDetails : Form
    {

        public BizTalkObject OrchestrationObject;

        public OrchestrationPortDetails(BizTalkObject orchestrationObject)
        {
            OrchestrationObject = orchestrationObject;

            InitializeComponent();
        }

        private void AddRow(DataTable details, string column1, string column2, string column3, string column4, string column5)
        {
            DataRow row = details.NewRow();

            row[0] = column1;
            row[1] = column2;
            row[2] = column3;
            row[3] = column4;
            row[4] = column5;
            details.Rows.Add(row);
        }

        private void OrchestrationPortDetails_Load(object sender, EventArgs e)
        {
            try
            {

                DataTable details = new DataTable();

                details.Columns.Add("Port");
                details.Columns.Add("Logical Name");
                details.Columns.Add("Phisical Name");
                details.Columns.Add("Port Type");
                details.Columns.Add("Two Way");

                BtsOrchestration orchestration = (BtsOrchestration)OrchestrationObject.NativeObject;

                foreach (OrchestrationPort port in orchestration.Ports)
                {

                    if (port.ReceivePort != null)
                        AddRow(details, "Receive Port", port.Name, port.ReceivePort.Name, port.PortType.FullName, port.ReceivePort.IsTwoWay.ToString());
                    else if (port.SendPort != null)
                        AddRow(details, "Send Port", port.Name, port.SendPort.Name, port.PortType.FullName, port.SendPort.IsTwoWay.ToString());
                    else if (port.SendPortGroup != null)
                        AddRow(details, "Send Port Group", port.Name, port.SendPortGroup.Name, port.PortType.FullName, "n.a.");
                    else
                        AddRow(details, "Unbound", port.Name, "Unbound", port.PortType.FullName, "n.a.");

                }

                detailGrid.DataSource = details;

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
