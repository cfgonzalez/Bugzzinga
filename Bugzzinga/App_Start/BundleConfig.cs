using System.Web.Optimization;

namespace Bugzzinga.App_Start
{
    /// <summary>
    /// Incluye los archivos .js y .css en el cliente.
    /// </summary>
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/thirdParty").Include(                                
                                "~/Scripts/ThirdParty/angular.js",
                                "~/Scripts/ThirdParty/jquery*",
                                "~/Scripts/ThirdParty/ui-bootstrap-tpls-0.6.0.js",
                                "~/Scripts/App/*.js"));

            //bundles.Add(new ScriptBundle("~/Scripts/thirdParty").Include(
            //                   "~/Scripts/ThirdParty/*.js",
            //                   "~/Scripts/App/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/*.css"));

            BundleTable.EnableOptimizations = false; 
        }
    }
}