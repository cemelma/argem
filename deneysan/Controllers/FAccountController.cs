using deneysan_BLL.ContactBL;
using deneysan_BLL.BankBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using deneysan_BLL.MailBL;
using deneysan.Models;
using deneysan_BLL.UserBL;

namespace deneysan.Controllers
{
    public class FAccountController : Controller
    {
        string lang = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();

        public ActionResult Index()
        {
            
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public ActionResult Index(RegisterLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (UserManager.Login(model.Email, model.Password))
                {
                    #region Cookie oluştur

                    string cookieName = "RegCookie";
                    HttpCookie getCookie = Request.Cookies[cookieName];
                    if (getCookie != null)
                    {
                        getCookie.Expires = DateTime.Now.AddHours(1);
                        getCookie = CyriptoClass.DecodeCookie(getCookie);
                        Response.Cookies.Set(getCookie);
                    }
                    else
                    {
                        getCookie = new HttpCookie(cookieName);
                        getCookie["UserName"] = model.Email;
                        getCookie.Expires = DateTime.Now.AddHours(1); // Burada 1 saat geçerlikik süresi oluşturuyoruz. 
                        getCookie = CyriptoClass.EncodeCookie(getCookie);
                        Response.Cookies.Add(getCookie);
                    }

                    #endregion
                    ///@SharedRess.SharedStrings.menu_culture/@SharedRess.SharedStrings.menuprojects_link
                    return RedirectToRoute("projects_" + lang, new { controller = "FProjects", action = "NewProject" });
                    //return RedirectToAction("Index", "FHome");
                }

                ModelState.AddModelError("", "Mail veya Şifreniz Hatalı.");
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult RegisterLogOut()
        {
            string cookieName = "RegCookie";
            HttpCookie getCookie = Request.Cookies[cookieName];
            if (getCookie != null)
            {
                getCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(getCookie);
            }
            return RedirectToAction("Index", "FHome");
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public ActionResult ForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                Tuple<bool, string> pass = UserManager.IsMailControl(model.Email);
                if (pass.Item1)
                {

                    var mset = MailManager.GetMailSettings();
                    using (var client = new SmtpClient(mset.ServerHost, mset.Port))
                    {
                        client.EnableSsl = false;
                        client.Credentials = new NetworkCredential(mset.ServerMail, mset.Password);
                        var mail = new MailMessage();
                        mail.From = new MailAddress(mset.ServerMail);
                        mail.To.Add(model.Email);
                        mail.Subject = "Argemsan.com şifre hatırlatma";
                        mail.IsBodyHtml = true;
                        mail.Body = "<div><b> Argemsan.com şifreniz: "+pass.Item2+"</b></div>";

                        if (mail.To.Count > 0) client.Send(mail);
                        ViewBag.process = "Şifreniz mail adresinize gönderilmiştir. Lütfen mail adresinizi kontrol ediniz ";
                        return View();
                    }
                }
                ViewBag.process = "Mail adresi bulunamadı";
                //ModelState.AddModelError("", "Mail adresi bulunamadı.");
            }
            return View(model);
        }

        public ActionResult ChangePassword()
        {
            HttpCookie cookie = Request.Cookies["RegCookie"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddHours(1);
                cookie = CyriptoClass.DecodeCookie(cookie);
                Request.Cookies.Set(cookie);
            }
            else
            {
                return RedirectToRoute("login_" + lang, new { controller = "FAccount", action = "Index" });
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                string email = "";
                HttpCookie cookie = Request.Cookies["RegCookie"];
                if (cookie != null)
                {
                    cookie.Expires = DateTime.Now.AddHours(1);
                    cookie = CyriptoClass.DecodeCookie(cookie);
                    email = cookie["UserName"];
                    Request.Cookies.Set(cookie);
                }

                if (UserManager.ChangePassword(model.Password, email))
                {
                    ViewBag.process = "Şifreniz güncellenmiştir.";
                }
                else ViewBag.process = "Şifre güncelleme hatası.";
                //ModelState.AddModelError("", "Mail adresi bulunamadı.");
            }
            return View(model);
        }

        public ActionResult NewRecord()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public ActionResult NewRecord(NewRegister model)
        {
            if (ModelState.IsValid)
            {
                if(!UserManager.IsMailControlRecord(model.Email))
                {
                    if (UserManager.Record(model.FullaName, model.Email, model.Password))
                    {
                        ViewBag.process = "Üyeliğiniz gerçekleşmiştir, sisteme giriş yapabilirsiniz.";
                        //return RedirectToRoute("login_" + lang, new { controller = "FAccount", action = "Index" });
                        //return RedirectToAction("Index", "FHome");
                    }
                    else ViewBag.process = "Üyelik sırasında bir hata oluştu.";
                }
                else ViewBag.process = "Mail adresi kullanımda!";


            }
            else ModelState.AddModelError("", "Lütfen mail adresinizi ve şifrenizi kontrol ediniz.");

            return View(model);
        }

    }
}
