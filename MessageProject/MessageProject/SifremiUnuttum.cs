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
    public partial class SifremiUnuttum : Form
    {
        Fonksiyonlar f = new Fonksiyonlar();
        KodYonetim Yonetim = new KodYonetim();
        public SifremiUnuttum()
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

        public int dogKodu1;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int top = int.Parse(S1.Text) + int.Parse(S2.Text);

            if (txttel.Text != "" &&  top == int.Parse(txtsayilar.Text))
            {
                Random rnd1 = new Random();
                dogKodu1 = rnd1.Next(100000, 1000000);
                

                string ApiAdres = "http://www.dakiksms.com/api/xml_api_ileri.php";

                string cevap = Yonetim.DakikSMSMesajGonder(txttel.Text, dogKodu1.ToString(), ApiAdres);
                mesajDurumu.Text = cevap;
                simpleButton4.Enabled = true;

            }
            else
            {
                if (top != int.Parse(txtsayilar.Text))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("SAYILARIN TOPLAMINDA HATA VAR !");
                }
                

            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (textEdit2.Text == dogKodu1.ToString())
            {
                if (textEdit3.Text == textEdit1.Text)
                {
                    string sorgu1 = "select * from iletisimBilgileri where T_Numarasi='" + txttel.Text + "'";
                    DataRow dr1 = f.GetDataRow(sorgu1);
                    int k_id = int.Parse(dr1["k_id"].ToString());
                    string sorgu = "update Login set Sifre='" + textEdit3.Text + "' where id='" + k_id + "'";
                    DataRow dr = f.GetDataRow(sorgu);
                    string sorgu2 = "select * from Login where id='" + k_id + "'";
                    DataRow dr2=f.GetDataRow(sorgu2);
                    string k_Adi = dr2["k_Adi"].ToString();
                    string mesaj = "KULLANICI ADINIZ '" + k_Adi + "'";
                    alertControl1.Show(this, "İŞLEM BAŞARILI .", "ŞİFRENİZ BAŞARIYLA DEĞİŞTİRİLDİ .");
                    DevExpress.XtraEditors.XtraMessageBox.Show("KULLANICI ADINIZ CEP TELEFONUNUZA İLETİLDİ.");
                    string ApiAdres = "http://www.dakiksms.com/api/xml_api_ileri.php";

                    string cevap = Yonetim.DakikSMSMesajGonder(txttel.Text, mesaj.ToString(), ApiAdres);
                    mesajDurumu.Text = cevap;
                    SifremiUnuttum frm = new SifremiUnuttum();
                    frm.Close();
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

        private void SifremiUnuttum_Load(object sender, EventArgs e)
        {
            RandomSayi();
            txtsayilar.Focus();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            RandomSayi();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            string sorgu1 = "select * from iletisimBilgileri where T_Numarasi='" + txttel.Text + "'";
            DataRow dr1 = f.GetDataRow(sorgu1);
            string k_id = dr1["T_Numarasi"].ToString();
            MessageBox.Show(k_id);
        }
    }
}
