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
    public partial class FrmModeratorSirketPaneli : Form
    {
        public FrmModeratorSirketPaneli()
        {
            InitializeComponent();
        }


        SqlBaglantisi bgl = new SqlBaglantisi();
        string sirketID;

        private void temizle()
        {
            TxtMail.Clear();
            TxtSifre.Clear();
            TxtSirketAdi.Clear();
            CmbAlan.Text = "";
            TxtSirketAdi.Focus();
        }



        private void FrmModeratorSirketPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Sirketler", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;


            // Alanları Combobox'a Çekme
            SqlCommand komutAlanCekme = new SqlCommand("Select AlanAd from Tbl_Alanlar", bgl.baglanti());
            SqlDataReader dr1 = komutAlanCekme.ExecuteReader();
            while (dr1.Read())
            {
                CmbAlan.Items.Add(dr1[0]);
            }
            bgl.baglanti().Close();



        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komutEkle = new SqlCommand("insert into Tbl_Sirketler (SirketAd, SirketAlan, SirketMail, SirketSifre, SirketBakiye) values (@s1, @s2, @s3, @s4, @s5)",bgl.baglanti());
            komutEkle.Parameters.AddWithValue("@s1",TxtSirketAdi.Text);
            komutEkle.Parameters.AddWithValue("@s2",CmbAlan.Text);
            komutEkle.Parameters.AddWithValue("@s3",TxtMail.Text);
            komutEkle.Parameters.AddWithValue("@s4",TxtSifre.Text);
            komutEkle.Parameters.AddWithValue("@s5", 0.ToString());
            komutEkle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şirket başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //datatable güncelleme
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Sirketler", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            sirketID = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtSirketAdi.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            CmbAlan.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtMail.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutSil = new SqlCommand("delete from Tbl_Sirketler where SirketID = @p1", bgl.baglanti());
            komutSil.Parameters.AddWithValue("@p1", sirketID);
            komutSil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şirket silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //datatable güncelleme
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Sirketler", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutGuncelle = new SqlCommand("Update Tbl_Sirketler set SirketAd=@p1, SirketAlan=@p2, SirketSifre=@p3, SirketMail=@p5 where SirketID=@p4", bgl.baglanti());
            komutGuncelle.Parameters.AddWithValue("@p1", TxtSirketAdi.Text);
            komutGuncelle.Parameters.AddWithValue("@p2", CmbAlan.Text);
            komutGuncelle.Parameters.AddWithValue("@p4", sirketID);
            komutGuncelle.Parameters.AddWithValue("@p3", TxtSifre.Text);
            komutGuncelle.Parameters.AddWithValue("@p5", TxtMail.Text);
            komutGuncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şirket güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //datatable güncelleme
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Sirketler", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            temizle();

        }
    }
}
