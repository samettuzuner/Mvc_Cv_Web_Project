using Mvc_Cv_Project.Models.Entity;
using Mvc_Cv_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Cv_Project.Controllers
{
    public class BilgilerimController:Controller
    {
        BilgilerimRepository repo = new BilgilerimRepository();
       
        public ActionResult Index()
        {
            var bilgi = repo.List();
            return View(bilgi);
          
        }
        [HttpGet]
        public ActionResult BilgilerimGetir(int id)
        {
            TblBilgilerim t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult BilgilerimGetir(TblBilgilerim p)
        {
            TblBilgilerim t = repo.Find(x => x.ID == p.ID);
            t.Aciklama = p.Aciklama;
            t.Madde1 = p.Madde1;
            t.Madde2 = p.Madde2;
            t.Madde3 = p.Madde3;
            repo.TUpdate(t);
            return View(t);
        }

    }
}