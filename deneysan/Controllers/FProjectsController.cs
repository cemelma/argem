
using deneysan.Areas.Admin.Helpers;
using deneysan_DAL.Context;
using deneysan_DAL.Entities;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using deneysan.Models;
using deneysan_BLL.MailBL;
using System.Net.Mail;
using System.Net;

namespace deneysan.Controllers
{
  public class FProjectsController : Controller
  {
    //
    // GET: /FProjects/

    string lang = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();

    public ActionResult NewProject()
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
        var str = Server.MapPath("");
      return View();
    }

    [HttpPost]
    public JsonResult ProjeKaydet(Projects model, string hdndokumanfile, string hdnimagefile)
    {
      using (DeneysanContext db = new DeneysanContext())
      {
        model.PageSlug = Utility.SetPagePlug(model.ProjeAdi);
        model.TimeCreated = DateTime.Now;
        model.Status = 0;
        model.Language = lang;
        model.Online = true;


        if (!string.IsNullOrEmpty(hdnimagefile))
        {
          model.ProjeDokümani = "/Content/projectfiles/" + hdndokumanfile;
        }

        db.Projects.Add(model);
        db.SaveChanges();

        if (!string.IsNullOrEmpty(hdnimagefile))
        {

          string[] imagesArray = hdnimagefile.Split(',');

          if (imagesArray != null && imagesArray.Length > 0)
          {
            for (int i = 0; i < imagesArray.Length; i++)
            {
              ProjectsGallery g = new ProjectsGallery();
              g.ProjeId = model.ProjeId;
              g.Image = "/Content/images/projects/" + imagesArray[i];
              g.ImageThumb = "/Content/images/projects/" + "thumb_" + imagesArray[i];
              db.ProjectsGallery.Add(g);
            }
          }

          db.SaveChanges();



          var mset = MailManager.GetMailSettings();
          var msend = MailManager.GetMailUsersList(1);

          using (var client = new SmtpClient(mset.ServerHost, mset.Port))
          {
            client.EnableSsl = false;
            client.Credentials = new NetworkCredential(mset.ServerMail, mset.Password);
            var mail = new MailMessage();
            mail.From = new MailAddress(mset.ServerMail);
            foreach (var item in msend)
              mail.To.Add(item.MailAddress);
            mail.Subject = "Yeni Proje Başvuru Bildirimi";
            mail.IsBodyHtml = true;
            mail.Body = "<h5><b>" + model.ProjeSahibi + " isimli kişiden bir proje başvurusu sistemde kayıt altına alınmıştır</b></h5>";

            if (mail.To.Count > 0) client.Send(mail);
          }


        }

      }
      return Json(true);
    }

     [HttpPost]
    public string SaveProjectDocumentFile()
    {
      Random rnd = new Random();
      int rndfilename = rnd.Next();
        HttpPostedFileBase hpf = Request.Files[0] as HttpPostedFileBase;
        string fileName = "";
         if (hpf.ContentLength != 0)
         {
           fileName = rndfilename + "_" + hpf.FileName;

           hpf.SaveAs(Path.Combine(Server.MapPath("/Content/projectfiles/" + fileName)));
         }

         return fileName;
    }

    [HttpPost]
    public string SaveProjectImages()
    {
      Random rnd = new Random();
      int rndfilename = rnd.Next();
        HttpPostedFileBase hpf = Request.Files[0] as HttpPostedFileBase;
        HttpPostedFileBase thhpf = hpf;

        string fileName = "";
         if (hpf.ContentLength != 0)
         {
           Random random = new Random();
           int rand = random.Next(1000, 99999999);
           fileName = Utility.SetPagePlug(thhpf.FileName.Split('.')[0])  + rand + Path.GetExtension(thhpf.FileName);
           thhpf.SaveAs(Server.MapPath("/Content/images/projects/" + fileName));

           rand = random.Next(1000, 99999999);
           new ImageHelper(280, 240).SaveThumbnail(hpf, "/Content/images/projects/","thumb_"+fileName);

         }

         return fileName;

    }


    public ActionResult ProjectList()
    {
      using (DeneysanContext db = new DeneysanContext())
      {
        List<Projects> projects = db.Projects.Where(x => x.Language == lang && x.Deleted == false && x.Online == true && x.Status == 1).OrderByDescending(x => x.ProjeId).ToList();

        return View(projects);
      }

    }

    public ActionResult ProjectDetail(int id)
    {
      ProjectDetailModel model = new ProjectDetailModel();
      using (DeneysanContext db = new DeneysanContext())
      {
       Projects project = db.Projects.Where(x => x.ProjeId == id).FirstOrDefault();
        if(project!=null)
        {
          model.Project = project;

          List<ProjectsGallery> gallery = db.ProjectsGallery.Where(x=>x.ProjeId==id).ToList();
          if(gallery!=null && gallery.Count()>0 )
            model.ProjectImages = gallery;
        }

        return View(model);
      }

    }

    public FileResult Download(string fileName)
    {
   
      return File(Server.MapPath("~/Content/projectfiles/"+fileName), "text/plain", "text/plain");
    }


    public class ProjectDetailModel
    {
      public Projects Project { get;set;}
      public List<ProjectsGallery> ProjectImages { get;set;}
    }

 
    
    //public ActionResult ProjectContent(int id)
    //{
    //    var project = ProjectManager.GetProjectById(id);
    //    return View(project);
    //}

  }
}
