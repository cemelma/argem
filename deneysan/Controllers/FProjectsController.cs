
using deneysan.Areas.Admin.Helpers;
using deneysan_DAL.Context;
using deneysan_DAL.Entities;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace deneysan.Controllers
{
  public class FProjectsController : Controller
  {
    //
    // GET: /FProjects/

    string lang = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();

    public ActionResult NewProject()
    {
      var str = Server.MapPath("~/Content/upload/1739476707_deneme.docx");
      return View();
    }

    [HttpPost]
    public JsonResult ProjeKaydet(Projects model, string hdndokumanfile)
    {
      using (DeneysanContext db = new DeneysanContext())
      {

       

        model.PageSlug = Utility.SetPagePlug(model.ProjeAdi);
        model.TimeCreated = DateTime.Now;
        model.Status = 0;
        model.Language = lang;
        

        
        if(System.IO.File.Exists(Server.MapPath("/Content/temp/"+hdndokumanfile)))
        {
          model.ProjeDokümani = Server.MapPath("/Content/upload/" + hdndokumanfile);
         // System.IO.File.Copy(Server.MapPath("~/Content/temp/" + hdndokumanfile), Server.MapPath("~/Content/upload/" + hdndokumanfile));
          System.IO.File.Delete(Server.MapPath("/Content/temp/" + hdndokumanfile));
        }
        db.Projects.Add(model);
        db.SaveChanges();
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
          
            hpf.SaveAs(Path.Combine(Server.MapPath("~/Content/temp/"+fileName)));
         }

         return fileName;
    }

  
    //public ActionResult ProjectContent(int id)
    //{
    //    var project = ProjectManager.GetProjectById(id);
    //    return View(project);
    //}

  }
}
