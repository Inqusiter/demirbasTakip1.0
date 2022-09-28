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
    public partial class HesapEkle : Form
    {
        public int PersonelID = EvrenselDegiskenler.PersonelID;
        public string PersonelAD = EvrenselDegiskenler.PersonelAD;
        public string PersonelYetki = EvrenselDegiskenler.PersonelYetki;
        VeriTabani veriTabani = new VeriTabani();

        public HesapEkle()
        {
            InitializeComponent();

            lbl_HesapPersonelYetki.Text = PersonelYetki;
            lbl_HesapPersonelAD.Text = PersonelAD;
            lbl_HesapPersonelID.Text = Convert.ToString(PersonelID);
            if (PersonelYetki!="Yönetici")
            {
                btn_Guncelle.Visible = false;
            }

        }
        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            // sifre kontrol degiskene atancak ve sql yazdırılcak sonra silinecek. kullanıcı sil eklenecek

            if ((txt_pekleSifre.Text == txt_pekleSifreT.Text) && (txt_pekleSifre.Text != string.Empty) && (txt_pekleSifreT.Text != string.Empty))
            {
                string pekleSifre = txt_pekleSifre.Text;
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Bilgiler kayıt edilsin mi?", "Kayıt", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        string veriKaydet = "INSERT INTO personel (YETKI, AD , SOYAD, PAROLA) VALUES (" + "'" + txt_pekleKidem.Text + "'" + "," + "'" + txt_pekleAd.Text + "'" + "," + "'" + txt_pekleSad.Text + "'" + "," + "'" + pekleSifre + "'"  + " )";

                        SqlCommand sc2 = new SqlCommand(veriKaydet, veriTabani.baglanti);

                        //sql baglandik
                        veriTabani.baglanti.Open();

                        // sorgu sonucu bir şey okuttuk ve ekledik bunu kullandık
                        sc2.ExecuteNonQuery();
                        veriTabani.baglanti.Close();
                        MessageBox.Show("Personel Eklendi");
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("HATA!");
                    }
                }

            }
            else
            {
                MessageBox.Show("İşlem Yapılmadı! Şifre Kutularından Birisi Boş Veya Şifreler Uyuşmuyor!");
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

        private void btn_HesapCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
