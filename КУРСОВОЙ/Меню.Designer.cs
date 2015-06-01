namespace КУРСОВОЙ
{
    partial class Меню
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Меню));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.обоиНаСтеныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.плиткаНаПолToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьЗаказToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьЗаказToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.кУРСОВОЙDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.кУРСОВОЙDataSetBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Bisque;
            this.listBox1.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 21;
            this.listBox1.Location = new System.Drawing.Point(335, 108);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(637, 235);
            this.listBox1.TabIndex = 17;
            // 
            // обоиНаСтеныToolStripMenuItem
            // 
            this.обоиНаСтеныToolStripMenuItem.Name = "обоиНаСтеныToolStripMenuItem";
            this.обоиНаСтеныToolStripMenuItem.Size = new System.Drawing.Size(204, 30);
            this.обоиНаСтеныToolStripMenuItem.Text = "Обои на стены";
            this.обоиНаСтеныToolStripMenuItem.Click += new System.EventHandler(this.обоиНаСтеныToolStripMenuItem_Click_1);
            // 
            // плиткаНаПолToolStripMenuItem
            // 
            this.плиткаНаПолToolStripMenuItem.Name = "плиткаНаПолToolStripMenuItem";
            this.плиткаНаПолToolStripMenuItem.Size = new System.Drawing.Size(204, 30);
            this.плиткаНаПолToolStripMenuItem.Text = "Плитка на пол";
            this.плиткаНаПолToolStripMenuItem.Click += new System.EventHandler(this.плиткаНаПолToolStripMenuItem_Click_1);
            // 
            // изменитьБДToolStripMenuItem
            // 
            this.изменитьБДToolStripMenuItem.Name = "изменитьБДToolStripMenuItem";
            this.изменитьБДToolStripMenuItem.Size = new System.Drawing.Size(198, 30);
            this.изменитьБДToolStripMenuItem.Text = "Изменить БД";
            this.изменитьБДToolStripMenuItem.Click += new System.EventHandler(this.изменитьБДToolStripMenuItem_Click_1);
            // 
            // создатьЗаказToolStripMenuItem1
            // 
            this.создатьЗаказToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обоиНаСтеныToolStripMenuItem,
            this.плиткаНаПолToolStripMenuItem});
            this.создатьЗаказToolStripMenuItem1.Name = "создатьЗаказToolStripMenuItem1";
            this.создатьЗаказToolStripMenuItem1.Size = new System.Drawing.Size(198, 30);
            this.создатьЗаказToolStripMenuItem1.Text = "Создать заказ";
            // 
            // создатьЗаказToolStripMenuItem
            // 
            this.создатьЗаказToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьЗаказToolStripMenuItem1,
            this.изменитьБДToolStripMenuItem});
            this.создатьЗаказToolStripMenuItem.Font = new System.Drawing.Font("Segoe Print", 11F);
            this.создатьЗаказToolStripMenuItem.Name = "создатьЗаказToolStripMenuItem";
            this.создатьЗаказToolStripMenuItem.Size = new System.Drawing.Size(69, 30);
            this.создатьЗаказToolStripMenuItem.Text = "Меню";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(331, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 21);
            this.label1.TabIndex = 16;
            this.label1.Text = "поля";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 31);
            this.button1.TabIndex = 15;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Список клиентов",
            "Список товаров",
            "Список проданных товаров",
            "Заказы"});
            this.comboBox1.Location = new System.Drawing.Point(12, 170);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(267, 31);
            this.comboBox1.TabIndex = 14;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkOrange;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьЗаказToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1013, 34);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Bisque;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "Выберите таблицу для просмотра";
            // 
            // Меню
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1013, 444);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Name = "Меню";
            this.Text = "Меню";
            ((System.ComponentModel.ISupportInitialize)(this.кУРСОВОЙDataSetBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem обоиНаСтеныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem плиткаНаПолToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьБДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьЗаказToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem создатьЗаказToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource кУРСОВОЙDataSetBindingSource;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label2;

    }
}