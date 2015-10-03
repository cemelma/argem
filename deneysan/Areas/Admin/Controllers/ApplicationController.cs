using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using deneysan.Areas.Admin.Filters;
using deneysan_BLL.ContactBL;
using deneysan_BLL.LanguageBL;
using deneysan_DAL.Entities;

namespace deneysan.Areas.Admin.Controllers
{
    [AuthenticateUser]
    public class ApplicationController : Controller
    {

        public ActionResult Index()
        {
            var list = ContactManager.GetApplicationList();
            return View(list);
        }

        [AllowAnonymous]
        public JsonResult DeleteRecord(int id)
        {
            bool isdelete = ContactManager.Delete(id);
            return Json(isdelete);
        }

    }
}
