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

namespace executie_mUI.Pages.executie
{
    /// <summary>
    /// Interaction logic for welcome.xaml
    /// </summary>
    public partial class welcome : UserControl
    {
        public welcome()
        {
            InitializeComponent();
        }
        public void Button_save(object sender, RoutedEventArgs e)
        {
            GlobalVariables.WerteSpeichern();
        }
        public void Button_load(object sender, RoutedEventArgs e)
        {
            GlobalVariables.WerteLaden();
        }
        public void Button_reset(object sender, RoutedEventArgs e)
        {
        }
    }
}
