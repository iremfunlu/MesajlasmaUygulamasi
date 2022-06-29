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
    public partial class ChatSayfasi : Form
    {
        Fonksiyonlar f = new Fonksiyonlar();
        public ChatSayfasi()
        {
            InitializeComponent();
        }
        public void mesajcek()
        {
            string h_k="H";
            string sorgu = @"select  k_Adi,m.Mesaj,m.id from Login as l
                            left join(select * from Mesajlar) as m
                            on(l.id=m.Gndrn_id) where m.H_K='" + h_k + "' order by m.id Desc ";
            DataTable dt = f.GetDataTable(sorgu);
            gridControl1.DataSource = dt;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (mesajyaz.Text!="")
            {
                Login lgn = Application.OpenForms["Login"] as Login;
                string k_adi = lgn.textEdit1.Text;
                string sifre = lgn.textEdit2.Text;
                string sorgu1 = "select * from Login where k_Adi='" + k_adi + "' and Sifre='" + sifre + "'";
                DataRow dr1 = f.GetDataRow(sorgu1);
                string gndrn_id = dr1["id"].ToString();
                
                string h_k = "H";

                string sorgu = "insert into Mesajlar(Mesaj,Gndrn_id,H_K) values('" + mesajyaz.Text + "','" + gndrn_id + "','" + h_k + "')";
                DataRow dr = f.GetDataRow(sorgu);
                mesajcek();
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("GÖNDERİLECEK MESAJ METNİNİ GİRİNİZ .");
            }
        }

        private void ChatSayfasi_Load(object sender, EventArgs e)
        {
            mesajcek();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void mesajyaz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnGonder.PerformClick();
                mesajyaz.Text = "";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mesajyaz_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            mesajcek();
        }
    }
}
