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
    public partial class Register : Form
    {
        Fonksiyonlar f = new Fonksiyonlar();
        
        public Register()
        {
            InitializeComponent();
        }

        public string id;           

        private void btnKayit_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text != "" && txtMail.Text != "" && txtSifre.Text != "" && txtSifreDog.Text != "" && txtSoyAdi.Text != "" && txtTel.Text != ""&&txtkAdi.Text!="" && txtAdi.Text != "AD" && txtMail.Text != "E-MAIL" && txtSifre.Text != "ŞİFRE" && txtSifreDog.Text != "ŞİFRE DOĞRULA" && txtSoyAdi.Text != "SOYAD" && txtTel.Text != "TELEFON NUMARASI" && txtkAdi.Text != "KULLANICI ADI")
            {
                string sorgu = "select * from Login where k_Adi='"+txtkAdi.Text+"'";
                string sorgu1="select * from iletisimBilgileri where T_Numarasi='"+txtTel.Text+"' and EMail='"+txtMail.Text+"'";
                DataRow dr=f.GetDataRow(sorgu);
                DataRow dr1=f.GetDataRow(sorgu1);
                if (dr == null && dr1 == null)
	            {
                    if (txtSifre.Text==txtSifreDog.Text)
                    {
                        string sorgu2="insert into Login(Adi,SoyAdi,k_Adi,Sifre) values('" + txtAdi.Text + "','" + txtSoyAdi.Text + "','" + txtkAdi.Text + "','" + txtSifre.Text + "')";
                        DataRow dr2=f.GetDataRow(sorgu2);
                        string sorgu3="select id,k_Adi from Login where k_Adi='"+txtkAdi.Text+"'";
                        DataRow dr3=f.GetDataRow(sorgu3);
                        int k_id=int.Parse(dr3["id"].ToString());
                        string sorgu4="insert into iletisimBilgileri(k_id,T_Numarasi,EMail) values('"+k_id+"','"+txtTel.Text+"','"+txtMail.Text+"')";
                        DataRow dr4 = f.GetDataRow(sorgu4);

                        alertControl1.Show(this,"KAYIT İŞLEMİ BAŞARILI","GİRİŞ YAPABİLİRSİNİZ");
                    
                        Login frm = new Login();
                        frm.Show();

                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("ŞİFRELER AYNI DEĞİL LÜTFEN KONTROL EDİNİZ !");
                    }
                   
		 
	            }
                else
	            {
                    if (dr!=null)
	                {
                        DevExpress.XtraEditors.XtraMessageBox.Show("BU KULLANICI ADINA AİT KULLANICI BULNMAKTADIR!");
	                }
                    if (dr1!=null)
	                {
                        DevExpress.XtraEditors.XtraMessageBox.Show("MAİL VEYA TELEFON NUMARASI BAŞKA BİR KULLANICIYA AİTTİR!");
	                }
                    
	            }
            }
            else
            {  
                DevExpress.XtraEditors.XtraMessageBox.Show("BOŞ GEÇİLMEMESİ GEREKEN ALANLAR VAR!");
                
                if (txtAdi.Text == "" || txtAdi.Text == "AD") 
                {
                    lblad.Visible = true;
                    txtAdi.Text = "AD";
                }
                if (txtSoyAdi.Text == "" || txtSoyAdi.Text == "SOYAD")
                {
                    lblsoyad.Visible = true;
                    txtSoyAdi.Text = "SOYAD";
                }
                if (txtMail.Text == "" || txtMail.Text == "E-MAIL")
                {
                    lblmail.Visible = true;
                    txtMail.Text = "E-MAIL";
                }
                if (txtSifre.Text == "" || txtSifre.Text == "ŞİFRE")
                {
                    lblsifre.Visible = true;
                    txtSifre.Text = "ŞİFRE";
                }
                if (txtSifreDog.Text == "" || txtSifreDog.Text == "ŞİFRE DOĞRULA")
                {
                    lblsifredog.Visible = true;
                    txtSifreDog.Text = "ŞİFRE DOĞRULA";
                }
                if (txtTel.Text == "" || txtTel.Text == "TELEFON NUMARASI")
                {
                    lbltel.Visible = true;
                    txtTel.Text = "TELEFON NUMARASI";
                }
                if (txtkAdi.Text == "" || txtkAdi.Text == "KULLANICI ADI") 
                {
                    lblkAdi.Visible = true;
                    txtkAdi.Text = "KULLANICI ADI";
                }
                
            }
        }

        private void txtAdi_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text=="AD")
            {
                txtAdi.Text = "";
            }
            
        }

        private void txtSoyAdi_Click(object sender, EventArgs e)
        {
            if (txtSoyAdi.Text == "SOYAD") 
            {
                txtSoyAdi.Text = "";
            }
        }

        private void txtkAdi_Click(object sender, EventArgs e)
        {
            if (txtkAdi.Text == "KULLANICI ADI") 
            {
                txtkAdi.Text = "";
            }
        }

        private void txtSifre_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text=="ŞİFRE")
            {
                txtSifre.Text = "";
            }
        }

        private void txtSifreDog_Click(object sender, EventArgs e)
        {
            if (txtSifreDog.Text == "ŞİFRE DOĞRULA") 
            {
                txtSifreDog.Text = "";
            }
        }

        private void txtTel_Click(object sender, EventArgs e)
        {
            if (txtTel.Text == "TELEFON NUMARASI") 
            {
                txtTel.Text = "";
            }
        }

        private void txtMail_Click(object sender, EventArgs e)
        {
            if (txtMail.Text == "E-MAIL") 
            {
                txtMail.Text = "";
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
            txtAdi.Focus();
        }
        private void linkLabel1_Click(object sender, EventArgs e)
        {
            SifremiUnuttum sifre = new SifremiUnuttum();
            sifre.Show();
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            string sorgu = @"insert into LoginSayiBulma(k_Adi,Sifre) values('deneme','deneme123')";
            DataTable dt = f.GetDataTable(sorgu);
        }

        private void girisYap_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.Show();
        }
    }
}
