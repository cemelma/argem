using deneysan.Areas.Admin.Filters;
using deneysan.Areas.Admin.Helpers;
using deneysan_BLL.LanguageBL;
using deneysan_BLL.ProductBL;
using deneysan_Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace deneysan.Areas.Admin.Controllers
{
  [AuthenticateUser]
    public class ProjectGroupController : Controller
    {
      public ActionResult Index()
      {
        string lang = FillLanguagesList();
        var grouplist = ProductManager.GetProjectGroupList(lang);
        return View(grouplist);
      }


      [HttpPost]
      public ActionResult Index(string drplanguage, string txtname)
      {
        string lang = FillLanguagesList();
        if (ModelState.IsValid)
        {
          ProjectGroup model = new ProjectGroup();
          model.GroupName = txtname;
          model.Language = drplanguage;
          //if (uploadfile != null && uploadfile.ContentLength > 0)
          //{
          //  Random random = new Random();
          //  int rand = random.Next(1000, 99999999);
          //  new ImageHelper(280, 240).SaveThumbnail(uploadfile, "/Content/images/productcategory/", Utility.SetPagePlug(model.GroupName) + "_" + rand + Path.GetExtension(uploadfile.FileName));
          //  model.GroupImage = "/Content/images/productcategory/" + Utility.SetPagePlug(model.GroupName) + "_" + rand + Path.GetExtension(uploadfile.FileName);
          //}
          //else
          //{
          //  model.GroupImage = "/Content/images/front/noimage.jpeg";
          //}

          model.PageSlug = Utility.SetPagePlug(txtname);
          ViewBag.ProcessMessage = ProductManager.AddProjectGroup(model);

          var grouplist = ProductManager.GetProjectGroupList(lang);

          return View(grouplist);


        }
        return View();
      }


      public ActionResult EdtiGroup()
      {
        var languages = LanguageManager.GetLanguages();
        var list = new SelectList(languages, "Culture", "Language");
        ViewBag.LanguageList = list;
        if (RouteData.Values["id"] != null)
        {
          int nid = 0;
          bool isnumber = int.TryParse(RouteData.Values["id"].ToString(), out nid);
          if (isnumber)
          {
            ProjectGroup editnews = ProductManager.GetGroupById(nid);
            return View(editnews);
          }
          else
            return View();
        }
        else
          return View();
      }

      [HttpPost]
      public ActionResult EdtiGroup(ProjectGroup model, HttpPostedFileBase uploadfile)
      {
        var languages = LanguageManager.GetLanguages();
        var list = new SelectList(languages, "Culture", "Language");
        ViewBag.LanguageList = list;
        if (ModelState.IsValid)
        {
          //ProjectGroup model = new ProjectGroup();
          // model.GroupName = txtname;
          //model.Language = drplanguage;
          if (uploadfile != null && uploadfile.ContentLength > 0)
          {
            Random random = new Random();
            int rand = random.Next(1000, 99999999);
           
          }
          if (RouteData.Values["id"] != null)
          {
            int nid = 0;
            bool isnumber = int.TryParse(RouteData.Values["id"].ToString(), out nid);
            if (isnumber)
            {
              model.PageSlug = Utility.SetPagePlug(model.GroupName);
              model.ProjectGroupId = nid;
              ViewBag.ProcessMessage = ProductManager.EditProjectGroup(model);
              return View(model);
            }
            else
            {
              ViewBag.ProcessMessage = false;
              return View(model);
            }
          }

        }
        return View();
      }




      public void UpdateRecord(int id, string name)
      {
        string clearname = name.Replace("%47", "\'");
        string pageslug = Utility.SetPagePlug(clearname);
        ProductManager.EditProjectGroup(id, clearname, pageslug);
      }


      public JsonResult GroupEditStatus(int id)
      {
        return Json(ProductManager.UpdateGroupStatus(id));
      }

      public JsonResult DeleteRecord(int id)
      {
        return Json(ProductManager.DeleteGroup(id));
      }


      public JsonResult SortRecords(string list)
      {
        JsonList psl = (new JavaScriptSerializer()).Deserialize<JsonList>(list);
        string[] idsList = psl.list;
        bool issorted = ProductManager.SortRecords(idsList);
        return Json(issorted);


      }

      public class JsonList
      {
        public string[] list { get; set; }
      }


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

    }
}
