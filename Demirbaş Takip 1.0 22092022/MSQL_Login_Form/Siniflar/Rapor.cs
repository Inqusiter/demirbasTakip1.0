using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSQL_Login_Form
{
    public class Rapor
    {
        VeriTabani veriTabani = new VeriTabani();


        public void htmlDosyaOlustur()
        {
            //string DosyaYolu = @"C:\Users\zamaz\Documents\test\index.html";
            //exe konumu aldık \\ split ederek dizi elemanlarına atadık kullanıcı bilgilerini edindik ve dosya konumu belirledik.
            int raporSayac = 1;
            string raporAd = "Rapor";
            string exeKonumu = Path.GetDirectoryName(Application.ExecutablePath);
            string[] parcaliDosyaYolu = exeKonumu.Split('\\');
            string diskAdi = parcaliDosyaYolu[0];
            string kullanicilar = parcaliDosyaYolu[1];
            string kullaniciadi = parcaliDosyaYolu[2];
            string dosyaYolu = diskAdi + "/" + kullanicilar + "/" + kullaniciadi + "/Documents" + "/Demirbas/" + raporAd + ".html";
            string cssDosaYolu = diskAdi + "/" + kullanicilar + "/" + kullaniciadi + "/Documents" + "/Demirbas";

            if (File.Exists(dosyaYolu) == false)
            {
                Directory.CreateDirectory(cssDosaYolu);
            }


            if (File.Exists(dosyaYolu) == true)
            {
                DialogResult raporSilme = new DialogResult();
                raporSilme = MessageBox.Show("Rapor+1 diye kayıt oluşturulsun mu? Hayır tıklarsanız eski raporu silip üzerine yazacağız.", "Evet", MessageBoxButtons.YesNo);
                if (raporSilme == DialogResult.Yes)
                {
                    raporSayac++;
                    raporAd = "Rapor" + Convert.ToString(raporSayac) ;
                    dosyaYolu = diskAdi + "/" + kullanicilar + "/" + kullaniciadi + "/Documents" + "/Demirbas/" + raporAd + ".html";
                    MessageBox.Show(raporAd + "olarak kaydettik çünkü aynı dosya var!");
                    //File.Delete(dosyaYolu);
                    //MessageBox.Show("Eski dosya silindi");
                    //raporAd += raporAd + System.DateTime.Today.ToString();
                    //dosyaYolu = diskAdi + "/" + kullanicilar + "/" + kullaniciadi + "/Documents" + "/Demirbas/" + raporAd + ".html";
                }
                File.Delete(dosyaYolu);

            }


            veriTabani.baglanti.Open();

                SqlDataAdapter demirbas_listele = new SqlDataAdapter
                    ("select URUN AS[Ürün], URUNID, SERINO AS[Ürün Seri], MARKA AS[Marka], TARIH AS[Tarih], SORUMLU AS[Zimmetli Kişi]," +
                    "BIRIM AS[Zimmetli Birim], BIRIMDETAY AS[Zimmetli.B Detay], KATAGORI AS[Zimmet Katagori], KULLANICI AS[Zimmetli Kullanıcı] , HURDA   from demirbasGirisListe Order By URUN ASC", veriTabani.baglanti);

                DataTable dataTable = new DataTable();
                demirbas_listele.Fill(dataTable);

                veriTabani.baglanti.Close();

            // string ifade içinde " kullanmak için ters slah kullanılır.
            // \" stringi bypass eder
            StreamWriter Yaz = new StreamWriter(dosyaYolu);
                Yaz.Write("<html>" +
            "<head>" +                                   
                    "<link href=\""+ cssDosaYolu + "/css/bootstrap.css\" "  +  "rel= \"stylesheet\"/>" +
                    // title attık çünkü çıktı alınınca ismini üste yazsın
                    " <title>Demirbaş Rapor</title>" +
            "</head>" +
                    "<body style=\"padding: 20px; \">" +
             "<div class=\"card-body\">" +
                "<table class=\"table table-hover table-striped\">" +
                     "<thead class=\"table-dark\">" +
                        "<tr>");

                for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        Yaz.Write( // dongu
                        "<th> " + dataTable.Columns[i].ColumnName + " <th>");
                    }

                     Yaz.Write(
                        "</tr>" +
                     "</thead>");
                Yaz.Write("<tr>");
                //üst lsite yazıldı alt liste dönülecek stün sayısı kadar sayacak yukardan aşşa 2 satır var 2 kere çalışacak
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    // stün sayısı kadar çalışacak
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        Yaz.Write("<td> " + dataTable.Rows[i].ItemArray[j] + " <td>");
                    }
                        Yaz.Write("</tr>" +
                                   "<tr>" );
                }
                // son parca
                Yaz.Write(
                    "</tr>" +
                "</table>" +
             "</div>" +
             "<div class=\"card-footer\">");
             Yaz.Write("Toplam demirbaş: " + EvrenselDegiskenler.DemirbasToplam + "Hurda demirbaş: " + EvrenselDegiskenler.HurdaToplam + "Aktif demirbaş: " + EvrenselDegiskenler.AktifKullanilanDemirbas);
             Yaz.Write(
             "</div>" +
                    "</html>");
                Yaz.Close();
                MessageBox.Show("Rapor Çıktı Alındı");
        }
    }
}
