using System.ComponentModel.DataAnnotations;

namespace Numarataj.Entity.Entities
{
    public class BaseEntity
    {
        [Key]
        public int BelgeNoId { get; set; }
        public DateTime? Tarih { get; set; }

        [StringLength(11, ErrorMessage = "TC Kimlik No 11 karakterden uzun olamaz.")]
        public string? TcKimlikNo { get; set; }

        [StringLength(100, ErrorMessage = "Ad Soyad 100 karakterden uzun olamaz.")]
        public string? AdSoyad { get; set; }

        [StringLength(15, ErrorMessage = "Telefon numarası 15 karakterden uzun olamaz.")]
        public string? Telefon { get; set; }

        [StringLength(100, ErrorMessage = "Mahalle adı 100 karakterden uzun olamaz.")]
        public string? Mahalle { get; set; }

        [StringLength(100, ErrorMessage = "Cadde Sokak adı 100 karakterden uzun olamaz.")]
        public string? CaddeSokak { get; set; }
        public string? DisKapi { get; set; }

        [StringLength(10, ErrorMessage = "Dış Kapı2 10 karakterden uzun olamaz.")]
        public string? DisKapi2 { get; set; }

        [StringLength(50, ErrorMessage = "İç Kapı No 50 karakterden uzun olamaz.")]
        public string? İcKapiNo { get; set; }

        [StringLength(100, ErrorMessage = "Site Adı 100 karakterden uzun olamaz.")]
        public string? SiteAdi { get; set; }

        [StringLength(100, ErrorMessage = "Bağımsız Bölge 100 karakterden uzun olamaz.")]
        public string? BagimsizBolge { get; set; }

        [StringLength(250, ErrorMessage = "Eski Adres 250 karakterden uzun olamaz.")]
        public string? EskiAdres { get; set; }

        [StringLength(50, ErrorMessage = "Blok Adı 50 karakterden uzun olamaz.")]
        public string? BlokAdi { get; set; }

        [StringLength(10, ErrorMessage = "Adres No 10 karakterden uzun olamaz.")]
        public string? AdresNo { get; set; }

        [StringLength(100, ErrorMessage = "İş Yeri Unvanı 100 karakterden uzun olamaz.")]
        public string? IsYeriUnvani { get; set; }

        [StringLength(10, ErrorMessage = "İç Kapı Sayısı 10 karakterden uzun olamaz.")]
        public string? IcKapiSayisi { get; set; }

        [StringLength(10, ErrorMessage = "İş Yeri Sayısı 10 karakterden uzun olamaz.")]
        public string? IsyeriSayisi { get; set; }

        [StringLength(50, ErrorMessage = "Pafta 50 karakterden uzun olamaz.")]
        public string? Pafta { get; set; }

        [StringLength(50, ErrorMessage = "Ada 50 karakterden uzun olamaz.")]
        public string? Ada { get; set; }

        [StringLength(50, ErrorMessage = "Parsel 50 karakterden uzun olamaz.")]
        public string? Parsel { get; set; }
    }
}
