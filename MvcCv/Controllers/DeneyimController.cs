using MvcCv.Models.Entitiy;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepositories repo = new DeneyimRepositories();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimlerim p)
        {
            repo.tAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == id);
            repo.tDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Deneyimgetir(int id)
        {
            TblDeneyimlerim t = repo.Find(x=>x.ID == id);   
            return View(t); 
        }
        [HttpPost]
        public ActionResult Deneyimgetir(TblDeneyimlerim p)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Tarih = p.Tarih;
            t.Acıklama = p.Acıklama;
            repo.tUpdate(t);    
            return RedirectToAction("Index");
        }
    } 
}