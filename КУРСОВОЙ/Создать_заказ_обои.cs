using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp;
using System.IO;
using iTextSharp.text.pdf;

namespace КУРСОВОЙ
{
    public partial class Создать_заказ_обои : Form
    {
        public Создать_заказ_обои()
        {
            InitializeComponent();
        }

        private void Создать_заказ_обои_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            label6.Text = ("id_товара" + " | " + "Наименование" + " | " + "Размер" + " | " + "Цена" + " | " + "Количество");
            var c = Program.db2.Zapros(0);
            foreach (Товары tov in c)
            {
                listBox1.Items.Add(tov);
            }
            label1.Text = ("id_клиента" + " | " + "                ФИО                " + " | " + "Почта");
            var a = Program.db1.Zapros(0);
            foreach (Клиенты kl in a)
            {
                listBox2.Items.Add(kl);
            }
        }
        public void Obnovlenie()
        {
            button2.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            label6.Text = ("id_товара" + " | " + "Наименование" + " | " + "Размер" + " | " + "Цена" + " | " + "Количество");
            var c = Program.db2.Zapros(0);
            foreach (Товары tov in c)
            {
                listBox1.Items.Add(tov);
            }
            label1.Text = ("id_клиента" + " | " + "                ФИО                " + " | " + "Почта");
            var a = Program.db1.Zapros(0);
            foreach (Клиенты kl in a)
            {
                listBox2.Items.Add(kl);
            }
        }

