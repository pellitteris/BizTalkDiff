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
    public partial class SelectCompareParameters : Form
    {
        public SelectCompareParameters()
        {
            InitializeComponent();
        }

        private void compareButton_Click(object sender, EventArgs e)
        {
            CompareParameters.SendPortCheckAddress = checkSptAddress.Checked;
            CompareParameters.SendPortCheckAddressFileMask = checkSptAddressFileMask.Checked;
            CompareParameters.SendPortCheckFilter = checkSptFilter.Checked;
            CompareParameters.SendPortCheckHost = checkSptHost.Checked;
            CompareParameters.SendPortCheckPipeline = checkSptPipeline.Checked;
            CompareParameters.SendPortCheckMaps = checkSptMaps.Checked;

            CompareParameters.SendPortGroupCheckFilter = checkSptgFilter.Checked;

            CompareParameters.ReceivePortCheckEnableRouting = checkRptEnableRouting.Checked;
            CompareParameters.ReceivePortCheckMaps = checkRptMaps.Checked;

            CompareParameters.ReceiveLocationCheckAddress = checkRlcAddress.Checked;
            CompareParameters.ReceiveLocationCheckAddressFileMask = checkRlcAddressFileMask.Checked;
            CompareParameters.ReceiveLocationCheckPipeline = checkRlcPipeline.Checked;
            CompareParameters.ReceiveLocationCheckHost = checkRlcHost.Checked;

            CompareParameters.OrchestrationCheckHost = checkOrcHost.Checked;
            CompareParameters.OrchestrationCheckBindings = checkOrcBindings.Checked;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void SelectCompareParameters_Load(object sender, EventArgs e)
        {
            checkSptAddress.Checked = CompareParameters.SendPortCheckAddress;
            checkSptAddressFileMask.Checked = CompareParameters.SendPortCheckAddressFileMask;
            checkSptFilter.Checked = CompareParameters.SendPortCheckFilter;
            checkSptHost.Checked = CompareParameters.SendPortCheckHost;
            checkSptPipeline.Checked = CompareParameters.SendPortCheckPipeline;
            checkSptMaps.Checked = CompareParameters.SendPortCheckMaps;

            checkSptgFilter.Checked = CompareParameters.SendPortGroupCheckFilter;

            checkRptEnableRouting.Checked = CompareParameters.ReceivePortCheckEnableRouting;
            checkRptMaps.Checked = CompareParameters.ReceivePortCheckMaps;

            checkRlcAddress.Checked = CompareParameters.ReceiveLocationCheckAddress;
            checkRlcAddressFileMask.Checked = CompareParameters.ReceiveLocationCheckAddressFileMask;
            checkRlcPipeline.Checked = CompareParameters.ReceiveLocationCheckPipeline;
            checkRlcHost.Checked = CompareParameters.ReceiveLocationCheckHost;

            checkOrcHost.Checked = CompareParameters.OrchestrationCheckHost;
            checkOrcBindings.Checked = CompareParameters.OrchestrationCheckBindings;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox)
                {
                    foreach (Control checkBox in control.Controls)
                    {
                        (checkBox as CheckBox).Checked = true;
                    }
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox)
                {
                    foreach (Control checkBox in control.Controls)
                    {
                        (checkBox as CheckBox).Checked = false;
                    }
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
