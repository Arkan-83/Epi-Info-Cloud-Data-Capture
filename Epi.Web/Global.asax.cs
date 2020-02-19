﻿using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;

namespace Epi.Web.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
        }

        protected void Application_Start()
        {
			string useSAMS = ConfigurationManager.AppSettings["USE_SAMS_AUTHENTICATION"];

			if(string.IsNullOrEmpty(useSAMS) == false && useSAMS.ToLower() == "true")
			{
				AreaRegistration.RegisterAllAreas();

				FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
				RouteConfig.RegisterRoutes(RouteTable.Routes);

				DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Mobile") { ContextCondition = (context => context.Request.UserAgent.IndexOf("Android", StringComparison.OrdinalIgnoreCase) >= 0) });
				DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Mobile") { ContextCondition = (context => context.Request.UserAgent.IndexOf("Opera Mobi", StringComparison.OrdinalIgnoreCase) >= 0) });
				DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Mobile") { ContextCondition = (context => context.Request.UserAgent.IndexOf("iPad", StringComparison.OrdinalIgnoreCase) >= 0) });

				//DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Android") { ContextCondition = (context => context.Request.UserAgent.IndexOf("Android", StringComparison.OrdinalIgnoreCase) >= 0) });
				//DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Opera") { ContextCondition = (context => context.Request.UserAgent.IndexOf("Opera Mobi", StringComparison.OrdinalIgnoreCase) >= 0) });
				//DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("iPhone") { ContextCondition = (context => context.Request.UserAgent.IndexOf("iPhone", StringComparison.OrdinalIgnoreCase) >= 0) });

				BundleConfig.RegisterBundles(BundleTable.Bundles);
				Bootstrapper.Initialise();
			}
			else
			{
				AreaRegistration.RegisterAllAreas();

				FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
				RouteConfig.RegisterRoutes(RouteTable.Routes);

				DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Mobile") { ContextCondition = (context => context.Request.UserAgent.IndexOf("Android", StringComparison.OrdinalIgnoreCase) >= 0) });
				DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Mobile") { ContextCondition = (context => context.Request.UserAgent.IndexOf("Opera Mobi", StringComparison.OrdinalIgnoreCase) >= 0) });
				DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Mobile") { ContextCondition = (context => context.Request.UserAgent.IndexOf("iPad", StringComparison.OrdinalIgnoreCase) >= 0) });

				//DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Android") { ContextCondition = (context => context.Request.UserAgent.IndexOf("Android", StringComparison.OrdinalIgnoreCase) >= 0) });
				//DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Opera") { ContextCondition = (context => context.Request.UserAgent.IndexOf("Opera Mobi", StringComparison.OrdinalIgnoreCase) >= 0) });
				//DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("iPhone") { ContextCondition = (context => context.Request.UserAgent.IndexOf("iPhone", StringComparison.OrdinalIgnoreCase) >= 0) });

				BundleConfig.RegisterBundles(BundleTable.Bundles);
				Bootstrapper.Initialise();

				//DisplayModes.Modes.Insert(0, new  DefaultDisplayMode("Mobile")
				//DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Mobile")
				//{
				//    ContextCondition = (ctx => ctx.Request.UserAgent != null
				//      && (ctx.Request.UserAgent.IndexOf("Android", StringComparison.OrdinalIgnoreCase) >= 0
				//      || ctx.Request.UserAgent.IndexOf("Mobile", StringComparison.OrdinalIgnoreCase) >= 0
				//      || ctx.Request.UserAgent.IndexOf("Opera Mobi", StringComparison.OrdinalIgnoreCase) >= 0
				//      || ctx.Request.UserAgent.IndexOf("Opera", StringComparison.OrdinalIgnoreCase) >= 0
				//      || ctx.Request.UserAgent.IndexOf("opera", StringComparison.OrdinalIgnoreCase) >= 0
				//      || ctx.Request.UserAgent.IndexOf("Opera Mini", StringComparison.OrdinalIgnoreCase) >= 0))
				//});
			}

		}

		/// <summary>
		///  HKLM\SYSTEM\CurrentControlSet\services\eventlog
		///  needs to be set in order to use the event log.
		/// </summary>
		protected void Application_Error()
        {
            Exception exc = Server.GetLastError();

            try
            {
				Epi.Web.Utility.ExceptionMessage.SendLogMessage(exc);
            }
            catch { }

            this.Response.Redirect("/", true);
        }
    }
}

