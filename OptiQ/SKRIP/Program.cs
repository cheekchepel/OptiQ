using OptiQ.kassa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptiQ
{
    static class Program
    {
        public static KASA KASA;

        public static main main;
        public static ShowMessage msg;
        public static add ad;
     
        public static login log;

        public static tovar tov;

        public static kategory kotek;

        public static addtovar addprd;

        public static Zakup zakup;
        public static fastaddprovid fstpr;
        public static Otlojka ooo;


        public static Oplata oplati;

        public static revizia revix;

        public static Vdolg dlg;
        public static Sales ssssss;

        public static Vesa vesika;



        private static Mutex m_instance;
        private const string m_appName = "NameOfMyApp";

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
           



            bool tryCreateNewApp;
            m_instance = new Mutex(true, m_appName,
                    out tryCreateNewApp);
            if (tryCreateNewApp)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new main());
                return;
            }
            else {

              
                MessageBox.Show("Приложение уже запущено");

            }



        }







    }
}
