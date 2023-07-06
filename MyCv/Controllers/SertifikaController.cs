using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCv.Models.Entity;
using MyCv.Repo;

namespace MyCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<Sertifikalar> repo = new GenericRepository<Sertifikalar>();

        [Authorize]
        public ActionResult Index()
        {
            var x = repo.List();
            return View(x);
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var i = repo.Find(x => x.ID == id);
            ViewBag.d = i.ID;
            return View(i);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(Sertifikalar p)
        {
            var i = repo.Find(x => x.ID == p.ID);
            i.Aciklama = p.Aciklama;
            i.Tarih = p.Tarih;
            i.yeterlilik = p.yeterlilik;
            repo.XUpdate(i);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSertifika(Sertifikalar p)
        {
            repo.XAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            var t = repo.Find(x => x.ID == id);
            repo.Delete(t);
            return RedirectToAction("Index");
        }
    }
}