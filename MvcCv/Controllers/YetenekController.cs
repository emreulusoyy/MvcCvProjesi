using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entitiy;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        DbCvEntities1 db = new DbCvEntities1();
        GenericRepositories<TblYeteneklerim> repo = new GenericRepositories<TblYeteneklerim>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TblYeteneklerim p)

        {
            repo.tAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x=> x.ID==id);
            repo.tDelete(yetenek);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
          
            return View(yetenek);
        }

        [HttpPost]
        public ActionResult YetenekDuzenle(TblYeteneklerim t)

        {
            var y = repo.Find(x => x.ID == t.ID);
            y.Yetenek = t.Yetenek;
            y.Oran = t.Oran;
            repo.tUpdate(y);
            return RedirectToAction("Index");
        }
    }
}