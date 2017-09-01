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
    internal partial class DetailsMessageBoxForm : Form
    {
        private const int COLLAPSEDHEIGHT = 173;
        private const int EXPANDEDHEIGHT = 300;
        public DetailsMessageBoxForm()
        {
            InitializeComponent();
        }

        public DetailsMessageBoxForm(string message, string details)
        {
            InitializeComponent();
            this.lblmessageText.Text = message;
            this.txtDetails.Text = details;
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {

            if (ActiveForm.Height == COLLAPSEDHEIGHT)
            {
                ActiveForm.Height = EXPANDEDHEIGHT;
            }
            else
            {
                ActiveForm.Height = COLLAPSEDHEIGHT;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public static class DetailsMessageBox
    {
        public static void Show(string message, string details)
        {
            // using construct ensures the resources are freed when form is closed
            using (var form = new DetailsMessageBoxForm(message, details))
            {
                form.ShowDialog();
            }
        }
    }
}
