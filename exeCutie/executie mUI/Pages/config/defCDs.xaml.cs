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
        //Button Save -> Werte Speichern
        public void Button_save(object sender, RoutedEventArgs e)
        {
            GlobalVariables.WerteSpeichern();
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
        }
        
        //Value Has Changed Funktionen
        private void ShieldwallSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalVariables.SW_HP = Convert.ToString(ShieldwallSlider.Value);
        }
        private void DieByTheSwordSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalVariables.DBTS_HP = Convert.ToString(DieByTheSwordSlider.Value);
        }
        private void DemobannerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalVariables.DB_HP = Convert.ToString(DemobannerSlider.Value);
        }
        private void DefStanceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalVariables.DefStHP = Convert.ToString(DefStanceSlider.Value);
        }
        private void RallyingCrySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalVariables.RC_HP = Convert.ToString(RallyingCrySlider.Value);
        }
        private void EnragedRegenerationSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalVariables.ER_HP = Convert.ToString(EnragedRegenerationSlider.Value);
        }
        private void InterveneSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalVariables.IS_HP = Convert.ToString(InterveneSlider.Value);
        }
        private void HealthstoneSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalVariables.HS_HP = Convert.ToString(HealthstoneSlider.Value);
        }
    }
}