using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Microsys.EAI.BizTalkUtilities
{
    public partial class ViewAttribute : Form
    {

        public string Content;

        public ViewAttribute(string content)
        {
            Content = content;

            InitializeComponent();
        }

        private void ViewAttribute_Load(object sender, EventArgs e)
        {

            string path = Path.GetTempPath();
            string fileName;

            try
            {
                var doc = XDocument.Parse(Content);

                fileName = Path.Combine(path, "Property.xml");

                doc.Save(fileName);
            }   
            catch
            {
                fileName = Path.Combine(path, "Property.txt"); 

                File.WriteAllText(fileName, Content); 
            }
            
            AttributeDetails.Navigate(fileName); 

        }
    }
}
