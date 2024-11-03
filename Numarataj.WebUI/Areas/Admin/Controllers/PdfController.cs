using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Numarataj.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Numarataj.DTO.DTOs.BasePdfDTOs;

namespace Numarataj.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Personel")]
    [Area("Admin")]
    public class PdfController : Controller
    {
        private readonly NumaratajDbContext _context;
        private readonly IMapper _mapper;

        public PdfController(NumaratajDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> GeneratePdf(int id, string title, string pdfName, int type, bool isTcHidden = false)
        {
            var ozelisyeriValues = await _context.OzelIsyeri.FirstOrDefaultAsync(x => x.BelgeNoId == id);
            var adresTespitResponse = _mapper.Map<ResultPdfDto>(ozelisyeriValues);

            if (type == 1)
            {
                var adresTespitValues = await _context.AdresTespit.FirstOrDefaultAsync(x => x.BelgeNoId == id);
                adresTespitResponse = _mapper.Map<ResultPdfDto>(adresTespitValues);
            }
            if (type == 2)
            {
                ozelisyeriValues = await _context.OzelIsyeri.FirstOrDefaultAsync(x => x.BelgeNoId == id);
                adresTespitResponse = _mapper.Map<ResultPdfDto>(ozelisyeriValues);
            }
            if (type == 3)
            {
                var sahacalismasiValues = await _context.SahaCalismasi.FirstOrDefaultAsync(x => x.BelgeNoId == id);
                adresTespitResponse = _mapper.Map<ResultPdfDto>(sahacalismasiValues);
            }
            if (type == 4)
            {
                var resmikurumValues = await _context.ResmiKurum.FirstOrDefaultAsync(x => x.BelgeNoId == id);
                adresTespitResponse = _mapper.Map<ResultPdfDto>(resmikurumValues);
            }
            if (type == 5)
            {
                var yenibinaValues = await _context.YeniBina.FirstOrDefaultAsync(x => x.BelgeNoId == id);
                adresTespitResponse = _mapper.Map<ResultPdfDto>(yenibinaValues);
            }
            //var adresTespitResponse = await _client.GetFromJsonAsync<ResultPdfDto>($"ozelisyeris/{id}");
            if (adresTespitResponse == null)
            {
                return NotFound(); // Eğer veri yoksa 404 döndür
            }

            using (MemoryStream stream = new MemoryStream())
            {
                // PDF belgesi oluşturma
                Document pdfDoc = new Document(PageSize.A4, 50, 50, 25, 25);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                // Türkçe karakterler için Arial Unicode MS fontunu kullanıyoruz
                string arialUnicodeMSPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");
                BaseFont bfArialUniCode = BaseFont.CreateFont(arialUnicodeMSPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                // Font ayarları
                Font titleFont = new Font(bfArialUniCode, 16, Font.BOLD);
                Font headerFont = new Font(bfArialUniCode, 12, Font.BOLD);
                Font bodyFont = new Font(bfArialUniCode, 10, Font.NORMAL);
                Font kalinFont = new Font(bfArialUniCode, 20, Font.BOLD);

                // ** Logo Ekleyin (Sol Üst Kısım) **
                var logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/matrix-admin-master/assets/images/logo-rapor.png");
                //string logoPath = @"C:\Users\IRMAKTEKNOLOJI\source\repos\Numarataj\Numarataj.WebUI\wwwroot\matrix-admin-master\assets\images\logo-rapor.png";
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);

                // Logonun boyutunu ayarlayın (çok büyük olmaması için)
                logo.ScaleToFit(110f, 60f); // Genişlik 100, yükseklik 50 olacak şekilde ayarlandı
                logo.SetAbsolutePosition(43, pdfDoc.PageSize.Height - 100); // Sol üst köşeye, hafif aşağıda
                pdfDoc.Add(logo);

                // Belge Başlıkları
                var tCParagraph = new Paragraph(new Chunk("T.C.", titleFont)) { Alignment = Element.ALIGN_CENTER };
                pdfDoc.Add(tCParagraph);

                var belediyeBaskamligiParagraph = new Paragraph(new Chunk("BATMAN BELEDİYE BAŞKANLIĞI", titleFont)) { Alignment = Element.ALIGN_CENTER };
                pdfDoc.Add(belediyeBaskamligiParagraph);

                var imarMudurluguParagraph = new Paragraph(new Chunk("İMAR VE ŞEHİRCİLİK MÜDÜRLÜĞÜ", headerFont)) { Alignment = Element.ALIGN_CENTER };
                pdfDoc.Add(imarMudurluguParagraph);

                var etutProjeParagraph = new Paragraph(new Chunk("NUMARATAJ BİRİMİ", bodyFont)) { Alignment = Element.ALIGN_CENTER };
                pdfDoc.Add(etutProjeParagraph);
                pdfDoc.Add(new Paragraph("\n"));
                pdfDoc.Add(new Paragraph("\n"));



                PdfPTable numaratajTable = new PdfPTable(3);
                numaratajTable.WidthPercentage = 100;
                numaratajTable.SetWidths(new float[] { 1, 3, 1 }); // İlk ve son sütun dar, orta sütun geniş

                // "Belge No" hücresini sola hizala
                numaratajTable.AddCell(new PdfPCell(new Phrase("Belge No: " + (adresTespitResponse.BelgeNoId.ToString() ?? ""), bodyFont))
                {
                    Border = Rectangle.NO_BORDER, // Kenar çizgisi yok
                    HorizontalAlignment = Element.ALIGN_LEFT // Sol hizalama
                });

                // "NUMARATAJ BELGESİ" hücresini ortala
                numaratajTable.AddCell(new PdfPCell(new Phrase("NUMARATAJ BELGESİ", kalinFont))
                {
                    Border = Rectangle.NO_BORDER, // Kenar çizgisi yok
                    HorizontalAlignment = Element.ALIGN_CENTER // Ortala
                });

                // "Tarih" hücresini sağa hizala
                numaratajTable.AddCell(new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy"), bodyFont))
                {
                    Border = Rectangle.NO_BORDER, // Kenar çizgisi yok
                    HorizontalAlignment = Element.ALIGN_RIGHT // Sağ hizalama
                });

                // Tabloyu PDF belgesine ekle
                pdfDoc.Add(numaratajTable);

                // Boşluk ekle
                pdfDoc.Add(new Paragraph("\n"));



                PdfPTable specialBusinessTable = new PdfPTable(1)
                {
                    WidthPercentage = 100
                };

                // Kenar çizgilerini eklemek için hücre oluştur
                PdfPCell specialBusinessCell = new PdfPCell(new Phrase(title, titleFont))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER, // Ortala
                    Border = Rectangle.BOX, // Kenar çizgisi ekle
                    Padding = 10 // Hücre içindeki boşluk
                };
                specialBusinessCell.BorderWidth = 2; // Kenar kalınlığını ayarla
                specialBusinessTable.AddCell(specialBusinessCell);

                // Tabloyu PDF belgesine ekle
                pdfDoc.Add(specialBusinessTable);

                var headerParagraph = new Paragraph("KİMLİK BİLGİLERİ", headerFont);
                headerParagraph.SpacingAfter = 5f; // 5 birim boşluk bırakıyoruz
                pdfDoc.Add(headerParagraph);

                // Kimlik bilgileri tablosu
                PdfPTable kimlikTable = new PdfPTable(2);
                kimlikTable.WidthPercentage = 100;
                if (!isTcHidden)
                {
                    kimlikTable.AddCell(new PdfPCell(new Phrase("TC Kimlik No:", bodyFont)) { Padding = 8, MinimumHeight = 8 });
                    kimlikTable.AddCell(new PdfPCell(new Phrase(adresTespitResponse.TcKimlikNo, bodyFont)) { Padding = 8, MinimumHeight = 8 });
                }
                kimlikTable.AddCell(new PdfPCell(new Phrase("Ad/Soyad:", bodyFont)) { Padding = 8, MinimumHeight = 8 });
                kimlikTable.AddCell(new PdfPCell(new Phrase(adresTespitResponse.AdSoyad, bodyFont)) { Padding = 8, MinimumHeight = 8 });
                kimlikTable.AddCell(new PdfPCell(new Phrase("Telefon:", bodyFont)) { Padding = 8, MinimumHeight = 8 });
                kimlikTable.AddCell(new PdfPCell(new Phrase(adresTespitResponse.Telefon ?? "", bodyFont)) { Padding = 8, MinimumHeight = 8 });

                pdfDoc.Add(kimlikTable);

                var adresHeaderParagraph = new Paragraph("ADRES BİLGİLERİ", headerFont);
                adresHeaderParagraph.SpacingAfter = 5f; // 5 birim boşluk bırakıyoruz
                pdfDoc.Add(adresHeaderParagraph);

                PdfPTable adresTable = new PdfPTable(2);
                adresTable.WidthPercentage = 100;

                adresTable.AddCell(new PdfPCell(new Phrase("Adres No:", bodyFont)) { Padding = 8, MinimumHeight = 8 });
                adresTable.AddCell(new PdfPCell(new Phrase(adresTespitResponse.AdresNo?.ToString() ?? "", bodyFont)) { Padding = 8, MinimumHeight = 8 });
                adresTable.AddCell(new PdfPCell(new Phrase("Mahalle:", bodyFont)) { Padding = 8, MinimumHeight = 8 });
                adresTable.AddCell(new PdfPCell(new Phrase(adresTespitResponse.Mahalle ?? "", bodyFont)) { Padding = 8, MinimumHeight = 8 });
                adresTable.AddCell(new PdfPCell(new Phrase("Cadde/Sokak:", bodyFont)) { Padding = 8, MinimumHeight = 8 });
                adresTable.AddCell(new PdfPCell(new Phrase(adresTespitResponse.CaddeSokak ?? "", bodyFont)) { Padding = 8, MinimumHeight = 8 });
                adresTable.AddCell(new PdfPCell(new Phrase("Dış Kapı:", bodyFont)) { Padding = 8, MinimumHeight = 8 });
                adresTable.AddCell(new PdfPCell(new Phrase(adresTespitResponse.DisKapi ?? "", bodyFont)) { Padding = 8, MinimumHeight = 8 });
                adresTable.AddCell(new PdfPCell(new Phrase("İç Kapı No:", bodyFont)) { Padding = 8, MinimumHeight = 8 });
                adresTable.AddCell(new PdfPCell(new Phrase(adresTespitResponse.İcKapiNo ?? "", bodyFont)) { Padding = 8, MinimumHeight = 8 });
                adresTable.AddCell(new PdfPCell(new Phrase("İş Yeri Ünvanı:", bodyFont)) { Padding = 8, MinimumHeight = 8 });
                adresTable.AddCell(new PdfPCell(new Phrase(" ", bodyFont)) { Padding = 8, MinimumHeight = 8 }); // Sabit değer


                pdfDoc.Add(adresTable);

                // Tapu Bilgileri
                var tapuHeaderParagraph = new Paragraph("TAPU BİLGİLERİ", headerFont);
                tapuHeaderParagraph.SpacingAfter = 5f; // 5 birim boşluk bırakıyoruz
                pdfDoc.Add(tapuHeaderParagraph);

                // Tapu bilgileri tablosu
                PdfPTable tapuTable = new PdfPTable(2);
                tapuTable.WidthPercentage = 100;
                tapuTable.AddCell(new PdfPCell(new Phrase("Ada:", bodyFont)) { Padding = 8, MinimumHeight = 8 });
                tapuTable.AddCell(new PdfPCell(new Phrase(adresTespitResponse.Ada ?? "", bodyFont)) { Padding = 8, MinimumHeight = 8 });

                tapuTable.AddCell(new PdfPCell(new Phrase("Parsel:", bodyFont)) { Padding = 8, MinimumHeight = 8 });
                tapuTable.AddCell(new PdfPCell(new Phrase(adresTespitResponse.Parsel ?? "", bodyFont)) { Padding = 8, MinimumHeight = 8 });

                tapuTable.AddCell(new PdfPCell(new Phrase("Yapı Adı:", bodyFont)) { Padding = 8, MinimumHeight = 8 });
                tapuTable.AddCell(new PdfPCell(new Phrase(adresTespitResponse.BlokAdi ?? "", bodyFont)) { Padding = 8, MinimumHeight = 8 });

                pdfDoc.Add(tapuTable);
                var adresDegisiklikHeaderParagraph = new Paragraph("ADRES DEĞİŞİKLİĞİ BİLGİLERİ", headerFont);
                adresDegisiklikHeaderParagraph.SpacingAfter = 5f; // 5 birim boşluk bırakıyoruz
                pdfDoc.Add(adresDegisiklikHeaderParagraph);
                PdfPTable adresDegisiklikTable = new PdfPTable(2);
                adresDegisiklikTable.WidthPercentage = 100;

                adresDegisiklikTable.AddCell(new PdfPCell(new Phrase("Eski Adres:", new Font(bfArialUniCode, 14, Font.NORMAL))) // Font boyutunu 14 pt yaptık
                {
                    HorizontalAlignment = Element.ALIGN_LEFT, // Soldan hizalama
                    Padding = 10 // Hücre içindeki boşluk
                });
                adresDegisiklikTable.AddCell(new PdfPCell(new Phrase(adresTespitResponse.EskiAdres ?? "", new Font(bfArialUniCode, 14, Font.NORMAL))) // Font boyutunu 14 pt yaptık
                {
                    Padding = 10 // Hücre içindeki boşluk
                });

                // Tabloyu PDF belgesine ekle
                pdfDoc.Add(adresDegisiklikTable);
                pdfDoc.Add(new Paragraph("\n"));


                Paragraph signatureParagraph = new Paragraph();
                signatureParagraph.Add(new Chunk("HAMZA TURGUT\n", new Font(bfArialUniCode, 12, Font.BOLD))); // Kalın ve sağa hizalı
                signatureParagraph.Add(new Chunk("NUMARATAJ PERSONELİ", new Font(bfArialUniCode, 10, Font.NORMAL))); // Altında normal fontla

                // Tüm metni sağa hizalayalım
                signatureParagraph.Alignment = Element.ALIGN_RIGHT;
                pdfDoc.Add(signatureParagraph);
                pdfDoc.Add(new Paragraph("\n"));

                PdfPTable table = new PdfPTable(1)
                {
                    TotalWidth = pdfDoc.PageSize.Width - pdfDoc.LeftMargin - pdfDoc.RightMargin,
                    LockedWidth = true,
                    SpacingBefore = 10f,
                    SpacingAfter = 10f
                };

                // Hücre oluşturma ve ayarlama
                PdfPCell cell = new PdfPCell(new Phrase("Batman Belediye Başkanlığı Şirinevler Mah. Atatürk Bulvarı No:2/Z-4 BATMAN Tel:(0488)2132759 / 1320", new Font(bfArialUniCode, 10, Font.ITALIC)))
                {
                    BorderColor = BaseColor.BLACK,
                    BorderWidth = 0.5f,
                    Padding = 5,
                    HorizontalAlignment = Element.ALIGN_LEFT
                };

                // Hücreyi tabloya ekle
                table.AddCell(cell);

                // Tablonun PDF belgesine eklenmesi
                pdfDoc.Add(table);

                // PDF belgesini kapat
                pdfDoc.Close();
                writer.Close();

                // PDF içeriğini byte dizisi olarak al ve dosya olarak döndür
                byte[] pdfContent = stream.ToArray();
                return File(pdfContent, "application/pdf", pdfName);
            }
        }
    }
}
