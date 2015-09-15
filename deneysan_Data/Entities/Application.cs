using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneysan_DAL.Entities
{
    public class Application
    {
         public int ApplicationId { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "İsim Alanı Boş Geçilemez")]
        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "CV Dosyası Alanı Boş Geçilemez")]
        [Display(Name = "CV Dosyası")]
        public string CVFile { get; set; }

    }
}
