﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepostory<Tbl_SosyalMedya> repo = new GenericRepostory<Tbl_SosyalMedya>();
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Tbl_SosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult SayfaGetir(Tbl_SosyalMedya p)
        {
            var hesap = repo.Find(x => x.ID == p.ID);
            hesap.Ad = p.Ad;
            hesap.Durum = true;
            hesap.Link = p.Link;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}