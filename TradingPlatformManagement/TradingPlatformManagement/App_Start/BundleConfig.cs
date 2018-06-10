using System.Web.Optimization;

namespace TradingPlatformManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;
            //General CSS
            bundles.Add(new StyleBundle("~/Content/Gentelella/css").Include(
                    "~/Content/Site.css",
                     "~/Content/gentelella/vendors/bootstrap/dist/css/bootstrap.min.css",
                     "~/Content/gentelella/vendors/font-awesome/css/font-awesome.min.css",
                     "~/Content/gentelella/vendors/nprogress/nprogress.css",
                     "~/Content/gentelella/vendors/iCheck/skins/flat/green.css",
                     "~/Content/gentelella/vendors/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css",
                     "~/Content/gentelella/vendors/jqvmap/dist/jqvmap.min.css",
                     "~/Content/gentelella/vendors/bootstrap-daterangepicker/daterangepicker.css",
                     "~/Content/gentelella/build/css/custom.min.css",
                     "~/Content/gentelella/vendors/pnotify/dist/pnotify.css",
                     "~/Content/gentelella/vendors/pnotify/dist/pnotify.css",
                     "~/Content/gentelella/vendors/pnotify/dist/pnotify.buttons.css",
                     "~/Content/gentelella/vendors/pnotify/dist/pnotify.nonblock.css",
                     "~/Content/gentelella/vendors/jquery-ui/jquery-ui.min.css"
                     ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                                    "~/Scripts/jquery.validate*"));
            //highlight
            bundles.Add(new StyleBundle("~/Content/highlight/css").Include("~/Content/highlight/styles/default.css"));
            bundles.Add(new ScriptBundle("~/Content/highlight/js").Include("~/Content/highlight/highlight.pack.js"));
            //modernizr JS
            bundles.Add(new ScriptBundle("~/Scripts/modernizr/js").Include(
                  "~/Scripts/modernizr-2.6.2.js",
                  "~/Scripts/kendo.modernizr.custom.js"
                   ));
            //template init js
            bundles.Add(new ScriptBundle("~/Scripts/TemplateInit").Include(
                  "~/Scripts/TemplateInit.js"
                   ));
            //Print CSS
            bundles.Add(new StyleBundle("~/Content/print/css").Include("~/Content/Print.css"));
            //Template JS
            bundles.Add(new ScriptBundle("~/Content/Gentelella/js").Include(
                    "~/Content/gentelella/vendors/bootstrap/dist/js/bootstrap.min.js",
                    "~/Content/gentelella/vendors/fastclick/lib/fastclick.js",
                    "~/Content/gentelella/vendors/nprogress/nprogress.js",
                    "~/Content/gentelella/vendors/Chart.js/dist/Chart.min.js",
                    //"~/Content/gentelella/vendors/gauge.js/dist/gauge.min.js",
                    "~/Content/gentelella/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js",
                    "~/Content/gentelella/vendors/iCheck/icheck.min.js",
                    "~/Content/gentelella/vendors/skycons/skycons.js",
                    "~/Content/gentelella/vendors/Flot/jquery.flot.js",
                    "~/Content/gentelella/vendors/Flot/jquery.flot.pie.js",
                    "~/Content/gentelella/vendors/Flot/jquery.flot.time.js",
                    "~/Content/gentelella/vendors/Flot/jquery.flot.stack.js",
                    "~/Content/gentelella/vendors/Flot/jquery.flot.resize.js",
                    "~/Content/gentelella/vendors/flot.orderbars/js/jquery.flot.orderBars.js",
                    "~/Content/gentelella/vendors/flot-spline/js/jquery.flot.spline.min.js",
                    "~/Content/gentelella/vendors/flot.curvedlines/curvedLines.js",
                    //"~/Content/gentelella/vendors/DateJS/build/date.js",
                    "~/Content/gentelella/vendors/jqvmap/dist/jquery.vmap.js",
                    //"~/Content/gentelella/vendors/jqvmap/dist/maps/jquery.vmap.world.js",
                    // "~/Content/gentelella/vendors/jqvmap/examples/js/jquery.vmap.sampledata.js",
                    "~/Content/gentelella/vendors/moment/min/moment.min.js",
                    "~/Content/gentelella/vendors/bootstrap-daterangepicker/daterangepicker.js",
                    "~/Content/gentelella/build/js/custom.min.js",
                    "~/Content/gentelella/vendors/pnotify/dist/pnotify.js",
                    "~/Content/gentelella/vendors/pnotify/dist/pnotify.buttons.js",
                    "~/Content/gentelella/vendors/pnotify/dist/pnotify.nonblock.js",
                    "~/Content/gentelella/vendors/jquery-ui/jquery-ui.min.js"
                     ));
            //ISO
            bundles.Add(new StyleBundle("~/Content/flags/css").Include(
               "~/Content/flags/css/flag-css.css",
               "~/Content/flags/css/flag-css.min.css"));
        }
    }
}
