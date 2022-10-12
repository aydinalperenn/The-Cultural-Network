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
    public partial class FrmEtkinlikListesiGenel : Form
    {
        public FrmEtkinlikListesiGenel()
        {
            InitializeComponent();
        }


        SqlBaglantisi bgl = new SqlBaglantisi();
        

        private void FrmEtkinlikListesiGenel_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Etkinlikler", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        
    }
}
