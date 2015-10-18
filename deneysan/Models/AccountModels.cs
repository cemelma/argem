using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace deneysan.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }

    public class RegisterLoginViewModel
    {
        [Required(ErrorMessage = "Mail Alanı Boş Geçilemez")]
        [Display(Name = "Mail Adresi")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Boş Geçilemez")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name = "Beni hatırla?")]
        public bool RememberMe { get; set; }
    }

    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Mail Alanı Boş Geçilemez")]
        [Display(Name = "Mail Adresi")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Şifre Alanı Boş Geçilemez")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class NewRegister
    {
        [Required(ErrorMessage = "Ad Alanı Boş Geçilemez")]
        [Display(Name = "Ad & Soyad")]
        public string FullaName { get; set; }

        [Required(ErrorMessage = "Mail Alanı Boş Geçilemez")]
        [Display(Name = "Mail Adresi")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Must be a valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Boş Geçilemez")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Bağlı bulunduğunuz kurum/şirket")]
        public string Institution { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "İletişim bilgisi")]
        public string Contact { get; set; }
    }

    public class ApplicationModel
    {
        [Required(ErrorMessage = "Mail Alanı Boş Geçilemez")]
        [Display(Name = "Mail Adresi")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "İsim Alanı Boş Geçilemez")]
        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "CV Dosyası Alanı Boş Geçilemez")]
        [Display(Name = "CV Dosyası")]
        public string CVFile { get; set; }

    }


}
