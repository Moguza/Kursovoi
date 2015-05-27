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
        
        private void Создать_заказ_плитка_на_пол_Load_1(object sender, EventArgs e)
        {
            button2.Enabled = false;
            label4.Text = ("id_товара" + " | " + "Наименование" + " | " + "Размер" + " | " + "Цена" + " | " + "Количество");
            var c = Program.db2.Zapros(0);
            foreach (Товары tov in c)
            {
                listBox1.Items.Add(tov);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if ((Convert.ToInt32(textBox1.Text) < 200) || (Convert.ToInt32(textBox2.Text) < 200))
                    {
                        MessageBox.Show("Вводите размеры в сантиметрах");
                    }
                    else
                    {
                        try
                        {
                            string str = listBox1.SelectedItem.ToString();
                            //     MessageBox.Show("Данные найдены");
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
                                Program.cena_pl = Convert.ToInt32(list[3]);
                                Program.razmer_pl = Convert.ToInt32(list[2]);
                            }
                            //   MessageBox.Show(Program.cena.ToString());
                        }
                        catch { MessageBox.Show("выделите строку"); }
                        try
                        {
                            a = Convert.ToDouble(textBox1.Text);
                            b = Convert.ToDouble(textBox2.Text);
                            double kol_m2 = 1000 / (Program.razmer_pl * Program.razmer_pl);
                            MessageBox.Show("В 1 м2 " + Math.Ceiling(kol_m2) + " плит");
                            double k = ((a * b) / Math.Ceiling(kol_m2)) / 10000;
                            double s = k * Program.cena_pl;
                            textBox3.Text = "вам потребуется " + Math.Ceiling(k) + " плитки(ок) стоимостью " + Math.Ceiling(s) + " рублей";
                            button2.Enabled = true;
                        }
                        catch
                        { MessageBox.Show("Вы ввели не все параметры"); }
                    }
                }
                catch
                { MessageBox.Show("Вы ввели не все параметры!"); }
            }
            
        }
    }
}