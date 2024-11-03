﻿
using System.ComponentModel.DataAnnotations;
namespace Numarataj.DTO.DTOs.ResmiKurumDTOs
{
    public class CreateResmiKurumDto
    {
        public int KayıtSiraNo { get; set; }
        public DateTime Tarih { get; set; }
        public string? TcKimlikNo { get; set; }
        public string? AdSoyad { get; set; }
        public string? Telefon { get; set; }
        public string? Mahalle { get; set; }
        public string? CaddeSokak { get; set; }
        public string? DisKapi { get; set; }
        public string? DisKapi2 { get; set; }
        public string? İcKapiNo { get; set; }
        public string? SiteAdi { get; set; }
        public string? BagimsizBolge { get; set; }
        public string? EskiAdres { get; set; }
        public string? BlokAdi { get; set; }
        public string? AdresNo { get; set; }
        public string? IsYeriUnvani { get; set; }
        public string? IcKapiSayisi { get; set; }
        public string? IsyeriSayisi { get; set; }
        public string? Pafta { get; set; }
        public string? Ada { get; set; }
        public string? Parsel { get; set; }
        public string? EsBina { get; set; }
    }

}
