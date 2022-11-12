using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler );
        }
        [HttpPost]
        public ActionResult Index(TblHobilerim t)
        {
            var hobi = repo.Find(x => x.ID == 1);
            hobi.Aciklama1 = t.Aciklama1;
            hobi.Aciklama2 = t.Aciklama2;
            repo.TUpdate(hobi);
            return RedirectToAction("Index");
        }
    }
}