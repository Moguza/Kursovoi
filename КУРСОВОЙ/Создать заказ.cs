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
    public partial class Создать_заказ_обои : Form
    {
        public Создать_заказ_обои()
        {
            InitializeComponent();
        }
        public int a;
        private void button1_Click(object sender, EventArgs e)
        {
             //if ((radioButton1.Checked == false) && (radioButton2.Checked == false) && (radioButton3.Checked == false) && (radioButton4.Checked == false))
             //   {
             //       MessageBox.Show("Ошибка! Выберите тип обоев");
             //   }
                if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == ""))
                {
                    MessageBox.Show("Ошибка! Вы не задали размеры комнаты");
                }
                //if (comboBox1.Text == "")
                //{
                //    MessageBox.Show("Ошибка! Вы не выбрали тип плитки");
                //}
                if ((textBox1.Text != "") && (textBox2.Text != "") && ((textBox3.Text != "")))
                {
                    Form1 f1 = new Form1();
                    f1.ShowDialog();
                } 
          a = Convert.ToInt32(textBox1.Text);
        }

        private void Создать_заказ_обои_Load(object sender, EventArgs e)
        {
            label6.Text = ("id_товара" + " | " + "Наименование" + " | " + "Цена" + " | " + "Количество");
            var c = Program.db2.Zapros(0);
            foreach (Товары tov in c)
            {
                listBox1.Items.Add(tov);
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
