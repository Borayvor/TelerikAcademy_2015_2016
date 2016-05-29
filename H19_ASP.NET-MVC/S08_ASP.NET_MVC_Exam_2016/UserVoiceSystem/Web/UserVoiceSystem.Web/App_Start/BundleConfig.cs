﻿namespace UserVoiceSystem.Web
{
    using System.Web.Optimization;

    public static class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);
            RegisterStyles(bundles);
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/KendoUI/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryUnobtrusive")
                .Include("~/Scripts/jquery.unobtrusive-ajax*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo")
                .Include(
                    "~/Scripts/KendoUI/kendo.all.min.js",
                    "~/Scripts/KendoUI/kendo.aspnetmvc.min.js"));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrapCss")
                .Include("~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/kendo/css")
                .Include(
                "~/Content/KendoUI/kendo.common.min.css",
                "~/Content/KendoUI/kendo.metro.min.css"));
        }
    }
}
