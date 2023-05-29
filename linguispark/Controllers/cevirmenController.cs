using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using linguispark.Models.entity;
namespace linguispark.Controllers
{
    public class cevirmenController : Controller
    {
        linguisparkEntities1 db = new linguisparkEntities1();
        // GET: cevrimenEkle
        public ActionResult Index()
        {
            var degerler = db.tblCevirmen.Where(i => i.durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult cevirmenEKle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult cevirmenEKle(tblCevirmen p)
        {
            db.tblCevirmen.Add(p);
            p.durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult cevirmenSil(int id)
        {
            var cevirmen = db.tblCevirmen.Find(id);
            cevirmen.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult cevirmenGuncellemeSayfasi(int id)
        {
            var cevirmen = db.tblCevirmen.Find(id);
            return View("cevirmenGuncellemeSayfasi", cevirmen);
        }
        [HttpPost]
        public ActionResult cevirmenGuncelle(tblCevirmen p)
        {
            var cevirmen = db.tblCevirmen.Find(p.id);
            cevirmen.cevirmenAdi = p.cevirmenAdi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}