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
    
    public partial class Login : Form
    {
        Fonksiyonlar f = new Fonksiyonlar();
        public Login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
                if (textEdit1.Text != "" && textEdit2.Text != "")
                {
                    string sorgu = "select id,Adi,SoyAdi,k_Adi,Sifre from Login where k_Adi='" + textEdit1.Text + "' and Sifre='" + textEdit2.Text + "' ";
                    DataRow dr = f.GetDataRow(sorgu);

                    if (dr == null)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("KULLANICI ADI VEYA ŞİFRE HATALI !!!");
                    }
                    else
                    {

                        AnaForm anaform = new AnaForm();
                        anaform.Show();
                        this.Hide();
                    }

                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("BOŞ GEÇİLMEMESİ GEREKEN ALANLAR VAR !!!");
                    if (textEdit1.Text == "")
                    {
                        lblk_adi.Visible = true;
                    }
                    if (textEdit2.Text == "")
                    {
                        lblsifre1.Visible = true;
                    }
                }
         
        }
    }
}
