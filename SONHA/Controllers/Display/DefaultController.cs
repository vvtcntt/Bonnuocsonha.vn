using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SONHA.Models;
namespace SONHA.Controllers.Display
{
    public class DefaultController : Controller
    {
        // GET: Default
        private SONHAContext db = new SONHAContext();
        public ActionResult Index()
        {
            tblConfig config = db.tblConfigs.First();
            ViewBag.Title = "<title>" + config.Title + "</title>";
            ViewBag.dcTitle = "<meta name=\"DC.title\" content=\"" + config.Title + "\" />";
            ViewBag.Description = "<meta name=\"description\" content=\"" + config.Description + "\"/>";
            ViewBag.Keyword = "<meta name=\"keywords\" content=\"" + config.Keywords + "\" /> ";
            ViewBag.h1 = "<h1 class=\"h1\">" + config.Title + "</h1>";
            ViewBag.canonical = "<link rel=\"canonical\" href=\"http://bonnuocsonha.vn\" />";
            string meta = "";
            meta += "<meta itemprop=\"name\" content=\"" + config.Name + "\" />";
            meta += "<meta itemprop=\"url\" content=\"" + Request.Url.ToString() + "\" />";
            meta += "<meta itemprop=\"description\" content=\"" + config.Description + "\" />";
            meta += "<meta itemprop=\"image\" content=\"http://bonnuocsonha.vn" + config.Logo + "\" />";
            meta += "<meta property=\"og:title\" content=\"" + config.Title + "\" />";
            meta += "<meta property=\"og:type\" content=\"product\" />";
            meta += "<meta property=\"og:url\" content=\"" + Request.Url.ToString() + "\" />";
            meta += "<meta property=\"og:image\" content=\"http://bonnuocsonha.vn" + config.Logo + "\" />";
            meta += "<meta property=\"og:site_name\" content=\"http://bonnuocsonha.vn\" />";
            meta += "<meta property=\"og:description\" content=\"" + config.Description + "\" />";
            meta += "<meta property=\"fb:admins\" content=\"\" />";
            ViewBag.Meta = meta;
            if (Session["Register"] != null && Session["Register"] != "")
            {
                ViewBag.register = Session["Register"].ToString();
                Session["Register"] = "";
            }
            return View();
        }
        public PartialViewResult partialdefault()
        { 
            return PartialView(db.tblConfigs.First());
        }
        public PartialViewResult partialSlide()
        {
            var listimageslide = db.tblImages.Where(p => p.Active == true && p.idCate == 1).OrderByDescending(p => p.Ord).Take(4).ToList();
            string chuoislide = "";
            for (int i = 0; i < listimageslide.Count; i++)
            {
                if (i == 0)
                {
                    chuoislide += "url(" + listimageslide[i].Images + ") " + (1200 * i) + "px 0 no-repeat";
                }
                else
                {

                    chuoislide += ", url(" + listimageslide[i].Images + ") " + (1200 * i) + "px 0 no-repeat";
                }
            }
            ViewBag.chuoislide = chuoislide;
            return PartialView(listimageslide);
        }
        public PartialViewResult partialInfonews()
        {
            var listNews = db.tblNews.Where(p => p.Active == true).OrderByDescending(p => p.DateCreate).Take(5).ToList();
            string chuoi = "";
            string chuoi1 = "";
            for(int i=0;i<listNews.Count;i++)
            {
                if(i==0)
                {
                    chuoi += "<div class=\"Tear_Homes\">";
                    chuoi += "<img src = \""+listNews[i].Images+ "\" alt=\"" + listNews[i].Name + "\" />";
                    chuoi += "<h3><a href = \"/3/" + listNews[i].Tag + "-" + listNews[i].id + ".aspx\" title=\"" + listNews[i].Name + "\">" + listNews[i].Name + "</a></h3>";
                    chuoi += "<span>" + listNews[i].Description + "</span>";
                    chuoi += " </div>";
                }
                else
                {
                    chuoi1 += "<h4><a href = \"/3/" + listNews[i].Tag + "-" + listNews[i].id + ".aspx\" title=\"" + listNews[i].Name + "\">" + listNews[i].Name + "</a></h4>";
                }
            }
            ViewBag.Chuoi = chuoi;
            ViewBag.Chuoi1 = chuoi1;
            var listImage = db.tblImages.Where(p => p.Active == true && p.idCate == 10).OrderByDescending(p => p.Ord).Take(1).ToList();
            if(listImage.Count>0)
                ViewBag.chuoiimages= "<a href=\""+listImage[0].Url+ "\" title=\"" + listImage[0].Name + "\"> <img src=\"" + listImage[0].Images + "\" alt=\"" + listImage[0].Name + "\" /></a>";
            var listVideo = db.tblVideos.Where(p => p.Active == true).OrderByDescending(p => p.Ord).ToList();
            if (listVideo.Count > 0)
            {
                if (listVideo[0].AutoPlay == true)
                { ViewBag.chuoivideo = "<iframe width=\"100%\" height=\"230\" src=\"https://www.youtube.com/embed/" + listVideo[0].Code + "?rel=0&autoplay=1\" frameborder=\"0\" allowfullscreen></iframe>"; }
                else
                {
                    ViewBag.chuoivideo = "<iframe width=\"100%\" height=\"230\" src=\"https://www.youtube.com/embed/" + listVideo[0].Code + "\" frameborder=\"0\" allowfullscreen></iframe>";
                }
            }
            return PartialView();
        }
        public PartialViewResult partialServices()
        {
            return PartialView();
        }
    }
}