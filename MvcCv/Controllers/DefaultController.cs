﻿using MvcCv.Models.Entity;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();        
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalmedya);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TblEgitimlerim.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.TblYeteneklerim.ToList();
            return PartialView(yetenekler);
        }

        public PartialViewResult Hobilerim()
        {
            var hobiler = db.TblHobilerim.ToList();
            return PartialView(hobiler);
        }

        public PartialViewResult Sertifikalarım()
        {
            var sertifikalar = db.TblSertifikalarim.ToList();
            return PartialView(sertifikalar);
        }      
        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(TblIletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblIletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
        //public PartialViewResult Projelerim(int sayfa=1)
        //{
        //    //var projeler = db.TblProjelerim.ToList();
        //    var projeler = db.TblProjelerim.ToList().ToPagedList(sayfa, 3);
        //    return PartialView(projeler);
        //}       
        public ActionResult Projelerim(int sayfa = 1)
        {
            //var projeler = db.TblProjelerim.ToList().ToPagedList(sayfa, 3);
            var projeler = db.TblProjelerim.ToList();
            return View(projeler);
        }
        //public ActionResult Projelerim2(int sayfa = 1)
        //{
        //    var projeler = db.TblProjelerim.ToList().ToPagedList(sayfa, 3);            
        //    return View(projeler);
        //}
    }
}