using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();        
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult HesapSil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            repo.TDelete(hesap);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SosyalMedyaGetir(int id)
        {
            var sosyalmedya = repo.Find(x => x.ID == id);
            return View(sosyalmedya);
        }
        [HttpPost]
        public ActionResult SosyalMedyaGetir(TblSosyalMedya t)
        {
            var sosyalmedya = repo.Find(x => x.ID == t.ID);
            sosyalmedya.Ad = t.Ad;
            sosyalmedya.Durum = true;
            sosyalmedya.Link = t.Link;
            sosyalmedya.Ikon = t.Ikon;
            repo.TUpdate(sosyalmedya);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}