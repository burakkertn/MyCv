using MyCv.Models.Entity;
using MyCv.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCv.Controllers
{
    public class ProjeController : Controller
    {
        // GET: Proje
       
        GenericRepository<Projeler> repo = new GenericRepository<Projeler>();

        [Authorize]
        public ActionResult Index()
        {
            var x = repo.List();
            return View(x);
        }

        [HttpGet]
        public ActionResult ProjeGetir(int id)
        {
            var i = repo.Find(x => x.ID == id);
            ViewBag.d = i.ID;
            return View(i);
        }

        [HttpPost]
        public ActionResult ProjeGetir(Projeler p)
        {
            var i = repo.Find(x => x.ID == p.ID);
            i.Ad = p.Ad;
            i.Aciklama = p.Aciklama;
            i.Aciklama2 = p.Aciklama2;
            repo.XUpdate(i);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YeniProje()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniProje(Projeler p)
        {
            repo.XAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult ProjeSil(int id)
        {
            var t = repo.Find(x => x.ID == id);
            repo.Delete(t);
            return RedirectToAction("Index");
        }
    }
}