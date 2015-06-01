using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace КУРСОВОЙ
{
    public static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        // public static int a;
        public static DB1 db1 = new DB1(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\КУРСОВОЙ_NEW.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        public static DB2 db2 = new DB2(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\КУРСОВОЙ_NEW.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        public static DB3 db3 = new DB3(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\КУРСОВОЙ_NEW.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        public static DB4 db4 = new DB4(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\КУРСОВОЙ_NEW.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        public static double cena = 0;
        public static double k;
        public static double s;
        public static string naim = "";
        public static int cena_pl;
        public static int razmer;
        public static int razmer_pl;
        public static int id_kl;
        public static int id_klient_tov;
        public static int id_tovara;
        public static string name;
        public static string fio_name;
        public static int id_tov;
        public static double kolichestvo;
        public static double new_kolichestvo;
        public static string mail = "";
        public static string FIO = "";
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Меню());
        }

    }
}