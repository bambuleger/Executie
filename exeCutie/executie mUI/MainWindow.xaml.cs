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
        #region Startparameter
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
                //MessageBox.Show("Settungs loaded from: " + GlobalVariables.curFile);
                
            }
            else
            {
                GlobalVariables.curFile = GlobalVariables.path + "CB_Executie_Arms_default.xml";
                GlobalVariables.noPlayer = "noPlayer";
                //MessageBox.Show("Settings loaded from: " + GlobalVariables.curFile);

            }
        }
        #endregion


        //Globale Variablen setzen
        #region Global Variables
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
        public static string SW_HP_use;
        public static string DBTS_HP_use;
        public static string DB_HP_use;
        public static string DefSt_HP_use;
        public static string RC_HP_use;
        public static string ER_HP_use;
        public static string IS_HP_use;
        public static string HS_HP_use;
        public static string ST_HP_use;
            //offCD
        public static string SkullB_use;
        public static string Racial_use;
        public static string Avatar_use;
        public static string Reckless_use;
        public static string DPSPot_use;
        public static string SynSpr_use;
        public static string RunAway_use;
            //misc
        public static string AoE_use;
        public static string AoE_count;
        public static string Shoutmode_shout;
            //raid_events
        public static string Immerseus_HC_use;
        public static string Immerseus_HC_count;
        public static string Nazgrim_HC_use;
        #endregion

        //Werte von XML laden
        #region WerteLaden()
        public static void WerteLaden() 
        {
            //XML definieren
            XmlDocument cutieconfigxml = new XmlDocument();

            //XML laden
            cutieconfigxml.Load(GlobalVariables.curFile);

            //Werte Lesen XML
                // DefCD HP
            XmlNodeList ShieldwallHP = cutieconfigxml.GetElementsByTagName("Shieldwall_HP");
            XmlNodeList DieByTheSwordHP = cutieconfigxml.GetElementsByTagName("DieByTheSword_HP");
            XmlNodeList DemobannerHP = cutieconfigxml.GetElementsByTagName("Demobanner_HP");
            XmlNodeList DefStanceHP = cutieconfigxml.GetElementsByTagName("DefStance_HP");
            XmlNodeList RallyingCryHP = cutieconfigxml.GetElementsByTagName("RallyingCry_HP");
            XmlNodeList EnragedRegenerationHP = cutieconfigxml.GetElementsByTagName("EnragedRegeneration_HP");
            XmlNodeList InterveneHP = cutieconfigxml.GetElementsByTagName("Intervene_HP");
            XmlNodeList HealthstoneHP = cutieconfigxml.GetElementsByTagName("Healthstone_HP");
                //DefCD use
            XmlNodeList ShieldwallUse = cutieconfigxml.GetElementsByTagName("Shieldwall_Use");
            XmlNodeList DieByTheSwordUse = cutieconfigxml.GetElementsByTagName("DieByTheSword_Use");
            XmlNodeList DemobannerUse = cutieconfigxml.GetElementsByTagName("Demobanner_Use");
            XmlNodeList DefStanceUse = cutieconfigxml.GetElementsByTagName("DefStance_Use");
            XmlNodeList RallyingCryUse = cutieconfigxml.GetElementsByTagName("RallyingCry_Use");
            XmlNodeList EnragedRegenerationUse = cutieconfigxml.GetElementsByTagName("EnragedRegeneration_Use");
            XmlNodeList InterveneUse = cutieconfigxml.GetElementsByTagName("Intervene_Use");
            XmlNodeList HealthstoneUse = cutieconfigxml.GetElementsByTagName("Healthstone_Use");
            XmlNodeList ShatteringThrowUse = cutieconfigxml.GetElementsByTagName("ShatteringThrow_Use");
                //OffCD use
            XmlNodeList SkullbannerUse = cutieconfigxml.GetElementsByTagName("Skullbanner_use");
            XmlNodeList RacialUse = cutieconfigxml.GetElementsByTagName("Racial_use");
            XmlNodeList AvatarUse = cutieconfigxml.GetElementsByTagName("Avatar_use");
            XmlNodeList RecklessnessUse = cutieconfigxml.GetElementsByTagName("Recklessness_use");
            XmlNodeList DPSPotionUse = cutieconfigxml.GetElementsByTagName("DPSPotion_use");
            XmlNodeList SynapseSpringsUse = cutieconfigxml.GetElementsByTagName("SynapseSprings_use");
            XmlNodeList RunAwayLittleGirlUse = cutieconfigxml.GetElementsByTagName("RunAwayLittleGirl_use");
                //misc
            XmlNodeList AoEUse = cutieconfigxml.GetElementsByTagName("AoE_use");
            XmlNodeList AoECount = cutieconfigxml.GetElementsByTagName("AoE_count");
            XmlNodeList Shoutmode = cutieconfigxml.GetElementsByTagName("Shoutmode");
                //
            XmlNodeList ImmerseusHCUse = cutieconfigxml.GetElementsByTagName("Immerseus_HC_use");
            XmlNodeList ImmerseusHCCount = cutieconfigxml.GetElementsByTagName("Immerseus_HC_count");
            XmlNodeList NazgrimHCUse = cutieconfigxml.GetElementsByTagName("Nazgrim_HC");




            //Variablen belegen
                //DefCD HP Werte
            GlobalVariables.SW_HP = ShieldwallHP[0].InnerText;
            GlobalVariables.DBTS_HP = DieByTheSwordHP[0].InnerText;
            GlobalVariables.DB_HP = DemobannerHP[0].InnerText;
            GlobalVariables.DefStHP = DefStanceHP[0].InnerText;
            GlobalVariables.RC_HP = RallyingCryHP[0].InnerText;
            GlobalVariables.ER_HP = EnragedRegenerationHP[0].InnerText;
            GlobalVariables.IS_HP = InterveneHP[0].InnerText;
            GlobalVariables.HS_HP = HealthstoneHP[0].InnerText;
                //DefCD use werte
            GlobalVariables.SW_HP_use = ShieldwallUse[0].InnerText;
            GlobalVariables.DBTS_HP_use = DieByTheSwordUse[0].InnerText;
            GlobalVariables.DB_HP_use = DemobannerUse[0].InnerText;
            GlobalVariables.DefSt_HP_use = DefStanceUse[0].InnerText;
            GlobalVariables.RC_HP_use = RallyingCryUse[0].InnerText;
            GlobalVariables.ER_HP_use = EnragedRegenerationUse[0].InnerText;
            GlobalVariables.IS_HP_use = InterveneUse[0].InnerText;
            GlobalVariables.HS_HP_use = HealthstoneUse[0].InnerText;
            GlobalVariables.ST_HP_use = ShatteringThrowUse[0].InnerText;
                //OffCD use werte
            GlobalVariables.SkullB_use = SkullbannerUse[0].InnerText;
            GlobalVariables.Racial_use = RacialUse[0].InnerText;
            GlobalVariables.Avatar_use = AvatarUse[0].InnerText;
            GlobalVariables.Reckless_use = RecklessnessUse[0].InnerText;
            GlobalVariables.DPSPot_use = DPSPotionUse[0].InnerText;
            GlobalVariables.SynSpr_use = SynapseSpringsUse[0].InnerText;
            GlobalVariables.RunAway_use = RunAwayLittleGirlUse[0].InnerText;
                //misc
            GlobalVariables.AoE_use = AoEUse[0].InnerText;
            GlobalVariables.AoE_count = AoECount[0].InnerText;
            GlobalVariables.Shoutmode_shout = Shoutmode[0].InnerText;
                //raid_events
            GlobalVariables.Immerseus_HC_use = ImmerseusHCUse[0].InnerText;
            GlobalVariables.Immerseus_HC_count = ImmerseusHCCount[0].InnerText;
            GlobalVariables.Nazgrim_HC_use = NazgrimHCUse[0].InnerText;
        }
        #endregion

        //Werte in XML speichern
        #region WerteSpeichern()
        public static void WerteSpeichern()
        {
            //checken welcher spieler und standard.xml bei bedarf kopieren
            if (GlobalVariables.curFile == GlobalVariables.path + "CB_Executie_Arms_default.xml" && GlobalVariables.noPlayer == "noPlayer")
            {
                // für gaming use
                GlobalVariables.noPlayer = Microsoft.VisualBasic.Interaction.InputBox("Existing file will be overwritten!!!\nInsert a character name here:", "failure | not logged in", "charaktername", 0, 0);
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
                //DefCD HP Werte
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("Shieldwall_HP").Value = GlobalVariables.SW_HP;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("DieByTheSword_HP").Value = GlobalVariables.DBTS_HP;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("Demobanner_HP").Value = GlobalVariables.DB_HP;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("DefStance_HP").Value = GlobalVariables.DefStHP;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("RallyingCry_HP").Value = GlobalVariables.RC_HP;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("EnragedRegeneration_HP").Value = GlobalVariables.ER_HP;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("Intervene_HP").Value = GlobalVariables.IS_HP;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("Healthstone_HP").Value = GlobalVariables.HS_HP;
                //DefCD use Werte
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("Shieldwall_Use").Value = GlobalVariables.SW_HP_use;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("DieByTheSword_Use").Value = GlobalVariables.DBTS_HP_use;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("Demobanner_Use").Value = GlobalVariables.DB_HP_use;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("DefStance_Use").Value = GlobalVariables.DefSt_HP_use;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("RallyingCry_Use").Value = GlobalVariables.RC_HP_use;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("EnragedRegeneration_Use").Value = GlobalVariables.ER_HP_use;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("Intervene_Use").Value = GlobalVariables.IS_HP_use;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("Healthstone_Use").Value = GlobalVariables.HS_HP_use;
            cutieconfig.Element("ExecutieSettings").Element("DefCD").Element("ShatteringThrow_Use").Value = GlobalVariables.ST_HP_use;
                //OffCD use Werte
            cutieconfig.Element("ExecutieSettings").Element("OffCD").Element("Skullbanner_use").Value = GlobalVariables.SkullB_use;
            cutieconfig.Element("ExecutieSettings").Element("OffCD").Element("Racial_use").Value = GlobalVariables.Racial_use;
            cutieconfig.Element("ExecutieSettings").Element("OffCD").Element("Avatar_use").Value = GlobalVariables.Avatar_use;
            cutieconfig.Element("ExecutieSettings").Element("OffCD").Element("Recklessness_use").Value = GlobalVariables.Reckless_use;
            cutieconfig.Element("ExecutieSettings").Element("OffCD").Element("DPSPotion_use").Value = GlobalVariables.DPSPot_use;
            cutieconfig.Element("ExecutieSettings").Element("OffCD").Element("SynapseSprings_use").Value = GlobalVariables.SynSpr_use;
            cutieconfig.Element("ExecutieSettings").Element("OffCD").Element("RunAwayLittleGirl_use").Value = GlobalVariables.RunAway_use;
                //misc
            cutieconfig.Element("ExecutieSettings").Element("misc").Element("AoE_use").Value = GlobalVariables.AoE_use;
            cutieconfig.Element("ExecutieSettings").Element("misc").Element("AoE_count").Value = GlobalVariables.AoE_count;
            cutieconfig.Element("ExecutieSettings").Element("misc").Element("Shoutmode").Value = GlobalVariables.Shoutmode_shout;
                //raid_events
            cutieconfig.Element("ExecutieSettings").Element("raid_events").Element("Immerseus_HC_use").Value = GlobalVariables.Immerseus_HC_use;
            cutieconfig.Element("ExecutieSettings").Element("raid_events").Element("Immerseus_HC_count").Value = GlobalVariables.Immerseus_HC_count;
            cutieconfig.Element("ExecutieSettings").Element("raid_events").Element("Nazgrim_HC").Value = GlobalVariables.Nazgrim_HC_use;


            //Werte der HP von defCDs ausgeben
            //MessageBox.Show(GlobalVariables.SW_HP + " " + GlobalVariables.DBTS_HP + " " + GlobalVariables.DB_HP + " " + GlobalVariables.DefStHP + " " + GlobalVariables.RC_HP + " " + GlobalVariables.ER_HP + " " + GlobalVariables.IS_HP + " " + GlobalVariables.HS_HP);

            //XML speichern
            cutieconfig.Save(GlobalVariables.savefile);

            //MessageBox: gespeichert in: ...
            MessageBox.Show("saved to: " + GlobalVariables.savefile);
        }
        #endregion


    }
}