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
    public class Tovary
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id_tovara
        {
            get;
            set;
        }
        [Column(DbType="varchar")]
        public string naimenovanie
        {
            get;
            set;
        }
        [Column(DbType="float")]
        public float cena
        {
            get;
            set;
        }
        [Column]
        public int kolichestvo
        {
            get;
            set;
        }
        public override string ToString()
        {
            return id_tovara + " | " + naimenovanie + " | " + cena + " | " + kolichestvo;
        }
    }
    public class DB2 : DataContext
    {
        public DB2(string cs)
            : base(cs)
        {
        }
        public System.Data.Linq.Table<Tovary> Tovar
        {
            get { return this.GetTable<Tovary>(); }
        }
        public void Check()
        {
            if (!this.DatabaseExists())
            {
                this.CreateDatabase();
            }
        }
        public void ADD(string naimenovanie, float cena, int kolichestvo)
        {
            Tovary tov = new Tovary();
            tov.naimenovanie = naimenovanie;
            tov.cena = cena;
            tov.kolichestvo = kolichestvo;
            this.Tovar.InsertOnSubmit(tov);
            this.SubmitChanges();
        }
        public void Edit(int id_tovara, string naimenovanie, float cena, int kolichestvo)
        {
            Tovary tov = this.Tovar.Where(c => c.id_tovara == id_tovara).FirstOrDefault();
            tov.naimenovanie = naimenovanie;
            tov.cena = cena;
            tov.kolichestvo = kolichestvo;
            this.SubmitChanges();
        }
        public void Delete(int id_tovara)
        {
            Tovary tov = this.Tovar.Where(c => c.id_tovara == id_tovara).FirstOrDefault();
            this.Tovar.DeleteOnSubmit(tov);
            this.SubmitChanges();
        }
        public List<Tovary> Zapros(int id_tovara)
        {
            return this.Tovar.Select(c => c).ToList();
          //   return null;
        }

    }
}
