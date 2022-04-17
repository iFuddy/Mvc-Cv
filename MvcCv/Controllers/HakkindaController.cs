using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HakkindaController : Controller
    {
        // GET: Hakkinda
        GenericRepostory<Tbl_Hakkinda> repo = new GenericRepostory<Tbl_Hakkinda>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkinda = repo.List();
            return View(hakkinda);
        }
        [HttpPost]
        public ActionResult Index(Tbl_Hakkinda p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Telefon = p.Telefon;
            t.Mail = p.Mail;
            t.Aciklama = p.Aciklama;
            t.Resim = p.Resim;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}