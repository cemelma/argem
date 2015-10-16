using deneysan_Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneysan_DAL.Entities
{
    public class Projects
    {
        [Key]
        public int ProjeId { get; set; }


        [Display(Name = "Adı Soyadı / Ünvanı")]
        [Required(ErrorMessage = "Proje sahibinin bilgilerini giriniz.")]
        public string ProjeSahibi { get; set; }

        [Display(Name = "Bağlı Bulunduğu Kurum/Kuruluş")]
     //   [Required(ErrorMessage = "Proje sahibinin bilgilerini giriniz.")]
        public string ProjeSahibiKurumu { get; set; }


        [Display(Name = "Telefon Numarası(Sabit Hat-Cep)")]
        [Required(ErrorMessage = "Telefon bilgisini giriniz.")]
        public string Telefon { get; set; }


        [Display(Name = "Faks Numarası")]
        //[Required(ErrorMessage = "Faks bilgisini giriniz.")]
        public string Faks { get; set; }


        [Display(Name = "Posta Adresi")]
        [Required(ErrorMessage = "Posta adresi bilgisini giriniz.")]
        public string PostaAdresi { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail bilgisini giriniz.")]
        public string Email { get; set; }


        [Display(Name = "Proje İsmi")]
        [Required(ErrorMessage = "Proje adını giriniz.")]
        public string ProjeAdi { get; set; }

        [Display(Name = "Projenin Özel Amacı")]
        [Required(ErrorMessage = "Projenin özel amacını giriniz.")]
        public string ProjeAmac { get; set; }

        [Display(Name = "Projenin Genel Hedefi")]
        [Required(ErrorMessage = "Projenin genel hedefini giriniz.")]
        public string ProjeHedefi { get; set; }

        [Display(Name = "Projenin Süresi")]
        [Required(ErrorMessage = "Projenin süresini giriniz.")]
        public string ProjeSuresi { get; set; }


        [Display(Name = "Projenin Toplam Bütçesi")]
        [Required(ErrorMessage = "Projenin toplam bütçesini giriniz.")]
        public string ProjeButcesi { get; set; }


        [Display(Name = "Projeyi Finanse Eden Kuruluş")]
        [Required(ErrorMessage = "Projeyi finanse eden kuruluşu giriniz.")]
        public string FinanseEdenKurum { get; set; }


        [Display(Name = "Projenin Uygulanacağı Yer")]
        [Required(ErrorMessage = "Projenin Uygulanacağı yeri girin.")]
        public string UygulanacagiYer { get; set; }


        [Display(Name = "Projenin Beklenen Sonuçları")]
        [Required(ErrorMessage = "Projenin beklenen sonuçlarını giriniz.")]
        public string BeklenenSonuclar { get; set; }

        [Display(Name = "Projenin Kısa Özeti ve İçeriği")]
        [Required(ErrorMessage = "Projenin özetini giriniz.")]
        public string ProjeOzeti { get; set; }

        [Display(Name = "Proje Dökümanı")]
        public string ProjeDokümani { get; set; }

        [Display(Name = "Proje Çizimi")]
        public string ProjeCizimi { get; set; }



        [Display(Name = "Proje Resmi")]
        public string ProjeResimleri { get; set; } 

        [Display(Name = "Dil")]
        [Required(ErrorMessage = "Dili Seçiniz.")]
        public string Language { get; set; }
        public string PageSlug { get; set; }
        public int SortOrder { get; set; }


        public DateTime? TimeCreated{ get; set; }
        public DateTime? TimeUpdated { get; set; }
        public bool Online { get; set; }
        public bool Deleted { get; set; }
        public int Status { get; set; }

        [Required(ErrorMessage = "Proje grubunu seçiniz")]
        public int ProjectGroupId { get; set; }
        public virtual ProjectGroup ProjectGroup { get; set; }
    }
}
