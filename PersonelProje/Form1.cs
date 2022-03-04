
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void şehirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Şehir frm = new Şehir();
            frm.Show();
        }

        private void personelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonel frm = new frmPersonel();
            frm.Show();
        }

        private void dTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPerDTO frm = new frmPerDTO();
            frm.Show();
        }

        private void anonimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPerAnonim frm = new FrmPerAnonim();
            frm.Show();
        }
    }
}

