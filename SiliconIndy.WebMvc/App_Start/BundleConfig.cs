using System.Web;
using System.Web.Optimization;

namespace SiliconIndy.WebMvc
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/codemirror_csharp").Include(
                      "~/Scripts/codemirror.js"));

            bundles.Add(new ScriptBundle("~/bundles/codemirror_csharp").Include(
                      "~/Scripts/codemirror_csharp.js"));

            bundles.Add(new ScriptBundle("~/bundles/comment-form").Include(
                      "~/Scripts/comment-form.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/font-awesome.css",
                      "~/Content/css/PagedList.css",
                      "~/Content/css/styles.css",
                      "~/Content/css/site.css"
                      ));
        }
    }
}
