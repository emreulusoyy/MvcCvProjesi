using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entitiy;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        GenericRepositories<TblSertifika> repo = new GenericRepositories<TblSertifika>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            return View(sertifika);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifika p)
        {
            var sertifika = repo.Find(y => y.ID == p.ID);
            sertifika.Tarih = p.Tarih;
            sertifika.Acıklama = p.Acıklama;
            repo.tUpdate(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(TblSertifika p)
        {
            repo.tAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            DbCvEntities1 db = new DbCvEntities1();
            var deger = db.TblSertifika.Where(x => x.ID == id).Select(y => y.ID).FirstOrDefault();
            ViewBag.d = deger;
            repo.tDelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}