using deneysan_BLL.InstituionalBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using deneysan.Helpers.Enums;

namespace deneysan.Controllers
{
    public class FInstitutionalController : Controller
    {
        string lang = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();

        //
        // GET: /Kurumsal/

        public ActionResult Index()
        {

            var aboutus = InstituionalManager.GetInstationalByLanguage(lang, Convert.ToInt32(EnumInstituionalTypes.Hakkimizda));
            if (aboutus == null) aboutus = new deneysan_DAL.Entities.Institutional() { };
            return View(aboutus);
        }

        public ActionResult VisionMision()
        {
            var visionmision = InstituionalManager.GetInstationalByLanguage(lang, Convert.ToInt32(EnumInstituionalTypes.Misyon));
            if (visionmision == null) visionmision = new deneysan_DAL.Entities.Institutional() { };
            return View(visionmision);
        }
    }
}
