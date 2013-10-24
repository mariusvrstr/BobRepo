﻿//-----------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="ABSA">
//     Copyright ABSA copyright tag
// </copyright>
//-----------------------------------------------------------------------
using Microsoft.Web.Optimization;

namespace ABSA.AOR.Web.App_Start
{
    using System.Web.Optimization;

    /// <summary>
    /// Contains the bundle details
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Registers the bundles.
        /// </summary>
        /// <param name="bundles">The bundles.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            // We want JQuery to load seperate and first
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/Scripts/jquery-1.9.1.js"));

            bundles.Add(new ScriptBundle("~/Scripts/app_common").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/common.js"));

            bundles.Add(new StyleBundle("~/Content/common_css").Include(
                "~/Content/site.css",
                "~/Content/bootstrap/bootstrap.css"));
        }
    }
}