using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using linguispark.Models.entity;
namespace linguispark.Controllers
{
    public class CevirmenKartController : Controller
    {
        linguisparkEntities1 db = new linguisparkEntities1();
        // GET: CevirmenKart
        public ActionResult Index()
        {
            var degerler = db.tblKart.Where(i=>i.kartDurum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult kartEkle()
        {
            List<SelectListItem> kart = (from x in db.tblCevirmen.ToList()
                                         where(x.durum==true)
                                         select new SelectListItem
                                         {
                                             Text = x.cevirmenAdi,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.kartlar = kart;
            return View();
        }
        [HttpPost]
        public ActionResult kartEkle(tblKart p)
        {
            var kart = db.tblKart.Where(x => x.id == p.kartBaslikCevirmenAdi).FirstOrDefault();
            db.tblKart.Add(p);
            p.kartDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult kartSil(int id)
        {
            var kart = db.tblKart.Find(id);
            kart.kartDurum= false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult kartGuncellemeSayfasi(int id)
        {
            List<SelectListItem> kart = (from x in db.tblCevirmen.ToList()
                                         where (x.durum == true)
                                         select new SelectListItem
                                         {
                                             Text = x.cevirmenAdi,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.kartlar = kart;
            var karts = db.tblKart.Find(id);
            return View("kartGuncellemeSayfasi", karts);
        }
        [HttpPost]
        public ActionResult kartGuncelle(tblKart p)
        {
            var kart = db.tblKart.Find(p.id);
            kart.kartBaslikCevirmenAdi = p.kartBaslikCevirmenAdi;
            kart.kartAciklama = p.kartAciklama;
            kart.kartFotograf = p.kartFotograf;
            var karts = db.tblCevirmen.Where(x => x.id == p.id).FirstOrDefault();
            kart.kartBaslikCevirmenAdi = karts.id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}