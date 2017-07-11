using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SONHA.Models;
namespace SONHA.Controllers.Display
{
    public class ErrorController : Controller
    {
        SONHAContext db = new SONHAContext();
        // GET: Error
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Redriect()
        {
            string f = Request.QueryString["f"].ToString();
            string tag = Request.QueryString["tag"].ToString();

           switch (f)
           {
               case "tp":
                   {

                       return Redirect("/Tag/" + StringClass.NameToTag(tag));

                   }

               case "tn":
                   {

                       return Redirect("/TagNews/" + tag);
                   }
               
           }
           string m = Request.QueryString["m"].ToString();
            
            return View();
        }
    }
}