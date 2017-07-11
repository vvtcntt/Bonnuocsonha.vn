using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SONHA.Models;
namespace SONHA.Controllers.Display
{
    public class ActionController : Controller
    {
        SONHAContext db = new SONHAContext();
        // GET: Action
        public ActionResult Index()
        {
            //var ListProduct = db.tblProducts.ToList();
            //foreach( var item in ListProduct)
            //{
            //    int id = item.id;
            //    tblProduct tblproduct = db.tblProducts.Find(id);
            //    tblproduct.Tag = StringClass.NameToTag(tblproduct.Name);
            //    tblproduct.Title = tblproduct.Name;
            //     db.SaveChanges();
            //}
            var ListNews = db.tblNews.ToList();
            foreach (var item in ListNews)
            {
                int id = item.id;
                tblNew tblnews = db.tblNews.Find(id);
                tblnews.Tag = StringClass.NameToTag(tblnews.Name);
                tblnews.Title = tblnews.Name;
                tblnews.idUser='1';
                db.SaveChanges();
            }
            return View();
        }
    }
}