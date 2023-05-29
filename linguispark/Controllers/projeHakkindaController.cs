using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using linguispark.Models.entity;
namespace linguispark.Controllers
{
    public class projeHakkindaController : Controller
    {
        // GET: projeHakkinda
        linguisparkEntities1 db = new linguisparkEntities1();
        public ActionResult Index()
        {
            var degerler = db.tblProjeHakkinda.ToList();
            return View(degerler);

        }

        public ActionResult Index1()
        {
            var degerler = db.tblProjeHakkinda.ToList();
            return View(degerler);
        }
        public ActionResult projeHakkindaSil(int id)
        {
            var deger = db.tblProjeHakkinda.Find(id);
            db.tblProjeHakkinda.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index1");
        }
        public ActionResult projeHakkindaGuncellemeSayfasi(int id)
        {
            var degerler = db.tblProjeHakkinda.Find(id);
            return View("projeHakkindaGuncellemeSayfasi", degerler);
        }
        [HttpPost]
        public ActionResult projeHakkindaGuncelle(tblProjeHakkinda p)
        {
            var degerler = db.tblProjeHakkinda.Find(p.id);
            degerler.fotograf = p.fotograf;
            degerler.projeHakkinda = p.projeHakkinda;
            db.SaveChanges();
            return RedirectToAction("Index1");
        }
    }
}