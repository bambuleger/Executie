using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using exeCutie.Properties;

namespace exeCutie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDownRC_HP.Text = Properties.Settings.Default.RC_HP.ToString();
            numericUpDownDB_HP.Text = Properties.Settings.Default.DB_HP.ToString(); 
            numericUpDownSW_HP.Text = Properties.Settings.Default.SW_HP.ToString();
        }

        private void Form1_Closing(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default["RC_HP"] = numericUpDownRC_HP.Text;
            Settings.Default["DB_HP"] = numericUpDownDB_HP.Text;
            Settings.Default["SW_HP"] = numericUpDownSW_HP.Text;
            Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
