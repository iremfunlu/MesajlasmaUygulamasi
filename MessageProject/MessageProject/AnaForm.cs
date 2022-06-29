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
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChatSayfasi chat = Application.OpenForms["ChatSayfasi"] as ChatSayfasi;
            if (chat != null)
            {
                chat.Activate();
            }
            else
            {
                chat = new ChatSayfasi();
                chat.MdiParent = this;
                chat.Show();
            }
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HesapAyarlari hesap = Application.OpenForms["HesapAyarlari"] as HesapAyarlari;
            if (hesap != null)
            {
                hesap.Activate();
            }
            else
            {
                hesap = new HesapAyarlari();
                hesap.MdiParent = this;
                hesap.Show();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            iletisimAyarlari iletisim = Application.OpenForms["iletisimAyarlari"] as iletisimAyarlari;
            if (iletisim != null)
            {
                iletisim.Activate();
            }
            else
            {
                iletisim = new iletisimAyarlari();
                iletisim.MdiParent = this;
                iletisim.Show();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SifreAyarlari sifre = Application.OpenForms["SifreAyarlari"] as SifreAyarlari;
            if (sifre != null)
            {
                sifre.Activate();
            }
            else
            {
                sifre = new SifreAyarlari();
                sifre.MdiParent = this;
                sifre.Show();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KisiselChat chat = Application.OpenForms["KisiselChat"] as KisiselChat;
            if (chat != null)
            {
                chat.Activate();
            }
            else
            {
                chat = new KisiselChat();
                chat.MdiParent = this;
                chat.Show();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
            Login lgn = new Login();
            lgn.Show();
        }

        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login lgn = new Login();
            lgn.Show();
        }
        private void AnaForm_Load(object sender, EventArgs e)
        {

        }

        private void AnaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Login ac = new Login();
            //ac.Show();
        }
    }
}
