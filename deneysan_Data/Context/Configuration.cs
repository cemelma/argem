using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using deneysan_DAL.Entities;

namespace deneysan_DAL.Context
{
    public class Configration : DbMigrationsConfiguration<DeneysanContext>
    {
        public Configration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }


        protected override void Seed(DeneysanContext context)
        {
          context.Languages.AddOrUpdate(x => x.LanguageId,
              new Languages() { LanguageId = 1, Language = "Türkçe",Culture="tr" },
              new Languages() { LanguageId = 2, Language = "İngilizce",Culture="en" }
              );

          context.AdminUser.AddOrUpdate(x => x.AdminUserId,
             new AdminUser() { AdminUserId = 1,FullName= "admin", Password = "123456",Email="admin@admin.com" }
           
             );

        
        }

    }
}
