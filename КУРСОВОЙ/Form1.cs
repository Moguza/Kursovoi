using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Linq.Mapping;
using System.Data.Linq;


namespace КУРСОВОЙ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Vyvod()
        {
            if (radioButton1.Checked == true)
            {
                label1.Text = ("id_клиента" + " | " + "ФИО" + " | " + "Почта");
                var c = Program.db1.Zapros(0);
                foreach (Клиенты kl in c)
                {
                    listBox1.Items.Add(kl);
                }
            }
            if (radioButton2.Checked == true)
            {
                label1.Text = ("id_товара" + " | " + "Наименование" + " | " + "Цена" + " | " + "Количество");
                var c = Program.db2.Zapros(0);
                foreach (Товары tov in c)
                {
                    listBox1.Items.Add(tov);
                }
            }
            if (radioButton3.Checked == true)
            {
                label1.Text = ("id_проданные_товары" + " | " + "id_товара" + " | " + "id_продажи");
                var c = Program.db3.Zapros(0);
                foreach (Проданные_товары SpTovProd in c)
                {
                    listBox1.Items.Add(SpTovProd);
                }
            }
            if (radioButton4.Checked == true)
            {
                label1.Text = ("id_продажи" + " | " + "id_клиента" + " | " + "Количество" + " | " + "Цена" + " | " + "Общая_Стоимость" + " | " + "Дата_продажи");
                var c = Program.db4.Zapros(0);
                foreach (Продажа prod in c)
                {
                    listBox1.Items.Add(prod);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                listBox1.Items.Clear();
                Vyvod();
                //Клиенты kl = new Клиенты();
                //kl.Show();
                //Close();
            }
            if (radioButton2.Checked == true)
            {
                listBox1.Items.Clear();
                Vyvod();
            }
            if (radioButton3.Checked == true)
            {
                listBox1.Items.Clear();
                Vyvod();
            }
            if (radioButton4.Checked == true)
            {
                listBox1.Items.Clear();
                Vyvod();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Добавление_редактирование f2 = new Добавление_редактирование();
            //   f2.typ = 0;
            if (radioButton1.Checked == true)
            {
                f2.typ = 0;
            }
            if (radioButton2.Checked == true)
            {
                f2.typ = 1;
            }
            if (radioButton3.Checked == true)
            {
                f2.typ = 2;
            }
            if (radioButton4.Checked == true)
            {
                f2.typ = 3;
            }
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                try
                {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Введите ID");
                        return;
                    }
                }
                catch { }
                listBox1.Items.Clear();
                int r;
                r = Convert.ToInt32(textBox1.Text);
                Program.db1.Delete(r);
                MessageBox.Show("Вы удалили запись с id " + textBox1.Text + " в таблице поставщики");
                textBox1.Text = "";
                Vyvod();
            }
        }
    }
}
