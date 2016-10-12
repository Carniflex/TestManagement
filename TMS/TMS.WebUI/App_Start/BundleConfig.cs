using System.Web.Optimization;

namespace TMS.WebUI.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterStyleBundles(bundles);
            RegisterJavascriptBundles(bundles);
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css")
                            .IncludeDirectory("~/Content","*.css",true)
                            .IncludeDirectory("~/Content","*.min.css",true));
        }


        private static void RegisterJavascriptBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js")
                           .IncludeDirectory("~/Scripts","*.js",true)
                           .IncludeDirectory("~/Scripts","*.min.js",true));
        }
    }
}