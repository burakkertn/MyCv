using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCv.Models.Entity;
using MyCv.Repo;

namespace MyCv.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        GenericRepository<Iletisim> repo = new GenericRepository<Iletisim>();
        [Authorize]
        public ActionResult Index()
        {
            var q = repo.List();
            return View(q);
        }
    }
}