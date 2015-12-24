using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace mosaic
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new Form1();
            Application.Run(MainForm);
        }
        static public Form1 MainForm;
    }
}
