using HastaneOtomasyon.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon
{
    public partial class frmRandevuEkle : Form
    {
        public frmRandevuEkle()
        {
            InitializeComponent();
        }

        private void frmRandevuEkle_Load(object sender, EventArgs e)
        {
            lstHastalar.Items.Clear();
            foreach (Hasta item in Hasta.Hastalar)
            {
                ListViewItem satir = new ListViewItem();
                satir.Text = item.Ad;
                satir.SubItems.Add(item.Soyad);
                satir.Tag = item;
                lstHastalar.Items.Add(satir);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lstHastalar.Items.Clear();
            List<Hasta> gosterilecek = (from x in Hasta.Hastalar
                                        where x.Ad.ToLower().StartsWith(textBox1.Text.ToLower())
                                        select x).ToList();
            foreach (Hasta item in gosterilecek)
            {
                ListViewItem satir = new ListViewItem();
                satir.Text = item.Ad;
                satir.SubItems.Add(item.Soyad);
                satir.Tag = item;
                lstHastalar.Items.Add(satir);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmHastaEkle frm = new frmHastaEkle();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmRandevuEkleDoktorSec frm = new frmRandevuEkleDoktorSec();
                frm.Tag = (Hasta)lstHastalar.FocusedItem.Tag;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void frmRandevuEkle_Activated(object sender, EventArgs e)
        {
            lstHastalar.Items.Clear();
            foreach (Hasta item in Hasta.Hastalar)
            {
                ListViewItem satir = new ListViewItem();
                satir.Text = item.Ad;
                satir.SubItems.Add(item.Soyad);
                satir.Tag = item;
                lstHastalar.Items.Add(satir);
            }
        }

        private void lstHastalar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
