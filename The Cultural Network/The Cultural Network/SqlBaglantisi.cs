using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace The_Cultural_Network
{
    class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-V1B0TCM;Initial Catalog=TheCulturalNetworkDatabase;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
