using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using linguispark.Models.entity;
namespace linguispark.Controllers
{
    public class anaSayfaController : Controller
    {
        linguisparkEntities1 db = new linguisparkEntities1();
        // GET: anaSayfa
        public ActionResult Index()
        {
            var kartlar = db.tblKart.Where(i => i.kartDurum == true).ToList();
            return View(kartlar);
        }
    }
}