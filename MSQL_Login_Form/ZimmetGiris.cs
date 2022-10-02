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
    public partial class ZimmetGiris : Form
    {
        VeriTabani veriTabani = new VeriTabani();

        Rapor rapor = new Rapor();

        string hurdaDurum;

        public ZimmetGiris()
        {

            InitializeComponent();

        }
        private void Verileri_Getir()
        {
            try
            {
                veriTabani.baglanti.Open();

                SqlDataAdapter demirbas_listele = new SqlDataAdapter
                    ("select URUN AS[Ürün], URUNID, SERINO AS[Ürün Seri], MARKA AS[Marka], TARIH AS[Tarih], SORUMLU AS[Zimmetli Kişi]," +
                    "BIRIM AS[Zimmetli Birim], BIRIMDETAY AS[Zimmetli.B Detay], KATAGORI AS[Zimmet Katagori], KULLANICI AS[Zimmetli Kullanıcı] , HURDA   from demirbasGirisListe Order By URUN ASC", veriTabani.baglanti);
               
                DataTable dataTable = new DataTable();
                demirbas_listele.Fill(dataTable);
                dtbl_DemirbasListe.DataSource = dataTable;
                veriTabani.baglanti.Close();

            }
            catch (global::System.Exception)
            {
                MessageBox.Show("Verileri getir işleminde sql hatası gerçekleşti yöneticiye ulaşın!");
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
            DataGridViewRow satir = dtbl_DemirbasListe.Rows[i];
            txt_Urun.Text = satir.Cells[0].Value.ToString();
            lbl_UrunID.Text = satir.Cells[1].Value.ToString();
            txt_SeriNo.Text = satir.Cells[2].Value.ToString();
            txt_ZimmetMarka.Text = satir.Cells[3].Value.ToString();
            txt_ZimmetTarih.Text = satir.Cells[4].Value.ToString();
            txt_ZimmetliKisi.Text = satir.Cells[5].Value.ToString();
            Cmbox_Birimler.Text = satir.Cells[6].Value.ToString();
            txt_ZimmetBirimDetay.Text = satir.Cells[7].Value.ToString();
            cmBox_AnaKatagori.Text = satir.Cells[8].Value.ToString();
            txt_ZimmetKullanici.Text = satir.Cells[9].Value.ToString();
            hurdaDurum = satir.Cells[10].Value.ToString();

            if (hurdaDurum =="0")
            {
                btn_Hurda.BackColor = Color.White;
            }
            else if (hurdaDurum == "1")
            {
                btn_Hurda.BackColor = Color.Black;
            }
            lbl_HurdaDurum.Text = hurdaDurum;

        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            DialogResult ekleTiklama = new DialogResult();
            ekleTiklama = MessageBox.Show("Ürün eklensin mi?", "Evet", MessageBoxButtons.YesNo);
            if (ekleTiklama == DialogResult.Yes)
            {
                try
                {
                    string veri = "INSERT INTO demirbasGirisListe (URUN, SERINO , MARKA, TARIH, SORUMLU, BIRIM, BIRIMDETAY, KATAGORI, KULLANICI, HURDA) VALUES (" + "'" + txt_Urun.Text + "'" + "," + "'" + txt_SeriNo.Text + "'" + "," + "'" + txt_ZimmetMarka.Text + "'" + "," + "'" + txt_ZimmetTarih.Text + "'" + "," + "'" + txt_ZimmetliKisi.Text + "'" + "," +
                        "'" + Cmbox_Birimler.SelectedItem + "'" + "," + "'" + txt_ZimmetBirimDetay.Text + "'" + "," + "'" + cmBox_AnaKatagori.SelectedItem + "'" + "," + "'" + txt_ZimmetKullanici.Text + "'" + "," + "'0'" + ")";

                    // nesne oluşturduk sc ismi verdik ve sqlQuery deşikenini baglantı adlı database içinde çalıştırdık
                    SqlCommand sc = new SqlCommand(veri, veriTabani.baglanti);

                    //sql baglandik
                    veriTabani.baglanti.Open();
                    // sorgu sonucu bir şey beklemiyoruz bunu kullandık
                    sc.ExecuteNonQuery();
                    veriTabani.baglanti.Close();

                    MessageBox.Show("Kayıt Başarılı", "Kaydedildi");
                    Verileri_Getir();
                }
                catch
                {
                    MessageBox.Show("Demirbaş ekleme işleminde sql hatası gerçekleşti yöneticiye ulaşın!");
                }
            }
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            {
                 DialogResult silTiklama = new DialogResult();
                silTiklama = MessageBox.Show("Bilgiler silinsin mi?", "Silme", MessageBoxButtons.YesNo);
            if (silTiklama == DialogResult.Yes)
                {
                try
                {
                    string veri = "DELETE FROM demirbasGirisListe WHERE URUNID =" + "'" + lbl_UrunID.Text+ "'" + "";

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
                    MessageBox.Show("Demirbaş silme işleminde sql hatası gerçekleşti yöneticiye ulaşın!");
                    }
                }
            }
        }


        private void btn_Kaydet_Click(object sender, EventArgs e)
        {

            DialogResult kaydetTiklama = new DialogResult();
            kaydetTiklama = MessageBox.Show("Bilgiler kayıt edilsin mi?", "Kayıt", MessageBoxButtons.YesNo);
            if (kaydetTiklama == DialogResult.Yes)
            {
                try
                {
                    string veriKaydet = "UPDATE  demirbasGirisListe  SET URUN = '" + txt_Urun.Text + "' ,SERINO = '" + txt_SeriNo.Text + "' ,MARKA = '" + txt_ZimmetMarka.Text+ "' , TARIH = '" + txt_ZimmetTarih.Text + "' , SORUMLU = '"+txt_ZimmetliKisi.Text+"' , BIRIM = '" + Cmbox_Birimler.Text+ "' , BIRIMDETAY = '" + txt_ZimmetBirimDetay.Text + "' ,KATAGORI = '" + Cmbox_Birimler.Text + "' ,KULLANICI = '" + txt_ZimmetKullanici.Text+ "'  WHERE URUNID = '" + lbl_UrunID.Text + "'";

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
                    MessageBox.Show("Demirbaş güncelleme işleminde sql hatası gerçekleşti yöneticiye ulaşın!!");
                }
            }
            else
            {
                MessageBox.Show("İşlem Yapılmadı!");
            }
        }

        private void btn_Hurda_Click(object sender, EventArgs e)
        {
            DialogResult hurdaTiklama = new DialogResult();
            hurdaTiklama = MessageBox.Show("Seçili seri no lu ürün hurdaya alınsın mı?", "Evet", MessageBoxButtons.YesNo);
            if (hurdaTiklama == DialogResult.Yes)
            {
                try
                {
                    if (hurdaDurum == "0")
                    {
                        hurdaDurum = "1";
                    }
                    else
                    {
                        hurdaDurum = "0";
                    }

                    string veriKaydet = "UPDATE  demirbasGirisListe  SET HURDA = '" + hurdaDurum + "'  WHERE URUNID = '" + lbl_UrunID.Text + "'";

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
                    MessageBox.Show("Hurda işleminde sql hatası gerçekleşti yöneticiye ulaşın!!");
                }
            }
            else
            {
                MessageBox.Show("İşlem Yapılmadı!");
            }
        }

        private void btn_Rapor_Click(object sender, EventArgs e)
        {
            rapor.htmlDosyaOlustur();
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

        private void ZimmetGiris_Load(object sender, EventArgs e)
        {
            Verileri_Getir();
        }
        private void txt_DemirbasAra_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string veriKaydet = "select * from  demirbasGirisListe  WHERE URUN LIKE '" + txt_DemirbasAra.Text + "%'";

                //sql baglandik
                veriTabani.baglanti.Open();

                SqlDataAdapter demirbas_listele = new SqlDataAdapter(veriKaydet, veriTabani.baglanti);
                DataTable dataTable = new DataTable();
                demirbas_listele.Fill(dataTable);
                dtbl_DemirbasListe.DataSource = dataTable;
                veriTabani.baglanti.Close();

            }
            catch
            {
                MessageBox.Show("Demirbaş arama işleminde sql hatası gerçekleşti yöneticiye ulaşın!!");
            }
        }

        private void txt_TarihAra_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string veriKaydet = "select * from  demirbasGirisListe  WHERE TARIH LIKE '" + txt_TarihAra.Text + "%'";

                //sql baglandik
                veriTabani.baglanti.Open();

                SqlDataAdapter demirbas_listele = new SqlDataAdapter(veriKaydet, veriTabani.baglanti);
                DataTable dataTable = new DataTable();
                demirbas_listele.Fill(dataTable);
                dtbl_DemirbasListe.DataSource = dataTable;
                veriTabani.baglanti.Close();

            }
            catch
            {
                MessageBox.Show("Demirbaş arama arama işleminde sql hatası gerçekleşti yöneticiye ulaşın!!");
            }
        }
    }
}
