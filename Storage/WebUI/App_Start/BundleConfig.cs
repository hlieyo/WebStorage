using System.Web;
using System.Web.Optimization;

namespace WebUI
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate.min.js", "~/Scripts/jquery.validate.unobtrusive.min.js"));


            //beyondadmin-v1.6.0.s3  
            bundles.Add(new ScriptBundle("~/adminStyles/css").Include("~/Content/assets/css/bootstrap.min.css", "~/Content/assets/css/font-awesome.min.css", "~/Content/assets/css/weather-icons.min.css", "~/Content/assets/css/beyond.min.css", "~/Content/assets/css/typicons.min.css", "~/Content/assets/css/animate.min.css", "~/Content/assets/css/googleapisFont.css"));

            bundles.Add(new ScriptBundle("~/bundles/adminskins").Include("~/Content/assets/js/skins.min.js", "~/Content/assets/js/jquery.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/admin").Include("~/Content/assets/js/bootstrap.min.js", "~/Content/assets/js/slimscroll/jquery.slimscroll.min.js", "~/Content/assets/js/beyond.min.js"));

            // sweetalert
            bundles.Add(new StyleBundle("~/Content/sweetalert").Include("~/Content/dist/sweetalert.css"));
            bundles.Add(new StyleBundle("~/bundles/sweetalert").Include("~/Content/dist/sweetalert-dev.js"));
        }
    }
}
