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
    public partial class FrmKullaniciKayit : Form
    {
        public FrmKullaniciKayit()
        {
            InitializeComponent();
        }



        SqlBaglantisi bgl = new SqlBaglantisi();




        private void BtnKayıtOl_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Kullanicilar (KullaniciAd,KullaniciSoyad,KullaniciMail,KullaniciTelefon,KullaniciSifre,KullaniciCinsiyet,KullaniciBakiye) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtAd.Text);
            komut.Parameters.AddWithValue("@p2",TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3",TxtMail.Text);
            komut.Parameters.AddWithValue("@p4",MskTelefon.Text);
            komut.Parameters.AddWithValue("@p5",TxtSifre.Text);
            komut.Parameters.AddWithValue("@p6",CmbCinsiyet.Text);
            komut.Parameters.AddWithValue("@p7", 0.ToString());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            LblMailAktarma.Text = TxtMail.Text;
            FrmKullaniciGiris fr = (FrmKullaniciGiris)Application.OpenForms["FrmKullaniciGiris"];
            fr.TxtMail.Text = LblMailAktarma.Text;
            MessageBox.Show("Kaydınız başarıyla gerçekleşti.\nŞifreniz: " + TxtSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
