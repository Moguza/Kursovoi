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

        //DB1 db1 = new DB1(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\КУРСОВОЙ.mdf;Integrated Security=True;User Instance=True");
        //DB2 db2 = new DB2(@"Data Source=.\SQLEXPRESS;AttachDbFilename=c:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\КУРСОВОЙ.mdf;Integrated Security=True;User Instance=True");
        //DB3 db3 = new DB3(@"Data Source=.\SQLEXPRESS;AttachDbFilename=c:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\КУРСОВОЙ.mdf;Integrated Security=True;User Instance=True");
        //DB4 db4 = new DB4(@"Data Source=.\SQLEXPRESS;AttachDbFilename=c:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\КУРСОВОЙ.mdf;Integrated Security=True;User Instance=True");
        //DB5 db5 = new DB5(@"Data Source=.\SQLEXPRESS;AttachDbFilename=c:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\КУРСОВОЙ.mdf;Integrated Security=True;User Instance=True");
        //DB6 db6 = new DB6(@"Data Source=.\SQLEXPRESS;AttachDbFilename=c:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\КУРСОВОЙ.mdf;Integrated Security=True;User Instance=True");
        //DB7 db7 = new DB7(@"Data Source=.\SQLEXPRESS;AttachDbFilename=c:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\КУРСОВОЙ.mdf;Integrated Security=True;User Instance=True");

        public  void Vyvod()
        {
            if (radioButton1.Checked == true)
            {
                label1.Text = ("id_поставщика" + " | " + "ФИО" + " | " + "Почта");
                var c = Program.db1.Zapros(0);
                foreach (Поставщики pos in c)
                {
                    listBox1.Items.Add(pos);
                }
            }
            if (radioButton2.Checked == true)
            {
                label1.Text = ("id_клиента" + " | " + "ФИО" + " | " + "Почта");
                var c = Program.db2.Zapros(0);
                foreach (Клиенты kl in c)
                {
                    listBox1.Items.Add(kl);
                }
            }
            if (radioButton3.Checked == true)
            {
                label1.Text = ("id_товара" + " | " + "Наименование" + " | " + "Цена" + " | " + "Количество");
                var c = Program.db3.Zapros(0);
                foreach (Товары tov in c)
                {
                    listBox1.Items.Add(tov);
                }
            }
            if (radioButton4.Checked == true)
            {
                label1.Text = ("id_Список_товаров_по_покупке" + " | " + "id_товара" + " | " + "id_покупки");
                var c = Program.db4.Zapros(0);
                foreach (Список_товаров_по_покупке SpTovPok in c)
                {
                    listBox1.Items.Add(SpTovPok);
                }
            }
            if (radioButton5.Checked == true)
            {
                label1.Text = ("id_Список_товаров_по_продаже" + " | " + "id_товара" + " | " + "id_продажи");
                var c = Program.db5.Zapros(0);
                foreach (Список_товаров_по_продаже SpTovProd in c)
                {
                    listBox1.Items.Add(SpTovProd);
                }
            }
            if (radioButton6.Checked == true)
            {
                label1.Text = ("id_продажи" + " | " + "id_клиента" + " | " + "Количество" + " | " + "Цена" + " | " + "Общая_Стоимость" + " | " + "Дата_продажи");
                var c = Program.db6.Zapros(0);
                foreach (Продажа prod in c)
                {
                    listBox1.Items.Add(prod);
                }
            }
            if (radioButton7.Checked == true)
            {
                label1.Text = ("id_покупки" + " | " + "id_поставщика" + " | " + "Количество" + " | " + "Цена" + " | " + "Общая_Стоимость" + " | " + "Дата_покупки");
                var c = Program.db7.Zapros(0);
                foreach (Покупка pok in c)
                {
                    listBox1.Items.Add(pok);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Список_поставщиков sp = new Список_поставщиков();
                sp.Show();
                Close();
                //listBox1.Items.Clear();
                //Vyvod();
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
            if (radioButton5.Checked == true)
            {
                listBox1.Items.Clear();
                Vyvod();
            }
            if (radioButton6.Checked == true)
            {
                listBox1.Items.Clear();
                Vyvod();
            }
            if (radioButton7.Checked == true)
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
            if (radioButton5.Checked == true)
            {
                f2.typ = 4;
            }
            if (radioButton6.Checked == true)
            {
                f2.typ = 5;
            }
            if (radioButton7.Checked == true)
            {
                f2.typ = 6;
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
