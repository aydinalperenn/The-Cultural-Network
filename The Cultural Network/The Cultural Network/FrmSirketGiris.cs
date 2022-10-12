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
    public partial class FrmSirketGiris : Form
    {
        public FrmSirketGiris()
        {
            InitializeComponent();
        }


        SqlBaglantisi bgl = new SqlBaglantisi();



        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komutGiris = new SqlCommand("Select * From Tbl_Sirketler where SirketMail=@p1 and SirketSifre=@p2", bgl.baglanti());
            komutGiris.Parameters.AddWithValue("@p1", TxtMail.Text);
            komutGiris.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komutGiris.ExecuteReader();  
            if (dr.Read())
            {
                FrmSirketDetay frsd = new FrmSirketDetay();
                frsd.mail = TxtMail.Text;
                frsd.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı mail veya şifre girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bgl.baglanti().Close();


        }

        
    }
}
