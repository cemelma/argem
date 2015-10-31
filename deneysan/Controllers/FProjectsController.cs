
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
using deneysan.utilities;
using deneysan_BLL.ProductBL;
using deneysan_Data.Entities;

namespace deneysan.Controllers
{
  public class FProjectsController : Controller
  {
    //
    // GET: /FProjects/

    string lang = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();

    public ActionResult NewProject()
    {
      List<ProjectGroup> projeGruplari = ProductManager.GetProjectGroupListForFront(lang);
      ViewBag.ProjeGruplari = new SelectList(projeGruplari, "ProjectGroupId", "GroupName");
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
        string kriter ="";
        if(TempData["kriter"]!=null)
         kriter = TempData["kriter"].ToString();
        List<ProjectGroup> projeGruplari = ProductManager.GetProjectGroupListForFront(lang);
        ViewBag.ProjeGruplari = new SelectList(projeGruplari, "ProjectGroupId", "GroupName");
        List<Projects> projects = new List<Projects>();
        if (!string.IsNullOrEmpty(kriter))
        {
          projects = db.Projects.Where(x => x.Language == lang && x.Deleted == false && x.Online == true && x.Status == (int)EnumProjectStatus.Confirmed && x.ProjeAdi.ToLower().Trim().Contains(kriter.ToLower().Trim())).OrderByDescending(x => x.ProjeId).ToList();
        }
        else
        {
         projects = db.Projects.Where(x => x.Language == lang && x.Deleted == false && x.Online == true && x.Status == (int)EnumProjectStatus.Confirmed).OrderByDescending(x => x.ProjeId).ToList();
        }
        
        ViewBag.Kriter = kriter;
        return View(projects);
      }

    }

    public ActionResult ProjectDetail(int id)
    {
      ProjectDetailModel model = new ProjectDetailModel();
      using (DeneysanContext db = new DeneysanContext())
      {
       Projects project = db.Projects.Where(x => x.ProjeId == id).FirstOrDefault();
       List<ProjectsGallery> gallery = new List<ProjectsGallery>();
        if(project!=null)
        {
          model.Project = project;

          gallery = db.ProjectsGallery.Where(x=>x.ProjeId==id).ToList();
        //  if(gallery!=null && gallery.Count()>0 )
           
        }
           model.ProjectImages = gallery;
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

    public class SearchProjectCriteria
    {
      public string Adi { get; set; }
      public string Suresi { get; set; }
      public string Yer { get; set; }
      public string Butce { get; set; }
      public int? ProjeGrubu{ get; set; }
      
    }

    [HttpPost]
    //public ActionResult SearchProject(SearchProjectCriteria criteria)
    public ActionResult SearchProject(FormCollection frm)
    {
      SearchProjectCriteria criteria = new SearchProjectCriteria();
      criteria.Adi = frm["txtsearchname"];
      criteria.Yer = frm["txtsearchplace"];
      criteria.Suresi = frm["txtsearchtime"];
      criteria.Butce = frm["txtsearchbudget"];
      if (!string.IsNullOrEmpty(frm["drpprojegruplari"].ToString()))
        criteria.ProjeGrubu = Convert.ToInt32(frm["drpprojegruplari"]);
      
      if(!string.IsNullOrEmpty(criteria.Adi))
        criteria.Adi = criteria.Adi.Replace(',',' ').Trim();


       List<Projects> projects = new List<Projects>();
      using (DeneysanContext db = new DeneysanContext())
      {
        if (criteria != null)
        {
          bool isadNull = string.IsNullOrEmpty(criteria.Adi) ? true : false;
          bool isyerNull = string.IsNullOrEmpty(criteria.Yer) ? true : false;
          bool isbutceNull = string.IsNullOrEmpty(criteria.Butce) ? true : false;
          bool issureNull = string.IsNullOrEmpty(criteria.Suresi) ? true : false;
          bool isgrupNull = !criteria.ProjeGrubu.HasValue ? true : false;

          projects = db.Projects.Where(x => (isadNull || x.ProjeAdi.Contains(criteria.Adi)) && (isyerNull || x.UygulanacagiYer.Contains(criteria.Yer)) && (isbutceNull || x.ProjeButcesi == criteria.Butce) && (issureNull || x.ProjeSuresi == criteria.Suresi)).ToList();

          if (criteria.ProjeGrubu.HasValue)
            projects = projects.Where(x=>x.Language == lang && x.Deleted == false && x.Online == true && x.Status == (int)EnumProjectStatus.Confirmed && x.ProjectGroupId==criteria.ProjeGrubu.Value).OrderByDescending(x => x.ProjeId).ToList();
          else
            projects = projects.Where(x => x.Language == lang && x.Deleted == false && x.Online == true && x.Status == (int)EnumProjectStatus.Confirmed).OrderByDescending(x => x.ProjeId).ToList();
        }
        else
        {
         projects = db.Projects.Where(x => x.Language == lang && x.Deleted == false && x.Online == true && x.Status == 1).OrderByDescending(x => x.ProjeId).ToList();
        }
        return PartialView("_projectlistpartial", projects);
      }
    }

 
    
    //public ActionResult ProjectContent(int id)
    //{
    //    var project = ProjectManager.GetProjectById(id);
    //    return View(project);
    //}

  }
}
