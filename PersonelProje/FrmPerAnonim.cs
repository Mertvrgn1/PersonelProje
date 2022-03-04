using PersonelProje.Connection;
using PersonelProje.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelProje
{
    public partial class FrmPerAnonim : Form
    {
        public FrmPerAnonim()
        {
            InitializeComponent();
        }
        PersonelContext db = DbConnect.GetConnection();

        private void FrmPerAnonim_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        private void Doldur()
        {
            var plist = db.Set<Personel>().Select(x => new
            {
                Id = x.Id,
                Name = x.Ad,
                Surname = x.Soyad,
                Salary = x.Maas,
                Gender=x.Cins,
                CityName = x.Sehir.SehirAd

            }).ToList();

            dataGridView1.DataSource = plist;
        }
    }
}
