using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using deneysan.Areas.Admin.Helpers;
using deneysan_BLL.LanguageBL;
//using deneysan_BLL.Project;
using deneysan_DAL.Entities;
using deneysan.Areas.Admin.Filters;
using deneysan_DAL.Context;
using deneysan.utilities;

namespace deneysan.Areas.Admin.Controllers
{
  [AuthenticateUser]
  public class ProjectController : Controller
  {
    //
    // GET: /Admin/Project/

    public ActionResult OnaylananProjeler()
    {
      string sellang = FillLanguagesList();

      using (DeneysanContext db = new DeneysanContext())
      {

        List<Projects> projeler = db.Projects.Where(x => x.Status == (int)EnumProjectStatus.Confirmed && x.Language == sellang && x.Deleted == false).ToList();
        return View(projeler);

      }


    }

    public ActionResult BekleyenProjeler()
    {
      string sellang = FillLanguagesList();

      using (DeneysanContext db = new DeneysanContext())
      {

        List<Projects> projeler = db.Projects.Where(x => x.Status == (int)EnumProjectStatus.Wait && x.Language == sellang && x.Deleted == false).ToList();
        return View(projeler);

      }


    }

    public ActionResult IptalEdilenProjeler()
    {
      string sellang = FillLanguagesList();

      using (DeneysanContext db = new DeneysanContext())
      {

        List<Projects> projeler = db.Projects.Where(x => x.Status == (int)EnumProjectStatus.Canceled && x.Language == sellang && x.Deleted == false).ToList();
        return View(projeler);

      }


    }

    //public ActionResult AddProject()
    //{
    //    var languages = LanguageManager.GetLanguages();
    //    var list = new SelectList(languages, "Culture", "Language");
    //    ViewBag.LanguageList = list;

    //    return View();
    //}


    //[HttpPost]
    //[ValidateInput(false)]
    //public ActionResult AddProject(Projects newmodel, HttpPostedFileBase uploadfile)
    //{
    //    var languages = LanguageManager.GetLanguages();
    //    var list = new SelectList(languages, "Culture", "Language");
    //    ViewBag.LanguageList = list;
    //    if (ModelState.IsValid)
    //    {
    //        if (uploadfile != null && uploadfile.ContentLength > 0)
    //        {
    //            Random random = new Random();
    //            int rand = random.Next(1000, 99999999);
    //            uploadfile.SaveAs(Server.MapPath("/Content/images/projects/" + Utility.SetPagePlug(newmodel.Name) + "_" + rand + Path.GetExtension(uploadfile.FileName)));
    //            newmodel.ProjectFile = "/Content/images/projects/" + Utility.SetPagePlug(newmodel.Name) + "_" + rand + Path.GetExtension(uploadfile.FileName);
    //        }
    //        newmodel.PageSlug = Utility.SetPagePlug(newmodel.Name);
    //        newmodel.TimeCreated = DateTime.Now;
    //        ViewBag.ProcessMessage = ProjectManager.AddProject(newmodel);
    //        ModelState.Clear();

    //        return View();
    //    }
    //    else
    //        return View();
    //}


    //public ActionResult EditProject()
    //{
    //    var languages = LanguageManager.GetLanguages();
    //    var list = new SelectList(languages, "Culture", "Language");
    //    ViewBag.LanguageList = list;
    //    if (RouteData.Values["id"] != null)
    //    {
    //        int nid = 0;
    //        bool isnumber = int.TryParse(RouteData.Values["id"].ToString(), out nid);
    //        if (isnumber)
    //        {
    //            Projects editrecord = ProjectManager.GetProjectById(nid);
    //            return View(editrecord);
    //        }
    //        else
    //            return View();
    //    }
    //    else
    //        return View();
    //    return View();
    //}


    //[HttpPost]
    //[ValidateInput(false)]
    //public ActionResult EditProject(Projects newmodel, HttpPostedFileBase uploadfile)
    //{
    //    var languages = LanguageManager.GetLanguages();
    //    var list = new SelectList(languages, "Culture", "Language");
    //    ViewBag.LanguageList = list;

    //    if (ModelState.IsValid)
    //    {
    //        if (uploadfile != null && uploadfile.ContentLength > 0)
    //        {
    //            Random random = new Random();
    //            int rand = random.Next(1000, 99999999);
    //            uploadfile.SaveAs(Server.MapPath("/Content/images/projects/" + Utility.SetPagePlug(newmodel.Name) + "_" + rand + Path.GetExtension(uploadfile.FileName)));
    //            newmodel.ProjectFile = "/Content/images/projects/" + Utility.SetPagePlug(newmodel.Name) + "_" + rand + Path.GetExtension(uploadfile.FileName);
    //        }

    //        newmodel.PageSlug = Utility.SetPagePlug(newmodel.Name);

