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
    public partial class Список_поставщиков : Form
    {
        public Список_поставщиков()
        {
            InitializeComponent();
        }

        private void Список_поставщиков_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            label1.Text = ("id_поставщика" + " | " + "ФИО" + " | " + "Почта");
            var c = Program.db1.Zapros(0);
            foreach (Поставщики pos in c)
            {
                listBox1.Items.Add(pos);
            }
        }
    }
}
