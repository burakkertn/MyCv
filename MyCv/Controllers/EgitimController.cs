using MyCv.Models.Entity;
using MyCv.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<Egitimler> repo = new GenericRepository<Egitimler>();



        [Authorize]

        public ActionResult Index()
        {
            var x = repo.List();
            return View(x);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(Egitimler p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.XAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            var t = repo.Find(x => x.ID == id);
            repo.Delete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EgitimGetir(Egitimler p)
        {
            var t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Altbaslik2 = p.Altbaslik2;
            t.Tarih = p.Tarih;
            repo.XUpdate(t);
            return RedirectToAction("Index");
        }
    }
}