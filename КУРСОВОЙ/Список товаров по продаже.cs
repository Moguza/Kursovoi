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
    public class Список_товаров_по_продаже
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id_Список_товаров_по_продаже
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
            return id_Список_товаров_по_продаже + " | " + id_товара + " | " + id_продажи;
        }
    }
    public class DB5 : DataContext
    {
        public DB5(string cs)
            : base(cs)
        {
        }
        public System.Data.Linq.Table<Список_товаров_по_продаже> Список_товаров_по_продаже
        {
            get { return this.GetTable<Список_товаров_по_продаже>(); }
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
            Список_товаров_по_продаже SpTovProd = new Список_товаров_по_продаже();
            SpTovProd.id_товара = id_товара;
            SpTovProd.id_продажи = id_продажи;
            this.Список_товаров_по_продаже.InsertOnSubmit(SpTovProd);
            this.SubmitChanges();
        }
        public void Edit(int id_Список_товаров_по_продаже, int id_товара, int id_продажи)
        {
            Список_товаров_по_продаже SpTovProd = this.Список_товаров_по_продаже.Where(c => c.id_Список_товаров_по_продаже == id_Список_товаров_по_продаже).FirstOrDefault();
            SpTovProd.id_товара = id_товара;
            SpTovProd.id_продажи = id_продажи;
            this.SubmitChanges();
        }
        public void Delete(int id_Список_товаров_по_продаже)
        {
            Список_товаров_по_продаже SpTovProd = this.Список_товаров_по_продаже.Where(c => c.id_Список_товаров_по_продаже == id_Список_товаров_по_продаже).FirstOrDefault();
            this.Список_товаров_по_продаже.DeleteOnSubmit(SpTovProd);
            this.SubmitChanges();
        }
        public List<Список_товаров_по_продаже> Zapros(int id_Список_товаров_по_продаже)
        {
            return this.Список_товаров_по_продаже.Select(c => c).ToList();
        }
    }
}
