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
        MesajlarRepository msjrepo = new MesajlarRepository();
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var proje = repo.List();            
            return View(proje);
        }
        public ActionResult ProjeDetay(int id)
        {
            var proje = repo.Find(x => x.id == id);            
            var deger = db.TblMesajlar.Where(x => x.ProjeId == id).Count();
            ViewBag.mesajSayisi = deger;
            return View(proje);
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
            proje.ProjeLink = t.ProjeLink;
            proje.Tarih = t.Tarih;
            repo.TUpdate(proje);
            return RedirectToAction("Index");
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
        public PartialViewResult _YorumListesi(int id)
        {
            var yorumlar = msjrepo.List().FindAll(x=>x.ProjeId == id);            
            return PartialView(yorumlar);
        }
        public PartialViewResult _TopProject()
        {            
            var degerler = db.TblProjelerim.OrderByDescending(x => x.ProjeBegeniSayisi).ToList();               
            return PartialView(degerler);
        }
    }
}