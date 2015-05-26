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

        private void Создать_заказ_обои_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            label6.Text = ("id_товара" + " | " + "Наименование" + " | " + "Размер" + " | " + "Цена" + " | " + "Количество");
            var c = Program.db2.Zapros(0);
            foreach (Товары tov in c)
            {
                listBox1.Items.Add(tov);
            }
        }
        public double a; //длина
        public double b; // ширина
        public double c; //высота
        public double k; // число рулонов
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
                            Program.cena = Convert.ToInt32(list[2]);
                        }
                        //   MessageBox.Show(Program.cena.ToString());
                    }
                    catch { MessageBox.Show("выделите строку");  } //КАК СДЕЛАТЬ ЧТОБЫ ДАЛЬШЕ НЕ ШЛО ?!
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

                            k = ((2 * (a + b) * c) - (dv_k * (dv_a * dv_b)) - (ok_k * (ok_a * ok_b))) / (106 * 1005);
                            double s = Math.Ceiling(k) * Program.cena;
                            textBox8.Text = "вам потребуется " + Math.Ceiling(k) + " рулонов стоимостью " + Math.Ceiling(s) + " рублей";

                        }
                        if (radioButton6.Checked == true)
                        {
                            k = (a * b) / (106 * 1005);
                            double s = Math.Ceiling(k) * Program.cena;
                            textBox8.Text = "вам потребуется " + Math.Ceiling(k) + " рулонов стоимостью " + Math.Ceiling(s) + " рублей";
                        }
                    }
                    catch
                    { MessageBox.Show("Вы ввели не все параметры"); }
                }
            }
            catch { MessageBox.Show("Вы ввели не все параметры!"); }
            button2.Enabled = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
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
        }

        
    }
}
