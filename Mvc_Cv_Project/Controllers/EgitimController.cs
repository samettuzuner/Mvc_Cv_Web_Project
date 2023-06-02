using Mvc_Cv_Project.Models.Entity;
using Mvc_Cv_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Cv_Project.Controllers
{
   
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();
      
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
            repo.Add(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            TblEgitimlerim t = repo.Find(x => x.ID == id);
            repo.Delete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            TblEgitimlerim t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EgitimDuzenle(TblEgitimlerim p)
        {
            TblEgitimlerim t = repo.Find(x => x.ID == p.ID);
            t.Universite = p.Universite;
            t.Bolum = p.Bolum;
            t.GNO = p.GNO;
            t.Tarih = p.Tarih;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}