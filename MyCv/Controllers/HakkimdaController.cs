using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCv.Models.Entity;
using MyCv.Repo;

namespace MyCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<About> repo = new GenericRepository<About>();
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var x = repo.List();
            return View(x);
        }

        [HttpPost]
        public ActionResult Index(About p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Mail = p.Mail;
            t.Telefon = p.Telefon;
            t.Aciklama = p.Aciklama;
            t.Aciklama1 = p.Aciklama1;
            t.Aciklama2 = p.Aciklama2;
            t.Resim = p.Resim;
            repo.XUpdate(t);
            return RedirectToAction("Index");
        }
    }
}