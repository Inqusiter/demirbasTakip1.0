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
    public partial class Anasayfa : Form
    {
        VeriTabani veriTabani = new VeriTabani();

        public Anasayfa()
        {
            InitializeComponent();
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
        }

        private void btn_AnaSayfa_Hesap_Click(object sender, EventArgs e)
        {
            Hesap hesap = new Hesap();
            hesap.Show();
        }

        private void btn_Anasayfa_ZimmetGiris_Click(object sender, EventArgs e)
        {
            ZimmetGiris zimmetgiris = new ZimmetGiris();
            zimmetgiris.Show();
        }

        private void btn_Anasayfa_Yonetici_Click(object sender, EventArgs e)
        {
            HesapEkle hesapekle = new HesapEkle();
            hesapekle.Show();
        }

        private void demirbasIstatisleri()
        {
            veriTabani.baglanti.Open();

            // sql sorgusu ile sütün sayısını aldık sonra sql komut oluşturduk içine stringi attık sonra int oluşturdumuz stun sayısına dönen sonucu attık ve labele yazdık
            string sqlkomutUrunSayisi = "Select count(URUN) from demirbasGirisListe";
            SqlCommand cmdUrunSayisi = new SqlCommand(sqlkomutUrunSayisi, veriTabani.baglanti);
            int stunSayisi = Convert.ToInt32(cmdUrunSayisi.ExecuteScalar());
            lbl_DemirbasToplam.Text = Convert.ToString(stunSayisi);

            // hurda sayisi için
            string sqlkomutHurdaSayisi = "SELECT count(HURDA) FROM demirbasGirisListe WHERE HURDA in ('0') ";
            SqlCommand cmdHurdaSayisi = new SqlCommand(sqlkomutHurdaSayisi, veriTabani.baglanti);
            int hurdaStunSayisi = Convert.ToInt32(cmdHurdaSayisi.ExecuteScalar());
            lbl_HurdaToplam.Text = Convert.ToString(hurdaStunSayisi);

            // kullanilan sayisi için
            string sqlkomut = "SELECT count(HURDA) FROM demirbasGirisListe WHERE HURDA in ('1') ";
            SqlCommand cmdKullanilanSayisi = new SqlCommand(sqlkomut, veriTabani.baglanti);
            int aktifKullanilanSayisi = Convert.ToInt32(cmdHurdaSayisi.ExecuteScalar());
            lbl_AktifKullanilan.Text = Convert.ToString(aktifKullanilanSayisi);

            veriTabani.baglanti.Close();

            EvrenselDegiskenler.DemirbasToplam = lbl_DemirbasToplam.Text;
            EvrenselDegiskenler.HurdaToplam = lbl_HurdaToplam.Text;
            EvrenselDegiskenler.AktifKullanilanDemirbas = lbl_AktifKullanilan.Text;
            
        }

        private void chart_AnasayfaAyarlar()
        {
            int a = Convert.ToInt32(lbl_DemirbasToplam.Text);
            int b = Convert.ToInt32(lbl_HurdaToplam.Text);
            int c = Convert.ToInt32(lbl_AktifKullanilan.Text);


            //x sağ üst chartın Series0 olan charta elemanlar ekliyoruz
            chart_Anasayfa.Series["Series0"].Points.AddXY(0, a);
            chart_Anasayfa.Series["Series0"].Points.AddXY(0, b);
            chart_Anasayfa.Series["Series0"].Points.AddXY(0, c);

            //label ayarları
            chart_Anasayfa.Series["Series0"].Points[0].Label = "Toplam";
            chart_Anasayfa.Series["Series0"].Points[0].LabelBackColor = Color.Transparent;
            chart_Anasayfa.Series["Series0"].Points[1].Label = "Hurda";
            chart_Anasayfa.Series["Series0"].Points[1].LabelBackColor = Color.Transparent;
            chart_Anasayfa.Series["Series0"].Points[2].Label = "Aktif";
            chart_Anasayfa.Series["Series0"].Points[2].LabelBackColor = Color.Transparent;

            //renk ayarları
            Color toplamColor = Color.FromArgb(255, 255, 255);
            chart_Anasayfa.Series["Series0"].Points[0].Color = toplamColor;

            Color hurdaColor = Color.FromArgb(255, 255, 128);
            chart_Anasayfa.Series["Series0"].Points[1].Color = hurdaColor;

            Color aktifColor = Color.FromArgb(128, 255, 128); 
            chart_Anasayfa.Series["Series0"].Points[2].Color = aktifColor;
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            demirbasIstatisleri();
            chart_AnasayfaAyarlar();
        }
    }
}
