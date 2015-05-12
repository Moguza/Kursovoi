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
    public partial class Добавление_редактирование : Form
    {
        public Добавление_редактирование()
        {
            InitializeComponent();
        }
        public int typ;
        private void Добавление_редактирование_Load(object sender, EventArgs e)
        {
            if (typ == 0)
            {
                label2.Text = "ФИО";
                label3.Text = "Почта";
                label4.Text = "----------";
                label5.Text = "----------";
                label6.Text = "----------";
            }
            if (typ == 1)
            {
                label2.Text = "ФИО";
                label3.Text = "Почта";
                label4.Text = "----------";
                label5.Text = "----------";
                label6.Text = "----------";
            }
            if (typ == 2)
            {
                label2.Text = "Наименование";
                label3.Text = "Цена";
                label4.Text = "Количество";
                label5.Text = "----------";
                label6.Text = "----------";
            }
            if (typ == 3)
            {
                label2.Text = "id_товара";
                label3.Text = "id_покупки";
                label4.Text = "----------";
                label5.Text = "----------";
                label6.Text = "----------";
            }
            if (typ == 4)
            {
                label2.Text = "id_товара";
                label3.Text = "id_продажи";
                label4.Text = "----------";
                label5.Text = "----------";
                label6.Text = "----------";
            }
            if (typ == 5)
            {
                label2.Text = "Количество";
                label3.Text = "Цена";
                label4.Text = "Стоимость";
                label5.Text = "Дата_продажи";
                label6.Text = "id_клиента";
            }
            if (typ == 6)
            {
                label2.Text = "Количество";
                label3.Text = "Цена";
                label4.Text = "Стоимость";
                label5.Text = "Дата_продажи";
                label6.Text = "id_поставщика";
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form1 f1= new Form1();
            //f1.ShowDialog();
            if (typ == 0)
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
                Close();
                MessageBox.Show("Новый поставщик добавлен успешно!");
            }
            if (typ == 1)
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
                Program.db2.ADD(textBox2.Text, textBox3.Text);
                textBox2.Text = "";
                textBox3.Text = "";
                Close();
                MessageBox.Show("Новый клиент добавлен успешно!");
            }
            if (typ == 2)
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
                Program.db3.ADD(textBox2.Text, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                Close();
                MessageBox.Show("Новый товар добавлен!");
            }
            if (typ == 3)
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
                Program.db4.ADD(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
                textBox2.Text = "";
                textBox3.Text = "";
                Close();
                MessageBox.Show("В список товаров по покупкам добавлена новая запись!");
            }
            if (typ == 4)
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
                Program.db5.ADD(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
                textBox2.Text = "";
                textBox3.Text = "";
                Close();
                MessageBox.Show("В список товаров по продажам добавлена новая запись!");
            }
            if (typ == 5)
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
                Program.db6.ADD(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), (float)Convert.ToDouble(textBox4.Text), (float)Convert.ToDouble(textBox5.Text), Convert.ToDateTime(textBox6.Text));
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                Close();
                MessageBox.Show("В список продаж добавлена новая запись!");
            }
            if (typ == 6)
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
                Program.db7.ADD(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), (float)Convert.ToDouble(textBox4.Text), (float)Convert.ToDouble(textBox5.Text), Convert.ToDateTime(textBox6.Text));
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                Close();
                MessageBox.Show("В список покупок добавлена новая запись!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (typ == 0)
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
                string s1, s2;
                int id;
                s1 = textBox2.Text;
                s2 = textBox3.Text;
                id = Convert.ToInt32(textBox1.Text);
                Program.db1.Edit(id, s1, s2);
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("Вы изменили запись с id " + textBox1.Text + " в таблице поставщики");
                textBox1.Text = "";
                Close();
            }
            if (typ == 1)
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
                string s1, s2;
                int id;
                s1 = textBox2.Text;
                s2 = textBox3.Text;
                id = Convert.ToInt32(textBox1.Text);
                Program.db2.Edit(id, s1, s2);
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("Вы изменили запись с id " + textBox1.Text + " в таблице клиенты");
                textBox1.Text = "";
                Close();
            }
            if (typ == 2)
            {
                try
                {
                    if ((textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == ""))
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
                string s1;
                float s2;
                int s3, id;
                s1 = textBox2.Text;
                s2 = Convert.ToInt32(textBox2.Text);
                s3 = Convert.ToInt32(textBox3.Text);
                id = Convert.ToInt32(textBox1.Text);
                Program.db3.Edit(id, s1, s2, s3);
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                MessageBox.Show("Вы изменили запись с id " + textBox1.Text + " в таблице товары");
                textBox1.Text = "";
                Close();
            }
            if (typ == 3)
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
                Program.db4.Edit(id, s1, s2);
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("Вы изменили запись с id " + textBox1.Text + " в таблице Список товаров по покупкам");
                textBox1.Text = "";
                Close();
            }
            if (typ == 4)
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
                Program.db5.Edit(id, s1, s2);
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("Вы изменили запись с id " + textBox1.Text + " в таблице Список товаров по продажам");
                textBox1.Text = "";
                Close();
            }
            if (typ == 5)
            {
                try
                {
                    if ((textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == ""))
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
                float s3, s4;
                DateTimeOffset s5;
                s1 = Convert.ToInt32(textBox2.Text);
                s2 = Convert.ToInt32(textBox3.Text);
                s3 = (float)Convert.ToDouble(textBox4.Text);
                s4 = (float)Convert.ToDouble(textBox5.Text);
                s5 = Convert.ToDateTime(textBox6.Text);
                id = Convert.ToInt32(textBox1.Text);
                Program.db7.Edit(id, s1, s2, s3, s4, s5);
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                MessageBox.Show("Вы изменили запись с id " + textBox1.Text + " в таблице Продажа");
                textBox1.Text = "";
                Close();
            }
            if (typ == 6)
            {
                try
                {
                    if ((textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == ""))
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
                float s3, s4;
                DateTimeOffset s5;
                s1 = Convert.ToInt32(textBox2.Text);
                s2 = Convert.ToInt32(textBox3.Text);
                s3 = (float)Convert.ToDouble(textBox4.Text);
                s4 = (float)Convert.ToDouble(textBox5.Text);
                s5 = Convert.ToDateTime(textBox6.Text);
                id = Convert.ToInt32(textBox1.Text);
                Program.db7.Edit(id, s1, s2, s3, s4, s5);
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                MessageBox.Show("Вы изменили запись с id " + textBox1.Text + " в таблице Покупка");
                textBox1.Text = "";
                Close();
            }
        }

    }
}
