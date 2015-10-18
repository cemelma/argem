using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using deneysan.Areas.Admin.Filters;
using deneysan_BLL.ContactBL;
using deneysan_BLL.LanguageBL;
using deneysan_DAL.Entities;
using deneysan_BLL.UserBL;

namespace deneysan.Areas.Admin.Controllers
{
    [AuthenticateUser]
    public class UserController : Controller
    {

        public ActionResult Index()
        {
            var list = UserManager.UserList();
            return View(list);
        }

        [AllowAnonymous]
        public JsonResult DeleteRecord(int id)
        {
            bool isdelete = UserManager.UserDelete(id);
            return Json(isdelete);
        }

    }
}
