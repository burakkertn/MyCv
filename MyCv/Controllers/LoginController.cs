using MyCv.Models.Entity;
using MyCv.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            DbCvEntities db = new DbCvEntities();
            var user = db.Admins.FirstOrDefault(x => x.Kullaniciadi == p.Kullaniciadi && x.Sifre == p.Sifre);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Kullaniciadi, false);
                Session["KullaniciAdi"] = user.Kullaniciadi.ToString();
                return RedirectToAction("Index", "Deneyim");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}