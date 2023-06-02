using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Cv_Project.Models.Entity;
using Mvc_Cv_Project.Repositories;

namespace Mvc_Cv_Project.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        GenericRepository<TblYetenekler> repo = new GenericRepository<TblYetenekler>(); //Generic Yapı 
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
        public ActionResult YeniYetenek(TblYetenekler p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.Delete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenekDuzenle = repo.Find(x => x.ID == id);
            return View(yetenekDuzenle);
        }
        [HttpPost]
        public ActionResult YetenekDuzenle(TblYetenekler t)
        {
            var yetenekDuzenle = repo.Find(x => x.ID == t.ID);
            yetenekDuzenle.Yetenek=t.Yetenek;
            yetenekDuzenle.Oran = t.Oran;
            repo.TUpdate(yetenekDuzenle);
            return RedirectToAction("Index");
        }
    }
}