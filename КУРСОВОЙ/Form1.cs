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

        public void Vyvod() //МЕТОД ВЫВОД
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
                label1.Text = ("id_товара" + " | " + "Наименование" + " | " + "Размер" + " | " + "Цена" + " | " + "Количество");
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
                label1.Text = ("id_продажи" + " | " + "id_клиента" + " | " + "Количество" + " | " + "Цена" + " | " + "Общая_Стоимость" + " | " + "Дата_продажи" + " | " + "id_товара");
                var c = Program.db4.Zapros(0);
                foreach (Продажа prod in c)
                {
                    listBox1.Items.Add(prod);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //УДАЛЕНИЕ
        {
            if (radioButton1.Checked == true)
            {
                var client = Program.db1.Клиенты.FirstOrDefault(c => c.ФИО == textBox1.Text);
                if (client == null)
                {
                    MessageBox.Show("Клиента с таким ФИО нет");
                    return;
                }

                var prpodajs = Program.db4.Продажа.Where(p => p.id_клиента == client.id_клиента);

                foreach(var p in prpodajs)
                {
                    var prodTovar = Program.db3.Проданные_товары.Where(pt => pt.id_продажи == p.id_продажи);
                    Program.db3.Проданные_товары.DeleteAllOnSubmit(prodTovar);
                    Program.db3.SubmitChanges();
                }

                Program.db4.Продажа.DeleteAllOnSubmit(prpodajs);
                Program.db4.SubmitChanges();

                Program.db1.Клиенты.DeleteOnSubmit(client);
                Program.db1.SubmitChanges();
                listBox1.Items.Clear();
                Vyvod();
                MessageBox.Show("Удаден клиент " + textBox1.Text);
                return;
            }
            if (radioButton2.Checked == true)
            {
                var tovar = Program.db2.Товар.FirstOrDefault(c => c.Наименование == textBox1.Text);
                if (tovar == null)
                {
                    MessageBox.Show("Товара с таким наименованием нет");
                    return;
                }

                var prpodajs = Program.db4.Продажа.Where(p => p.id_товара == tovar.id_товара);

                foreach (var p in prpodajs)
                {
                    var prodTovar = Program.db3.Проданные_товары.Where(pt => pt.id_продажи == p.id_продажи);
                    Program.db3.Проданные_товары.DeleteAllOnSubmit(prodTovar);
                    Program.db3.SubmitChanges();
                }

                Program.db4.Продажа.DeleteAllOnSubmit(prpodajs);
                Program.db4.SubmitChanges();

                Program.db2.Товар.DeleteOnSubmit(tovar);
                Program.db2.SubmitChanges();

                listBox1.Items.Clear();
                Vyvod();

                MessageBox.Show("Удаден товар " + textBox1.Text);
                return;
            }

        }


        private void button5_Click(object sender, EventArgs e)//ДОБАВЛЕНИЕ
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
                listBox1.Items.Clear();
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
                    if ((textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == ""))
                    {
                        MessageBox.Show("Часть полей не заполнено");
                        return;
                    }
                }
                catch { }
                listBox1.Items.Clear();
                Program.db2.ADD(textBox2.Text, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
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
                listBox1.Items.Clear();
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
                    if ((textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == "") || (textBox8.Text == ""))
                    {
                        MessageBox.Show("Часть полей не заполнено");
                        return;
                    }
                }
                catch { }
                listBox1.Items.Clear();
                Program.db4.ADD(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), (float)Convert.ToDouble(textBox4.Text), (float)Convert.ToDouble(textBox5.Text), Convert.ToDateTime(textBox6.Text), Convert.ToInt32(textBox7.Text));
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox8.Text = "";
                MessageBox.Show("В список продаж добавлена новая запись!");
                Vyvod();
            }
        }

        private void button4_Click(object sender, EventArgs e)//ИЗМЕНЕИЕ ПО АЙДИ
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
                listBox1.Items.Clear();
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
                    if ((textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == ""))
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
                listBox1.Items.Clear();
                string s1;
                float s2, s3;
                int s4, id;
                s1 = textBox2.Text;
                s2 = Convert.ToInt32(textBox3.Text);
                s3 = Convert.ToInt32(textBox4.Text);
                s4 = Convert.ToInt32(textBox5.Text);
                id = Convert.ToInt32(textBox7.Text);
                Program.db2.Edit(id, s1, s2, s3, s4);
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
                listBox1.Items.Clear();
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
                listBox1.Items.Clear();
                int s1, s2, s6, id;
                float s3, s4;
                DateTimeOffset s5;
                s1 = Convert.ToInt32(textBox2.Text);
                s2 = Convert.ToInt32(textBox3.Text);
                s3 = (float)Convert.ToDouble(textBox4.Text);
                s4 = (float)Convert.ToDouble(textBox5.Text);
                s5 = Convert.ToDateTime(textBox6.Text);
                s6 = Convert.ToInt32(textBox7.Text);
                id = Convert.ToInt32(textBox7.Text);
                Program.db4.Edit(id, s1, s2, s3, s4, s5, s6);
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                MessageBox.Show("Вы изменили запись с id " + textBox7.Text + " в таблице Продажа");
                textBox7.Text = "";
                Vyvod();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "ФИО";
            label4.Text = "Почта";
            label5.Text = "----------";
            label6.Text = "----------";
            label7.Text = "----------";
            label9.Text = "----------";
            listBox1.Items.Clear();
            Vyvod();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "Наименование";
            label4.Text = "Размер(ширина)";
            label5.Text = "Цена(рулон, кв. м)";
            label6.Text = "Количество";
            label7.Text = "----------";
            label9.Text = "----------";
            listBox1.Items.Clear();
             Vyvod();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "id_товара";
            label4.Text = "id_продажи";
            label5.Text = "----------";
            label6.Text = "----------";
            label7.Text = "----------";
            label9.Text = "----------";
            listBox1.Items.Clear();
            Vyvod();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "id_клиента";
            label4.Text = "Количество";
            label5.Text = "Цена";
            label6.Text = "Стоимость";
            label7.Text = "Дата_продажи";
            label9.Text = "id_товара";
            listBox1.Items.Clear();
            Vyvod();
        }

        private void button1_Click(object sender, EventArgs e) //ПОИСК
        {
            listBox1.Items.Clear();
            if (radioButton1.Checked == true)
            {
                var clientList = Program.db1.Клиенты.ToList();
                var clients = clientList.Where(c => c.ФИО.ToLower().Contains(textBox7.Text.ToLower())).ToList();
                //FirstOrDefault -> null то записи такой нет, если не null то есть

                label1.Text = ("id_клиента" + " | " + "ФИО" + " | " + "Почта");
                foreach (Клиенты kl in clients)
                {
                    listBox1.Items.Add(kl);
                }
            }
            if (radioButton2.Checked == true)
            {
                var tovarList = Program.db2.Товар.ToList();
                var tovaty = tovarList.Where(c => c.Наименование.ToLower().Contains(textBox7.Text.ToLower())).ToList();
                label1.Text = ("id_товара" + " | " + "Наименование" + " | " + "Размер" + " | " + "Цена" + " | " + "Количество");
                foreach (Товары tov in tovaty)
                {
                    listBox1.Items.Add(tov);
                }
            }
            if (radioButton3.Checked == true)
            {
                //var prod_tovList = Program.db3.Проданные_товары.ToList();
                //var prod_tovary = prod_tovList.Where(c => c.id_продажи.ToLower().Contains(textBox7.Text.ToLower())).ToList();
                ////FirstOrDefault -> null то записи такой нет, если не null то есть

                //label1.Text = ("id_проданные_товары" + " | " + "id_товара" + " | " + "id_продажи");
                //foreach (Проданные_товары pr_tov in prod_tovary)
                //{
                //    listBox1.Items.Add(pr_tov);
                //}
            }
            if (radioButton4.Checked == true)
            {
                //var clientList = Program.db1.Клиенты.ToList();
                //var clients = clientList.Where(c => c.ФИО.ToLower().Contains(textBox7.Text.ToLower())).ToList();
                ////FirstOrDefault -> null то записи такой нет, если не null то есть

                //label1.Text = ("id_продажи" + " | " + "id_клиента" + " | " + "Количество" + " | " + "Цена" + " | " + "Общая_Стоимость" + " | " + "Дата_продажи");
                //foreach (Клиенты kl in clients)
                //{
                //    listBox1.Items.Add(kl);
                //}
            }
        }



    }
}
