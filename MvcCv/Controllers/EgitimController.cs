using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entitiy;
using MvcCv.Repositories;


namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        GenericRepositories<TblEgitimlerim> repo = new GenericRepositories<TblEgitimlerim>();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim p)

        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.tAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.tDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var egitim = repo.Find(x => x.ID == id);

            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimGetir(TblEgitimlerim t)

        {
            var y = repo.Find(x => x.ID == t.ID);
            y.Baslık = t.Baslık;
            y.AltBaslık1 = t.AltBaslık1;
            y.AltBaslık2 = t.AltBaslık2;
            y.GNO = t.GNO;
            y.Tarih = t.Tarih;
            repo.tUpdate(y);
            return RedirectToAction("Index");
        }
    }
}