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
            bundles.Add(new ScriptBundle("~/Scripts/thirdParty").Include("~/Scripts/ThirdParty/*.js"));

            bundles.Add(new ScriptBundle("~/Scripts/viewModels").Include("~/Scripts/ViewModels/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/*.css"));
        }
    }
}