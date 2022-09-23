using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MSQL_Login_Form
{
    public partial class Katagoriler : Form
    {
        VeriTabani veriTabani = new VeriTabani();

        public Katagoriler()
        {
            InitializeComponent();
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bilgiler kayıt edilsin mi?", "Kayıt", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    MessageBox.Show("Veri güncellendi");
                }
                catch
                {
                    MessageBox.Show("HATA!");
                }
            }
            else
            {
                MessageBox.Show("İşlem Yapılmadı!");
            }



        }

        private bool surukle = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


        private void pnl_AnasayfaTop_MouseDown(object sender, MouseEventArgs e)
        {
            surukle = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void pnl_AnasayfaTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (surukle)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void pnl_AnasayfaTop_MouseUp(object sender, MouseEventArgs e)
        {
            surukle = false;
        }

        private void btn_AnasayfaCikis_Click(object sender, EventArgs e)
        {
            //komple kapatma
            Application.ExitThread();
        }

        private void btn_Profil_Rapor_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Close();
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            lstBox_Katagoriler.Items.Clear();

            try
            {
                veriTabani.baglanti.Open();
                //SQL baglandık datayı tek tek atadık
                SqlDataAdapter katagoriler = new SqlDataAdapter("SELECT KATAGORI FROM katagoriler", veriTabani.baglanti);
                DataTable KatagorilerData = new DataTable();
                katagoriler.Fill(KatagorilerData);
                for (int i = 0; i < KatagorilerData.Rows.Count; i++)
                {
                    cmBox_Katagori.Items.Add(KatagorilerData.Rows[i]["KATAGORI"].ToString());
                    lstBox_Katagoriler.Items.Add(KatagorilerData.Rows[i]["KATAGORI"].ToString());
                }
                veriTabani.baglanti.Close();

            }
            catch (global::System.Exception)
            {
                MessageBox.Show("TRYCATCH HATASI");
            }

        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {

            if (txt_KatagoriEkle.Text != string.Empty)
            {
                try
                {
                    string veri = "INSERT INTO katagoriler (KATAGORI) VALUES (" + "'" + txt_KatagoriEkle.Text + "'" + " )";

                    // nesne oluşturduk sc ismi verdik ve sqlQuery deşikenini baglantı adlı database içinde çalıştırdık
                    SqlCommand sc = new SqlCommand(veri, veriTabani.baglanti);

                    //sql baglandik
                    veriTabani.baglanti.Open();
                    // sorgu sonucu bir şey beklemiyoruz bunu kullandık
                    sc.ExecuteNonQuery();
                    veriTabani.baglanti.Close();

                    MessageBox.Show("Kayıt Başarılı", "Kaydedildi");

                }
                catch
                {
                    MessageBox.Show("TRYCATCH HATASI");
                }
            }
            else
            {
                MessageBox.Show("Boş katagori Eklenemez!", "HATA!");
            }


        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bilgiler silinsin mi?", "Silme", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    string veri = "DELETE FROM katagoriler WHERE KATAGORI =" + "'" + lstBox_Katagoriler.SelectedItem + "'" + "";

                    // nesne oluşturduk sc ismi verdik ve sqlQuery deşikenini baglantı adlı database içinde çalıştırdık
                    SqlCommand sc = new SqlCommand(veri, veriTabani.baglanti);

                    //sql baglandik
                    veriTabani.baglanti.Open();
                    // sorgu sonucu bir şey beklemiyoruz bunu kullandık
                    sc.ExecuteNonQuery();
                    veriTabani.baglanti.Close();

                    MessageBox.Show("Silme işlemi başarılı", "Personel Silindi");

                }
                catch
                {
                    MessageBox.Show("hata");
                }
            }
        }
    }
}
