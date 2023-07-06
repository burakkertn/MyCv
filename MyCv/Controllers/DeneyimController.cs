using MyCv.Models.Entity;
using MyCv.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCv.Controllers
{
    public class DeneyimController : Controller

    {

        // GET: Deneyim
        DeneyimRepo repo = new DeneyimRepo();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(Deneyimler p)
        {
            repo.XAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            Deneyimler x = repo.Find(t => t.ID == id);
            repo.Delete(x);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            Deneyimler x = repo.Find(t => t.ID == id);
            return View(x);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(Deneyimler p)
        {
            Deneyimler x = repo.Find(t => t.ID == p.ID);
            x.Baslik = p.Baslik;
            x.AltBaslik = p.AltBaslik;
            x.Tarih = p.Tarih;
            x.Aciklama = p.Aciklama;
            repo.XUpdate(x);
            return RedirectToAction("Index");
        }
    }
}