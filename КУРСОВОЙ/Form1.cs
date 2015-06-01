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
    public partial class Изменить_БД : Form
    {
        public Изменить_БД()
        {
            InitializeComponent();
        }

        public void Vydelenie_object_kl()//Выделение из таблицы поля
        {
            try
            {
                string str = listBox1.SelectedItem.ToString();
                char razd = '|';
                string[] words = str.Split(razd);
                int N = words.Length;
                List<string> list = new List<string>();
                int M = 0;
                for (int i = 0; i < N; i++)
                {
                    if ((words[i] != "") && (words[i] != "\n"))
                    {
                        list.Add(words[i]);
                        M++;
                    }
                }
                for (int i = 0; i < N; i++)
                {
                    Program.id_klient_tov = Convert.ToInt32(list[0]);
                    Program.fio_name = Convert.ToString(list[1]);
                    Program.mail = Convert.ToString(list[2]);
                }
            }
            catch { MessageBox.Show("выделите строку"); return; }
        }
        public void Vydelenie_object_tov()
        {
            try
            {
                string str = listBox1.SelectedItem.ToString();
                char razd = '|';
                string[] words = str.Split(razd);
                int N = words.Length;
                List<string> list = new List<string>();
                int M = 0;
                for (int i = 0; i < N; i++)
                {
                    if ((words[i] != "") && (words[i] != "\n"))
                    {
                        list.Add(words[i]);
                        M++;
                    }
                }
                for (int i = 0; i < N; i++)
                {
                    Program.id_tov = Convert.ToInt32(list[0]);
                    Program.naim = Convert.ToString(list[1]);
                    Program.razmer = Convert.ToInt32(list[2]);
                    Program.cena = Convert.ToDouble(list[3]);
                    Program.kolichestvo = Convert.ToDouble(list[4]); 
                }
            }
            catch { MessageBox.Show("выделите строку"); return; } 
        }
        

        public void Vyvod() //МЕТОД ВЫВОД
        {
            if (radioButton1.Checked == true)
            {
                label1.Text = ("id_клиента" + " | " + "                ФИО                " + " | " + "Почта");
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
        }

        private void button3_Click(object sender, EventArgs e) //УДАЛЕНИЕ
        {
            if (radioButton1.Checked == true)
            {
                Vydelenie_object_kl();
                var client = Program.db1.Клиенты.FirstOrDefault(c => c.id_клиента == Program.id_klient_tov);
                
                var prpodajs = Program.db4.Продажа.Where(p => p.id_клиента == client.id_клиента);

                foreach (var p in prpodajs)
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
                MessageBox.Show("Удаден клиент " + Program.fio_name);
                return;
            }
            if (radioButton2.Checked == true)
            {
                Vydelenie_object_tov();
                var tovar = Program.db2.Товар.FirstOrDefault(c => c.id_товара == Program.id_klient_tov);
                
                var prod_tov = Program.db3.Проданные_товары.Where(p => p.id_товара == tovar.id_товара);
                

                Program.db3.Проданные_товары.DeleteAllOnSubmit(prod_tov);
                Program.db3.SubmitChanges();

                Program.db2.Товар.DeleteOnSubmit(tovar);
                Program.db2.SubmitChanges();

                listBox1.Items.Clear();
                Vyvod();

                MessageBox.Show("Удаден товар " + Program.naim);
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
        }

        private void button1_Click(object sender, EventArgs e) //ПОИСК
        {
            listBox1.Items.Clear();
            if (radioButton1.Checked == true)
            {
                   var clientList = Program.db1.Клиенты.ToList();

                    var clients = clientList.Where(c => c.ФИО.ToLower().Contains(textBox7.Text.ToLower())).ToList();
                    if (clients.Count == 0)
                    {
                        MessageBox.Show("Клиента с таким ФИО нет!");
                        listBox1.Items.Clear();
                        textBox7.Text = "";
                        Vyvod();
                        return;
                    }
                    label1.Text = ("id_клиента" + " | " + "                ФИО                " + " | " + "Почта");
                        foreach (Клиенты kl in clients)
                        {
                            listBox1.Items.Add(kl);
                        }
                        button3.Enabled = true;
                        button4.Enabled = true;
            }
            if (radioButton2.Checked == true)
            {
                var tovarList = Program.db2.Товар.ToList();
                var tovaty = tovarList.Where(c => c.Наименование.ToLower().Contains(textBox7.Text.ToLower())).ToList();
                if (tovaty.Count == 0)
                {
                    MessageBox.Show("Такого товара нет!");
                    listBox1.Items.Clear();
                    textBox7.Text = "";
                    Vyvod();
                    return;
                }
                label1.Text = ("id_товара" + " | " + "Наименование" + " | " + "Размер" + " | " + "Цена" + " | " + "Количество");
                foreach (Товары tov in tovaty)
                {
                    listBox1.Items.Add(tov);
                }
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)//ИЗМЕНЕИЕ
        {
            if (radioButton1.Checked == true)
            {
                Vydelenie_object_kl();
                listBox1.Items.Clear();
                string s1, s2;
                if (textBox2.Text != "")
                {
                    s1 = textBox2.Text;
                }
                else { s1 = Program.fio_name; }
                if (textBox3.Text != "")
                {
                    s2 = textBox3.Text;
                }
                else { s2 = Program.mail; }
                s2 = textBox3.Text;
                Program.db1.Edit(Program.id_klient_tov, s1, s2);
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("Вы изменили запись с id " + Program.id_klient_tov + " в таблице клиенты");
                textBox7.Text = "";
                Vyvod();
            }
            if (radioButton2.Checked == true)
            {
                Vydelenie_object_tov();
                listBox1.Items.Clear();
                string s1;
                float s2, s3, s4;
                if (textBox2.Text != "")
                {
                    s1 = textBox2.Text;
                }
                else { s1 = Program.fio_name; }
                if (textBox3.Text != "")
                {
                    s2 = Convert.ToInt32(textBox3.Text);
                }
                else { s2 = Program.razmer; }
                if(textBox4.Text != "")
                {
                    s3 = Convert.ToInt32(textBox4.Text);
                }
                else { s3 = (float)Program.cena; }
                if (textBox4.Text != "")
                { 
                    s3 = Convert.ToInt32(textBox4.Text);
                }
                else { s3 = (float)Program.cena; }
                if (textBox5.Text != "")
                {
                    s4 = Convert.ToInt32(textBox5.Text);
                }
                else { s4 = (float)Program.kolichestvo; }
                Program.db2.Edit(Program.id_tov, s1, s2, s3, s4);
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                MessageBox.Show("Вы изменили запись с id " + Program.id_tov + " в таблице товары");
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
            button1.Enabled = true;
            button5.Enabled = true;
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
             button1.Enabled = true;
             button5.Enabled = true;
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
            button1.Enabled = true;
            button5.Enabled = true;
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
            button1.Enabled = true;
            button5.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
         //   textBox2.Text = Convert.ToString(Program.fio_name);
            button3.Enabled = true;
            button4.Enabled = true;
        }

    }
}
