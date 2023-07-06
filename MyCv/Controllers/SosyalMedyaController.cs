using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCv.Models.Entity;
using MyCv.Repo;

namespace MyCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<SosyalMedya> repo = new GenericRepository<SosyalMedya>();

        [Authorize]
        public ActionResult Index()
        {
            var x = repo.List();
            return View(x);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(SosyalMedya p)
        {
            repo.XAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            var t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult Duzenle(SosyalMedya p)
        {
            var t = repo.Find(x => x.ID == p.ID);
            t.Durum = true;
            t.Ad = p.Ad;
            t.Link = p.Link;
            t.Icon = p.Icon;
            repo.XUpdate(t);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var t = repo.Find(x => x.ID == id);
            t.Durum = false;
            repo.XUpdate(t);
            return RedirectToAction("Index");
        }
    }
}