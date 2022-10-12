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
    public partial class FrmModeratorAlanPaneli : Form
    {
        public FrmModeratorAlanPaneli()
        {
            InitializeComponent();
        }


        SqlBaglantisi bgl = new SqlBaglantisi();

        private void temizle()
        {
            TxtBransAdi.Clear();
            TxtBransID.Clear();
            TxtBransAdi.Focus();
        }



        private void FrmModeratorAlanPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Alanlar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komutEkle = new SqlCommand("insert into Tbl_Alanlar (AlanAd) values (@a1)", bgl.baglanti());
            komutEkle.Parameters.AddWithValue("@a1", TxtBransAdi.Text);
            komutEkle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kategori başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Alanlar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtBransID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtBransAdi.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutSil = new SqlCommand("Delete From Tbl_Alanlar where AlanID=@b1", bgl.baglanti());
            komutSil.Parameters.AddWithValue("@b1", TxtBransID.Text);
            komutSil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kategori silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Alanlar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutGuncelle = new SqlCommand("update Tbl_Alanlar set AlanAd=@x1 where AlanID=@x2", bgl.baglanti());
            komutGuncelle.Parameters.AddWithValue("@x1", TxtBransAdi.Text);
            komutGuncelle.Parameters.AddWithValue("@x2", TxtBransID.Text);
            komutGuncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kategori başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Alanlar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            temizle();
        }
    }
}
