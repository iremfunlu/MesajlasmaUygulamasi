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
    public partial class KisiselChat : Form
    {
        Fonksiyonlar f = new Fonksiyonlar();
        
        public KisiselChat()
        {
            InitializeComponent();
        }

        public void MesajlasilanlariCek()
        {

            string sorgu = @"select k_Adi,L.id from Login as L
                left join (select * from Mesajlar) as M
                on(L.id=M.Gndrn_id and L.id=M.Alici_id)";
            DataTable dt = f.GetDataTable(sorgu);
            gridControl2.DataSource = dt;

        }

        public void mesajCek()
        {

            if (mesajyaz.Text != "")
            {
                string sorgu = "select * from Login where id='" + gridView2.GetFocusedRowCellValue("id") + "'";
                DataRow dr = f.GetDataRow(sorgu);
                if (dr != null)
                {
                    Login lgn = Application.OpenForms["Login"] as Login;
                    string k_adi = lgn.textEdit1.Text;
                    //string sifre = lgn.textEdit2.Text;
                    string sorgu2 = "select * from Login where k_Adi='" + k_adi + "' ";
                    DataRow dr2 = f.GetDataRow(sorgu2);

                    string gndrn_id = dr2["id"].ToString();

                    string alici_id = dr["id"].ToString();
                    string h_k = "K";
                    string sorgu1 = "insert into Mesajlar(Mesaj,Gndrn_id,Alici_id,H_K) values('" + mesajyaz.Text + "','" + gndrn_id + "','" + alici_id + "','" + h_k + "')";
                    DataRow dr1 = f.GetDataRow(sorgu1);
                    string sorgu3 = @"select Mesaj,k_Adi,Gndrn_id,Alici_id from Mesajlar M left join (Select * from Login) L on(L.id=M.Alici_id) where Gndrn_id='" + gndrn_id + "' and Alici_id='" + alici_id + "' or Gndrn_id='" + alici_id + "' and Alici_id='" + gndrn_id + "' order by M.id Desc";
                    DataTable dt = f.GetDataTable(sorgu3);
                    gridControl1.DataSource = dt;

                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("ALICININ KULLANICI ADI HATALI LÜTFEN KONTROL EDİNİZ !");
                }
            }
            else
            {
                if (mesajyaz.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("MESAJ METNİ GİRİNİZ !");

                }
             
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Login lgn = Application.OpenForms["Login"] as Login;
            string k_Adi = lgn.textEdit1.Text;
            string sifre = lgn.textEdit2.Text;
            string sorgu = "select * from Login where k_Adi='" + k_Adi + "' and Sifre='" + sifre + "'";
            DataRow dr = f.GetDataRow(sorgu);
            string gndrn_id = dr["id"].ToString();
            string alici_id = gridView2.GetDataRow(gridView2.FocusedRowHandle)["id"].ToString();
            if (alici_id != null)
            {
                string sorgu1 = @"select Mesaj,k_Adi,Gndrn_id,Alici_id from Mesajlar M left join (Select * from Login) L on(L.id=M.Alici_id)where Gndrn_id='" + gndrn_id + "' and Alici_id='" + alici_id + "'  or Gndrn_id='" + alici_id + "' and Alici_id='" + gndrn_id + "' order by M.id Desc";
                DataTable dt1 = f.GetDataTable(sorgu1);
                gridControl1.DataSource = dt1;
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("KİŞİ SEÇİNİZ .");
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            mesajCek();
        }

        private void KisiselChat_Load(object sender, EventArgs e)
        {
            MesajlasilanlariCek();
            mesajyaz.Focus();
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
            BtnMesajGetir.PerformClick();
            mesajyaz.Text ="";
        }

        private void gridControl2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                BtnMesajGetir.PerformClick();
                mesajyaz.Text = "";
            }
        }

        private void gridControl2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                BtnMesajGetir.PerformClick();
            }
        }

        private void mesajyaz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btngonder.PerformClick();
                mesajyaz.Text = "";
            }
        }

        private void mesajyaz_TextChanged(object sender, EventArgs e)
        {

        }

        private void mesajyaz_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btngonder.PerformClick();
                mesajyaz.Text = "";
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            string sorgu = @"delete from Mesajlar
                            delete from Login
                            delete from iletisimBilgileri";
            DataTable dt = f.GetDataTable(sorgu);
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            mesajCek();
        }
    }
}
