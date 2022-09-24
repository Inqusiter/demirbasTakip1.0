using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MSQL_Login_Form
{
    public partial class Giris : Form
    {

        public int PersonelID;
        public string PersonelAD;
        public string PersonelYetki;
        // nesne tanımladık 
        VeriTabani veriTabani = new VeriTabani();

        public Giris()
        {
            InitializeComponent();

        }
        private void btn_giris_Click(object sender, EventArgs e)
        {
            string kullaniciAd = txt_kullaniciAd.Text;
            string kullaniciSifre = txt_sifre.Text;


            // baglantı acma
            veriTabani.baglanti.Open();
            veriTabani.sqlKomut.Connection = veriTabani.baglanti;

            veriTabani.sqlKomut.CommandText = "Select * From personel where AD='" + kullaniciAd + "'And PAROLA='" + kullaniciSifre + "'";
            Anasayfa anasayfa = new Anasayfa();
            try
            {
                veriTabani.sqlVeriOku = veriTabani.sqlKomut.ExecuteReader();
                if (veriTabani.sqlVeriOku.Read())
                {
                    // sql sorgusu içerisinde  çekilen ve belirlenen stünü bir değişkene atar
                    PersonelID = Convert.ToInt32(veriTabani.sqlVeriOku["ID"].ToString());
                    PersonelAD = veriTabani.sqlVeriOku["AD"].ToString();
                    PersonelYetki = veriTabani.sqlVeriOku["YETKI"].ToString();
                    // diğer formda ki nesneye ulaşmak için privateden publice aldık
                    EvrenselDegiskenler.PersonelID = PersonelID;
                    EvrenselDegiskenler.PersonelAD = PersonelAD;
                    EvrenselDegiskenler.PersonelRutbe = PersonelYetki;
                    anasayfa.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
                    veriTabani.baglanti.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Giriş işleminde sql hatası gerçekleşti yöneticiye ulaşın!!");
            }
        }



        private bool surukle = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


        private void pnl_GirisTop_MouseDown(object sender, MouseEventArgs e)
        {
            surukle = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void pnl_GirisTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (surukle)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void pnl_GirisTop_MouseUp(object sender, MouseEventArgs e)
        {
            surukle = false;
        }

        private void btn_GirisKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
