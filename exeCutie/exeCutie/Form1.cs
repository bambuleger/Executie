using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// user namespace
using System.Xml;
using System.Xml.Linq;

namespace exeCutie
{
    public partial class Form1 : Form
    {
        // Vars definieren
        string RC_HP, SW_HP, DBTS_HP, DB_HP, ER_HP, DStHP_HP;
        bool DStuse_bool;

        //XML Laden
        //"D:\\ragnar\\WoW\\Coding\\Executie\\exeCutie\\exeCutie\\exeCutie.xml"


        public Form1()
        {
            InitializeComponent();
        }

        public void Main()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //XML öffnen
            XmlDocument cutieconfigxml = new XmlDocument();
            cutieconfigxml.Load("exeCutie.xml");
            
            //Werte lesen LINQ
            //RC_HP = cutieconfig.Root.Element("ExecutieSettings").Element("RallyingCry").Value;
            //SW_HP = cutieconfig.Root.Element("ExecutieSettings").Element("ShieldWall").Value;
            //DBTS_HP = cutieconfig.Root.Element("ExecutieSettings").Element("DieByTheSword").Value;
            //DB_HP = cutieconfig.Root.Element("ExecutieSettings").Element("DemoBanner").Value;
            //ER_HP = cutieconfig.Root.Element("ExecutieSettings").Element("EnragedRegeneration").Value;
            //DStuse_bool = Convert.ToBoolean(cutieconfig.Root.Element("ExecutieSettings").Element("DStuse").Value);
            //DStHP_HP = cutieconfig.Root.Element("ExecutieSettings").Element("DStHP").Value;

            //Werte Lesen XML
            XmlNodeList RallyingCryHP = cutieconfigxml.GetElementsByTagName("RallyingCry");
            XmlNodeList ShieldWallHP = cutieconfigxml.GetElementsByTagName("ShieldWall");
            XmlNodeList DieByTheSwordHP = cutieconfigxml.GetElementsByTagName("DieByTheSword");
            XmlNodeList DemoBannerHP = cutieconfigxml.GetElementsByTagName("DemoBanner");
            XmlNodeList EnragedRegenerationHP = cutieconfigxml.GetElementsByTagName("EnragedRegeneration");
            XmlNodeList DStuse = cutieconfigxml.GetElementsByTagName("DStuse");
            XmlNodeList DStHP = cutieconfigxml.GetElementsByTagName("DStHP");
            
            //Variablen belegen
            RC_HP = RallyingCryHP[0].InnerText;
            SW_HP = ShieldWallHP[0].InnerText;
            DBTS_HP = DieByTheSwordHP[0].InnerText;
            DB_HP = DemoBannerHP[0].InnerText;
            ER_HP = EnragedRegenerationHP[0].InnerText;
            DStuse_bool = Convert.ToBoolean(DStuse[0].InnerText);
            DStHP_HP = DStHP[0].InnerText;

            //Variablen in Felder schreiben
            numericUpDownRC_HP.Text = RallyingCryHP[0].InnerText;
            numericUpDownSW_HP.Text = ShieldWallHP[0].InnerText;
            numericUpDownDBTS_HP.Text = DieByTheSwordHP[0].InnerText;
            numericUpDownDB_HP.Text = DemoBannerHP[0].InnerText;
            numericUpDownER_HP.Text = EnragedRegenerationHP[0].InnerText;
            checkbox_DStuse.Checked = Convert.ToBoolean(DStuse[0].InnerText);
            numericUpDownDStuse_HP.Text = DStHP[0].InnerText;

        }

        private void Form1_Closing(object sender, EventArgs e)
        {
        }

        private void btnPoC_Click(object sender, EventArgs e)
        {
            MessageBox.Show(RC_HP);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Variablen aus Felder lesen
            RC_HP = numericUpDownRC_HP.Text;
            SW_HP = numericUpDownSW_HP.Text;
            DBTS_HP = numericUpDownDBTS_HP.Text;
            DB_HP = numericUpDownDB_HP.Text;
            ER_HP = numericUpDownER_HP.Text;
            DStuse_bool = checkbox_DStuse.Checked;
            DStHP_HP = numericUpDownDStuse_HP.Text;

            MessageBox.Show(RC_HP + " " + SW_HP + " " + DBTS_HP + " " + DB_HP + " " + ER_HP + " " + DStuse_bool + " " + DStHP_HP);

            XDocument cutieconfig = XDocument.Load("exeCutie.xml");
            cutieconfig.Descendants("RallyingCry").First().Value = RC_HP;
            cutieconfig.Descendants("ShieldWall").First().Value = SW_HP;
            cutieconfig.Descendants("DieByTheSword").First().Value = DBTS_HP;
            cutieconfig.Descendants("DemoBanner").First().Value = DB_HP;
            cutieconfig.Descendants("EnragedRegeneration").First().Value = ER_HP;
            cutieconfig.Descendants("DStuse").First().Value = Convert.ToString(DStuse_bool);
            cutieconfig.Descendants("DStHP").First().Value = DStHP_HP;
            cutieconfig.Save("exeCutie.xml");
        }
    }
}