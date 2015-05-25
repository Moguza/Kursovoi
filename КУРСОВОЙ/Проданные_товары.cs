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
    public class Проданные_товары
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id_проданные_товары
        {
            get;
            set;
        }
        [Column]
        public int id_товара
        {
            get;
            set;
        }
        [Column]
        public int id_продажи
        {
            get;
            set;
        }
        public override string ToString()
        {
            return id_проданные_товары + " | " + id_товара + " | " + id_продажи;
        }
    }
    public class DB3 : DataContext
    {
        public DB3(string cs)
            : base(cs)
        {
        }
        public System.Data.Linq.Table<Проданные_товары> Проданные_товары
        {
            get { return this.GetTable<Проданные_товары>(); }
        }
        public void Check()
        {
            if (!this.DatabaseExists())
            {
                this.CreateDatabase();
            }
        }
        public void ADD(int id_товара, int id_продажи)
        {
            Проданные_товары SpTovProd = new Проданные_товары();
            SpTovProd.id_товара = id_товара;
            SpTovProd.id_продажи = id_продажи;
            this.Проданные_товары.InsertOnSubmit(SpTovProd);
            this.SubmitChanges();
        }
        public void Edit(int id_проданные_товары, int id_товара, int id_продажи)
        {
            Проданные_товары SpTovProd = this.Проданные_товары.Where(c => c.id_проданные_товары == id_проданные_товары).FirstOrDefault();
            SpTovProd.id_товара = id_товара;
            SpTovProd.id_продажи = id_продажи;
            this.SubmitChanges();
        }
        public void Delete(int id_проданные_товары)
        {
            Проданные_товары SpTovProd = this.Проданные_товары.Where(c => c.id_проданные_товары == id_проданные_товары).FirstOrDefault();
            this.Проданные_товары.DeleteOnSubmit(SpTovProd);
            this.SubmitChanges();
        }
        public List<Проданные_товары> Zapros(int id_Проданные_товары)
        {
            return this.Проданные_товары.Select(c => c).ToList();
        }
    }
}
