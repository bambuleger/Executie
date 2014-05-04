using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
// eigene namespaces
using System.IO;
using System.Xml;
using System.Data;


namespace exeCutie
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //// XML Load
            //XmlDocument cutieconfig = new XmlDocument();
            //cutieconfig.Load("exeCutie.xml");
            //XmlNodeList RallyingCryHP = cutieconfig.GetElementsByTagName("RallyingCry");

            //// String ersetzen
            //String dateiPfad = "D:\\ragnar\\WoW\\Coding\\Executie\\exeCutie\\exeCutie\\bin\\Debug\\Executie_Arms.cs";

            //StreamReader inputStreamReader = File.OpenText(dateiPfad);
            //String Inhalt = inputStreamReader.ReadToEnd();
            //inputStreamReader.Close();

            //String ersetzen = "// ToDo:";
            //String durch = RallyingCryHP[0].InnerText;

            //Inhalt = Inhalt.Replace(ersetzen, durch);

            //StreamWriter outputStreamWriter = File.CreateText(dateiPfad);
        }
    }
}
