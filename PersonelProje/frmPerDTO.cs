using PersonelProje.Connection;
using PersonelProje.Context;
using PersonelProje.DTO;
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
    public partial class frmPerDTO : Form
    {
        public frmPerDTO()
        {
            InitializeComponent();
        }
        PersonelContext db = DbConnect.GetConnection();
        Personel SecPersonel;
        List<PersonelDTO> plist = new List<PersonelDTO>();

        private void frmPerDTO_Load(object sender, EventArgs e)
        {
            Doldur();
            CmDoldur();

            
        }

        private void CmDoldur()
        {
            var slist = db.Set<Sehir>().Select(x => new
            {
                x.SehirAd,x.SehirId

            }).ToList();

            cmBoxPer.DataSource = slist;
            cmBoxPer.DisplayMember = "SehirAd";
            cmBoxPer.ValueMember = "SehirId";
        }

        private void Doldur()
        {
             plist = db.Set<Personel>().Select(x => new PersonelDTO
            {
                Id = x.Id,
                Ad = x.Ad,
                Soyad = x.Soyad,
                Maas = x.Maas,
                SehirAd = x.Sehir.SehirAd,
                Cins=x.Cins

            }).ToList();
            

            dataGridView1.DataSource = plist;
            //decimal tmaas = 0;
            //foreach (var item in plist)
            //{
            //    tmaas += item.Maas;
            //}
            //txToplam.Text = tmaas.ToString();

            //decimal tmaas = plist.Sum(x => x.Maas);
            //txToplam.Text = tmaas.ToString();

            txToplam.Text = plist.Sum(x => x.Maas).ToString();
            txOrt.Text = plist.Average(item => item.Maas).ToString();
            txTopSayi.Text = plist.Count.ToString();
            txToplamE.Text = plist.Where(x => x.Cins == "E").Sum(x => x.Maas).ToString();
            txToplamK.Text = plist.Where(x => x.Cins == "K").Sum(x => x.Maas).ToString();
            txOrtalamaE.Text = plist.Where(x => x.Cins == "E").Average(x => x.Maas).ToString();
            txOrtalamaK.Text = plist.Where(x => x.Cins == "K").Average(x => x.Maas).ToString();


        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           int secId =(int) dataGridView1.CurrentRow.Cells[0].Value;
            SecPersonel = db.Set<Personel>().Find(secId);
            txAd.Text = SecPersonel.Ad.ToString();
            txCins.Text = SecPersonel.Cins.ToString();
            txMaas.Text = SecPersonel.Maas.ToString();
            //txSehirId.Text = SecPersonel.SehirId.ToString();
            txSoyad.Text = SecPersonel.Soyad.ToString();
            cmBoxPer.SelectedValue = SecPersonel.SehirId;
        }

        private void ckAdSıra_CheckedChanged(object sender, EventArgs e)
        {
            plist = plist.OrderBy(x => x.Ad).ToList();
            dataGridView1.DataSource = plist;
        }

        private void ckMaasSira_CheckedChanged(object sender, EventArgs e)
        {
            plist = plist.OrderBy(x => x.Maas).ToList();
            dataGridView1.DataSource = plist;
        }

        private void ckAdSıra_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckAdSıra.Checked)
            {
                plist = plist.OrderBy(x => x.Ad).ToList();
                dataGridView1.DataSource = plist;
            }
            else
            {
                plist = plist.OrderBy(x => x.Id).ToList();
                dataGridView1.DataSource = plist;
            }
        }

        private void ckMaasSira_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckMaasSira.Checked)
            {
                plist = plist.OrderBy(x => x.Maas).ToList();
                dataGridView1.DataSource = plist;
            }
            else
            {
                plist = plist.OrderBy(x => x.Id).ToList();
                dataGridView1.DataSource = plist;
            }
        }

        private void txAra_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txAra.Text))
            {
                plist = plist.Where(x => x.Ad.ToLower().Contains(txAra.Text.ToLower())).ToList();
                dataGridView1.DataSource = plist;
            }
            else
            {
                Doldur();
            }

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Personel yper = new Personel();
            yper.Ad = txAd.Text;
            yper.Cins = txCins.Text;
            yper.Maas = Convert.ToDecimal(txMaas.Text);
            yper.SehirId = (int)cmBoxPer.SelectedValue;
            //yper.SehirId = Convert.ToInt32(txSehirId.Text);
            yper.Soyad = txSoyad.Text;
            db.Set<Personel>().Add(yper);
            db.SaveChanges();
            Doldur();

        }

        private void btnGuncel_Click(object sender, EventArgs e)
        {
            SecPersonel.Ad = txAd.Text;
            SecPersonel.Cins = txCins.Text;
            SecPersonel.Soyad = txSoyad.Text;
            //SecPersonel.SehirId = Convert.ToInt32(txSehirId.Text);
            SecPersonel.SehirId = (int)cmBoxPer.SelectedValue;
            SecPersonel.Maas = Convert.ToDecimal(txMaas.Text);
            db.SaveChanges();
            Doldur();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            
            db.Set<Personel>().Remove(SecPersonel);
            db.SaveChanges();
            Doldur();
        }
    }
}


