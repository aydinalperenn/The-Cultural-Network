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
    public partial class FrmKullaniciBiletlerim : Form
    {
        public FrmKullaniciBiletlerim()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        

   

        private void FrmKullaniciBiletlerim_Load(object sender, EventArgs e)
        {
            FrmKullaniciDetay frm = (FrmKullaniciDetay)Application.OpenForms["FrmKullaniciDetay"];
            LblAktarmaBiletlerim.Text = frm.lblBiletlerimKullaniciID.Text;

            // Etkinlik Listesi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select KullaniciAdSoyad,EtkinlikAd,BiletSayisi,ToplamFiyat, EtkinlikID From Tbl_Biletler where KullaniciID='" + LblAktarmaBiletlerim.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void detayGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int etkinlikID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["EtkinlikID"].Value.ToString());

                if (etkinlikID != 0)
                {
                    FrmModeratorEtkGoster f = new FrmModeratorEtkGoster();
                    f.EtkinlikID = etkinlikID.ToString();
                    f.Show();
                }

            }
        }
    }
}
