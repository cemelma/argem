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

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(User model)
        {
            ViewBag.ProcessMessage = UserManager.AddUsers(model);
            ModelState.Clear();
            return View();
        }


        public ActionResult Edit()
        {
            if (RouteData.Values["id"] != null)
            {
                int nid = 0;
                bool isnumber = int.TryParse(RouteData.Values["id"].ToString(), out nid);
                if (isnumber)
                {
                    User editrecord = UserManager.GetUsersById(nid);
                    return View(editrecord);
                }
                else
                    return View();
            }
            else return View();
        }

        [HttpPost]
        public ActionResult Edit(User model)
        {
            if (ModelState.IsValid)
            {
                if (RouteData.Values["id"] != null)
                {
                    int nid = 0;
                    bool isnumber = int.TryParse(RouteData.Values["id"].ToString(), out nid);
                    if (isnumber)
                    {
                        model.UserId = nid;
                        ViewBag.ProcessMessage = UserManager.EditUser(model);
                        return View(model);
                    }
                    else
                    {
                        ViewBag.ProcessMessage = false;
                        return View(model);
                    }
                }
                else return View();
            }
            else return View();
        }

    }
}
