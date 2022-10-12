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
    public partial class FrmModeratorEtkGoster : Form
    {

        public string EtkinlikID;
        SqlBaglantisi bgl = new SqlBaglantisi();




        public FrmModeratorEtkGoster()
        {
            InitializeComponent();
        }

        private void FrmModeratorEtkGoster_Load(object sender, EventArgs e)
        {

            SqlCommand komutVeriCek = new SqlCommand("Select EtkinlikAd, EtkinlikSirket, EtkinlikAlan, EtkinlikSehir, EtkinlikTarih, EtkinlikSaat, EtkinlikUcret, EtkinlikResim From Tbl_Etkinlikler where EtkinlikID=@x", bgl.baglanti());
            komutVeriCek.Parameters.AddWithValue("@x", EtkinlikID);
            SqlDataReader KapveSatSay = komutVeriCek.ExecuteReader();
            while (KapveSatSay.Read())
            {
                LblEtkAd.Text = KapveSatSay[0].ToString();
                LblEtkSirket.Text = KapveSatSay[1].ToString();
                LblEtkKategori.Text = KapveSatSay[2].ToString();
                LblEtkSehir.Text = KapveSatSay[3].ToString();
                LblEtkTarih.Text = KapveSatSay[4].ToString();
                LblEtkSaat.Text = KapveSatSay[5].ToString();
                LblEtkUcret.Text = KapveSatSay[6].ToString();
                PcxEtkResim.ImageLocation = KapveSatSay[7].ToString();

                bgl.baglanti().Close();
            }

        }
    }
}
