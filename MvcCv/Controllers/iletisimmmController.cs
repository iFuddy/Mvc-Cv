using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class iletisimmmController : Controller
    {
        // GET: iletisimmm
        GenericRepostory<Tbl_iletisim> repo = new GenericRepostory<Tbl_iletisim>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
        public ActionResult iletisimSil(int id)
        {
            var iletisim = repo.Find(x => x.ID == id);
            repo.TDelete(iletisim);
            return RedirectToAction("Index");
        }
    }
}