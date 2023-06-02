using Mvc_Cv_Project.Models.Entity;
using Mvc_Cv_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Cv_Project.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        GenericRepository<Tbliletisim> repo=new GenericRepository<Tbliletisim>();
        public ActionResult Index()
        {
            var mesajlar=repo.List();
            return View(mesajlar);
        }
        public ActionResult iletisimSil(int id)
        {
            var iletisim = repo.Find(x => x.ID == id);
            repo.Delete(iletisim);
            return RedirectToAction("Index");
        }

    }
}