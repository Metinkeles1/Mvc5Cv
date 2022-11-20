using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class ProjeController : Controller
    {        
        // GET: Proje
        ProjeRepository repo = new ProjeRepository();
        public ActionResult Index()
        {
            var proje = repo.List();
            return View(proje);
        }
        public PartialViewResult ProjeDetay(int id)
        {
            var proje = repo.Find(x => x.id == id);
            return PartialView(proje);
        }
        [HttpGet]
        public ActionResult ProjeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProjeEkle(TblProjelerim t)
        {
            if (!ModelState.IsValid)
            {
                return View("ProjeEkle");
            }
            repo.TAdd(t);
            return RedirectToAction("Index");
        }        
        public ActionResult ProjeSil(int id)
        {
            var proje = repo.Find(x => x.id == id);
            repo.TDelete(proje);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ProjeGetir(int id)
        {
            var proje = repo.Find(x => x.id == id);
            return View(proje);
        }
        [HttpPost]
        public ActionResult ProjeGetir(TblProjelerim t)
        {
            var proje = repo.Find(x => x.id == t.id);
            proje.ProjeName = t.ProjeName;
            proje.ProjeAciklama = t.ProjeAciklama;
            proje.ProjeResim1 = t.ProjeResim1;
            proje.ProjeResim2 = t.ProjeResim2;
            proje.ProjeResim2Açıklama = t.ProjeResim2Açıklama;
            proje.ProjeResim3 = t.ProjeResim3;
            proje.ProjeResim3Açıklama = t.ProjeResim3Açıklama;
            proje.Tarih = t.Tarih;
            repo.TUpdate(proje);
            return RedirectToAction("Index");
        }
    }
}