        public double a; //длина
        public double b; // ширина
        public double c; //высота
        public double dv_a;//длина  двери
        public double dv_b;//ширина двери
        public double dv_k;// число дверей
        public double ok_a;//длина окна
        public double ok_b;//ширина окна
        public int ok_k;// число окон

        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Convert.ToInt32(textBox1.Text) < 200) || ((Convert.ToInt32(textBox2.Text) < 200)) || ((Convert.ToInt32(textBox3.Text) < 100)) || (Convert.ToInt32(textBox4.Text) < 50) || (Convert.ToInt32(textBox5.Text) < 50) || (Convert.ToInt32(textBox6.Text) < 50) || (Convert.ToInt32(textBox7.Text) < 50))
                {
                    MessageBox.Show("Вводите размеры в сантиметрах");
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
                            Program.id_tov = Convert.ToInt32(list[0]);
                            Program.naim = Convert.ToString(list[1]);
                            Program.razmer = Convert.ToInt32(list[2]);
                            Program.cena = Convert.ToDouble(list[3]);
                            Program.kolichestvo = Convert.ToDouble(list[4]);
                        }
                    }
                    catch { MessageBox.Show("выделите строку"); return; } 

                    try
                    {
                        a = Convert.ToDouble(textBox1.Text);
                        b = Convert.ToDouble(textBox2.Text);
                        c = Convert.ToDouble(textBox3.Text);
                        dv_a = Convert.ToDouble(textBox4.Text);
                        dv_b = Convert.ToDouble(textBox5.Text);
                        dv_k = Convert.ToInt32(comboBox1.Text);
                        ok_a = Convert.ToDouble(textBox6.Text);
                        ok_b = Convert.ToDouble(textBox7.Text);
                        ok_k = Convert.ToInt32(comboBox2.Text);

                        if (radioButton5.Checked == true)
                        {
                            if ((Program.razmer == 100) || (Program.razmer == 50))
                            {

                                if (Program.razmer == 100)
                                {
                                    Program.k = ((2 * (a + b) * c) - (dv_k * (dv_a * dv_b)) - (ok_k * (ok_a * ok_b))) / (106 * 1005);
                                    Program.s = Math.Ceiling(Program.k) * Program.cena;
                                    textBox8.Text = "Вам потребуется " + Math.Ceiling(Program.k) + " рулонов стоимостью " + Math.Ceiling(Program.s) + " рублей";
                                    if (Program.kolichestvo > Program.k)
                                    {
                                        Program.new_kolichestvo = Program.kolichestvo - Program.k;
                                    }
                                    else { MessageBox.Show("Невозможно осуществить заказ, товаров на складе недостаточно"); return; }
                                    button6.Enabled = true;
                                }
                                if (Program.razmer == 50)
                                {
                                    Program.k = ((2 * (a + b) * c) - (dv_k * (dv_a * dv_b)) - (ok_k * (ok_a * ok_b))) / (53 * 1005);
                                    Program.s = Math.Ceiling(Program.k) * Program.cena;
                                    textBox8.Text = "Вам потребуется " + Math.Ceiling(Program.k) + " рулонов стоимостью " + Math.Ceiling(Program.s) + " рублей";
                                    if (Program.kolichestvo > Program.k)
                                    {
                                        Program.new_kolichestvo = Program.kolichestvo - Program.k;
                                    }
                                    else { MessageBox.Show("Невозможно осуществить заказ, товаров на складе недостаточно"); return; }
                                    button6.Enabled = true;
                                }
                            }
                            else { MessageBox.Show("Возможно, вы выбрали не обои"); return; } 
                    }
                        

                        if (radioButton6.Checked == true)
                        {
                            try
                            {
                                if (Program.razmer == 100)
                                {
                                    Program.k = (a * b) / (106 * 1005);
                                    Program.s = Math.Ceiling(Program.k) * Program.cena;
                                    textBox8.Text = "вам потребуется " + Math.Ceiling(Program.k) + " рулонов стоимостью " + Math.Ceiling(Program.s) + " рублей";
                                    if (Program.kolichestvo > Program.k)
                                    {
                                        Program.new_kolichestvo = Program.kolichestvo - Program.k;
                                    }
                                    else { MessageBox.Show("Невозможно осуществить заказ, товаров на складе недостаточно"); return; }
                                    button6.Enabled = true;
                                }
                                if (Program.razmer == 50)
                                {
                                    Program.k = (a * b) / (53 * 1005);
                                    Program.s = Math.Ceiling(Program.k) * Program.cena;
                                    textBox8.Text = "вам потребуется " + Math.Ceiling(Program.k) + " рулонов стоимостью " + Math.Ceiling(Program.s) + " рублей";
                                    if (Program.kolichestvo > Program.k)
                                    {
                                        Program.new_kolichestvo = Program.kolichestvo - Program.k;
                                    }
                                    else { MessageBox.Show("Невозможно осуществить заказ, товаров на складе недостаточно"); return; }
                                    button6.Enabled = true;
                                }
                            }
                            catch { MessageBox.Show("Неверный размер , возможно, вы выбрали не обои"); return; }

                        }
                    }
                    catch
                    { MessageBox.Show("Вы ввели не все параметры"); return; }
                }
            }
            catch { MessageBox.Show("Вы ввели не все параметры!"); return; }
        }//РАССЧИТЫВАЕТСЯ И СОЗДАЁТСЯ НАКЛАДНАЯ 

        private void button2_Click_1(object sender, EventArgs e)
        {
            Obnovlenie();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox8.Text = "";
            button2.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox8.Text = "";
            button2.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
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
                    }
                }
                
                int id = Program.db4.ADD(Program.id_kl, (int)Math.Ceiling(Program.k), (float)Program.cena, (int)Math.Ceiling(Program.s), DateTime.Now);
                Program.db3.ADD(Program.id_tov, id);
                Program.db2.Edit(Program.id_tov, Program.naim, Program.razmer, (float)Program.cena, (float)Math.Floor(Program.new_kolichestvo));
                MessageBox.Show("заказ оплачен покупателем" + Program.FIO);
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
            label15.Text = ("id_клиента" + " | " + "                ФИО                " + " | " + "Почта");
            foreach (Клиенты kl in clients)
            {
                listBox2.Items.Add(kl);
            }
            
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
            }
            
            button4.Enabled = true;
        }

    }
}
