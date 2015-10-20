using CSCources.DAL;
using CSCources.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSCources.Controllers
{
    public class AdminController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            //ViewBag.usr1 = userManager.FindByName("Admin");
            ViewBag.usr = userManager.Users;

            return View();
        }

        public PartialViewResult _Settings(string id)
        {
            IList<string> roles = new List<string> { "У пользователя нет ролей" };
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser usr = userManager.FindById(id);
            if (usr != null)
                roles = userManager.GetRoles(usr.Id);

            ViewBag.roles = roles;

            return PartialView();
        }
    }
}