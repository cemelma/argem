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

            List<Projects> projeler = db.Projects.Where(x=>x.Status==(int)EnumProjectStatus.Confirmed && x.Language==sellang).ToList();
            return View(projeler);
           
          }
         
         
        }

        public ActionResult BekleyenProjeler()
        {
          string sellang = FillLanguagesList();

          using (DeneysanContext db = new DeneysanContext())
          {

            List<Projects> projeler = db.Projects.Where(x => x.Status == (int)EnumProjectStatus.Wait && x.Language == sellang).ToList();
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


        //public JsonResult EditStatus(int id)
        //{
        //    string NowState;
        //    bool isupdate = ProjectManager.UpdateStatus(id);
        //    return Json(isupdate);
        //}


        //public JsonResult Delete(int id)
        //{
        //    bool isdelete = ProjectManager.Delete(id);
        //    //if (isdelete)
        //    return Json(isdelete);
        //    //  else return false;
        //}

        //public JsonResult SortRecords(string list)
        //{
        //    JsonList psl = (new JavaScriptSerializer()).Deserialize<JsonList>(list);
        //    string[] idsList = psl.list;
        //    bool issorted = ProjectManager.SortRecords(idsList);
        //    return Json(issorted);


        //}

        //public class JsonList
        //{
        //    public string[] list { get; set; }
        //}
    }
}
