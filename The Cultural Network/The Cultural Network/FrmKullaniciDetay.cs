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
    public partial class FrmKullaniciDetay : Form
    {
        public FrmKullaniciDetay()
        {
            InitializeComponent();
        }

        public string mail;

        private string adSoyad;
        public string ADSOYAD
        {
            get
            {
                return adSoyad;
            }
            set
            {
                adSoyad = value;
            }
        }


        private void EtkBilgGorunurYap()
        {
            LblEtkAd.Visible = true;
            LblEtkKategori.Visible = true;
            LblEtkSaat.Visible = true;
            LblEtkSehir.Visible = true;
            LblEtkSirket.Visible = true;
            LblEtkTarih.Visible = true;
            LblEtkUcret.Visible = true;
            PcxEtkResim.Visible = true;
        }

        private void EtkBilgGorunmezYap()
        {
            LblEtkAd.Visible = false;
            LblEtkKategori.Visible = false;
            LblEtkSaat.Visible = false;
            LblEtkSehir.Visible = false;
            LblEtkSirket.Visible = false;
            LblEtkTarih.Visible = false;
            LblEtkUcret.Visible = false;
            PcxEtkResim.Visible = false;
        }

        private void temizle()
        {
            TxtID.Clear();
            CmbKategori.Text = "";
            CmbSirket.Text = "";
            CmbSehir.Text = "";
            TxtAdet.Clear();
        }



        SqlBaglantisi bgl = new SqlBaglantisi();



        private void FrmKullaniciDetay_Load(object sender, EventArgs e)
        {
            LblMail.Text = mail;

            // Ad-Soyad ve Bakiye Çekme
            SqlCommand komutKulBilgileri = new SqlCommand("Select KullaniciAd,KullaniciSoyad,KullaniciBakiye, KullaniciID From Tbl_Kullanicilar where KullaniciMail=@p1", bgl.baglanti());
            komutKulBilgileri.Parameters.AddWithValue("@p1", LblMail.Text);
            SqlDataReader dr = komutKulBilgileri.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];
                LblBakiye.Text = dr[2].ToString();
                lblBiletlerimKullaniciID.Text = dr[3].ToString();
            }
            bgl.baglanti().Close();



            // Ana Sayfa
            // *********

            // Kategorileri Çekme
            SqlCommand komutKategoriCekme = new SqlCommand("Select AlanAd From Tbl_Alanlar", bgl.baglanti());
            SqlDataReader dr2 = komutKategoriCekme.ExecuteReader();
            while (dr2.Read())
            {
                CmbKategori.Items.Add(dr2[0].ToString());
            }
            bgl.baglanti().Close();

        }

        private void CmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbSirket.Items.Clear();
            CmbSirket.Text = "";
            CmbSehir.Text = "";
            TxtAdet.Text = "";

            SqlCommand komutSirketAdiCek = new SqlCommand("Select SirketAd From Tbl_Sirketler where SirketAlan=@p1", bgl.baglanti());
            komutSirketAdiCek.Parameters.AddWithValue("@p1", CmbKategori.Text);
            SqlDataReader dr3 = komutSirketAdiCek.ExecuteReader();
            while (dr3.Read())
            {
                CmbSirket.Items.Add(dr3[0].ToString());
            }
            bgl.baglanti().Close();

            dataGridView2.DataSource = null;
            TxtID.Clear();

            EtkBilgGorunmezYap();

        }

        private void CmbSirket_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbSehir.Items.Clear();
            CmbSehir.Text = "";
            TxtAdet.Text = "";

            SqlCommand komutKategoriCek = new SqlCommand("Select distinct (EtkinlikSehir) From Tbl_Etkinlikler where EtkinlikSirket=@parameter and EtkinlikDurum=0", bgl.baglanti());
            komutKategoriCek.Parameters.AddWithValue("@parameter", CmbSirket.Text);
            SqlDataReader dr = komutKategoriCek.ExecuteReader();
            while (dr.Read())
            {
                CmbSehir.Items.Add(dr[0].ToString());
            }
            bgl.baglanti().Close();

            dataGridView2.DataSource = null;
            TxtID.Clear();

            EtkBilgGorunmezYap();

        }

        private void CmbSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtAdet.Text = "";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Etkinlikler where EtkinlikAlan ='" + CmbKategori.Text + "'" + " and EtkinlikSirket='" + CmbSirket.Text + "' and EtkinlikDurum=0 and EtkinlikSehir='" + CmbSehir.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;

            TxtID.Clear();

            EtkBilgGorunmezYap();

        }

        private void BtnBilgiDuzenle_Click(object sender, EventArgs e)
        {
            FrmKullaniciBilgiDüzenle fr = new FrmKullaniciBilgiDüzenle();
            fr.mail = LblMail.Text;
            fr.Show();

        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            FrmGirisler frg = new FrmGirisler();
            frg.Show();
            this.Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            TxtID.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            CmbSehir.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();

            // Etkinliği sağ tarafa çekme
            PcxEtkResim.ImageLocation = dataGridView2.Rows[secilen].Cells[11].Value.ToString();
            LblEtkAd.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            LblEtkSirket.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
            LblEtkKategori.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            LblEtkSehir.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            LblEtkTarih.Text = dataGridView2.Rows[secilen].Cells[6].Value.ToString();
            LblEtkSaat.Text = dataGridView2.Rows[secilen].Cells[7].Value.ToString();
            LblEtkUcret.Text = dataGridView2.Rows[secilen].Cells[8].Value.ToString();

            // Etkinlik Bilgileri (Sağ Taraf)'i görünür yap
            EtkBilgGorunurYap();

        }

        private void BtnBiletAl_Click(object sender, EventArgs e)
        {
            int kapasite = 0;
            int satisSayisi = 0;
            int ucret = 0;
            int bakiye = Convert.ToInt32(LblBakiye.Text);


            if (TxtID.Text != "" || TxtID.Text != String.Empty)
            {
                if (TxtAdet.Text != "" || TxtAdet.Text != String.Empty)
                {
                    int adet = Convert.ToInt32(TxtAdet.Text);

                    SqlCommand komutVeriCek = new SqlCommand("Select EtkinlikKapasite, EtkinlikSatisSayisi, EtkinlikUcret From Tbl_Etkinlikler where EtkinlikID=@x", bgl.baglanti());
                    komutVeriCek.Parameters.AddWithValue("@x", TxtID.Text);
                    SqlDataReader KapveSatSay = komutVeriCek.ExecuteReader();
                    while (KapveSatSay.Read())
                    {
                        kapasite = Convert.ToInt32(KapveSatSay[0]);
                        satisSayisi = Convert.ToInt32(KapveSatSay[1]);
                        ucret = adet * Convert.ToInt32(KapveSatSay[2]);
                        bakiye -= ucret;
                        bgl.baglanti().Close();
                    }

                    if (adet > 0)
                    {
                        if (bakiye >= 0)
                        {
                            satisSayisi += adet;
                            if (satisSayisi > kapasite)
                            {
                                MessageBox.Show("Bilet satın alımı gerçekleşmedi.\nEtkinlik kapasitesini göz önüne alarak işlem yapınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (satisSayisi != 0 && satisSayisi == kapasite)
                                {
                                    SqlCommand komutEtkinlikDurumuGuncelle = new SqlCommand("Update Tbl_Etkinlikler set EtkinlikDurum=@p2 where EtkinlikID=@p1", bgl.baglanti());
                                    komutEtkinlikDurumuGuncelle.Parameters.AddWithValue("@p1", TxtID.Text);
                                    komutEtkinlikDurumuGuncelle.Parameters.AddWithValue("@p2", "True");
                                    komutEtkinlikDurumuGuncelle.ExecuteNonQuery();
                                    bgl.baglanti().Close();

                                    temizle();

                                }

                                int sirketBakiye = 0;

                                SqlCommand komutBiletAl = new SqlCommand("Update Tbl_Etkinlikler set EtkinlikSatisSayisi=@p1 where EtkinlikID= @p2", bgl.baglanti());
                                komutBiletAl.Parameters.AddWithValue("@p1", satisSayisi.ToString());
                                komutBiletAl.Parameters.AddWithValue("@p2", TxtID.Text);
                                komutBiletAl.ExecuteNonQuery();
                                bgl.baglanti().Close();


                                SqlCommand komutKullaniciBakiyeAktarma = new SqlCommand("Update Tbl_Kullanicilar set KullaniciBakiye=@p1 where KullaniciMail=@p2", bgl.baglanti());
                                komutKullaniciBakiyeAktarma.Parameters.AddWithValue("@p1", bakiye.ToString());
                                komutKullaniciBakiyeAktarma.Parameters.AddWithValue("@p2", LblMail.Text);
                                komutKullaniciBakiyeAktarma.ExecuteNonQuery();
                                bgl.baglanti().Close();


                                string kullaniciId = "";
                                SqlCommand komutKullaniciBakiyeCekme = new SqlCommand("Select KullaniciBakiye, KullaniciID From Tbl_Kullanicilar where KullaniciMail=@p1", bgl.baglanti());
                                komutKullaniciBakiyeCekme.Parameters.AddWithValue("@p1", LblMail.Text);
                                SqlDataReader dr = komutKullaniciBakiyeCekme.ExecuteReader();
                                while (dr.Read())
                                {
                                    LblBakiye.Text = dr[0].ToString();
                                    kullaniciId = dr[1].ToString();
                                }
                                bgl.baglanti().Close();


                                // Şirket bakiyesi çekme

                                SqlCommand komutSirketBakiyesiCekme = new SqlCommand("Select SirketBakiye From Tbl_Sirketler where SirketAd=@y1", bgl.baglanti());
                                komutSirketBakiyesiCekme.Parameters.AddWithValue("@y1", CmbSirket.Text);
                                SqlDataReader dry = komutSirketBakiyesiCekme.ExecuteReader();
                                while (dry.Read())
                                {
                                    sirketBakiye = Convert.ToInt32(dry[0].ToString());
                                }
                                sirketBakiye += ucret;
                                bgl.baglanti().Close();



                                // Şirket Bakiyesi Aktarma

                                SqlCommand komutSirketBakiyesiAktarma = new SqlCommand("Update Tbl_Sirketler set SirketBakiye=@l1 where SirketAd=@l2", bgl.baglanti());
                                komutSirketBakiyesiAktarma.Parameters.AddWithValue("@l1", sirketBakiye.ToString());
                                komutSirketBakiyesiAktarma.Parameters.AddWithValue("@l2", CmbSirket.Text);
                                komutSirketBakiyesiAktarma.ExecuteNonQuery();
                                bgl.baglanti().Close();


                                // Biletlerim Tablosuna Bilet Ekleme
                                SqlCommand komutBiletlerim = new SqlCommand("insert into Tbl_Biletler (KullaniciID,EtkinlikID,BiletSayisi,KullaniciAdSoyad,EtkinlikAd,ToplamFiyat) values (@b1,@b2,@b3,@b4,@b5,@b6)", bgl.baglanti());
                                komutBiletlerim.Parameters.AddWithValue("@b1", kullaniciId);
                                komutBiletlerim.Parameters.AddWithValue("@b2", TxtID.Text);
                                komutBiletlerim.Parameters.AddWithValue("@b3", adet);
                                komutBiletlerim.Parameters.AddWithValue("@b4", LblAdSoyad.Text);
                                komutBiletlerim.Parameters.AddWithValue("@b5", LblEtkAd.Text);
                                komutBiletlerim.Parameters.AddWithValue("@b6", ucret.ToString());
                                komutBiletlerim.ExecuteNonQuery();
                                bgl.baglanti().Close();



                                MessageBox.Show("Bilet satın alımı başarıyla gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                //Combobox yenileme
                                DataTable dt = new DataTable();
                                SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Etkinlikler where EtkinlikAlan ='" + CmbKategori.Text + "'" + " and EtkinlikSirket='" + CmbSirket.Text + "' and EtkinlikDurum=0 and EtkinlikSehir='" + CmbSehir.Text + "'", bgl.baglanti());
                                da.Fill(dt);
                                dataGridView2.DataSource = dt;

                            }


                        }

                        else
                        {
                            MessageBox.Show("İşlem gerçekleşmedi!\nYetersiz bakiye.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("İşlem gerçekleşmedi!\nAlınacak bilet sayısı sıfırdan büyük olmalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("İşlem gerçekleşmedi!\nAlınacak bilet sayısı boş bırakılmamalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("İşlem gerçekleşmedi!\nLütfen önce listeden etkinlik seçimi yapın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }                    

        }

        private void BtnEtkinlikListesi_Click(object sender, EventArgs e)
        {
            FrmEtkinlikListesiGenel freg = new FrmEtkinlikListesiGenel();
            freg.Show();
        }

        private void BtnBakiyeYükle_Click(object sender, EventArgs e)
        {
            FrmKullaniciBakiyeYukle frmkby = new FrmKullaniciBakiyeYukle();
            frmkby.ADSOYAD = LblAdSoyad.Text;
            frmkby.MAIL = LblMail.Text;
            frmkby.Show();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
            fr.Show();
        }

        private void BtnBiletlerim_Click(object sender, EventArgs e)
        {
            // string id = "";
            //SqlCommand komutKulBilgileri = new SqlCommand("Select KullaniciID From Tbl_Kullanicilar where KullaniciMail=@p1", bgl.baglanti());
            //komutKulBilgileri.Parameters.AddWithValue("@p1", LblMail.Text);
            //SqlDataReader dr = komutKulBilgileri.ExecuteReader();
            //while (dr.Read())
            //{
            //    id = dr[0].ToString();
            //}
            //bgl.baglanti().Close();

            FrmKullaniciBiletlerim fr = new FrmKullaniciBiletlerim();
            
            fr.Show();
        }

        
    }

}
