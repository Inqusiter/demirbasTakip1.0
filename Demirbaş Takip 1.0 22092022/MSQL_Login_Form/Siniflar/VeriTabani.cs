using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MSQL_Login_Form
{
    public class VeriTabani
    {
        public SqlDataReader sqlVeriOku;
        //degiskeni sql komutu olarak tanımlama
        public SqlCommand sqlKomut = new SqlCommand();

        public SqlConnection baglanti = new SqlConnection("Data Source=192.168.60.131;Initial Catalog=demirbas;User ID=sa;Password=Berat123456789");

    }

}
