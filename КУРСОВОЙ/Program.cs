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
        public static DB1 db1 = new DB1(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\КУРСОВОЙ.mdf;Integrated Security=True;User Instance=True");
        public static DB2 db2 = new DB2(@"Data Source=.\SQLEXPRESS;AttachDbFilename=c:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\КУРСОВОЙ.mdf;Integrated Security=True;User Instance=True");
        public static DB3 db3 = new DB3(@"Data Source=.\SQLEXPRESS;AttachDbFilename=c:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\КУРСОВОЙ.mdf;Integrated Security=True;User Instance=True");
        public static DB4 db4 = new DB4(@"Data Source=.\SQLEXPRESS;AttachDbFilename=c:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\КУРСОВОЙ.mdf;Integrated Security=True;User Instance=True");
        public static DB5 db5 = new DB5(@"Data Source=.\SQLEXPRESS;AttachDbFilename=c:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\КУРСОВОЙ.mdf;Integrated Security=True;User Instance=True");
        public static DB6 db6 = new DB6(@"Data Source=.\SQLEXPRESS;AttachDbFilename=c:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\КУРСОВОЙ.mdf;Integrated Security=True;User Instance=True");
        public static DB7 db7 = new DB7(@"Data Source=.\SQLEXPRESS;AttachDbFilename=c:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\КУРСОВОЙ.mdf;Integrated Security=True;User Instance=True");

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Меню());
        }

    }
}