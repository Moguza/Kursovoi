using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace КУРСОВОЙ
{
    public partial class Создать_заказ_плитка_на_пол : Form
    {
        public Создать_заказ_плитка_на_пол()
        {
            InitializeComponent();
        }

        private void Создать_заказ_плитка_на_пол_Load(object sender, EventArgs e)
        {
            label4.Text = ("id_товара" + " | " + "Наименование" + " | " + "Цена" + " | " + "Количество");
            var c = Program.db2.Zapros(0);
            foreach (Tovary tov in c)
            {
                listBox1.Items.Add(tov);
            }
        }
    }
}
