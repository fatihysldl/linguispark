using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using linguispark.Models.entity;
using linguispark.Controllers;
using System.Net.Mail;
using linguispark.Helpers;
namespace linguispark.Controllers
{
    public class satinAlimFormController : Controller
    {
        linguisparkEntities1 db = new linguisparkEntities1();
        
        //// GET: satinAlimForm
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult satinAlimSayfasiA(int id)
        {
            List<SelectListItem> cevirmenList = (from x in db.tblCevirmen.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.cevirmenAdi,
                                                     Value = x.id.ToString(),
                                                     Selected = (x.id == id)
                                                 }).ToList();
            var satis = db.tblSatis.Find(id);
            ViewBag.cevirmenAdi = cevirmenList;
            if (satis != null && !cevirmenList.Any(x => x.Value == satis.cevirmen.ToString()))
            {
                var defaultSelected = cevirmenList.FirstOrDefault();
                if (defaultSelected != null)
                    defaultSelected.Selected = true;
            }


            return View();
        }

        [HttpGet]
        public ActionResult satinAlim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult satinAlim(tblSatis p)
        {
            // var cevir = db.tblCevirmen.Where(x => x.id==p.cevirmen).FirstOrDefault();
            //if (p.cevirmen == null)
            //{
            //    var defaultSelected = db.tblSatis.Find(p.id)?.cevirmen;
            //    p.cevirmen = defaultSelected;
            //}

            if (p.cevirmen == null)
            {
                p.cevirmen = null;
            }
            else
            {
                // Geçerli bir çevirmen seçilmişse, sadece o çevirmenin ID'sini atayın
                p.cevirmen = db.tblSatis.Find(p.id)?.cevirmen;
            }
            db.tblSatis.Add(p);
            db.SaveChanges();
     

            string toAddress = p.Mail.ToString(); // Alıcı e-posta adresi
            string subject = "Satın Alma Onayı"; // E-posta konusu
            string body = "Satın alma işlemi başarıyla gerçekleştirildi."; // E-posta içeriği

            EmailHelper.SendEmail(toAddress, subject, body);

            return RedirectToAction("Index", "satinAlindiBilgiSayfasi");

        }
    }
}