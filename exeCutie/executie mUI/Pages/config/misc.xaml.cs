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
    /// Interaction logic for misc.xaml
    /// </summary>
    public partial class misc : UserControl
    {
        public misc()
        {
            InitializeComponent();
            
            //Slider Value aus variablen setzen
            AoESlider.Value = Convert.ToDouble(GlobalVariables.AoE_count);
            
            //checkbox checked/unchecked aus variablen setzen
            AoEUse.IsChecked = Convert.ToBoolean(GlobalVariables.SW_HP_use);

            //Shoutmode aus variablen setzen
            if (GlobalVariables.Shoutmode_shout == "battleshout")
            {
                ShoutButton.IsChecked = true;
                ShoutButton.Content = "BattleShout";
            }
            else if (GlobalVariables.Shoutmode_shout == "commandingshout")
            {
                ShoutButton.IsChecked = false;
                ShoutButton.Content = "CommandingShout";
            }
         }

        //Button Save -> Werte Speichern
        public void Button_save(object sender, RoutedEventArgs e)
        {
            GlobalVariables.WerteSpeichern();
        }

        //Value Has Changed Funktionen
            //AoE Count Werte
        private void AoESlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GlobalVariables.AoE_count = AoESlider.Value.ToString("##0");
        }
        
        //use Werte
            //AoE_use
        private void AoEUse_Checked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.AoE_use = "true";
        }
        private void AoEUse_UnChecked(object sender, RoutedEventArgs e)
        {
            GlobalVariables.AoE_use = "false";
        }
            //Radiobutton
        //private void Checkbox_Checked(object sender, RoutedEventArgs e)
        //{
        //    CommandingShoutButton.IsChecked = false;
        //}
            //ToggleButton
        private void ShoutButton_Checked(object sender, RoutedEventArgs e)
        {
            ShoutButton.IsChecked = true;
            ShoutButton.Content = "BattleShout";
            GlobalVariables.Shoutmode_shout = "battleshout";
        }
        private void ShoutButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ShoutButton.IsChecked = false;
            ShoutButton.Content = "CommandingShout";
            GlobalVariables.Shoutmode_shout = "commandingshout";
        }

    }
}
