using System;
using System.Collections.Generic;
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
using executie_mUI;

namespace executie_mUI.Pages.config
{
    /// <summary>
    /// Interaction logic for defCDs.xaml
    /// </summary>
    public partial class defCDs : UserControl
    {
        public defCDs()
        {
            InitializeComponent();
            ShieldwallSlider.Value = Convert.ToDouble(GlobalVariables.SW_HP);
            DieByTheSwordSlider.Value = Convert.ToDouble(GlobalVariables.DBTS_HP);
            DemobannerSlider.Value = Convert.ToDouble(GlobalVariables.DB_HP);
            DefStanceSlider.Value = Convert.ToDouble(GlobalVariables.DefStHP);
            RallyingCrySlider.Value = Convert.ToDouble(GlobalVariables.RC_HP);
            EnragedRegenerationSlider.Value = Convert.ToDouble(GlobalVariables.ER_HP);
            InterveneSlider.Value = Convert.ToDouble(GlobalVariables.IS_HP);
            HealthstoneSlider.Value = Convert.ToDouble(GlobalVariables.HS_HP);
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            ////Variablen aus Felder lesen

            //SW_HP = ShieldwallSlider.Value
            //DBTS_HP = DieByTheSwordSlider.Value
            //DB_HP = DemobannerSlider.Value
            //DSt_HP= DefStanceSlider.Value
            //RC_HP = RallyingCrySlider.Value
            //ER_HP = EnragedRegenerationSlider.Value
            //IS_HP = InterveneSlider.Value
            //HS_HP = HealthstoneSlider.Value
            
            //MessageBox.Show(SW_HP + " " + DBTS_HP + " " + DB_HP + " " + DSt_HP + " " + RC_HP + " " + ER_HP + " " + IS_HP + " " + HS_HP);

            //MessageBox.Show(GlobalVariables.SW_HP_Global);
            //GlobalVariables.SW_HP_Global = "bearbeitet";
            //MessageBox.Show(GlobalVariables.SW_HP_Global);


            ////XML laden
            //XDocument cutieconfig = XDocument.Load("Combats\\exeCutie.xml");
            ////XML Elemente schreiben
            //cutieconfig.Element("ExecutieSettings").Element("General").Element("RallyingCry").Value = RC_HP;
            //cutieconfig.Element("ExecutieSettings").Element("General").Element("ShieldWall").Value = SW_HP;
            //cutieconfig.Element("ExecutieSettings").Element("General").Element("DieByTheSword").Value = DBTS_HP;
            //cutieconfig.Element("ExecutieSettings").Element("General").Element("DemoBanner").Value = DB_HP;
            //cutieconfig.Element("ExecutieSettings").Element("General").Element("EnragedRegeneration").Value = ER_HP;
            //cutieconfig.Element("ExecutieSettings").Element("General").Element("DStuse").Value = Convert.ToString(DStuse_bool);
            //cutieconfig.Element("ExecutieSettings").Element("General").Element("DStHP").Value = DStHP_HP;
            ////XML speichern
            //cutieconfig.Save("Combats\\exeCutie.xml");
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {

        }
    }
}