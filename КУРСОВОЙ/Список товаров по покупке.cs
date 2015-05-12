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
    public class Список_товаров_по_покупке
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id_Список_товаров_по_покупке
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
        public int id_покупки
        {
            get;
            set;
        }
        public override string ToString()
        {
            return id_Список_товаров_по_покупке + " | " + id_товара + " | " + id_покупки;
        }
    }
    public class DB4 : DataContext
    {
        public DB4(string cs)
            : base(cs)
        {
        }
        public System.Data.Linq.Table<Список_товаров_по_покупке> Список_товаров_по_покупке
        {
            get { return this.GetTable<Список_товаров_по_покупке>(); }
        }
        public void Check()
        {
            if (!this.DatabaseExists())
            {
                this.CreateDatabase();
            }
        }
        public void ADD(int id_товара, int id_покупки)
        {
            Список_товаров_по_покупке SpTovPok = new Список_товаров_по_покупке();
            SpTovPok.id_товара = id_товара;
            SpTovPok.id_покупки = id_покупки;
            this.Список_товаров_по_покупке.InsertOnSubmit(SpTovPok);
            this.SubmitChanges();
        }
        public void Edit(int id_Список_товаров_по_покупке, int id_товара, int id_покупки)
        {
            Список_товаров_по_покупке SpTovPok = this.Список_товаров_по_покупке.Where(c => c.id_Список_товаров_по_покупке == id_Список_товаров_по_покупке).FirstOrDefault();
            SpTovPok.id_товара = id_товара;
            SpTovPok.id_покупки = id_покупки;
            this.SubmitChanges();
        }
        public void Delete(int id_Список_товаров_по_покупке)
        {
            Список_товаров_по_покупке SpTovPok = this.Список_товаров_по_покупке.Where(c => c.id_Список_товаров_по_покупке == id_Список_товаров_по_покупке).FirstOrDefault();
            this.Список_товаров_по_покупке.DeleteOnSubmit(SpTovPok);
            this.SubmitChanges();
        }
        public List<Список_товаров_по_покупке> Zapros(int id_Список_товаров_по_покупке)
        {
            return this.Список_товаров_по_покупке.Select(c => c).ToList();
        }
    }
}
