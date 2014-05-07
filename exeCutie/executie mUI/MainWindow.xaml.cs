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

namespace executie_mUI
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {

        }
    }

    class GlobalVariables
    {
        public static string SW_HP_Global = "start";
        public static string[] PLAYER = Environment.GetCommandLineArgs();
        public static string curFile;                                           //= GlobalVariables.PLAYER[1] + ".xml";
        public static bool exists = (File.Exists(GlobalVariables.curFile));

        public static void settingsfilef()
        {
            if (GlobalVariables.PLAYER.Length >= 2)
            {
                MessageBox.Show(GlobalVariables.PLAYER[1] + ".xml");
                GlobalVariables.curFile = "CB_Executie_Arms_" + GlobalVariables.PLAYER[1] + ".xml";
            }
            else
            {
                MessageBox.Show("CB_Executie_Arms_default.xml");
                GlobalVariables.curFile = "CB_Executie_Arms_default.xml";
            }
        }
    }
}