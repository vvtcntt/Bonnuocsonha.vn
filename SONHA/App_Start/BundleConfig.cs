using System.Web;
using System.Web.Optimization;

namespace SONHA
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
            bundles.Add(new StyleBundle("~/Content/Display/Style/css").Include(
                        "~/Content/Display/Style/contact.css",
                        "~/Content/Display/Style/contact_Rs.css",
                        "~/Content/Display/Style/Default.css",
                        "~/Content/Display/Style/Default_Rs.css",
                        "~/Content/Display/Style/jquery.mmenu.all.css",
                        "~/Content/Display/Style/News.css",
                        "~/Content/Display/Style/Order.css",
                        "~/Content/Display/Style/Order_Rs.css",
                        "~/Content/Display/Style/Product.css",
                        "~/Content/Display/Style/Product_Rs.css",
                        "~/Content/Display/Style/slide.css",
                        "~/Content/Display/Style/Popup.css",
                        "~/Content/Display/Style/baogia.css",
                        "~/Content/Display/Style/Baogia_Rs.css",
                        "~/Content/PagedList.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}