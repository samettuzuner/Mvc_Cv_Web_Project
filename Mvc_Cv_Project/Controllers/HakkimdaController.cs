using Mvc_Cv_Project.Models.Entity;
using Mvc_Cv_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Cv_Project.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        HakkimdaRepository repo = new HakkimdaRepository();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult HakkimdaGetir(int id)
        {
            TblHakkimda t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult HakkimdaGetir(TblHakkimda p)
        {
            TblHakkimda t = repo.Find(x => x.ID == p.ID);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Aciklama = p.Aciklama;
            repo.TUpdate(t);
            return View(t);
        }

    }
}