using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        dbCvEntities db = new dbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Hakkinda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.Tbl_SosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.Tbl_Deneyimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitimlerim()
        {
            var Egitimlerim = db.Tbl_Egitimlerim.ToList();
            return PartialView(Egitimlerim);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.Tbl_Yetenekler.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobilerim()
        {
            var hobiler = db.Tbl_Hobilerim.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifikalar()
        {
            var Sertifikalar = db.Tbl_Sertifikalar.ToList();
            return PartialView(Sertifikalar);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(Tbl_iletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbl_iletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}