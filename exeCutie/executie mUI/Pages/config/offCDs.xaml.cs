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

namespace executie_mUI.Pages.config
{
    /// <summary>
    /// Interaction logic for offCDs.xaml
    /// </summary>
    public partial class offCDs : UserControl
    {
        public offCDs()
        {
            InitializeComponent();
            //checkbox checked/unchecked aus variablen setzen
            SkullbannerUse.IsChecked = Convert.ToBoolean(GlobalVariables.SkullB_use);
            RacialUse.IsChecked = Convert.ToBoolean(GlobalVariables.Racial_use);
            AvatarUse.IsChecked = Convert.ToBoolean(GlobalVariables.Avatar_use);
            RecklessnessUse.IsChecked = Convert.ToBoolean(GlobalVariables.Reckless_use);
            DPSPotionUse.IsChecked = Convert.ToBoolean(GlobalVariables.DPSPot_use);
            SynapseSpringsUse.IsChecked = Convert.ToBoolean(GlobalVariables.SynSpr_use);
            RunAwayLittleGirlUse.IsChecked = Convert.ToBoolean(GlobalVariables.RunAway_use);
        }
        //Button Save -> Werte Speichern

        public void Button_save(object sender, RoutedEventArgs e)
        {
            GlobalVariables.WerteSpeichern();
        }

        #region use werte
        //use Werte
            //SkullB_use
        private void SkullbannerUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.SkullB_use = "true";
        }
        private void SkullbannerUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.SkullB_use = "false";
        }
            //Racial_use
        private void RacialUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.Racial_use = "true";
        }
        private void RacialUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.Racial_use = "false";
        }
            //Avatar_use
        private void AvatarUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.Avatar_use = "true";
        }
        private void AvatarUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.Avatar_use = "false";
        }
            //Reckless_use
        private void RecklessnessUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.Reckless_use = "true";
        }
        private void RecklessnessUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.Reckless_use = "false";
        }
            //DPSPot_use
        private void DPSPotionUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.DPSPot_use = "true";
        }
        private void DPSPotionUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.DPSPot_use = "false";
        }
            //SynSpr_use
        private void SynapseSpringsUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.SynSpr_use = "true";
        }
        private void SynapseSpringsUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.SynSpr_use = "false";
        }
            //RunAway_use
        private void RunAwayLittleGirlUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.RunAway_use = "true";
        }
        private void RunAwayLittleGirlUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.RunAway_use = "false";
        }
        #endregion
    }
}
