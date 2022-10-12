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
    public partial class FrmModeratorDetay : Form
    {
        public FrmModeratorDetay()
        {
            InitializeComponent();
        }


        public string TCnumara;
        SqlBaglantisi bgl = new SqlBaglantisi();

        public string etkinlikID;


        private void FrmModeratorDetay_Load(object sender, EventArgs e)
        {
            LblTC.Text = TCnumara;


            // Etkinlik Listesi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Etkinlikler", bgl.baglanti());
            da.Fill(dt);
            dgEtkinlik.DataSource = dt;



            // Ad Soyad
            SqlCommand komut1 = new SqlCommand("Select ModeratorAdSoyad From Tbl_Moderatorler where ModeratorTC = @p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", LblTC.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblAdSoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();



            // Kategorileri datagride aktarma
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Alanlar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView3.DataSource = dt1;

            // Şirketleri datagride aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From Tbl_Sirketler", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            


        }

        private void BtnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand komutDuyuruOlustur = new SqlCommand("insert into Tbl_Duyurular (duyuru) values (@d1)", bgl.baglanti());
            komutDuyuruOlustur.Parameters.AddWithValue("@d1", RchDuyuru.Text);
            komutDuyuruOlustur.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru başarıyla oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RchDuyuru.Clear();
        }

        private void BtnSirketİslemleri_Click(object sender, EventArgs e)
        {
            FrmModeratorSirketPaneli msp = new FrmModeratorSirketPaneli();
            msp.Show();
        }

        private void BtnKategoriIslemleri_Click(object sender, EventArgs e)
        {
            FrmModeratorAlanPaneli frmap = new FrmModeratorAlanPaneli();
            frmap.Show();
        }

        

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            FrmGirisler frg = new FrmGirisler();
            frg.Show();
            this.Close();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular frd = new FrmDuyurular();
            frd.Show();
        }

        private void detayGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgEtkinlik.Rows.Count>0)
            {
                int etkinlikID = Convert.ToInt32(dgEtkinlik.CurrentRow.Cells["EtkinlikID"].Value.ToString());

                if (etkinlikID != 0)
                {
                    FrmModeratorEtkGoster f = new FrmModeratorEtkGoster();
                    f.EtkinlikID = etkinlikID.ToString();
                    f.ShowDialog();                    
                }

            }
                       
        }
    }
}
