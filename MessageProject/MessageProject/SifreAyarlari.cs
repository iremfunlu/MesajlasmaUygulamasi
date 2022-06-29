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
    public partial class SifreAyarlari : Form
    {
        Fonksiyonlar f = new Fonksiyonlar();
        KodYonetim yonetim = new KodYonetim();
        public SifreAyarlari()
        {
            InitializeComponent();
        }
        void RandomSayi()
        {
            Random rnd1 = new Random();
            int sayi1 = rnd1.Next(1, 101);
            S1.Text = sayi1.ToString();
            Random rnd2 = new Random();
            int sayi2 = rnd2.Next(1, 101);
            S2.Text = sayi2.ToString();

        }
        //Random rnd2 = new Random();
        public int dogKodu1 ;

        /*public static string  bilgicek(string tel)
        {
           
            
           
        }*/

        private void txtSifre_Click(object sender, EventArgs e)
        {
            //txtSifre.Text = "";
        }

        private void txtDKodu_Click(object sender, EventArgs e)
        {
           // txtDKodu.Text = "";
        }

        private void txtSifreT_Click(object sender, EventArgs e)
        {
           // txtSifreT.Text = "";
        }

        private void SifreAyarlari_Load(object sender, EventArgs e)
        {
            RandomSayi();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Login lgn = Application.OpenForms["Login"] as Login;
            string k_Adi = lgn.textEdit1.Text;
            //string sifre = lgn.textEdit2.Text;
            string sorgu = "select * from Login where k_Adi='" + k_Adi + "'";
            DataRow dr = f.GetDataRow(sorgu);
            int k_id = int.Parse(dr["id"].ToString());
            string sorgu1 = "select * from iletisimBilgileri where k_id='" + k_id + "'";
            DataRow dr1 = f.GetDataRow(sorgu1);
            string tel = dr1["T_Numarasi"].ToString();
            
            int top = int.Parse(S1.Text)+int.Parse(S2.Text);
            
            


            if (txttel.Text != "" && txttel.Text == tel.ToString() && top == int.Parse(txtsayilar.Text))
            {
                Random rnd1 = new Random();
                dogKodu1 = rnd1.Next(100000, 1000000);
                //dogKodu1 = dogKodu;

                string ApiAdres = "http://www.dakiksms.com/api/xml_api_ileri.php";

                string cevap = yonetim.DakikSMSMesajGonder(txttel.Text, dogKodu1.ToString(), ApiAdres);
                mesajDurumu.Text = cevap;
                simpleButton2.Enabled = true;
                simpleButton1.Enabled = false;
                
            }
            else
            {
                if (top != int.Parse(txtsayilar.Text))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("SAYILARIN TOPLAMINDA HATA VAR !");
                }
                else if (txttel.Text != tel.ToString())
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("TELEFON NUMARANIZI KONTROL EDİNİZ !");
                }
                
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            RandomSayi();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txtDKodu.Text==dogKodu1.ToString())
            {
                if (txtSifre.Text==txtSifreT.Text)
                {
                    Login lgn = Application.OpenForms["Login"] as Login;
                    string k_Adi = lgn.textEdit1.Text;
                    string sorgu = "update Login set Sifre='" + txtSifre.Text + "' where k_Adi='" + k_Adi + "'";
                    DataRow dr = f.GetDataRow(sorgu);
                    alertControl1.Show(this, "İŞLEM BAŞARILI .", "ŞİFRENİZ BAŞARIYLA DEĞİŞTİRİLDİ .");

                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("ŞİFRELER AYNI DEĞİL. LÜTFEN KONTROL EDİNİZ.");
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("DOĞRULAMA KODUNU HATALI GİRDİNİZ. LÜTFEN KONTROL EDİNİZ !");
            }
        }
    }
}
