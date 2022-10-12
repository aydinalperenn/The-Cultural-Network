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
    public partial class FrmSirketDetay : Form
    {
        public FrmSirketDetay()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        public string id;
        public string sirketID;
        public string mail;

        private void temizle()
        {
            TxtResimYolu.Clear();
            TxtEtkUcreti.Clear();
            TxtEtkSatisSayisi.Clear();
            TxtEtkKapasitesi.Clear();
            TxtEtkID.Clear();
            TxtEtkAdi.Clear();
            CmbEtkSehirleri.Text = "";
            CmbKategori.Text = "";
            MskEtkSaati.Clear();
            MskEtkTarihi.Clear();

            TxtEtkAdi.Focus();
        }
        



        private void FrmSirketDetay_Load(object sender, EventArgs e)
        {
            // Kategorileri comboboxa aktarma
            SqlCommand komutKategoriCekme = new SqlCommand("Select AlanAd from Tbl_Alanlar", bgl.baglanti());
            SqlDataReader dr1 = komutKategoriCekme.ExecuteReader();
            while (dr1.Read())
            {
                CmbKategori.Items.Add(dr1[0]);
            }
            bgl.baglanti().Close();
            TxtEtkID.Text = id;

            LblSirketMaili.Text = mail;


            // Şirket Adı ve Bakiyesi
            
            SqlCommand komutAdveBakiyeYazdirma = new SqlCommand("Select SirketAd, SirketBakiye, SirketID From Tbl_Sirketler where SirketMail=@p1", bgl.baglanti());
            komutAdveBakiyeYazdirma.Parameters.AddWithValue("@p1", LblSirketMaili.Text);
            SqlDataReader dr2 = komutAdveBakiyeYazdirma.ExecuteReader();
            while (dr2.Read())
            {
                LblSirketAdi.Text = dr2[0].ToString();
                LblBakiye.Text = dr2[1].ToString();
                sirketID = dr2[2].ToString();

                bgl.baglanti().Close();
            }

            // Etkinlikler
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Etkinlikler where EtkinlikSirket='" + LblSirketAdi.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }


        private void BtnCikis_Click(object sender, EventArgs e)
        {
            FrmGirisler frg = new FrmGirisler();
            frg.Show();
            this.Close();
        }

        private void BtnBilgiDuzenle_Click(object sender, EventArgs e)
        {


            FrmSirketBilgiDuzenle fr = new FrmSirketBilgiDuzenle();
            fr.sirketID = sirketID;
            fr.Show();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
            fr.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtEtkID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtEtkAdi.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            CmbEtkSehirleri.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbKategori.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskEtkTarihi.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            MskEtkSaati.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            TxtEtkUcreti.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            TxtEtkSatisSayisi.Text = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            TxtEtkKapasitesi.Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            TxtResimYolu.Text = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            
                string sifir = "0";
                SqlCommand komutKaydet = new SqlCommand("insert into Tbl_Etkinlikler (EtkinlikAd,EtkinlikSehir,EtkinlikAlan,EtkinlikSirket,EtkinlikTarih,EtkinlikSaat,EtkinlikUcret,EtkinlikKapasite,EtkinlikSatisSayisi,EtkinlikDurum,EtkinlikResim) values (@e1,@e2,@e3,@e4,@e5,@e6,@e7,@e8,@e9,@e10,@e11)", bgl.baglanti());
                komutKaydet.Parameters.AddWithValue("@e1", TxtEtkAdi.Text);
                komutKaydet.Parameters.AddWithValue("@e2", CmbEtkSehirleri.Text);
                komutKaydet.Parameters.AddWithValue("@e3", CmbKategori.Text);
                komutKaydet.Parameters.AddWithValue("@e4", LblSirketAdi.Text);
                komutKaydet.Parameters.AddWithValue("@e5", MskEtkTarihi.Text);
                komutKaydet.Parameters.AddWithValue("@e6", MskEtkSaati.Text);
                komutKaydet.Parameters.AddWithValue("@e7", TxtEtkUcreti.Text);
                komutKaydet.Parameters.AddWithValue("@e8", TxtEtkKapasitesi.Text);
                komutKaydet.Parameters.AddWithValue("@e9", sifir);
                komutKaydet.Parameters.AddWithValue("@e10", "False");
                komutKaydet.Parameters.AddWithValue("@e11", TxtResimYolu.Text);

                komutKaydet.ExecuteNonQuery();
                bgl.baglanti().Close();


                MessageBox.Show("Etkinlik başarıyla oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Etkinlikler
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Etkinlikler where EtkinlikSirket='" + LblSirketAdi.Text + "'", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;
           
                       

            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutEtkSil = new SqlCommand("Delete from Tbl_Etkinlikler where EtkinlikId=@p1", bgl.baglanti());
            komutEtkSil.Parameters.AddWithValue("@p1", TxtEtkID.Text);
            komutEtkSil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Etkinlik silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TxtEtkID.Clear();
            

            // datatable güncelleme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Etkinlikler where EtkinlikSirket='" + LblSirketAdi.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand KomutEtkGuncelle = new SqlCommand("Update Tbl_Etkinlikler set EtkinlikAd=@e2, EtkinlikAlan=@e3, EtkinlikTarih=@e4, EtkinlikSaat=@e5, EtkinlikSehir=@e6, EtkinlikUcret=@e7, EtkinlikKapasite=@e8, EtkinlikSatisSayisi=@e9, EtkinlikResim=@e10 where EtkinlikID=@e1", bgl.baglanti());
            KomutEtkGuncelle.Parameters.AddWithValue("@e1",TxtEtkID.Text);
            KomutEtkGuncelle.Parameters.AddWithValue("@e2",TxtEtkAdi.Text);
            KomutEtkGuncelle.Parameters.AddWithValue("@e3",CmbKategori.Text);
            KomutEtkGuncelle.Parameters.AddWithValue("@e4",MskEtkTarihi.Text);
            KomutEtkGuncelle.Parameters.AddWithValue("@e5",MskEtkSaati.Text);
            KomutEtkGuncelle.Parameters.AddWithValue("@e6",CmbEtkSehirleri.Text);
            KomutEtkGuncelle.Parameters.AddWithValue("@e7",TxtEtkUcreti.Text);
            KomutEtkGuncelle.Parameters.AddWithValue("@e8",TxtEtkKapasitesi.Text);
            KomutEtkGuncelle.Parameters.AddWithValue("@e9",TxtEtkSatisSayisi.Text);
            KomutEtkGuncelle.Parameters.AddWithValue("@e10",TxtResimYolu.Text);
            KomutEtkGuncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Etkinlik güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // datatable güncelleme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Etkinlikler where EtkinlikSirket='" + LblSirketAdi.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            temizle();

        }

        private void BtnResimEkle_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            TxtResimYolu.Text = openFileDialog1.FileName;
        }

        private void etkinliğiİnceleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int etkinlikID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["EtkinlikID"].Value.ToString());

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
