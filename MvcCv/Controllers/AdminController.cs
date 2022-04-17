﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepostory<Tbl_Admin> repo = new GenericRepostory<Tbl_Admin>();
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(Tbl_Admin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            Tbl_Admin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminGetir(int id)
        {
            Tbl_Admin t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminGetir(Tbl_Admin p)
        {
            Tbl_Admin t = repo.Find(x => x.ID == p.ID);
            t.KullaniciAdi = p.KullaniciAdi;
            t.Sifre = p.Sifre;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}