using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SONHA.Models;
namespace SONHA.Controllers.Display.Section.Product
{
    public class ProductController : Controller
    {
        private SONHAContext db = new SONHAContext();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        List<string> Mangphantu = new List<string>();
        public List<string> Arrayid(int idParent)
        {

            var ListMenu = db.tblGroupProducts.Where(p => p.ParentID == idParent).ToList();

            for (int i = 0; i < ListMenu.Count; i++)
            {
                Mangphantu.Add(ListMenu[i].id.ToString());
                int id = int.Parse(ListMenu[i].id.ToString());
                Arrayid(id);

            }

            return Mangphantu;
        }
        string nUrl = "";
        public string UrlProduct(int idCate)
        {
            var ListMenu = db.tblGroupProducts.Where(p => p.id == idCate).ToList();
            for (int i = 0; i < ListMenu.Count; i++)
            {
                nUrl = " <a href=\"/1/" + ListMenu[i].Tag + "-"+ListMenu[i].id+".aspx\" title=\"" + ListMenu[i].Name + "\"> " + " " + ListMenu[i].Name + "</a> <i></i>" + nUrl;
                string ids = ListMenu[i].ParentID.ToString();
                if (ids != null && ids != "")
                {
                    int id = int.Parse(ListMenu[i].ParentID.ToString());
                    UrlProduct(id);
                }
            }
            return nUrl;
        }
        public PartialViewResult partialProductHomes()
        {
            string chuoi = "";
            var ListCapcity = db.tblCapacities.Where(p => p.Active == true).OrderBy(p => p.Ord).ToList();
            foreach (var item in ListCapcity)
            { if(item.Priority==true)
                {
                    chuoi += "<div class=\"cls_Product\">";
                    chuoi += "<div class=\"nvar_ct\">";
                    chuoi += "<h2><a href=\"/" + item.Tag + ".html\" title=\"" + item.Name + "\">" + item.Name + "</a></h2>";
                    chuoi += "</div>";
                    int idCap = item.id;
                    var LitsProduct = db.tblProducts.Where(p => p.Active == true && p.Capacity == idCap && p.Design == 1 && p.ViewHomes == true && p.Material == 0).OrderBy(p => p.Ord).ToList();
                    if (LitsProduct.Count < 5)
                    {
                        //chuoi += "<div class=\"nVar_01\">"; 
                        //chuoi += "<span>Bồn đứng và Bồn nằm</span> ";
                        //chuoi += "</div>";
                        chuoi += "<div class=\"Content_clsProduct\">";
                        var LitsProduct1 = db.tblProducts.Where(p => p.Active == true && p.Capacity == idCap && p.ViewHomes == true && p.Material == 0).OrderBy(p => p.Ord).ToList();
                        foreach (var item1 in LitsProduct1)
                        {
                            chuoi += "<div class=\"Tear_1\">";
                            if (item1.New == true)
                                chuoi += "<div class=\"Note\"></div>";
                            chuoi += "<div class=\"OrderNow\">";
                            chuoi += "<a rel=\"miendatwebPopup\" href=\"#popup_content\" onclick=\"javascript:return CreateOrder(" + item1.id + ");\" title=\"Đặt hàng\">Đặt hàng</a>";
                            chuoi += "</div>";
                            chuoi += "<div class=\"img\">";
                            chuoi += "<a href=\"/0/" + item1.Tag + "-" + item1.idCate + "-" + item1.id + ".aspx\" title=\"" + item1.Name + "\"><img src=\"" + item1.ImageLinkThumb + "\" alt=\"" + item1.Name + "\" /></a>";
                            chuoi += "</div>";
                            chuoi += "<a href=\"/0/" + item1.Tag + "-" + item1.idCate + "-" + item1.id + ".aspx\" class=\"Name\" title=\"" + item1.Name + "\">" + item1.Name + "</a>";
                            chuoi += "<span class=\"Price\">" + string.Format("{0:#,#}", item1.Price) + "đ</span>";
                            chuoi += "<span class=\"PriceSale\">" + string.Format("{0:#,#}", item1.PriceSale) + "đ</span>";
                            chuoi += "</div>";
                        }
                        chuoi += "</div>";
                        chuoi += "<a href=\"/" + item.Tag + ".html\" title=\"" + item.Name + "\" class=\"Xemthem\"></a>";
                    }
                    else
                    {
                        chuoi += "<div class=\"nVar_01\">";
                        chuoi += "<span>Bồn đứng</span> ";
                        chuoi += "</div>";
                        chuoi += "<div class=\"Content_clsProduct\">";

                        foreach (var item1 in LitsProduct)
                        {
                            chuoi += "<div class=\"Tear_1\">";
                            if (item1.New == true)
                                chuoi += "<div class=\"Note\"></div>";
                            chuoi += "<div class=\"OrderNow\">";
                            chuoi += "<a rel=\"miendatwebPopup\" href=\"#popup_content\" onclick=\"javascript:return CreateOrder(" + item1.id + ");\" title=\"Đặt hàng\">Đặt hàng</a>";
                            chuoi += "</div>";
                            chuoi += "<div class=\"img\">";
                            chuoi += "<a href=\"/0/" + item1.Tag + "-" + item1.idCate + "-" + item1.id + ".aspx\" title=\"" + item1.Name + "\"><img src=\"" + item1.ImageLinkThumb + "\" alt=\"" + item1.Name + "\" /></a>";
                            chuoi += "</div>";
                            chuoi += "<a href=\"/0/" + item1.Tag + "-" + item1.idCate + "-" + item1.id + ".aspx\" class=\"Name\" title=\"" + item1.Name + "\">" + item1.Name + "</a>";
                            chuoi += "<span class=\"Price\">" + string.Format("{0:#,#}", item1.Price) + "đ</span>";
                            chuoi += "<span class=\"PriceSale\">" + string.Format("{0:#,#}", item1.PriceSale) + "đ</span>";
                            chuoi += "</div>";
                        }
                        chuoi += "</div>";
                        chuoi += "<a href=\"/" + item.Tag + ".html\" title=\"" + item.Name + "\" class=\"Xemthem\"></a>";

                        chuoi += "<div class=\"nVar_01\">";
                        chuoi += "<span>Bồn Nằm</span> ";
                        chuoi += "</div>";
                        chuoi += "<div class=\"Content_clsProduct\">";
                        var LitsProduct1 = db.tblProducts.Where(p => p.Active == true && p.Capacity == idCap && p.Design == 0 && p.ViewHomes == true && p.Material == 0).OrderBy(p => p.Ord).ToList();
                        foreach (var item1 in LitsProduct1)
                        {
                            chuoi += "<div class=\"Tear_1\">";
                            if (item1.New == true)
                                chuoi += "<div class=\"Note\"></div>";
                            chuoi += "<div class=\"OrderNow\">";
                            chuoi += "<a rel=\"miendatwebPopup\" href=\"#popup_content\" onclick=\"javascript:return CreateOrder(" + item1.id + ");\" title=\"Đặt hàng\">Đặt hàng</a>";
                            chuoi += "</div>";
                            chuoi += "<div class=\"img\">";
                            chuoi += "<a href=\"/0/" + item1.Tag + "-" + item1.idCate + "-" + item1.id + ".aspx\" title=\"" + item1.Name + "\"><img src=\"" + item1.ImageLinkThumb + "\" alt=\"" + item1.Name + "\" /></a>";
                            chuoi += "</div>";
                            chuoi += "<a href=\"/0/" + item1.Tag + "-" + item1.idCate + "-" + item1.id + ".aspx\" class=\"Name\" title=\"" + item1.Name + "\">" + item1.Name + "</a>";
                            chuoi += "<span class=\"Price\">" + string.Format("{0:#,#}", item1.Price) + "đ</span>";
                            chuoi += "<span class=\"PriceSale\">" + string.Format("{0:#,#}", item1.PriceSale) + "đ</span>";
                            chuoi += "</div>";
                        }
                        chuoi += "</div>";
                        chuoi += "<a href=\"/" + item.Tag + ".html\" title=\"" + item.Name + "\" class=\"Xemthem\"></a>";

                    }

                    //kết thúc
                    chuoi += "</div>";
                    chuoi += "<div class=\"Clear\"></div>";
                    Mangphantu.Clear();
                }
            else
                {
                   chuoi += "<h2 class=\"hh2\"><a href =\"/" + item.Tag + ".html\" title=\"" + item.Name + "\">" + item.Name+"</a></h2>";                     
                }
               
            }
            ViewBag.chuoi = chuoi;

            //Lòad
            string chuoi1 = "";
            var ListMenu = db.tblGroupProducts.Where(p => p.Active == true && p.Priority == true).OrderBy(p => p.Ord).ToList();
            foreach (var item in ListMenu)
            {
                chuoi1 += "<div class=\"cls_Product\">";
                chuoi1 += "<div class=\"nvar_ct\">";
                chuoi1 += "<h2><a href=\"/1/" + item.Tag + "-"+item.id+".aspx\" title=\"" + item.Name + "\">" + item.Name + "</a></h2>";
                chuoi1 += "</div>";
                int id = item.id;
                List<string> Mang = new List<string>();
                Mang=Arrayid(id);
                Mang.Add(id.ToString());
                 chuoi1 += "<div class=\"Content_clsProduct\">";
                var LitsProduct1 = db.tblProducts.Where(p => p.Active == true && Mang.Contains(p.idCate.ToString()) && p.Priority == true ).OrderBy(p => p.idCate).ToList();
                foreach (var item1 in LitsProduct1)
                {
                    chuoi1 += "<div class=\"Tear_1\">";
                    if (item1.New == true)
                        chuoi1 += "<div class=\"Note\"></div>";
                    chuoi1 += "<div class=\"OrderNow\">";
                    chuoi1 += "<a rel=\"miendatwebPopup\" href=\"#popup_content\" onclick=\"javascript:return CreateOrder(" + item1.id + ");\" title=\"Đặt hàng\">Đặt hàng</a>";
                    chuoi1 += "</div>";
                    chuoi1 += "<div class=\"img\">";
                    chuoi1 += "<a href=\"/0/" + item1.Tag + "-" + item1.idCate + "-" + item1.id + ".aspx\" title=\"" + item1.Name + "\"><img src=\"" + item1.ImageLinkThumb + "\" alt=\"" + item1.Name + "\" /></a>";
                    chuoi1 += "</div>";
                    chuoi1 += "<a href=\"/0/" + item1.Tag + "-" + item1.idCate + "-" + item1.id + ".aspx\" class=\"Name\" title=\"" + item1.Name + "\">" + item1.Name + "</a>";
                    chuoi1 += "<span class=\"Price\">" + string.Format("{0:#,#}", item1.Price) + "đ</span>";
                    chuoi1 += "<span class=\"PriceSale\">" + string.Format("{0:#,#}", item1.PriceSale) + "đ</span>";
                    chuoi1 += "</div>";
                }
                chuoi1 += "</div>";
                chuoi1 += "<a href=\"/1/" + item.Tag + "-"+item.id+".aspx\" title=\"" + item.Name + "\" class=\"Xemthem\"></a>";
                chuoi1 += "</div>";
                Mangphantu.Clear();
            }
            ViewBag.chuoi1 = chuoi1;
            return PartialView();
        }
        public ActionResult ProductDetail(string tag)
        {
            var tblproduct = db.tblProducts.First(p => p.Tag == tag);
            ViewBag.Title = "<title>" + tblproduct.Title + "</title>";
            ViewBag.dcTitle = "<meta name=\"DC.title\" content=\"" + tblproduct.Title + "\" />";
            ViewBag.Description = "<meta name=\"description\" content=\"" + tblproduct.Description + "\"/>";
            ViewBag.Keyword = "<meta name=\"keywords\" content=\"" + tblproduct.Keyword + "\" /> ";
            ViewBag.canonical = "<link rel=\"canonical\" href=\"http://bonnuocsonha.vn/0/" + StringClass.NameToTag(tblproduct.Tag) + "-" + tblproduct.idCate + "-" + tblproduct.id + ".aspx\" />";
            string meta = "";
            tblproduct.Visit = tblproduct.Visit + 1;
            db.SaveChanges();
            meta += "<meta itemprop=\"name\" content=\"" + tblproduct.Name + "\" />";
            meta += "<meta itemprop=\"url\" content=\"" + Request.Url.ToString() + "\" />";
            meta += "<meta itemprop=\"description\" content=\"" + tblproduct.Description + "\" />";
            meta += "<meta itemprop=\"image\" content=\"http://bonnuocsonha.vn" + tblproduct.ImageLinkThumb + "\" />";
            meta += "<meta property=\"og:title\" content=\"" + tblproduct.Title + "\" />";
            meta += "<meta property=\"og:type\" content=\"product\" />";
            meta += "<meta property=\"og:url\" content=\"" + Request.Url.ToString() + "\" />";
            meta += "<meta property=\"og:image\" content=\"http://bonnuocsonha.vn" + tblproduct.ImageLinkThumb + "\" />";
            meta += "<meta property=\"og:site_name\" content=\"http://bonnuocsonha.vn\" />";
            meta += "<meta property=\"og:description\" content=\"" + tblproduct.Description + "\" />";
            meta += "<meta property=\"fb:admins\" content=\"\" />";
            ViewBag.Meta = meta; int idcate = int.Parse(tblproduct.idCate.ToString());
            ViewBag.nUrl = "<a href=\"/\" title=\"Trang chủ\" rel=\"nofollow\"><span class=\"iCon\"></span> Trang chủ</a><i></i>" + UrlProduct(idcate);
            string chuoitag = "";
            if (tblproduct.Keyword != null)
            {
                string Chuoi = tblproduct.Keyword;
                string[] Mang = Chuoi.Split(',');
                List<int> araylist = new List<int>();
                for (int i = 0; i < Mang.Length; i++)
                {
                    string tagsp = StringClass.NameToTag(Mang[i]);
                    chuoitag += "<h2><a href=\"/Tag/" + tagsp + "\" title=\"" + Mang[i] + "\">" + Mang[i] + "</a></h2>";
                }
            }
            ViewBag.chuoitag = chuoitag;
            int idcap = 0;
            if(tblproduct.Capacity.ToString()!=null && tblproduct.Capacity.ToString()!="")
            {
            idcap = int.Parse(tblproduct.Capacity.ToString());
                var tblcapacity = db.tblCapacities.Find(idcap);
                ViewBag.capa = tblcapacity.Capacity;
                ViewBag.cappacity = tblcapacity.Capacity;
                ViewBag.songuoisd = tblcapacity.Note;
            }
           
            //Load tính năng
            var ListGroupCri = db.tblGroupCriterias.Where(p => p.idCate == idcate).ToList();
            List<int> Mang1 = new List<int>();
            for (int i = 0; i < ListGroupCri.Count; i++)
            {
                Mang1.Add(int.Parse(ListGroupCri[i].idCri.ToString()));
            }
            int idp = int.Parse(tblproduct.id.ToString());
            var ListCri = db.tblCriterias.Where(p => Mang1.Contains(p.id) && p.Active == true).ToList();
            string chuoi = "";
            #region[Lọc thuộc tính]


            for (int i = 0; i < ListCri.Count; i++)
            {
                int idCre = int.Parse(ListCri[i].id.ToString());
                var ListCr = (from a in db.tblConnectCriterias
                              join b in db.tblInfoCriterias on a.idCre equals b.id
                              where a.idpd == idp && b.idCri == idCre && b.Active == true
                              select new
                              {
                                  b.Name,
                                  b.Url,
                                  b.Ord
                              }).OrderBy(p => p.Ord).ToList();
                if (ListCr.Count > 0)
                {
                    chuoi += "<tr>";
                    chuoi += "<td>" + ListCri[i].Name + "</td>";
                    chuoi += "<td>";
                    int dem = 0;
                    string num = "";
                    if (ListCr.Count > 1)
                        num = "⊹ ";
                    foreach (var item in ListCr)
                        if (item.Url != null && item.Url != "")
                        {
                            chuoi += "<a href=\"" + item.Url + "\" title=\"" + item.Name + "\">";
                            if (dem == 1)
                                chuoi += num + item.Name;
                            else
                                chuoi += num + item.Name;
                            dem = 1;
                            chuoi += "</a>";
                        }
                        else
                        {
                            if (dem == 1)
                                chuoi += num + item.Name + "</br> ";
                            else
                                chuoi += num + item.Name + "</br> "; ;
                            dem = 1;
                        }
                    chuoi += "</td>";
                    chuoi += " </tr>";
                }
            }
            #endregion
            ViewBag.video = db.tblGroupProducts.Find(idcate).Video;
            ViewBag.chuoi = chuoi;
            //load sản phẩm gần giá
            string chuoilq = "";

            int nPrice = int.Parse(tblproduct.PriceSale.ToString());
            var List_01 = db.tblProducts.Where(p => p.Active == true && p.Capacity == idcap && p.Tag != tag).OrderBy(p => p.PriceSale).Take(6).ToList();
            for (int i = 0; i < List_01.Count; i++)
            {
                chuoilq += " <div class=\"Tear_cg\">";
                chuoilq += " <a href=\"/0/" + List_01[i].Tag + "-" + List_01[i].idCate + "-" + List_01[i].id + ".aspx\" class=\"name_cg\" title=\"" + List_01[i].Name + "\">" + List_01[i].Name + "</a>";
                chuoilq += " <img src=\"" + List_01[i].ImageLinkThumb + "\" title=\"" + List_01[i].Name + "\" />";
                chuoilq += "<span class=\"Price\">Giá  : <span>" + string.Format("{0:#,#}", List_01[i].PriceSale) + "đ</span></span>";
                chuoilq += "<span class=\"PriceSale\">Giá thị trường: <span>" + string.Format("{0:#,#}", List_01[i].Price) + "đ</span></span>";
                chuoilq += "</div>";
            }
            ViewBag.chuoilq = chuoilq;
            var tblManu = (from a in db.tblConnectManuProducts join b in db.tblManufactures on a.idManu equals b.id where a.idCate == idcate select b).Take(1).ToList();
            if(tblManu.Count>0)
            {
                ViewBag.manu = tblManu[0].Name;
                 ViewBag.urlmanu = tblManu[0].Images;
            }
            
            if(tblproduct.Material.ToString()!=null && tblproduct.Material.ToString()!="")
            {
                int nMaterial = int.Parse(tblproduct.Material.ToString());
                int nDesign = int.Parse(tblproduct.Design.ToString());
                var kiemtra = db.tblProducts.Where(p => p.Active == true && p.idCate == idcate && p.Design == nDesign && p.Material == nMaterial && p.id != idp && p.Capacity == idcap).Take(1).ToList();
                if (kiemtra.Count > 0)
                    ViewBag.xemthem = "<div class=\"xemthemchitiet\">Bạn có thể xem thêm " + tblManu[0].Name + " cùng dung tích khác : <a href=\"/0/" + kiemtra[0].Tag + "-"+kiemtra[0].id+".aspx\" title=\"" + kiemtra[0].Name + "\">   " + kiemtra[0].Name + "</a></div>";

            }
           
            var ImageList =  db.tblImageProducts.Where(p=>p.idProduct==idp).ToList();
            if (ImageList.Count > 0)
            {
                for (int i = 0; i < ImageList.Count;i++ )
                {
                    ViewBag.chuoianh = " <div class=\"Tear_Img\">  <a href=\"#\" title=\"" + ImageList[i].Name + "\"><img src=\"" + ImageList[i].Images + "\" alt=\"" + ImageList[i].Name + "\" /></a></div>";

                }
            }
            var imageSale = (from a in db.tblConnectImages join b in db.tblImages on a.idImg equals b.id where a.idCate == idcate && b.idCate == 12 select b).OrderByDescending(p=>p.Ord).Take(1).ToList();
            if(imageSale.Count>0)
            ViewBag.imageSale = "<a href=\"" + imageSale[0].Url + "\" title=\"" + imageSale[0].Name + "\"><img src=\"" + imageSale[0].Images + "\" alt=\"" + imageSale[0].Name + "\" /></a>"; 
            return View(tblproduct);
        }
        public ActionResult ListProduct(string tag)
        {
            var tblgroupproduct = db.tblGroupProducts.First(p => p.Tag == tag);
            int id = tblgroupproduct.id;
            ViewBag.Title = "<title>" + tblgroupproduct.Title + "</title>";
            ViewBag.dcTitle = "<meta name=\"DC.title\" content=\"" + tblgroupproduct.Title + "\" />";
            ViewBag.Description = "<meta name=\"description\" content=\"" + tblgroupproduct.Description + "\"/>";
            ViewBag.Keyword = "<meta name=\"keywords\" content=\"" + tblgroupproduct.Keyword + "\" /> ";
            ViewBag.canonical = "<link rel=\"canonical\" href=\"http://bonnuocsonha.vn/1/" + tblgroupproduct.Tag + "-"+tblgroupproduct.id+".aspx\" />";
            string meta = "";
            meta += "<meta itemprop=\"name\" content=\"" + tblgroupproduct.Name + "\" />";
            meta += "<meta itemprop=\"url\" content=\"" + Request.Url.ToString() + "\" />";
            meta += "<meta itemprop=\"description\" content=\"" + tblgroupproduct.Description + "\" />";
            meta += "<meta itemprop=\"image\" content=\"http://bonnuocsonha.vn" + tblgroupproduct.Images + "\" />";
            meta += "<meta property=\"og:title\" content=\"" + tblgroupproduct.Title + "\" />";
            meta += "<meta property=\"og:type\" content=\"product\" />";
            meta += "<meta property=\"og:url\" content=\"" + Request.Url.ToString() + "\" />";
            meta += "<meta property=\"og:image\" content=\"http://bonnuocsonha.vn" + tblgroupproduct.Images + "\" />";
            meta += "<meta property=\"og:site_name\" content=\"http://bonnuocsonha.vn\" />";
            meta += "<meta property=\"og:description\" content=\"" + tblgroupproduct.Description + "\" />";
            meta += "<meta property=\"fb:admins\" content=\"\" />";
            ViewBag.Meta = meta;
            ViewBag.nUrl = "<a href=\"/\" title=\"Trang chủ\" rel=\"nofollow\"><span class=\"iCon\"></span> Trang chủ</a><i></i>" + UrlProduct(tblgroupproduct.id) + "<i></i><h1>"+tblgroupproduct.Title+"</h1>";

            ViewBag.Name = tblgroupproduct.Name;
            ViewBag.Des = tblgroupproduct.Content;
            string chuoi = "";
            var ListGroup = db.tblGroupProducts.Where(p => p.Active == true && p.ParentID == id).OrderBy(p => p.Ord).ToList();
            if(ListGroup.Count>0)
            {
                foreach (var item in ListGroup)
                {
                    chuoi += "<div class=\"cls_Product\">";
                    chuoi += "<div class=\"nvar_ct\">";
                    chuoi += "<h2><a href=\"/1/" + item.Tag + "-"+item.id+".aspx\" title=\"" + item.Name + "\">" + item.Name + "</a></h2>";
                    chuoi += "</div>";
                    chuoi += "<div class=\"Content_clsProduct\">";
                    int idcate = item.id;
                    //List<string> Mang = new List<string>();
                    //Mang = Arrayid(idcate);
                    //Mang.Add(idcate.ToString());
                    var LitsProduct = db.tblProducts.Where(p => p.Active == true && p.idCate == idcate).OrderBy(p => p.Ord).ToList();
                    foreach (var item1 in LitsProduct)
                    {
                        chuoi += "<div class=\"Tear_1\">";
                        if (item1.New == true)
                            chuoi += "<div class=\"Note\"></div>";
                        chuoi += "<div class=\"OrderNow\">";
                        chuoi += "<a rel=\"miendatwebPopup\" href=\"#popup_content\" onclick=\"javascript:return CreateOrder(" + item1.id + ");\" title=\"Đặt hàng\">Đặt hàng</a>";
                        chuoi += "</div>";
                        chuoi += "<div class=\"img\">";
                        chuoi += "<a href=\"/0/" + item1.Tag + "-" + item1.idCate + "-" + item1.id + ".aspx\" title=\"" + item1.Name + "\"><img src=\"" + item1.ImageLinkThumb + "\" alt=\"" + item1.Name + "\" /></a>";
                        chuoi += "</div>";
                        chuoi += "<a href=\"/0/" + item1.Tag + "-" + item1.idCate + "-" + item1.id + ".aspx\" class=\"Name\" title=\"" + item1.Name + "\">" + item1.Name + "</a>";
                        chuoi += "<span class=\"Price\">" + string.Format("{0:#,#}", item1.Price) + "đ</span>";
                        chuoi += "<span class=\"PriceSale\">" + string.Format("{0:#,#}", item1.PriceSale) + "đ</span>";
                        chuoi += "</div>";
                    }
                    chuoi += "</div>";
                    chuoi += "</div>";
                }
            }
            else
            {
                
                chuoi += "<div class=\"cls_Product\">";
                chuoi += "<div class=\"nvar_ct\">";
                chuoi += "<h2><a href=\"/1/" + tblgroupproduct.Tag + "-" + tblgroupproduct.id + ".aspx\" title=\"" + tblgroupproduct.Name + "\">" + tblgroupproduct.Name + "</a></h2>";
                chuoi += "</div>";
                chuoi += "<div class=\"Content_clsProduct\">";
                int idcate = tblgroupproduct.id;
                
                var LitsProduct = db.tblProducts.Where(p => p.Active == true && p.idCate==idcate).OrderBy(p => p.Ord).ToList();
                foreach (var item1 in LitsProduct)
                {
                    chuoi += "<div class=\"Tear_1\">";
                    if (item1.New == true)
                        chuoi += "<div class=\"Note\"></div>";
                    chuoi += "<div class=\"OrderNow\">";
                    chuoi += "<a rel=\"miendatwebPopup\" href=\"#popup_content\" onclick=\"javascript:return CreateOrder(" + item1.id + ");\" title=\"Đặt hàng\">Đặt hàng</a>";
                    chuoi += "</div>";
                    chuoi += "<div class=\"img\">";
                    chuoi += "<a href=\"/0/" + item1.Tag + "-" + item1.idCate + "-" + item1.id + ".aspx\" title=\"" + item1.Name + "\"><img src=\"" + item1.ImageLinkThumb + "\" alt=\"" + item1.Name + "\" /></a>";
                    chuoi += "</div>";
                    chuoi += "<a href=\"/0/" + item1.Tag + "-"+item1.idCate+"-"+item1.id+".aspx\" class=\"Name\" title=\"" + item1.Name + "\">" + item1.Name + "</a>";
                    chuoi += "<span class=\"Price\">" + string.Format("{0:#,#}", item1.Price) + "đ</span>";
                    chuoi += "<span class=\"PriceSale\">" + string.Format("{0:#,#}", item1.PriceSale) + "đ</span>";
                    chuoi += "</div>";
                }


                chuoi += "</div>";
                chuoi += "</div>";

            }
            ViewBag.chuoi = chuoi;
            return View();
        }
        public ActionResult Tag(string tag)
        {
            string[] Mang1 = StringClass.COnvertToUnSign1(tag.ToUpper()).Split('-');
            string chuoitag = "";
            for (int i = 0; i < Mang1.Length; i++)
            {
                if (i == 0)
                    chuoitag += Mang1[i];
                else
                    chuoitag += " " + Mang1[i];
            }
            int dem = 1;
            string name = "";
            List<tblProduct> ListProducts = (from c in db.tblProducts select c).ToList();
            List<tblProduct> listProduct = ListProducts.FindAll(delegate(tblProduct math)
            {
                string kd = StringClass.COnvertToUnSign1(math.Keyword.ToUpper());
                if (StringClass.COnvertToUnSign1(math.Keyword.ToUpper()).Contains(chuoitag.ToUpper()))
                {

                    string[] Manghienthi = math.Keyword.Split(',');
                    foreach (var item in Manghienthi)
                    {
                        if (dem == 1)
                        {
                            var kiemtra = StringClass.COnvertToUnSign1(item.ToUpper()).Contains(chuoitag.ToUpper());
                            if (kiemtra == true)
                            {
                                name = item;
                                dem = 0;

                            }
                        }
                    }

                    return true;
                }

                else
                    return false;
            }
            );
            ViewBag.Name = name;
            ViewBag.Title = "<title>" + name + "</title>";
            ViewBag.dcTitle = "<meta name=\"DC.title\" content=\"" + name + "\" />";
            ViewBag.Description = "<meta name=\"description\" content=\"" + name + "\"/>";
            ViewBag.Keyword = "<meta name=\"keywords\" content=\"" + name + "\" /> ";
            string meta = "";
            meta += "<meta itemprop=\"name\" content=\"" + name + "\" />";
            meta += "<meta itemprop=\"url\" content=\"" + Request.Url.ToString() + "\" />";
            meta += "<meta itemprop=\"description\" content=\"" + tag + "\" />";
            meta += "<meta itemprop=\"image\" content=\"\" />";
            meta += "<meta property=\"og:title\" content=\"" + name + "\" />";
            meta += "<meta property=\"og:type\" content=\"product\" />";
            meta += "<meta property=\"og:url\" content=\"" + Request.Url.ToString() + "\" />";
            meta += "<meta property=\"og:image\" content=\"\" />";
            meta += "<meta property=\"og:site_name\" content=\"http://bonnuocsonha.vn\" />";
            meta += "<meta property=\"og:description\" content=\"" + name + "\" />";
            meta += "<meta property=\"fb:admins\" content=\"\" />";



              string chuoi = "";
             var listProduct1 = listProduct.Where(p => p.Active == true).OrderBy(p => p.PriceSale).ToList();

                chuoi += "<div class=\"cls_Product\">";
            
                chuoi += "<div class=\"Content_clsProduct\">";

                foreach (var item1 in listProduct1)
                {
                    chuoi += "<div class=\"Tear_1\">";
                    if (item1.New == true)
                        chuoi += "<div class=\"Note\"></div>";
                    chuoi += "<div class=\"OrderNow\">";
                    chuoi += "<a rel=\"miendatwebPopup\" href=\"#popup_content\" onclick=\"javascript:return CreateOrder(" + item1.id + ");\" title=\"Đặt hàng\">Đặt hàng</a>";
                    chuoi += "</div>";
                    chuoi += "<div class=\"img\">";
                    chuoi += "<a href=\"/0/" + item1.Tag + "-"+item1.idCate+"-"+item1.id+".aspx\" title=\"" + item1.Name + "\"><img src=\"" + item1.ImageLinkThumb + "\" alt=\"" + item1.Name + "\" /></a>";
                    chuoi += "</div>";
                    chuoi += "<a href=\"/0/" + item1.Tag + "-" + item1.idCate + "-" + item1.id + ".aspx\" class=\"Name\" title=\"" + item1.Name + "\">" + item1.Name + "</a>";
                    chuoi += "<span class=\"Price\">" + string.Format("{0:#,#}", item1.Price) + "đ</span>";
                    chuoi += "<span class=\"PriceSale\">" + string.Format("{0:#,#}", item1.PriceSale) + "đ</span>";
                    chuoi += "</div>";
                }


                chuoi += "</div>";
                chuoi += "</div>";

          
            ViewBag.chuoi = chuoi;
            return View();
        }
        public ActionResult Search()
        {
            if (Session["Search"] != null && Session["Search"] != "")
            {
                string tag = Session["Search"].ToString();
                ViewBag.Title = "<title>" + tag + "</title>";
                ViewBag.dcTitle = "<meta name=\"DC.title\" content=\"" + tag + "\" />";
                ViewBag.Description = "<meta name=\"description\" content=\"Tìm kiếm " + tag + "\"/>";
                ViewBag.Keyword = "<meta name=\"keywords\" content=\"" + tag + "\" /> ";
                ViewBag.Name = tag;
                ViewBag.nUrl = "<a href=\"/\" title=\"Trang chủ\" rel=\"nofollow\"><span class=\"iCon\"></span> Trang chủ</a><i></i>" + tag;
                ViewBag.Name = tag;
                string chuoi = "";
                var ListProduct = db.tblProducts.Where(p => p.Active == true && p.Name.Contains(tag)).OrderBy(p => p.PriceSale).ToList();

                chuoi += "<div class=\"cls_Product\">";

                chuoi += "<div class=\"Content_clsProduct\">";

                foreach (var item1 in ListProduct)
                {
                    chuoi += "<div class=\"Tear_1\">";
                    if (item1.New == true)
                        chuoi += "<div class=\"Note\"></div>";
                    chuoi += "<div class=\"OrderNow\">";
                    chuoi += "<a rel=\"miendatwebPopup\" href=\"#popup_content\" onclick=\"javascript:return CreateOrder(" + item1.id + ");\" title=\"Đặt hàng\">Đặt hàng</a>";
                    chuoi += "</div>";
                    chuoi += "<div class=\"img\">";
                    chuoi += "<a href=\"/0/" + item1.Tag + "-" + item1.idCate + "-" + item1.id + ".aspx\" title=\"" + item1.Name + "\"><img src=\"" + item1.ImageLinkThumb + "\" alt=\"" + item1.Name + "\" /></a>";
                    chuoi += "</div>";
                    chuoi += "<a href=\"/0/" + item1.Tag + "-" + item1.idCate + "-" + item1.id + ".aspx\" class=\"Name\" title=\"" + item1.Name + "\">" + item1.Name + "</a>";
                    chuoi += "<span class=\"Price\">" + string.Format("{0:#,#}", item1.Price) + "đ</span>";
                    chuoi += "<span class=\"PriceSale\">" + string.Format("{0:#,#}", item1.PriceSale) + "đ</span>";
                    chuoi += "</div>";
                }


                chuoi += "</div>";
                chuoi += "</div>";


                ViewBag.chuoi = chuoi;

            }
            return View();
        }
        public ActionResult ListCapacity(string tag)
        {
            var tblCapacity = db.tblCapacities.First(p => p.Tag == tag);
            int id = tblCapacity.id;
            ViewBag.Title = "<title>" + tblCapacity.Title + "</title>";
            ViewBag.dcTitle = "<meta name=\"DC.title\" content=\"" + tblCapacity.Title + "\" />";
            ViewBag.Description = "<meta name=\"description\" content=\"" + tblCapacity.Description + "\"/>";
            ViewBag.Keyword = "<meta name=\"keywords\" content=\"" + tblCapacity.Keyword + "\" /> ";
            ViewBag.canonical = "<link rel=\"canonical\" href=\"http://bonnuocsonha.vn/" + tblCapacity.Tag + ".html\" />";
            string meta = "";
            meta += "<meta itemprop=\"name\" content=\"" + tblCapacity.Name + "\" />";
            meta += "<meta itemprop=\"url\" content=\"" + Request.Url.ToString() + "\" />";
            meta += "<meta itemprop=\"description\" content=\"" + tblCapacity.Description + "\" />";
            meta += "<meta itemprop=\"image\" content=\"http://bonnuocsonha.vn" + tblCapacity.Images + "\" />";
            meta += "<meta property=\"og:title\" content=\"" + tblCapacity.Title + "\" />";
            meta += "<meta property=\"og:type\" content=\"product\" />";
            meta += "<meta property=\"og:url\" content=\"" + Request.Url.ToString() + "\" />";
            meta += "<meta property=\"og:image\" content=\"http://bonnuocsonha.vn" + tblCapacity.Images + "\" />";
            meta += "<meta property=\"og:site_name\" content=\"http://bonnuocsonha.vn\" />";
            meta += "<meta property=\"og:description\" content=\"" + tblCapacity.Description + "\" />";
            meta += "<meta property=\"fb:admins\" content=\"\" />";
            ViewBag.Meta = meta;
            ViewBag.nUrl = "<a href=\"/\" title=\"Trang chủ\" rel=\"nofollow\"><span class=\"iCon\"></span> Trang chủ</a><i></i> <h1>"+tblCapacity.Title+"</h1>";

            ViewBag.Name = tblCapacity.Name;
            ViewBag.Des = tblCapacity.Content;
            string chuoi = "";
            chuoi += "<div class=\"cls_Product\">";
            chuoi += "<div class=\"nvar_ct\">";
            chuoi += "<h2><a href=\"/" + tblCapacity.Tag + ".html\" title=\"" + tblCapacity.Name + "\">" + tblCapacity.Name + "</a></h2>";
            chuoi += "</div>";
            chuoi += "<div class=\"nVar_01\">";

            chuoi += "<span>Bồn đứng</span> ";
            chuoi += "</div>";
            chuoi += "<div class=\"Content_clsProduct\">";
            int idCap = tblCapacity.id;
            var LitsProduct = db.tblProducts.Where(p => p.Active == true && p.Capacity == idCap && p.Design == 1  ).OrderBy(p => p.Ord).ToList();
            foreach (var item1 in LitsProduct)
            {
                chuoi += "<div class=\"Tear_1\">";
                if (item1.New == true)
                    chuoi += "<div class=\"Note\"></div>";
                chuoi += "<div class=\"OrderNow\">";
                chuoi += "<a rel=\"miendatwebPopup\" href=\"#popup_content\" onclick=\"javascript:return CreateOrder(" + item1.id + ");\" title=\"Đặt hàng\">Đặt hàng</a>";
                chuoi += "</div>";
                chuoi += "<div class=\"img\">";
                chuoi += "<a href=\"/0/" + item1.Tag + "-" + item1.idCate + "-" + item1.id + ".aspx\" title=\"" + item1.Name + "\"><img src=\"" + item1.ImageLinkThumb + "\" alt=\"" + item1.Name + "\" /></a>";
                chuoi += "</div>";
                chuoi += "<a href=\"/0/" + item1.Tag + "-" + item1.idCate + "-" + item1.id + ".aspx\" class=\"Name\" title=\"" + item1.Name + "\">" + item1.Name + "</a>";
                chuoi += "<span class=\"Price\">" + string.Format("{0:#,#}", item1.Price) + "đ</span>";
                chuoi += "<span class=\"PriceSale\">" + string.Format("{0:#,#}", item1.PriceSale) + "đ</span>";
                chuoi += "</div>";
            }
            chuoi += "</div>";
 
            chuoi += "<div class=\"nVar_01\">";
            chuoi += "<span>Bồn Nằm</span> ";
            chuoi += "</div>";
            chuoi += "<div class=\"Content_clsProduct\">";
            var LitsProduct1 = db.tblProducts.Where(p => p.Active == true && p.Capacity == idCap && p.Design == 0 ).OrderBy(p => p.Ord).ToList();
            foreach (var item1 in LitsProduct1)
            {
                chuoi += "<div class=\"Tear_1\">";
                if (item1.New == true)
                    chuoi += "<div class=\"Note\"></div>";
                chuoi += "<div class=\"OrderNow\">";
                chuoi += "<a rel=\"miendatwebPopup\" href=\"#popup_content\" onclick=\"javascript:return CreateOrder(" + item1.id + ");\" title=\"Đặt hàng\">Đặt hàng</a>";
                chuoi += "</div>";
                chuoi += "<div class=\"img\">";
                chuoi += "<a href=\"/0/" + item1.Tag + "-" + item1.idCate + "-" + item1.id + ".aspx\" title=\"" + item1.Name + "\"><img src=\"" + item1.ImageLinkThumb + "\" alt=\"" + item1.Name + "\" /></a>";
                chuoi += "</div>";
                chuoi += "<a href=\"/0/" + item1.Tag + "-" + item1.idCate + "-" + item1.id + ".aspx\" class=\"Name\" title=\"" + item1.Name + "\">" + item1.Name + "</a>";
                chuoi += "<span class=\"Price\">" + string.Format("{0:#,#}", item1.Price) + "đ</span>";
                chuoi += "<span class=\"PriceSale\">" + string.Format("{0:#,#}", item1.PriceSale) + "đ</span>";
                chuoi += "</div>";
            }
            chuoi += "</div>";
             //kết thúc
            chuoi += "</div>";
            ViewBag.chuoi = chuoi;
            return View();
        }
    }
}