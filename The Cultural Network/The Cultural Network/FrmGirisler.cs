using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Cultural_Network
{
    public partial class FrmGirisler : Form
    {
        public FrmGirisler()
        {
            InitializeComponent();
        }

        private void BtnKullaniciGirisi_Click(object sender, EventArgs e)
        {
            FrmKullaniciGiris frkg = new FrmKullaniciGiris();
            frkg.Show();
            this.Hide();
        }

        private void BtnModeratorGirisi_Click(object sender, EventArgs e)
        {
            FrmModeratorGiris frmg = new FrmModeratorGiris();
            frmg.Show();
            this.Hide();
        }

        private void BtnSirketGirisi_Click(object sender, EventArgs e)
        {
            FrmSirketGiris frsg = new FrmSirketGiris();
            frsg.Show();
            this.Hide();
        }
    }
}
