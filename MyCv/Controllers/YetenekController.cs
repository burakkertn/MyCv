using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCv.Models.Entity;
using MyCv.Repo;

namespace MyCv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        GenericRepository<Yetenekler> repo = new GenericRepository<Yetenekler>();

        [Authorize]
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }

        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniYetenek(Yetenekler p)
        {

            repo.XAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.Delete(yetenek);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekGüncelle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }

        [HttpPost]
        public ActionResult YetenekGüncelle(Yetenekler p)
        {
            var yetenek = repo.Find(x => x.ID == p.ID);
            yetenek.Yetenek = p.Yetenek;
            yetenek.Oran = p.Oran;
            repo.XUpdate(yetenek);
            return RedirectToAction("Index");
        }
    }
}