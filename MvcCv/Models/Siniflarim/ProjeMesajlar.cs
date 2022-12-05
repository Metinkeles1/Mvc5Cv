using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCv.Models.Siniflarim
{
    public class ProjeMesajlar
    {
        public IEnumerable<TblMesajlar> mesaj { get; set; }
        public IEnumerable<TblProjelerim> proje{ get; set; }
    }
}