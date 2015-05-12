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
    public class Клиенты
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id_клиента
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
            return id_клиента + " | " + ФИО + " | " + Почта;
        }
    }
    public class DB2 : DataContext
    {
        public DB2(string cs)
            : base(cs)
        {
        }
        public System.Data.Linq.Table<Клиенты> Клиенты
        {
            get { return this.GetTable<Клиенты>(); }
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
            Клиенты kl = new Клиенты();
            kl.ФИО = ФИО;
            kl.Почта = Почта;
            this.Клиенты.InsertOnSubmit(kl);
            this.SubmitChanges();
        }
        public void Edit(int id_клиента, string ФИО, string Почта)
        {
            Клиенты kl = this.Клиенты.Where(c => c.id_клиента == id_клиента).FirstOrDefault();
            kl.ФИО = ФИО;
            kl.Почта = Почта;
            this.SubmitChanges();
        }
        public void Delete(int id_клиента)
        {
            Клиенты kl = this.Клиенты.Where(c => c.id_клиента == id_клиента).FirstOrDefault();
            this.Клиенты.DeleteOnSubmit(kl);
            this.SubmitChanges();
        }
        public List<Клиенты> Zapros(int id_клиента)
        {
            return this.Клиенты.Select(c => c).ToList();
        }
    }
}
