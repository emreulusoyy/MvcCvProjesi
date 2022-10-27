using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entitiy;
using MvcCv.Repositories;
namespace MvcCv.Controllers
{
    public class iletisimController : Controller
    {
        GenericRepositories<TblIletisim> repo = new GenericRepositories<TblIletisim>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}