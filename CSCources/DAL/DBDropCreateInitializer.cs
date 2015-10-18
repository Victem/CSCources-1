using CSCources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSCources.DAL
{
    public class DBDropCreateInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {

        }
    }
}