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
            button3.Enabled = false;
            label6.Text = ("id_товара" + " | " + "Наименование" + " | " + "Размер" + " | " + "Цена" + " | " + "Количество");
            var c = Program.db2.Zapros(0);
            foreach (Товары tov in c)
            {
                listBox1.Items.Add(tov);
            }
        }
        public string way_dog = @"C:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\Отчёт\";
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
                            Program.cena = Convert.ToInt32(list[3]);
                            Program.razmer = Convert.ToInt32(list[2]);
                        }
                    }
                    catch { MessageBox.Show("выделите строку"); } //КАК СДЕЛАТЬ ЧТОБЫ ДАЛЬШЕ НЕ ШЛО ?!
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
                            try
                            {
                                if (Program.razmer == 100)
                                {
                                    k = ((2 * (a + b) * c) - (dv_k * (dv_a * dv_b)) - (ok_k * (ok_a * ok_b))) / (106 * 1005);
                                    double s = Math.Ceiling(k) * Program.cena;
                                    MessageBox.Show("Размер " + Program.razmer);
                                    textBox8.Text = "вам потребуется " + Math.Ceiling(k) + " рулонов стоимостью " + Math.Ceiling(s) + " рублей";
                                    button2.Enabled = true;
                                    button3.Enabled = true;
                                }
                                if (Program.razmer == 50)
                                {
                                    k = ((2 * (a + b) * c) - (dv_k * (dv_a * dv_b)) - (ok_k * (ok_a * ok_b))) / (53 * 1005);
                                    double s = Math.Ceiling(k) * Program.cena;
                                    textBox8.Text = "вам потребуется " + Math.Ceiling(k) + " рулонов стоимостью " + Math.Ceiling(s) + " рублей";
                                    button2.Enabled = true;
                                    button3.Enabled = true;
                                }
                            }
                            catch { MessageBox.Show("Неверный размер , возможно, вы выбрали не обои"); } //ПОЧЕМУ НЕ РАБОТЕТ ?!!!

                        }
                        if (radioButton6.Checked == true)
                        {
                            try
                            {
                                if (Program.razmer == 100)
                                {
                                    k = (a * b) / (106 * 1005);
                                    double s = Math.Ceiling(k) * Program.cena;
                                    textBox8.Text = "вам потребуется " + Math.Ceiling(k) + " рулонов стоимостью " + Math.Ceiling(s) + " рублей";
                                    button2.Enabled = true;
                                    button3.Enabled = true;
                                }
                                if (Program.razmer == 50)
                                {
                                    k = (a * b) / (53 * 1005);
                                    double s = Math.Ceiling(k) * Program.cena;
                                    textBox8.Text = "вам потребуется " + Math.Ceiling(k) + " рулонов стоимостью " + Math.Ceiling(s) + " рублей";
                                    button2.Enabled = true;
                                    button3.Enabled = true;
                                }
                            }
                            catch { MessageBox.Show("Неверный размер , возможно, вы выбрали не обои"); }

                        }
                    }
                    catch
                    { MessageBox.Show("Вы ввели не все параметры"); }
                }
            }
            catch { MessageBox.Show("Вы ввели не все параметры!"); }
            
           
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

        private void button3_Click(object sender, EventArgs e)
        {
            var x = Program.db2.Zapros(0);
            int nomer = 0;
            var doc = new Document();
            foreach (Товары tov in x)
            {
                x.Last();
                nomer = tov.id_товара;
            }
            PdfWriter.GetInstance(doc, new FileStream(way_dog + nomer.ToString() + @".pdf", FileMode.Create));
            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Users\Ольга\ARIAL.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            //////////
            iTextSharp.text.Phrase j3 = new Phrase("Цена: " + Program.cena,
           new iTextSharp.text.Font(baseFont, 12,
           iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            Paragraph a3 = new Paragraph(j3);
            a3.SpacingAfter = 10;
            MessageBox.Show("создан");
            doc.Add(a3);
            doc.Close();

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
        }

        
        

        
    }
}
