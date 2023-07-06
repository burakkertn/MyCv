using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCv.Models.Entity;
using MyCv.Repo;

namespace MyCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<Hobiler> repo = new GenericRepository<Hobiler>();
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var x = repo.List();
            return View(x);
        }

        [HttpPost]
        public ActionResult Index(Hobiler p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Aciklama = p.Aciklama;
            t.Aciklama1 = p.Aciklama1;
            t.Aciklama2 = p.Aciklama2;
            t.Aciklama3 = p.Aciklama3;
            t.Aciklama4 = p.Aciklama4;
            repo.XUpdate(t);
            return RedirectToAction("Index");
        }
    }
}