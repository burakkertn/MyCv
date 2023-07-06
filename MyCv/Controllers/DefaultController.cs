using MyCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
       
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.Abouts.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.SosyalMedyas.Where(x => x.Durum == true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.Deneyimlers.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitim()
        {
            var egitimler = db.Egitimlers.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Yetenek()
        {
            var yetenekler = db.Yeteneklers.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobi()
        {
            var hobiler = db.Hobilers.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifika()
        {
            var sertifikalar = db.Sertifikalars.ToList();
            return PartialView(sertifikalar);
        }
        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }
        [HttpPost]

        public PartialViewResult Iletisim(Iletisim x)
        {
            x.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Iletisims.Add(x);
            db.SaveChanges();
            return PartialView();
        }


  
    }
}