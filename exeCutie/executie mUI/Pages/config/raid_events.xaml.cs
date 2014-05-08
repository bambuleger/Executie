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
    /// Interaction logic for raid_events.xaml
    /// </summary>
    public partial class raid_events : UserControl
    {
        public raid_events()
        {
            InitializeComponent();

            ImmerseusHCUse.IsChecked = Convert.ToBoolean(GlobalVariables.Immerseus_HC_use);
            ImmerseusHCSlider.Value = Convert.ToDouble(GlobalVariables.Immerseus_HC_count);
            NazgrimHCUse.IsChecked = Convert.ToBoolean(GlobalVariables.Nazgrim_HC_use);
        }

        //Button Save -> Werte Speichern
        public void Button_save(object sender, RoutedEventArgs e)
        {
            GlobalVariables.WerteSpeichern();
        }

        //Value Has Changed Funktionen
        #region WERTE
            //HP Werte
        private void ImmerseusHCSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalVariables.Immerseus_HC_count = Convert.ToString(ImmerseusHCSlider.Value);
        }
        //use Werte
            //SW_HP_use
        private void ImmerseusHCUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.Immerseus_HC_use = "true";
        }
        private void ImmerseusHCUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.Immerseus_HC_use = "false";
        }
            //SW_HP_use
        private void NazgrimHCUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.Nazgrim_HC_use = "true";
        }
        private void NazgrimHCUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.Nazgrim_HC_use = "false";
        }
        #endregion

    }
}
