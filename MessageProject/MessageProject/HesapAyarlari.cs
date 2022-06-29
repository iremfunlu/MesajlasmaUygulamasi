using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageProject
{
    public partial class HesapAyarlari : Form
    {
        Fonksiyonlar f = new Fonksiyonlar();
        public HesapAyarlari()
        {
            InitializeComponent();
        }
        public void loadbilgileri(string k_adi)
        {
            Login lgn = Application.OpenForms["Login"] as Login;
            string sifre = lgn.textEdit2.Text;
            //string k_adi = lgn.textEdit1.Text;
            string sorgu = "select * from Login where k_Adi='" + k_adi + "' ";
            DataRow dr = f.GetDataRow(sorgu);
            string Adi = dr["Adi"].ToString();
            string SoyAdi = dr["SoyAdi"].ToString();
            label2.Text = Adi;
            label4.Text = SoyAdi;
            label6.Text = k_adi;
            txtAdi.Text = label2.Text;
            txtSoyAdi.Text = label4.Text;
            txtkAdi.Text = label6.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtAdi_Click(object sender, EventArgs e)
        {
           
        }

        private void txtSoyAdi_Click(object sender, EventArgs e)
        {
           
        }

        private void tctkAdi_Click(object sender, EventArgs e)
        {
            
        }

        private void HesapAyarlari_Load(object sender, EventArgs e)
        {
            Login lgn = Application.OpenForms["Login"] as Login;
            string sifre = lgn.textEdit2.Text;
            string k_adi = lgn.textEdit1.Text;
            loadbilgileri(k_adi);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text!="" && txtAdi.Text!="AD" && txtkAdi.Text!="" && txtSoyAdi.Text!="" && txtSoyAdi.Text!="SOYAD" && txtkAdi.Text!="KULLANICI ADI")
	        {
                Login lgn = Application.OpenForms["Login"] as Login;
                string sifre = lgn.textEdit2.Text;
                string k_adi = lgn.textEdit1.Text;
                if (k_adi!=txtkAdi.Text)
                {
                    string sorgu = "select * from Login where k_Adi='" + txtkAdi + "'";
                    DataRow dr = f.GetDataRow(sorgu);
                    if (dr!=null)
                    {
                        alertControl1.Show(this, "OLUMSUZ", "KULLANICI ADI BAŞKASINA AİT");
                    }
                    else
                    {
                        string sorgu1 = "update Login set k_Adi='" + txtkAdi.Text + "',Adi='" + txtAdi.Text + "',SoyAdi='" + txtSoyAdi.Text + "' where k_Adi='" + k_adi + "' ";
                        DataRow dr1 = f.GetDataRow(sorgu1);
                        loadbilgileri(txtkAdi.Text);
                        alertControl1.Show(this, "İŞLEM BAŞARILI", "BİLGİLERİNİZ BAŞARIYLA GÜNCELLENDİ .");

                    }

                }

	        }
            else
	        {
                DevExpress.XtraEditors.XtraMessageBox.Show("ALANLARI BOŞ GEÇMEYİNİZ .");

	        }
        }
    }
}
