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
    public class Товары
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id_товара
        {
            get;
            set;
        }
        [Column]
        public string Наименование
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
        public int Количество
        {
            get;
            set;
        }
        public override string ToString()
        {
            return id_товара + " | " + Наименование + " | " + Цена + " | " + Количество;
        }
    }
    public class DB3 : DataContext
    {
        public DB3(string cs)
            : base(cs)
        {
        }
        public System.Data.Linq.Table<Товары> Товары
        {
            get { return this.GetTable<Товары>(); }
        }
        public void Check()
        {
            if (!this.DatabaseExists())
            {
                this.CreateDatabase();
            }
        }
        public void ADD(string Наименование, float Цена, int Количество)
        {
            Товары tov = new Товары();
            tov.Наименование = Наименование;
            tov.Цена = Цена;
            tov.Количество = Количество;
            this.Товары.InsertOnSubmit(tov);
            this.SubmitChanges();
        }
        public void Edit(int id_товара, string Наименование, float Цена, int Количество)
        {
            Товары tov = this.Товары.Where(c => c.id_товара == id_товара).FirstOrDefault();
            tov.Наименование = Наименование;
            tov.Цена = Цена;
            tov.Количество = Количество;
            this.SubmitChanges();
        }
        public void Delete(int id_товара)
        {
            Товары tov = this.Товары.Where(c => c.id_товара == id_товара).FirstOrDefault();
            this.Товары.DeleteOnSubmit(tov);
            this.SubmitChanges();
        }
        public List<Товары> Zapros(int id_товара)
        {
            return this.Товары.Select(c => c).ToList();
        }
    }
}
