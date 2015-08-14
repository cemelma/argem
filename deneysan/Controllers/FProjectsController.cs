
using deneysan.Areas.Admin.Helpers;
using deneysan_DAL.Context;
using deneysan_DAL.Entities;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
namespace deneysan.Controllers
{
  public class FProjectsController : Controller
  {
    //
    // GET: /FProjects/

    string lang = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();

    public ActionResult NewProject()
    {
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



        if (!string.IsNullOrEmpty(hdnimagefile))
        {
            model.ProjeDokümani = "/Content/upload/" + hdndokumanfile;
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
         // model.ProjeResimleri = hdndokumanfile;
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
        List<Projects>  projects =db.Projects.Where(x => x.Language == lang).ToList();

        return View(projects);
      }

    }

    public ActionResult ProjectDetail(int id)
    {
      using (DeneysanContext db = new DeneysanContext())
      {
       var project = db.Projects.Where(x => x.ProjeId == id).FirstOrDefault();

        return View(project);
      }

    }
    
    //public ActionResult ProjectContent(int id)
    //{
    //    var project = ProjectManager.GetProjectById(id);
    //    return View(project);
    //}

  }
}
