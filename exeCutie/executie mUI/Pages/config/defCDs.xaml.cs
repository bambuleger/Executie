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

            //Slider Value aus variablen setzen
            ShieldwallSlider.Value = Convert.ToDouble(GlobalVariables.SW_HP);
            DieByTheSwordSlider.Value = Convert.ToDouble(GlobalVariables.DBTS_HP);
            DemobannerSlider.Value = Convert.ToDouble(GlobalVariables.DB_HP);
            DefStanceSlider.Value = Convert.ToDouble(GlobalVariables.DefStHP);
            RallyingCrySlider.Value = Convert.ToDouble(GlobalVariables.RC_HP);
            EnragedRegenerationSlider.Value = Convert.ToDouble(GlobalVariables.ER_HP);
            InterveneSlider.Value = Convert.ToDouble(GlobalVariables.IS_HP);
            HealthstoneSlider.Value = Convert.ToDouble(GlobalVariables.HS_HP);
            //checkbox checked/unchecked aus variablen setzen
            ShieldwallUse.IsChecked = Convert.ToBoolean(GlobalVariables.SW_HP_use);
            DieByTheSwordUse.IsChecked = Convert.ToBoolean(GlobalVariables.DBTS_HP_use);
            DemobannerUse.IsChecked = Convert.ToBoolean(GlobalVariables.DB_HP_use);
            DefStanceUse.IsChecked = Convert.ToBoolean(GlobalVariables.DefSt_HP_use);
            RallyingCryUse.IsChecked = Convert.ToBoolean(GlobalVariables.RC_HP_use);
            EnragedRegenerationUse.IsChecked = Convert.ToBoolean(GlobalVariables.ER_HP_use);
            InterveneUse.IsChecked = Convert.ToBoolean(GlobalVariables.IS_HP_use);
            HealthstoneUse.IsChecked = Convert.ToBoolean(GlobalVariables.HS_HP_use);
            ShatteringThrowUse.IsChecked = Convert.ToBoolean(GlobalVariables.ST_HP_use);
        }
        
        //Button Save -> Werte Speichern
        public void Button_save(object sender, RoutedEventArgs e)
        {
            GlobalVariables.WerteSpeichern();
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
        }

        //Value Has Changed Funktionen
        #region HPWERTE    
            //HP Werte
        private void ShieldwallSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalVariables.SW_HP = ShieldwallSlider.Value.ToString("##0");
        }
        private void DieByTheSwordSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalVariables.DBTS_HP = DieByTheSwordSlider.Value.ToString("##0");
        }
        private void DemobannerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalVariables.DB_HP = DemobannerSlider.Value.ToString("##0");
        }
        private void DefStanceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalVariables.DefStHP = DefStanceSlider.Value.ToString("##0");
        }
        private void RallyingCrySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalVariables.RC_HP = RallyingCrySlider.Value.ToString("##0");
        }
        private void EnragedRegenerationSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalVariables.ER_HP = EnragedRegenerationSlider.Value.ToString("##0");
        }
        private void InterveneSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalVariables.IS_HP = InterveneSlider.Value.ToString("##0");
        }
        private void HealthstoneSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalVariables.HS_HP = HealthstoneSlider.Value.ToString("##0");
        }
        #endregion

        #region use werte
            //use Werte
        //SW_HP_use
        private void ShieldwallUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.SW_HP_use = "true";
        }
        private void ShieldwallUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.SW_HP_use = "false";
        }
            //DBTS_HP_use
        private void DieByTheSwordUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.DBTS_HP_use = "true";
        }
        private void DieByTheSwordUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.DBTS_HP_use = "false";
        }
            //DB_HP_use
        private void DemobannerUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.DB_HP_use = "true";
        }
        private void DemobannerUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.DB_HP_use = "false";
        }
            //DefSt_HP_use
        private void DefStUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.DefSt_HP_use = "true";
        }
        private void DefStUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.DefSt_HP_use = "false";
        }
            //RC_HP_use
        private void RallyingCryUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.RC_HP_use = "true";
        }
        private void RallyingCryUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.RC_HP_use = "false";
        }
            //ER_HP_use
        private void EnragedRegenerationUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.ER_HP_use = "true";
        }
        private void EnragedRegenerationUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.ER_HP_use = "false";
        }
            //IS_HP_use
        private void InterveneUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.IS_HP_use = "true";
        }
        private void InterveneUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.IS_HP_use = "false";
        }
            //HS_HP_use
        private void HealthstoneUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.HS_HP_use = "true";
        }
        private void HelathstoneUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.HS_HP_use = "false";
        }
            //ST_HP_use
        private void ShatteringThrowUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.ST_HP_use = "true";
        }
        private void ShatteringThrowUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.ST_HP_use = "false";
        }
        #endregion

    }
}