using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ProjeMesajController : Controller
    {
        // GET: ProjeMesaj
        
        public ActionResult Index()
        {
            return View();
        }
      
    }
}