using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;


//Hab mal probiert ohne eingeloggt zu sein zu speichern.. das popup kommt, ich geb nen namen ein, drück ok, danach wieder "reagiert nich mehr".. is das normal dass das noch nich geht? ka was du unten in der werte speichern methode genau machst.. um das problem zu fixen, musst du einfach immer wenn du nen pfad zu irgendeiner datei angibst "Combats\\CB_Executie\\FILENAME" benutzen

namespace executie_mUI
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            GlobalVariables.settingsfilef();
            GlobalVariables.WerteLaden();
        }
    }

    class GlobalVariables
    {
        //Startparameter für PlayerSettings
        public static string[] PLAYER = Environment.GetCommandLineArgs();
        public static string curFile;                                           //= GlobalVariables.PLAYER[1] + ".xml";
        public static bool exists = (File.Exists(GlobalVariables.curFile));
        public static string savefile;
        public static string noPlayer = "";
        public static string path = "Combats\\CB_Executie\\";
        public static void settingsfilef()
        {
            if (GlobalVariables.PLAYER.Length >= 2)
            {
                GlobalVariables.curFile = GlobalVariables.path + "CB_Executie_Arms_" + GlobalVariables.PLAYER[1] + ".xml";
                GlobalVariables.charname = GlobalVariables.PLAYER[1];
                MessageBox.Show("Settungs loaded from: " + GlobalVariables.curFile);
                
            }
            else
            {
                GlobalVariables.curFile = GlobalVariables.path + "CB_Executie_Arms_default.xml";
                GlobalVariables.noPlayer = "noPlayer";
                MessageBox.Show("Settings loaded from: " + GlobalVariables.curFile);

            }
        }

        //Globale Variablen setzen
            //charname
        public static string charname;
            //defCD
        public static string SW_HP;
        public static string DBTS_HP;
        public static string DB_HP;
        public static string DefStHP;
        public static string RC_HP;
        public static string ER_HP;
        public static string IS_HP;
        public static string HS_HP;
        
        //Werte von XML laden
        public static void WerteLaden() 
        {
            //XML definieren
            XmlDocument cutieconfigxml = new XmlDocument();

            //XML laden
            cutieconfigxml.Load(GlobalVariables.curFile);

            //Werte Lesen XML
            XmlNodeList ShieldwallHP = cutieconfigxml.GetElementsByTagName("Shieldwall_HP");
            XmlNodeList DieByTheSwordHP = cutieconfigxml.GetElementsByTagName("DieByTheSword_HP");
            XmlNodeList DemobannerHP = cutieconfigxml.GetElementsByTagName("Demobanner_HP");
            XmlNodeList DefStanceHP = cutieconfigxml.GetElementsByTagName("DefStance_HP");
            XmlNodeList RallyingCryHP = cutieconfigxml.GetElementsByTagName("RallyingCry_HP");
            XmlNodeList EnragedRegenerationHP = cutieconfigxml.GetElementsByTagName("EnragedRegeneration_HP");
            XmlNodeList InterveneHP = cutieconfigxml.GetElementsByTagName("Intervene_HP");
            XmlNodeList HealthstoneHP = cutieconfigxml.GetElementsByTagName("Healtstone_HP");

            //Variablen belegen
            GlobalVariables.SW_HP = ShieldwallHP[0].InnerText;
            GlobalVariables.DBTS_HP = DieByTheSwordHP[0].InnerText;
            GlobalVariables.DB_HP = DemobannerHP[0].InnerText;
            GlobalVariables.DefStHP = DefStanceHP[0].InnerText;
            GlobalVariables.RC_HP = RallyingCryHP[0].InnerText;
            GlobalVariables.ER_HP = EnragedRegenerationHP[0].InnerText;
            GlobalVariables.IS_HP = InterveneHP[0].InnerText;
            GlobalVariables.HS_HP = HealthstoneHP[0].InnerText;
        }

        //Werte in XML speichern
        public static void WerteSpeichern()
        {
            //checken welcher spieler und standard.xml bei bedarf kopieren
            if (GlobalVariables.curFile == GlobalVariables.path + "CB_Executie_Arms_default.xml" && GlobalVariables.noPlayer == "noPlayer")
            {
                // für gaming use
                GlobalVariables.noPlayer = Microsoft.VisualBasic.Interaction.InputBox("Existing file will be overwritten!!!\nInsert a charakter name here:", "failure | not logged in", "charaktername", 0, 0);
                File.Delete(GlobalVariables.path + "CB_Executie_Arms_" + noPlayer + ".xml");
                File.Copy(GlobalVariables.path + "CB_Executie_Arms_default.xml", GlobalVariables.path + "CB_Executie_Arms_" + noPlayer + ".xml");
                GlobalVariables.savefile =GlobalVariables.path + "CB_Executie_Arms_" + noPlayer + ".xml";
                
                ////für standard use
                //GlobalVariables.savefile = GlobalVariables.curFile
            }
            else if (GlobalVariables.curFile != GlobalVariables.path + "CB_Executie_Arms_default.xml")
            {
                GlobalVariables.savefile = GlobalVariables.curFile;
            }

            //XML laden
            XDocument cutieconfig = XDocument.Load(GlobalVariables.savefile);

            //XML Elemente schreiben
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("Shieldwall_HP").Value = GlobalVariables.SW_HP;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("DieByTheSword_HP").Value = GlobalVariables.DBTS_HP;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("Demobanner_HP").Value = GlobalVariables.DB_HP;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("DefStance_HP").Value = GlobalVariables.DefStHP;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("RallyingCry_HP").Value = GlobalVariables.RC_HP;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("EnragedRegeneration_HP").Value = GlobalVariables.ER_HP;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("Intervene_HP").Value = GlobalVariables.IS_HP;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("Healtstone_HP").Value = GlobalVariables.HS_HP;

            //Werte der HP von defCDs ausgeben
            //MessageBox.Show(GlobalVariables.SW_HP + " " + GlobalVariables.DBTS_HP + " " + GlobalVariables.DB_HP + " " + GlobalVariables.DefStHP + " " + GlobalVariables.RC_HP + " " + GlobalVariables.ER_HP + " " + GlobalVariables.IS_HP + " " + GlobalVariables.HS_HP);

            //XML speichern
            cutieconfig.Save(GlobalVariables.savefile);

            //MessageBox: gespeichert in: ...
            MessageBox.Show("saved to: " + GlobalVariables.path + GlobalVariables.savefile);
        }


    }
}