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
    [Table]
    public class Покупка
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id_покупки
        {
            get;
            set;
        }
        [Column]
        public int id_поставщика
        {
            get;
            set;
        }
        [Column]
        public int Количество
        {
            get;
            set;
        }
        [Column]
        public float Цена
        {
            get;
            set;
        }
        [Column]
        public float Стоимость
        {
            get;
            set;
        }
        [Column]
        public DateTimeOffset Дата_покупки
        {
            get;
            set;
        }

        public override string ToString()
        {
            return id_покупки + " | " + id_поставщика + " | " + Количество + " | " + Цена + " | " + Стоимость + " | " + Дата_покупки;
        }
    }
    public class DB7 : DataContext
    {
        public DB7(string cs)
            : base(cs)
        {
        }
        public System.Data.Linq.Table<Покупка> Покупка
        {
            get { return this.GetTable<Покупка>(); }
        }
        public void Check()
        {
            if (!this.DatabaseExists())
            {
                this.CreateDatabase();
            }
        }
        public void ADD(int id_поставщика, int Количество, float Цена, float Стоимость, DateTimeOffset Дата_покупки)
        {
            Покупка pok = new Покупка();
            pok.id_поставщика = id_поставщика;
            pok.Количество = Количество;
            pok.Цена = Цена;
            pok.Стоимость = Стоимость;
            pok.Дата_покупки = Дата_покупки;
            this.Покупка.InsertOnSubmit(pok);
            this.SubmitChanges();
        }
        public void Edit(int id_покупки, int id_поставщика, int Количество, float Цена, float Стоимость, DateTimeOffset Дата_покупки)
        {
            Покупка pok = this.Покупка.Where(c => c.id_покупки == id_покупки).FirstOrDefault();
            pok.id_поставщика = id_поставщика;
            pok.Количество = Количество;
            pok.Цена = Цена;
            pok.Стоимость = Стоимость;
            pok.Дата_покупки = Дата_покупки;
            this.SubmitChanges();
        }
        public void Delete(int id_покупки)
        {
            Покупка pok = this.Покупка.Where(c => c.id_покупки == id_покупки).FirstOrDefault();
            this.Покупка.DeleteOnSubmit(pok);
            this.SubmitChanges();
        }
        public List<Покупка> Zapros(int id_покупки)
        {
            return this.Покупка.Select(c => c).ToList();
        }
    }
}