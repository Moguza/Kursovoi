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

        public double a; //длина
        public double b; // ширина

       

        private void Создать_заказ_плитка_на_пол_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            button4.Enabled = false;
            button6.Enabled = false;
            button2.Enabled = false;
            label6.Text = ("id_товара" + " | " + "Наименование" + " | " + "Размер" + " | " + "Цена" + " | " + "Количество");
            var c = Program.db2.Zapros(0);
            foreach (Товары tov in c)
            {
                listBox1.Items.Add(tov);
            }
            label4.Text = ("id_клиента" + " | " + "                ФИО                " + " | " + "Почта");
            var a = Program.db1.Zapros(0);
            foreach (Клиенты kl in a)
            {
                listBox2.Items.Add(kl);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            label6.Text = ("id_товара" + " | " + "Наименование" + " | " + "Размер" + " | " + "Цена" + " | " + "Количество");
            var c = Program.db2.Zapros(0);
            foreach (Товары tov in c)
            {
                listBox1.Items.Add(tov);
            }
            label4.Text = ("id_клиента" + " | " + "                ФИО                " + " | " + "Почта");
            var a = Program.db1.Zapros(0);
            foreach (Клиенты kl in a)
            {
                listBox2.Items.Add(kl);
            }
            button4.Enabled = false;
            button6.Enabled = false;
            button2.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string str = listBox2.SelectedItem.ToString();
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
                    Program.id_kl = Convert.ToInt32(list[0]);
                    Program.FIO = Convert.ToString(list[1]);
                    Program.mail = Convert.ToString(list[2]);
                }
            }
            catch
            { MessageBox.Show("Выделите строку"); return; }
            var dialog = new SaveFileDialog();
            dialog.Filter = "Pdf (*.pdf)|*.pdf";
            if (dialog.ShowDialog() != DialogResult.Cancel)
            {
                Pdf_nakladnaya pd = new Pdf_nakladnaya();
                pd.PDF(dialog.FileName);
                MessageBox.Show("Сохранено");
            button4.Enabled = true;
            button2.Enabled = true;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    string str = listBox2.SelectedItem.ToString();
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
                        Program.id_kl = Convert.ToInt32(list[0]);
                        Program.FIO = Convert.ToString(list[1]);
                        Program.mail = Convert.ToString(list[2]);
                    }
                    string st = listBox1.SelectedItem.ToString();
                    string[] words2 = st.Split(razd);
                    int n = words2.Length;
                    List<string> list2 = new List<string>();
                    int m = 0;
                    for (int i = 0; i < n; i++)
                    {
                        if ((words2[i] != "") && (words2[i] != "\n"))
                        {
                            list2.Add(words2[i]);
                            m++;
                        }
                    }

                    for (int i = 0; i < n; i++)
                    {
                        Program.id_tov = Convert.ToInt32(list2[0]);
                        Program.naim = Convert.ToString(list2[1]);
                    }
                }

                int id = Program.db4.ADD(Program.id_kl, (int)Math.Ceiling(Program.k), (float)Program.cena, (int)Math.Ceiling(Program.s), DateTime.Now);
                Program.db3.ADD(Program.id_tov, id);
                Program.db2.Edit(Program.id_tov, Program.naim, Program.razmer, (float)Program.cena, (float)Math.Floor(Program.new_kolichestvo));
                MessageBox.Show("заказ оплачен покупателем" + Program.FIO);
                button2.Enabled= true;
            }
            catch { MessageBox.Show("выделите строку"); return; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var tovarList = Program.db2.Товар.ToList();
            var tovaty = tovarList.Where(c => c.Наименование.ToLower().Contains(textBox9.Text.ToLower())).ToList();
            if (tovaty.Count == 0)
            {
                MessageBox.Show("Такого товара нет!");
                listBox1.Items.Clear();
                textBox9.Text = "";
                var c = Program.db2.Zapros(0);
                foreach (Товары tov in c)
                {
                    listBox1.Items.Add(tov);
                }
                return;
            }
            label6.Text = ("id_товара" + " | " + "Наименование" + " | " + "Размер" + " | " + "Цена" + " | " + "Количество");
            foreach (Товары tov in tovaty)
            {
                listBox1.Items.Add(tov);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            var clientList = Program.db1.Клиенты.ToList();

            var clients = clientList.Where(c => c.ФИО.ToLower().Contains(textBox10.Text.ToLower())).ToList();
            if (clients.Count == 0)
            {
                MessageBox.Show("Клиента с таким ФИО нет!");
                listBox2.Items.Clear();
                textBox10.Text = "";
                var a = Program.db1.Zapros(0);
                foreach (Клиенты kl in a)
                {
                    listBox2.Items.Add(kl);
                }
                return;
            }
            label4.Text = ("id_клиента" + " | " + "                ФИО                " + " | " + "Почта");
            foreach (Клиенты kl in clients)
            {
                listBox2.Items.Add(kl);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Convert.ToInt32(textBox1.Text) < 200) || (Convert.ToInt32(textBox2.Text) < 200))
                {
                    MessageBox.Show("Вводите размеры в сантиметрах");
                    return;
                }
                else
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
                            Program.cena = Convert.ToInt32(list[3]);
                            Program.razmer = Convert.ToInt32(list[2]);
                            Program.kolichestvo = Convert.ToInt32(list[4]);
                            Program.naim = Convert.ToString(list[1]);
                        }
                    }
                    catch { MessageBox.Show("выделите строку"); }
                    try
                    {
                        a = Convert.ToDouble(textBox1.Text);
                        b = Convert.ToDouble(textBox2.Text);
                        double kol_m2 = 10000 / (Program.razmer * Program.razmer);
                        Program.k = ((a * b) * Math.Ceiling(kol_m2))/10000;
                        Program.s = kol_m2 * Program.cena;
                        textBox3.Text = "Для 1 м2   " + kol_m2 + " плит. Итого Вам потребуется " + Math.Ceiling(Program.k) + " плитки(ок) стоимостью " + Math.Ceiling(Program.s) + " рублей";
                        if (Program.kolichestvo > Program.k)
                        {
                            Program.new_kolichestvo = Program.kolichestvo - Program.k;
                        }
                        else { MessageBox.Show("Невозможно осуществить заказ, товаров на складе недостаточно"); return; }
                        button6.Enabled = true;
                    }
                    catch
                    { MessageBox.Show("Вы ввели не все параметры"); return; }
                }
            }
            catch
            { MessageBox.Show("Вы ввели не все параметры!"); return; }
        }
    }
}