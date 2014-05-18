using System.Web;
using System.Web.Optimization;

namespace FitFlow
{
    public class BundleConfig
    {
        // バンドルの詳細については、http://go.microsoft.com/fwlink/?LinkId=301862 を参照してください
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.0.min.js",
                        "~/Scripts/jquery-ui-1.10.4.custom.min.js",
                        "~/Scripts/jquery.dataTables.js",
                        "~/Scripts/jquery.dataTables.customize.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 開発と学習には、Modernizr の開発バージョンを使用します。次に、実稼働の準備が
            // できたら、http://modernizr.com にあるビルド ツールを使用して、必要なテストのみを選択します。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/bootstrap-datepicker.ja.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/spin.min.js",
                      "~/Scripts/site.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.css",
                      "~/Content/docs.min.css",
                      "~/Content/datepicker3.css",
                      "~/Content/site.css"));
        }
    }
}
