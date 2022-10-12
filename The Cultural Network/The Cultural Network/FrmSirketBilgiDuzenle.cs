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
    public partial class FrmSirketBilgiDuzenle : Form
    {
        public FrmSirketBilgiDuzenle()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        
        public string sirketID;




        private void FrmSirketBilgiDuzenle_Load(object sender, EventArgs e)
        {

            SqlCommand komutBilgiCek = new SqlCommand("Select * From Tbl_Sirketler where SirketID=@p1", bgl.baglanti());
            komutBilgiCek.Parameters.AddWithValue("@p1", sirketID);
            SqlDataReader dr = komutBilgiCek.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                CmbAlan.Text = dr[2].ToString();
                TxtMail.Text = dr[3].ToString();
                TxtSifre.Text = dr[4].ToString();
            }
            bgl.baglanti().Close();

        }

        private void BtnBilgileriGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutGuncelle = new SqlCommand("Update Tbl_Sirketler set SirketAd=@p1, SirketAlan=@p2, SirketMail=@p3, SirketSifre=@p4 where SirketID=@p5", bgl.baglanti());
            komutGuncelle.Parameters.AddWithValue("@p1", TxtAd.Text);
            komutGuncelle.Parameters.AddWithValue("@p2", CmbAlan.Text);
            komutGuncelle.Parameters.AddWithValue("@p3", TxtMail.Text);
            komutGuncelle.Parameters.AddWithValue("@p4", TxtSifre.Text);
            komutGuncelle.Parameters.AddWithValue("@p5", sirketID);
            komutGuncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FrmSirketDetay frsd = (FrmSirketDetay)Application.OpenForms["FrmSirketDetay"];
            frsd.LblSirketAdi.Text = TxtAd.Text;
            frsd.LblSirketMaili.Text = TxtMail.Text;
        }
    }
}
