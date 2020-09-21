using System.Web;
using System.Web.Optimization;

namespace SeedaniLegalCare
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            bundles.Add(new StyleBundle("~/Content/css/css").Include(
                      "~/Content/css/open-iconic-bootstrap.min.css",
                      "~/Content/css/animate.css",
                      "~/Content/css/owl.carousel.min.css",
                      "~/Content/css/owl.theme.default.min.css",
                      "~/Content/css/magnific-popup.css",
                      "~/Content/css/aos.css",
                      "~/Content/css/ionicons.min.css",
                      "~/Content/css/flaticon.css",
                      "~/Content/css/icomoon.css",
                      "~/Content/css/style.css"

              ));

            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                    "~/Scripts/js/jquery.min.js",
                    "~/Scripts/js/jquery-migrate-3.0.1.min.js",
                    "~/Scripts/js/popper.min.js",
                    "~/Scripts/js/bootstrap.min.js",
                    "~/Scripts/js/jquery.easing.1.3.js",
                    "~/Scripts/js/jquery.waypoints.min.js",
                    "~/Scripts/js/jquery.stellar.min.js",
                    "~/Scripts/js/owl.carousel.min.js",
                    "~/Scripts/js/jquery.magnific-popup.min.js",
                    "~/Scripts/js/aos.js",
                    "~/Scripts/js/jquery.animateNumber.min.js",
                    "~/Scripts/js/scrollax.min.js",
                    "~/Scripts/js/google-map.js",
                    "~/Scripts/js/main.js"
                ));
        }
    }
}
