using MvcCv.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
       DbCvEntities1 db = new DbCvEntities1();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }

        public PartialViewResult Hakkımda()
        {
            return PartialView();
        }
      
        public PartialViewResult Egitimlerim()
        {
            var egitim = db.TblEgitimlerim.ToList();
            return PartialView(egitim);
        }

        public PartialViewResult Yeteneklerim()
        {
            var yetenek = db.TblYeteneklerim.ToList();
            return PartialView(yetenek);
        }
        public PartialViewResult Hobilerim()
        {
            var hobi = db.TblHobilerim.ToList();
            return PartialView(hobi);
        }
        public PartialViewResult Sertifikalarım()
        {
            var sertifika = db.TblSertifika.ToList();
            return PartialView(sertifika);
        }
        [HttpGet]
        public PartialViewResult İletisim()
        {
          
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult İletisim(TblIletisim p)
        {
            p.Tarih = DateTime.Parse( DateTime.Now.ToShortDateString()); //Şimdiki tarih
            db.TblIletisim.Add(p);
            db.SaveChanges();
            return PartialView();
        }
    }

}