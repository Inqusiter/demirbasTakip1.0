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
    public partial class Hesap : Form
    {
        public int PersonelID = EvrenselDegiskenler.PersonelID;
        public string PersonelAD = EvrenselDegiskenler.PersonelAD;
        public string PersonelYetki = EvrenselDegiskenler.PersonelYetki;

        VeriTabani veritabani = new VeriTabani();

        public Hesap()
        {
            InitializeComponent();

            lbl_HesapPersonelRutbe.Text = PersonelYetki;
            lbl_HesapPersonelAD.Text = PersonelAD;
            lbl_HesapPersonelID.Text = Convert.ToString(PersonelID);

        }
        private void btn_Guncelle_Click(object sender, EventArgs e)
        {   // bug fixlendi
            if ((txt_Sifre1.Text == string.Empty) || (txt_Sifre2.Text == string.Empty))
            {            
                MessageBox.Show("Şifreni boş mu yapmak istiyorsun?!! \n Böyle bir şey mümkün değil.");
            }
            else
            {
                if ((txt_Sifre1.Text == txt_Sifre2.Text))
                {
                    DialogResult dialog = new DialogResult();
                    dialog = MessageBox.Show("Bilgiler kayıt edilsin mi?", "Kayıt", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        try
                        {
                            string veriKaydet = "UPDATE  personel  SET PAROLA = '" + txt_Sifre2.Text + "'  WHERE ID = '" + PersonelID + "'";

                            SqlCommand sc2 = new SqlCommand(veriKaydet, veritabani.baglanti);

                            //sql baglandik
                            veritabani.baglanti.Open();

                            // sorgu sonucu bir şey okuttuk ve ekledik bunu kullandık
                            sc2.ExecuteNonQuery();
                            veritabani.baglanti.Close();
                            MessageBox.Show("Veri güncellendi");
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Şifre güncelleme işleminde sql hatası gerçekleşti yöneticiye ulaşın!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("İşlem Yapılmadı! Kullanıcı Tarafından Red!");
                    }
                }
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
