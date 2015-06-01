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
    public class Продажа
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id_продажи
        {
            get;
            set;
        }
        [Column(DbType = "int")]
        public int id_клиента
        {
            get;
            set;
        }
        [Column(DbType = "int")]
        public int Количество
        {
            get;
            set;
        }
        [Column(DbType = "float")]
        public float Цена
        {
            get;
            set;
        }
        [Column(DbType = "float")]
        public float Стоимость
        {
            get;
            set;
        }
        [Column(DbType = "datetime")]
        public DateTimeOffset Дата_продажи
        {
            get;
            set;
        }
        
        public override string ToString()
        {
            return id_продажи + " | " + id_клиента + " | " + Количество + " | " + Цена + " | " + Стоимость + " | " + Дата_продажи;
        }
    }
    public class DB4 : DataContext
    {
        public DB4(string cs)
            : base(cs)
        {
        }
        public System.Data.Linq.Table<Продажа> Продажа
        {
            get { return this.GetTable<Продажа>(); }
        }

        public void Check()
        {
            if (!this.DatabaseExists())
            {
                this.CreateDatabase();
            }
        }

        public int ADD(int id_клиента, int Количество, float Цена, float Стоимость, DateTimeOffset Дата_продажи)
        {
            Продажа prod = new Продажа();
            prod.id_клиента = id_клиента;
            prod.Количество = Количество;
            prod.Цена = Цена;
            prod.Стоимость = Стоимость;
            prod.Дата_продажи = Дата_продажи;
            this.Продажа.InsertOnSubmit(prod);
            this.SubmitChanges();
            return prod.id_продажи;
        }
        public void Edit(int id_продажи, int id_клиента, int Количество, float Цена, float Стоимость, DateTimeOffset Дата_продажи)
        {
            Продажа prod = this.Продажа.Where(c => c.id_продажи == id_продажи).FirstOrDefault();
            prod.id_клиента = id_клиента;
            prod.Количество = Количество;
            prod.Цена = Цена;
            prod.Стоимость = Стоимость;
            prod.Дата_продажи = Дата_продажи;
            this.SubmitChanges();
        }
        public void Delete(int id_продажи)
        {
            Продажа prod = this.Продажа.Where(c => c.id_продажи == id_продажи).FirstOrDefault();
            this.Продажа.DeleteOnSubmit(prod);
            this.SubmitChanges();
        }
        public List<Продажа> Zapros(int id_продажи)
        {
            return this.Продажа.Select(c => c).ToList();
        }
    }
}