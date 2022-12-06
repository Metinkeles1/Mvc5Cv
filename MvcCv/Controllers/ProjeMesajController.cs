using MvcCv.Models.Entity;
using MvcCv.Models.Siniflarim;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class ProjeMesajController : Controller
    {
        // GET: ProjeMesaj
        MesajlarRepository msjrepo = new MesajlarRepository();
        ProjeRepository repo = new ProjeRepository();
        DbCvEntities db = new DbCvEntities();
        [HttpGet]
        public ActionResult Index(int id=1)
        {
            ProjeMesajlar cs = new ProjeMesajlar();
            cs.proje = db.TblProjelerim.ToList();
            cs.mesaj = db.TblMesajlar.ToList();            
            return View(cs);
        }   
        public PartialViewResult _YorumListesi(int id)
        {
            var yorumlar = msjrepo.List().FindAll(x => x.ProjeId == id).Where(x=>x.Durum==true).ToList();
            return PartialView(yorumlar);
        }
        [HttpGet]
        public PartialViewResult _ProjeYorumlar(int id)
        {
            var projeid = id;
            ViewBag.projeid = projeid;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ProjeYorumlar(TblMesajlar p)
        {            
            msjrepo.TAdd(p);
            return PartialView();
        }      
        public ActionResult YorumSil(int id)
        {
            var yorum = msjrepo.Find(x=>x.Id == id);
            yorum.Durum = !yorum.Durum;
            msjrepo.TUpdate(yorum);
            return RedirectToAction("Index");
        }
    }
}