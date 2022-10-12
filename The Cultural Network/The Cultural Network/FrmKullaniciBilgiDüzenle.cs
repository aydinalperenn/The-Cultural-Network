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
    public partial class FrmKullaniciBilgiDüzenle : Form
    {
        public FrmKullaniciBilgiDüzenle()
        {
            InitializeComponent();
        }


        public string mail;
        SqlBaglantisi bgl = new SqlBaglantisi();

        private void FrmKullaniciBilgiDüzenle_Load(object sender, EventArgs e)
        {
            TxtMail.Text = mail;
            SqlCommand komutBilgiCek = new SqlCommand("Select * From Tbl_Kullanicilar where KullaniciMail = @p1", bgl.baglanti());
            komutBilgiCek.Parameters.AddWithValue("@p1", TxtMail.Text);
            SqlDataReader dr = komutBilgiCek.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                MskTelefon.Text = dr[4].ToString();
                TxtSifre.Text = dr[5].ToString();
                CmbCinsiyet.Text = dr[6].ToString();
            }

        }

        private void BtnBilgileriGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutGuncelle = new SqlCommand("update Tbl_Kullanicilar set KullaniciAd = @p1, KullaniciSoyad = @p2, KullaniciTelefon = @p3, KullaniciSifre = @p4, kullaniciCinsiyet = @p5 where KullaniciMail = @p6", bgl.baglanti());
            komutGuncelle.Parameters.AddWithValue("@p1", TxtAd.Text);
            komutGuncelle.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komutGuncelle.Parameters.AddWithValue("@p3", MskTelefon.Text);
            komutGuncelle.Parameters.AddWithValue("@p4", TxtSifre.Text);
            komutGuncelle.Parameters.AddWithValue("@p5", CmbCinsiyet.Text);
            komutGuncelle.Parameters.AddWithValue("@p6", TxtMail.Text);
            komutGuncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FrmKullaniciDetay fr = (FrmKullaniciDetay)Application.OpenForms["FrmKullaniciDetay"];
            fr.LblAdSoyad.Text = TxtAd.Text+ " " + TxtSoyad.Text;

        }
    }
}
