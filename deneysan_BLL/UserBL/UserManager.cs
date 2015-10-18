using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using deneysan_BLL.LogBL;
using deneysan_DAL.Context;
using deneysan_DAL.Entities;
using log4net;

namespace deneysan_BLL.UserBL
{
    public class UserManager
    {
        static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static bool Login(string email, string password)
        {
            using (DeneysanContext db = new DeneysanContext())
            {
                User record = db.User.SingleOrDefault(d => d.Email == email && d.Password == password);
                if (record != null)
                {
                    return true;
                }
                else return false;
            }
        }

        public static Tuple<bool,string> IsMailControl(string email)
        {
            using (DeneysanContext db = new DeneysanContext())
            {
                User record = db.User.FirstOrDefault(d => d.Email == email);
                if (record != null)
                {
                    return new Tuple<bool, string>(true,record.Password);
                }
                else return new Tuple<bool, string>(false, "");
            }
        }

        public static bool ChangePassword(string password, string email)
        {
            using (DeneysanContext db = new DeneysanContext())
            {
                User record = db.User.SingleOrDefault(d => d.Email == email);
                if (record != null)
                {
                    record.Password = password;
                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
        }
        public static bool Record(string fullname, string email, string password, string institution, string contact)
        {
            try
            {
                using (DeneysanContext db = new DeneysanContext())
                {
                    User record = new User();
                    record.Email = email;
                    record.FullName = fullname;
                    record.Password = password;
                    record.Institution = institution;
                    record.Contact = contact;
                    record.isActive = true;
                    db.User.Add(record);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsMailControlRecord(string email)
        {
            try
            {
                using (DeneysanContext db = new DeneysanContext())
                {
                    //User record = db.User.FirstOrDefault(d=> d.Email == email);
                  if (db.User.Any(d => d.Email == email))
                    return true;
                  else return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool IsLogin()
        {
            //HttpCookie cookie = Request.Cookies["RegCookie"];
            //if (cookie != null)
            //{
            //    //cookie.Expires = DateTime.Now.AddHours(1);
            //    //cookie = CyriptoClass.DecodeCookie(cookie);
            //    //cookie["UserName"];
            //    return true;
            //}
            //else
                return false;
        }

        public static List<User> UserList()
        {
            using (DeneysanContext db = new DeneysanContext())
            {
                var list = db.User.Where(d =>d.isActive == true).ToList();
                return list;
            }
        }

        public static bool UserDelete(int id)
        {
            using (DeneysanContext db = new DeneysanContext())
            {
                try
                {
                    var record = db.User.FirstOrDefault(d => d.UserId == id);
                    record.isActive = false;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
