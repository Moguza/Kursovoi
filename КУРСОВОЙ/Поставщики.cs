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
    public class Поставщики
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id_поставщика
        {
            get;
            set;
        }
        [Column]
        public string ФИО
        {
            get;
            set;
        }
        [Column]
        public string Почта
        {
            get;
            set;
        }
        public override string ToString()
        {
            return id_поставщика + " | " + ФИО + " | " + Почта;
        }
    }
    public class DB1 : DataContext
    {
        public DB1(string cs)
            : base(cs)
        {
        }
        public System.Data.Linq.Table<Поставщики> Поставщики
        {
            get { return this.GetTable<Поставщики>(); }
        }
        public void Check()
        {
            if (!this.DatabaseExists())
            {
                this.CreateDatabase();
            }
        }
        public void ADD(string ФИО, string Почта)
        {
            Поставщики pos = new Поставщики();
            pos.ФИО = ФИО;
            pos.Почта = Почта;
            this.Поставщики.InsertOnSubmit(pos);
            this.SubmitChanges();
        }
        public void Edit(int id_поставщика, string ФИО, string Почта)
        {
            Поставщики pos = this.Поставщики.Where(c => c.id_поставщика == id_поставщика).FirstOrDefault();
            pos.ФИО = ФИО;
            pos.Почта = Почта;
            this.SubmitChanges();
        }
        public void Delete(int id_поставщика)
        {
            Поставщики pos = this.Поставщики.Where(c => c.id_поставщика == id_поставщика).FirstOrDefault();
            this.Поставщики.DeleteOnSubmit(pos);
            this.SubmitChanges();
        }
        public List<Поставщики> Zapros(int id_поставщика)
        {
            return this.Поставщики.Select(c => c).ToList();
        }
    }
}
