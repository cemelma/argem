using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace deneysan.Helpers
{
    public class MailTemplateUtil
    {
        public string CustomFormat(string Data, params object[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                string Pattern = string.Format(@"(\[{0}\])", i);
                Data = Regex.Replace(Data, Pattern, parameters[i].ToString());
            }
            return Data;
        }

        public string GetMailTemplate(string templateTitle)
        {
            using (StreamReader SR = new StreamReader(HttpContext.Current.Server.MapPath("/HTMLTemplate/" + templateTitle + ".html"), Encoding.Default))
            {
                return SR.ReadToEnd();
            }
        }
    }
}