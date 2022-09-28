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
        SqlDataReader sqlVeriOku;
        SqlCommand sqlKomut;
        public void Sql()
        {


            // veri tabanı nesne olarak tanımlama ve bagalnma
            SqlConnection baglanti = new SqlConnection("Data Source=lspdonline.mssql.somee.com;Initial Catalog=lspdonline;User ID=bobmarley_SQLLogin_1;Password=myqfg8abtj");
            //degiskeni sql komutu olarak tanımlama
            sqlKomut = new SqlCommand();
            // baglantı acma
            baglanti.Open();
            sqlKomut.Connection = baglanti;
        }



    }
}
