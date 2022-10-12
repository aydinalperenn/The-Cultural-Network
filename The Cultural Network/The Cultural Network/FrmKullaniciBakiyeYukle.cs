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
    public partial class FrmKullaniciBakiyeYukle : Form
    {
        public FrmKullaniciBakiyeYukle()
        {
            InitializeComponent();
        }

        private string adSoyad;
        private string mail;
        private string sifre;
        private int bakiye;

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

        public string MAIL
        {
            get
            {
                return mail;
            }
            set
            {
                mail = value;
            }
        }


        SqlBaglantisi bgl = new SqlBaglantisi();




        private void FrmKullaniciBakiyeYukle_Load(object sender, EventArgs e)
        {
            LblAdSoyad.Text = adSoyad;
            LblMail.Text = mail;           

            SqlCommand komutVeriCek = new SqlCommand("Select KullaniciBakiye, KullaniciSifre From Tbl_Kullanicilar where KullaniciMail=@p1", bgl.baglanti());
            komutVeriCek.Parameters.AddWithValue("@p1", LblMail.Text);
            SqlDataReader dr = komutVeriCek.ExecuteReader();
            while (dr.Read())
            {
                bakiye = Convert.ToInt32(dr[0].ToString());
                sifre = dr[1].ToString();
                LblBakiye.Text = bakiye.ToString();
            }
            bgl.baglanti().Close();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                string[] sembol1 = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "v", "y", "z", "q", "x", "w"};
                string[] sembol2 = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "Y", "Z", "Q", "X", "W" };
                string[] sembol3 = {"+", "-", "*", "/", "#", "!", "?", "'", "^", "%"};

                Random r = new Random();
                int s1, s2, s3, s4, s5;
                s1 = r.Next(0, sembol1.Length);
                s2 = r.Next(0, sembol2.Length);
                s3 = r.Next(0, sembol3.Length);
                s4 = r.Next(0, 10);
                s5 = r.Next(0, 10);
            
                LblCaptcha.Text = s4.ToString() + sembol1[s1].ToString() + sembol2[s2].ToString() + s5.ToString() + sembol3[s3].ToString();
                LblCaptcha.Visible = true;

            }

            else
            {
                LblCaptcha.Visible = false;
            }

        }

        private void BtnBakiyeEkle_Click(object sender, EventArgs e)
        {
            if((checkBox1.Checked == true) && (TxtSifre.Text == sifre) && (TxtKarakterler.Text == LblCaptcha.Text))
            {
                bakiye += Convert.ToInt32(TxtMiktar.Text);
                SqlCommand komutBakiyeYukle = new SqlCommand("Update Tbl_Kullanicilar set KullaniciBakiye=@x1 where KullaniciMail=@x2", bgl.baglanti());
                komutBakiyeYukle.Parameters.AddWithValue("@x1", bakiye.ToString());
                komutBakiyeYukle.Parameters.AddWithValue("@x2", LblMail.Text);
                komutBakiyeYukle.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Para yükleme işleminiz başarıyla gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmKullaniciDetay fr = (FrmKullaniciDetay)Application.OpenForms["FrmKullaniciDetay"];
                fr.LblBakiye.Text = bakiye.ToString();
                
                
                LblBakiye.Text = bakiye.ToString();
                TxtSifre.Clear();
                TxtMiktar.Clear();
                TxtKarakterler.Clear();
                checkBox1.Checked = false;

            }

            else
            {
                MessageBox.Show("Para yükleme işleminiz başarısız oldu!\nLütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
