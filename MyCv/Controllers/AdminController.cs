using MyCv.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCv.Models.Entity;

namespace MyCv.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<Admin> repo = new GenericRepository<Admin>();
        [Authorize]
        public ActionResult Index()
        {
            var t = repo.List();
            return View(t);
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(Admin p)
        {
            repo.XAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            Admin x = repo.Find(t => t.ID == id);
            repo.Delete(x);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminDuzenle(int id)
        {
            Admin x = repo.Find(t => t.ID == id);
            return View(x);
        }

        [HttpPost]
        public ActionResult AdminDuzenle(Admin p)
        {
            Admin x = repo.Find(t => t.ID == p.ID);
            x.Kullaniciadi = p.Kullaniciadi;
            x.Sifre = p.Sifre;
            repo.XUpdate(x);
            return RedirectToAction("Index");
        }
    }
}