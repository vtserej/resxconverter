using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var xml = textBox1.Text;

            string finalText = "";

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);

            XmlNode rootNode = doc.ChildNodes[1];

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.Attributes["name"] == null || node.ChildNodes.Count == 0)
                {
                    continue;
                }

                foreach (XmlNode nod in node.ChildNodes)
                {
                    if (nod.Name == "value")
                    {

                        finalText += "'" + node.Attributes["name"].InnerText + "'" + " : " + "'" + nod.InnerText + "'" + "," + Environment.NewLine;    
                    }
                }

            }

            textBox2.Text = finalText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox2.Text);
        }
    }
}
