using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneysan_DAL.Entities
{
    public class User
    {
        
        public int UserId { get; set; }

        [Required(ErrorMessage = "İsim Alanı Boş Geçilemez")]
        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Mail Alanı Boş Geçilemez")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Boş Geçilemez")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Bağlı bulunduğunuz kurum/şirket")]
        public string Institution { get; set; }

        [Display(Name = "İletişim bilgisi")]
        public string Contact { get; set; }

        public bool isActive { get; set; }
    }
}
