using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Mvc_Cv_Project.Models.Entity;
using QRCoder;
using System.IO;
using System.Windows.Documents;

namespace Mvc_Cv_Project.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }
        public ActionResult Hakkımda()
        {
            var s = db.TblHakkimda.ToList();
            return View(s);
        }

        public PartialViewResult Egitim()
        {
            var egitim = db.TblEgitimlerim.ToList();
            return PartialView(egitim);
        }
        public PartialViewResult Yetenekler()
        {
            var yetenek = db.TblYetenekler.ToList();
            return PartialView(yetenek);
        }
        public PartialViewResult Sertifikalar()
        {
            var sertifika = db.TblSertifikalarim.ToList();
            return PartialView(sertifika);
        }
        public PartialViewResult Projeler()
        {
            var proje = db.TblProjelerim.ToList();
            return PartialView(proje);
        }
        public PartialViewResult Tecrubelerim()
        {
            var tecrube = db.TblTecrubelerim.ToList();
            return PartialView(tecrube);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
            var iletisimm = db.TblHakkimda.ToList();
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(Tbliletisim t)
        {
            t.Tarih = DateTime.Now.Date;
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
            
        }
        public ActionResult Sertifikalarim()
        {
            var sertifikalar = db.TblSertifikalarim.ToList();
            return View(sertifikalar);
        }

        public ActionResult GenerateQRCode(int ID, int width = 250)
        {
            var sertifika = db.TblSertifikalarim.Find(ID);
            string text = sertifika.SertifikaAdres;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(5, Color.Black, Color.White, false);


            MemoryStream ms = new MemoryStream();
            qrCodeImage.Save(ms, ImageFormat.Png);
            ms.Position = 0;
            return new FileContentResult(ms.ToArray(), "image/png") { FileDownloadName = "qrcode.png" };
        }

    }
}