    //        if (RouteData.Values["id"] != null)
    //        {
    //            int nid = 0;
    //            bool isnumber = int.TryParse(RouteData.Values["id"].ToString(), out nid);
    //            if (isnumber)
    //            {
    //                newmodel.ProjectId = nid;
    //                ViewBag.ProcessMessage = ProjectManager.EditProject(newmodel);
    //                return View(newmodel);
    //            }
    //            else
    //            {
    //                ViewBag.ProcessMessage = false;
    //                return View(newmodel);
    //            }
    //        }
    //        else return View();
    //    }
    //    else
    //        return View();

    //    return View();
    //}


    string FillLanguagesList()
    {
      string lang = "";
      if (RouteData.Values["lang"] == null)
        lang = "tr";
      else lang = RouteData.Values["lang"].ToString();

      var languages = LanguageManager.GetLanguages();
      var list = new SelectList(languages, "Culture", "Language", lang);
      ViewBag.LanguageList = list;
      return lang;
    }

    public JsonResult DeleteRecord(int id)
    {
      using (DeneysanContext db = new DeneysanContext())
      {
        var record = db.Projects.FirstOrDefault(d => d.ProjeId == id);
        record.Deleted = true;

        db.SaveChanges();
        return Json(true);
      }

    }

  
    public bool ChangeProjectStatus(int id, int status)
    {
      bool returnValue = false;
      using (DeneysanContext db = new DeneysanContext())
      {
        if (db.Projects.Any(d => d.ProjeId == id))
        {
          Projects record = db.Projects.FirstOrDefault(d => d.ProjeId == id);
          record.Status = status;
          db.SaveChanges();
            return true;
        }
        else
        {
          return returnValue;
        }

      }
    }

    public JsonResult EditStatus(int id)
    {
      using (DeneysanContext db = new DeneysanContext())
      {
        var list = db.Projects.SingleOrDefault(d => d.ProjeId == id);
        try
        {

          if (list != null)
          {
            list.Online = list.Online == true ? false : true;
            db.SaveChanges();

          }
          return Json(list.Online);

        }
        catch (Exception)
        {
          return Json(list.Online);
        }
      }
    }

  

   

    public ActionResult EditProject(int id)
    {
      ProjectDetailModel model = new ProjectDetailModel();
      using (DeneysanContext db = new DeneysanContext())
      {
        if (RouteData.Values["id"] != null)
        {
          int nid = 0;
          bool isnumber = int.TryParse(RouteData.Values["id"].ToString(), out nid);
          if (isnumber)
          {
            Projects record = db.Projects.Where(x => x.ProjeId == id).FirstOrDefault();
            model.Project = record;

            model.ProjectImages = db.ProjectsGallery.Where(x => x.ProjeId == id).ToList();

            var languages = LanguageManager.GetLanguages();
            var list = new SelectList(languages, "Culture", "Language", record.Language);
            ViewBag.LanguageList = list;
            return View(model);
          }
          else
            return View();
        }
        else
          return View();
      }
    }




    [HttpPost]
    public ActionResult EditProject(Projects model, string hdnProjeDokumani,string hdnimagefile)
    {
    
      using (DeneysanContext db = new DeneysanContext())
      {

        model.PageSlug = Utility.SetPagePlug(model.ProjeAdi);
        if (!string.IsNullOrEmpty(hdnProjeDokumani))
        {
          model.ProjeDokümani = "/Content/projectfiles/" + hdnProjeDokumani;
        }
        else
          model.ProjeDokümani = "";

        model.TimeUpdated = DateTime.Now;

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
        }

        var languages = LanguageManager.GetLanguages();
        var list = new SelectList(languages, "Culture", "Language", model.Language);
        ViewBag.LanguageList = list;
        return View(model);

      }
    
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
        fileName = Utility.SetPagePlug(thhpf.FileName.Split('.')[0]) + rand + Path.GetExtension(thhpf.FileName);
        thhpf.SaveAs(Server.MapPath("/Content/images/projects/" + fileName));

        rand = random.Next(1000, 99999999);
        new ImageHelper(280, 240).SaveThumbnail(hpf, "/Content/images/projects/", "thumb_" + fileName);

      }

      return fileName;

    }



    public FileResult Download(string fileName)
    {

      return File(Server.MapPath("~/Content/projectfiles/" + fileName), "text/plain", "text/plain");
    }


    [HttpPost]
    public void DeleteProjectImage(int id)
    {
      using (DeneysanContext db = new DeneysanContext())
      {
        try
        {
          var record = db.ProjectsGallery.FirstOrDefault(d => d.ProjeId == id);
          db.ProjectsGallery.Remove(record);
          db.SaveChanges();

       
        }
        catch (Exception)
        {
         
        }
      }
    }


  }

  

  public class ProjectDetailModel
  {
    public Projects Project { get; set; }
    public List<ProjectsGallery> ProjectImages { get; set; }
  }


}
