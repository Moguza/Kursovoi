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
                foreach (Tovary tov in c)
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


        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                try
                {
                    if (textBox7.Text == "")
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
                MessageBox.Show("Вы удалили запись с id " + textBox7.Text + " в таблице поставщики");
                textBox7.Text = "";
                Vyvod();
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                try
                {
                    if ((textBox2.Text == "") || (textBox3.Text == ""))
                    {
                        MessageBox.Show("Часть полей не заполнено");
                        return;
                    }
                }
                catch { }
                Program.db1.ADD(textBox2.Text, textBox3.Text);
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("Новый клиент добавлен успешно!");
                Vyvod();
            }
            if (radioButton2.Checked == true)
            {
                try
                {
                    if ((textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == ""))
                    {
                        MessageBox.Show("Часть полей не заполнено");
                        return;
                    }
                }
                catch { }
                Program.db2.ADD(textBox2.Text, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                MessageBox.Show("Новый товар добавлен!");
                Vyvod();
            }
            if (radioButton3.Checked == true)
            {
                try
                {
                    if ((textBox2.Text == "") || (textBox3.Text == ""))
                    {
                        MessageBox.Show("Часть полей не заполнено");
                        return;
                    }
                }
                catch { }
                Program.db3.ADD(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("В список проданных товаров добавлена новая запись!");
                Vyvod();
            }
            if (radioButton4.Checked == true)
            {
                try
                {
                    if ((textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == ""))
                    {
                        MessageBox.Show("Часть полей не заполнено");
                        return;
                    }
                }
                catch { }
                Program.db4.ADD(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), (float)Convert.ToDouble(textBox4.Text), (float)Convert.ToDouble(textBox5.Text), Convert.ToDateTime(textBox6.Text));
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                MessageBox.Show("В список продаж добавлена новая запись!");
                Vyvod();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                try
                {
                    if ((textBox2.Text == "") || (textBox3.Text == ""))
                    {
                        MessageBox.Show("Часть полей не заполнено");
                        return;
                    }
                    if (textBox7.Text == "")
                    {
                        MessageBox.Show("Вы не указали ID");
                        return;
                    }
                }
                catch { }
                string s1, s2;
                int id;
                s1 = textBox2.Text;
                s2 = textBox3.Text;
                id = Convert.ToInt32(textBox7.Text);
                Program.db1.Edit(id, s1, s2);
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("Вы изменили запись с id " + textBox7.Text + " в таблице клиенты");
                textBox7.Text = "";
                Vyvod();
            }
            if (radioButton2.Checked == true)
            {
                try
                {
                    if ((textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == ""))
                    {
                        MessageBox.Show("Часть полей не заполнено");
                        return;
                    }
                    if (textBox7.Text == "")
                    {
                        MessageBox.Show("Вы не указали ID");
                        return;
                    }
                }
                catch { }
                string s1;
                float s2;
                int s3, id;
                s1 = textBox2.Text;
                s2 = Convert.ToInt32(textBox2.Text);
                s3 = Convert.ToInt32(textBox3.Text);
                id = Convert.ToInt32(textBox7.Text);
             Program.db2.Edit(id, s1, s2, s3);
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                MessageBox.Show("Вы изменили запись с id " + textBox7.Text + " в таблице товары");
                textBox7.Text = "";
                Vyvod();
            }
            if (radioButton3.Checked == true)
            {
                try
                {
                    if ((textBox2.Text == "") || (textBox3.Text == ""))
                    {
                        MessageBox.Show("Часть полей не заполнено");
                        return;
                    }
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Вы не указали ID");
                        return;
                    }
                }
                catch { }
                int s1, s2, id;
                s1 = Convert.ToInt32(textBox2.Text);
                s2 = Convert.ToInt32(textBox3.Text);
                id = Convert.ToInt32(textBox1.Text);
                Program.db3.Edit(id, s1, s2);
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("Вы изменили запись с id " + textBox7.Text + " в таблице Список товаров по продажам");
                textBox7.Text = "";
                Vyvod();
            }
            if (radioButton4.Checked == true)
            {
                try
                {
                    if ((textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == ""))
                    {
                        MessageBox.Show("Часть полей не заполнено");
                        return;
                    }
                    if (textBox7.Text == "")
                    {
                        MessageBox.Show("Вы не указали ID");
                        return;
                    }
                }
                catch { }
                int s1, s2, id;
                float s3, s4;
                DateTimeOffset s5;
                s1 = Convert.ToInt32(textBox2.Text);
                s2 = Convert.ToInt32(textBox3.Text);
                s3 = (float)Convert.ToDouble(textBox4.Text);
                s4 = (float)Convert.ToDouble(textBox5.Text);
                s5 = Convert.ToDateTime(textBox6.Text);
                id = Convert.ToInt32(textBox7.Text);
                Program.db4.Edit(id, s1, s2, s3, s4, s5);
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                MessageBox.Show("Вы изменили запись с id " + textBox7.Text + " в таблице Продажа");
                textBox7.Text = "";
                Vyvod();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "ФИО";
            label4.Text = "Почта";
            label5.Text = "----------";
            label6.Text = "----------";
            label7.Text = "----------";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "Наименование";
            label4.Text = "Цена";
            label5.Text = "Количество";
            label6.Text = "----------";
            label7.Text = "----------";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "id_товара";
            label4.Text = "id_продажи";
            label5.Text = "----------";
            label6.Text = "----------";
            label7.Text = "----------";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "id_клиента";
            label4.Text = "Количество";
            label5.Text = "Цена";
            label6.Text = "Стоимость";
            label7.Text = "Дата_продажи";
        }


        


    }
}
