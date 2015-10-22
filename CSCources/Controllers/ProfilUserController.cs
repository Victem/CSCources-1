using CSCources.DAL;
using CSCources.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSCources.Controllers
{
    public class ProfilUserController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProfilUser
        public ActionResult Index()
        {
            //получаем всех пользователей
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ViewBag.Usrs = userManager.Users;

            return View();
        }

        public ActionResult _GetUsrs(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var thisUser = userManager.FindById(id);

            if (thisUser != null)
            {
                return PartialView("_GetUsrs", thisUser);
            }

            return View("Index");
        }
    }
}