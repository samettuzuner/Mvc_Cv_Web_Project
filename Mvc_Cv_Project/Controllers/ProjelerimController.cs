using Mvc_Cv_Project.Models.Entity;
using Mvc_Cv_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Cv_Project.Controllers
{
    public class ProjelerimController: Controller
    {
        // GET: Projelerim
        GenericRepository<TblProjelerim> repo = new GenericRepository<TblProjelerim>();
        public ActionResult Index()
        {
            var proje = repo.List();
            return View(proje);
        }
        [HttpGet]
        public ActionResult YeniProje()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniProje(TblProjelerim p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }
        public ActionResult ProjeSil(int id)
        {
            var proje = repo.Find(x => x.ID == id);
            repo.Delete(proje);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ProjeDuzenle(int id)
        {
            var proje = repo.Find(x => x.ID == id);
            return View(proje);
        }
        [HttpPost]
        public ActionResult ProjeDuzenle(TblProjelerim t)
        {
            var proje = repo.Find(x => x.ID == t.ID);
            proje.Proje_Adi = t.Proje_Adi;
            proje.Kullanilan_Diller = t.Kullanilan_Diller;
            proje.ProjeLink = t.ProjeLink;
            repo.TUpdate(proje);
            return RedirectToAction("Index");
        }
    }
}