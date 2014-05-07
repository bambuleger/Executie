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
            GlobalVariables.werteladen();
        }
    }

    class GlobalVariables
    {
        //Startparameter für PlayerSettings
        public static string[] PLAYER = Environment.GetCommandLineArgs();
        public static string curFile;                                           //= GlobalVariables.PLAYER[1] + ".xml";
        public static bool exists = (File.Exists(GlobalVariables.curFile));
        public static void settingsfilef()
        {
            if (GlobalVariables.PLAYER.Length >= 2)
            {
                GlobalVariables.curFile = "CB_Executie_Arms_" + GlobalVariables.PLAYER[1] + ".xml";
                MessageBox.Show("Settungs loaded from: " + GlobalVariables.curFile);
            }
            else
            {
                GlobalVariables.curFile = "CB_Executie_Arms_default.xml";
                MessageBox.Show("Settings loaded from: " + GlobalVariables.curFile);
            }
        }

        //Globale Variablen setzen
            //defCD
        public static string SW_HP;
        public static string DBTS_HP;
        public static string DB_HP;
        public static string DefStHP;
        public static string RC_HP;
        public static string ER_HP;
        public static string IS_HP;
        public static string HS_HP;
        
        //Werte laden
        public static void werteladen() 
        {
            //XML öffnen
            XmlDocument cutieconfigxml = new XmlDocument();
            cutieconfigxml.Load(curFile);

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


    }
}