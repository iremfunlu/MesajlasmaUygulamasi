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
    public partial class iletisimAyarlari : Form
    {
        Fonksiyonlar f = new Fonksiyonlar();
        public iletisimAyarlari()
        {
            InitializeComponent();
        }

        public void bilgicek()
        {
            Login lgn = Application.OpenForms["Login"] as Login;
            string k_Adi = lgn.textEdit1.Text;
            
            string sorgu = "select * from Login where k_Adi='" + k_Adi + "'";
            DataRow dr = f.GetDataRow(sorgu);
            int k_id = int.Parse(dr["id"].ToString());
            string sorgu1 = "select * from iletisimBilgileri where k_id='" + k_id + "'";
            DataRow dr1 = f.GetDataRow(sorgu1);
            string tel = dr1["T_Numarasi"].ToString();
            string mail = dr1["EMail"].ToString();
            label2.Text = tel;
            label4.Text = mail;
            txtmail.Text = mail;
            txttel.Text = tel;
        }

        private void iletisimAyarlari_Load(object sender, EventArgs e)
        {
            bilgicek();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txttel.Text!=""&&txtmail.Text!="")
            {
                Login lgn=Application.OpenForms["Login"] as Login;
                string k_adi=lgn.textEdit1.Text;

                string sorgu = "update iletisimBilgileri set T_Numarasi='" + txttel.Text + "',EMail='" + txtmail.Text + "'  where T_Numarasi='" + label2.Text + "' and EMail='" + label4.Text + "'";
                DataRow dr = f.GetDataRow(sorgu);
                bilgicek();
                alertControl1.Show(this, "İŞLEM BAŞARILI", "BİLGİLERİNİZ BAŞARIYLA GÜNCELLENDİ.");

                
            }
        }
    }
}
