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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       private void обоиНаСтеныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Создать_заказ_обои sz_steny = new Создать_заказ_обои();
            sz_steny.ShowDialog();
        }
        
        private void плиткаНаПолToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Создать_заказ_плитка_на_пол sz_pol = new Создать_заказ_плитка_на_пол();
            sz_pol.ShowDialog();
        }

        private void изменитьБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Список клиентов")
            {
                label1.Text = ("id_клиента" + " | " + "ФИО" + " | " + "Почта");
                var c = Program.db1.Zapros(0);
                foreach (Клиенты kl in c)
                {
                    listBox1.Items.Add(kl);
                }
            }
            if (comboBox1.Text == "Список товаров")
            {
                label1.Text = ("id_товара" + " | " + "Наименование" + " | " + "Цена" + " | " + "Количество");
                var c = Program.db2.Zapros(0);
                foreach (Товары tov in c)
                {
                    listBox1.Items.Add(tov);
                }
            }
            if (comboBox1.Text == "Список проданных товаров")
            {
                label1.Text = ("id_проданные_товары" + " | " + "id_товара" + " | " + "id_продажи");
                var c = Program.db3.Zapros(0);
                foreach (Проданные_товары SpTovProd in c)
                {
                    listBox1.Items.Add(SpTovProd);
                }
            }
            if (comboBox1.Text == "Заказы")
            {
                label1.Text = ("id_продажи" + " | " + "id_клиента" + " | " + "Количество" + " | " + "Цена" + " | " + "Общая_Стоимость" + " | " + "Дата_продажи");
                var c = Program.db4.Zapros(0);
                foreach (Продажа prod in c)
                {
                    listBox1.Items.Add(prod);
                }
            }
        }

        

        

        
    }
}
