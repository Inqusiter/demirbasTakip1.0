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
    public partial class ZimmetDevir : Form
    {
        VeriTabani veriTabani = new VeriTabani();

        public ZimmetDevir()
        {

            InitializeComponent();

        }

        private void Verileri_Getir()
        {
            try
            {
                veriTabani.baglanti.Open();

                SqlDataAdapter demirbas_listele = new SqlDataAdapter
                    ("select URUN AS[Ürün], URUNKOD, URUNSERINO AS[Ürün Seri], MARKA AS[Marka], TARIH AS[Tarih], ZIMMETLIKISI AS[Zimmetli Kişi]," +
                    "ZIMMETLIBIRIM AS[Zimmetli Birim], ZIMMETLIBIRIMDETAY AS[Zimmetli.B Detay], ZIMMETKATAGORI AS[Zimmet Katagori], ZIMMETKULLANICI AS[Zimmetli Kullanıcı]   from demirbasGirisListe Order By URUN ASC", veriTabani.baglanti);
                DataTable dataTable = new DataTable();
                demirbas_listele.Fill(dataTable);
                dtbl_personel.DataSource = dataTable;
                veriTabani.baglanti.Close();

            }
            catch (global::System.Exception)
            {
                MessageBox.Show("error");
            }
        }


        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            Verileri_Getir();

        }

        int i;
        private void dtbl_personel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           //URUN, URUNSERINO , MARKA, TARIH, ZIMMETLIKISI, ZIMMETLIBIRIM, ZIMMETLIBIRIMDETAY, ZIMMETKATAGORI, ZIMMETKULLANICI

            i = e.RowIndex;
            DataGridViewRow satir = dtbl_personel.Rows[i];
            txt_Urun.Text = satir.Cells[0].Value.ToString();
            lbl_UrunKod.Text = satir.Cells[1].Value.ToString();
            txt_SeriNo.Text = satir.Cells[2].Value.ToString();
            txt_ZimmetMarka.Text = satir.Cells[3].Value.ToString();
            txt_ZimmetTarih.Text = satir.Cells[4].Value.ToString();
            txt_ZimmetliKisi.Text = satir.Cells[5].Value.ToString();
            Cmbox_Birimler.Text = satir.Cells[6].Value.ToString();
            txt_ZimmetBirimDetay.Text = satir.Cells[7].Value.ToString();
            cmBox_AnaKatagori.Text = satir.Cells[8].Value.ToString();
            txt_ZimmetKullanici.Text = satir.Cells[9].Value.ToString();

        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            try
            {

                string veri = "INSERT INTO demirbasGirisListe (URUN, URUNSERINO , MARKA, TARIH, ZIMMETLIKISI, ZIMMETLIBIRIM, ZIMMETLIBIRIMDETAY, ZIMMETKATAGORI, ZIMMETKULLANICI) VALUES (" + "'" +txt_Urun.Text+ "'" + "," + "'" + txt_SeriNo.Text + "'" + "," + "'" + txt_ZimmetMarka.Text + "'" + "," + "'" + txt_ZimmetTarih.Text + "'" + "," + "'" + txt_ZimmetliKisi.Text + "'" + "," +
                    "'" + Cmbox_Birimler.SelectedItem + "'" + "," + "'" + txt_ZimmetBirimDetay.Text + "'" + "," + "'" + cmBox_AnaKatagori.SelectedItem + "'" + "," + "'" + txt_ZimmetKullanici.Text + "'" + " )";

                // nesne oluşturduk sc ismi verdik ve sqlQuery deşikenini baglantı adlı database içinde çalıştırdık
                SqlCommand sc = new SqlCommand(veri, veriTabani.baglanti);

                //sql baglandik
                veriTabani.baglanti.Open();
                // sorgu sonucu bir şey beklemiyoruz bunu kullandık
                sc.ExecuteNonQuery();
                veriTabani.baglanti.Close();

                MessageBox.Show("Kayıt Başarılı","Kaydedildi");
                Verileri_Getir();

            }
            catch 
            {

                MessageBox.Show("hata");
            }

        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            {
            
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bilgiler silinsin mi?", "Silme", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
                {
                try
                {
                    string veri = "DELETE FROM demirbasGirisListe WHERE URUNKOD =" + "'" + lbl_UrunKod.Text+ "'" + "";

                    // nesne oluşturduk sc ismi verdik ve sqlQuery deşikenini baglantı adlı database içinde çalıştırdık
                    SqlCommand sc = new SqlCommand(veri, veriTabani.baglanti);

                    //sql baglandik
                    veriTabani.baglanti.Open();
                    // sorgu sonucu bir şey beklemiyoruz bunu kullandık
                    sc.ExecuteNonQuery();
                    veriTabani.baglanti.Close();

                    MessageBox.Show("Silme işlemi başarılı", "Personel Silindi");
                    Verileri_Getir();

                }
                catch
                {
                    MessageBox.Show("hata");
                }

                }
            }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {

            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bilgiler kayıt edilsin mi?", "Kayıt", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    string veriKaydet = "UPDATE  demirbasGirisListe  SET URUN = '" + txt_Urun.Text + "' ,URUNSERINO = '" + txt_SeriNo.Text + "' ,MARKA = '" + txt_ZimmetMarka.Text+ "' , TARIH = '" + txt_ZimmetTarih.Text + "' , ZIMMETLIKISI = '"+txt_ZimmetliKisi.Text+"' , ZIMMETLIBIRIM = '" + Cmbox_Birimler.Text+ "' , ZIMMETLIBIRIMDETAY = '" + txt_ZimmetBirimDetay.Text + "' ,ZIMMETKATAGORI = '" + Cmbox_Birimler.Text + "' ,ZIMMETKULLANICI = '" + txt_ZimmetKullanici.Text+ "'  WHERE URUNKOD = '" + lbl_UrunKod.Text + "'";

                    SqlCommand sc2 = new SqlCommand(veriKaydet, veriTabani.baglanti);

                    //sql baglandik
                    veriTabani.baglanti.Open();

                    // sorgu sonucu bir şey okuttuk ve ekledik bunu kullandık
                    sc2.ExecuteNonQuery();
                    veriTabani.baglanti.Close();
                    MessageBox.Show("Veri güncellendi");

                    Verileri_Getir();

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

        private void btn_Anasayfa_Katagoriler_Click(object sender, EventArgs e)
        {
            Katagoriler katagoriler = new Katagoriler();
            katagoriler.Show();
            this.Close();
        }


        private void Anasayfa_Load(object sender, EventArgs e)
        {

            try
            {
                veriTabani.baglanti.Open();

                //SQL baglandık datayı tek tek atadık
                SqlDataAdapter katagoriler = new SqlDataAdapter("SELECT KATAGORI FROM katagoriler", veriTabani.baglanti);
                DataTable KatagorilerData = new DataTable();
                katagoriler.Fill(KatagorilerData);
                for (int i = 0; i < KatagorilerData.Rows.Count; i++)
                {
                    cmBox_AnaKatagori.Items.Add(KatagorilerData.Rows[i]["KATAGORI"].ToString());
                }

                veriTabani.baglanti.Close();

            }
            catch (global::System.Exception)
            {
                MessageBox.Show("error");
            }

        }

        private void btn_AnaSayfa_Hesap_Click(object sender, EventArgs e)
        {
            Hesap hesap = new Hesap();
            hesap.Show();
        }

        private void txt_DemirbasAra_TextChanged(object sender, EventArgs e)
        {
                try
                {
                string veriKaydet = "select * from  demirbasGirisListe  WHERE URUN LIKE '" + txt_DemirbasAra.Text + "%'";

                //sql baglandik
                veriTabani.baglanti.Open();

                 SqlDataAdapter demirbas_listele = new SqlDataAdapter (veriKaydet, veriTabani.baglanti);
                 DataTable dataTable = new DataTable();
                 demirbas_listele.Fill(dataTable);
                 dtbl_personel.DataSource = dataTable;
                 veriTabani.baglanti.Close();

                }
                catch (global::System.Exception)
                {
                    MessageBox.Show("error");
                }
        }

    }
}
