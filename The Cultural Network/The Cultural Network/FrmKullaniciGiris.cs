using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace The_Cultural_Network
{
    public partial class FrmKullaniciGiris : Form
    {
        public FrmKullaniciGiris()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();




        private void BtnUyeOl_Click(object sender, EventArgs e)
        {
            FrmKullaniciKayit fr = new FrmKullaniciKayit();
            fr.Show();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Kullanicilar where KullaniciMail=@p1 and KullaniciSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtMail.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmKullaniciDetay frkd = new FrmKullaniciDetay();
                frkd.mail = TxtMail.Text;
                frkd.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bgl.baglanti().Close();
        }
    }
}
