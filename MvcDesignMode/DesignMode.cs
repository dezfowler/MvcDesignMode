using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcDesignMode
{
    /// <summary>
    /// Entry point to activating design mode
    /// </summary>
    public class DesignMode
    {
        /// <summary>
        /// Activate design mode with default options
        /// </summary>
        /// <param name="controllerAssemblyType">A type in the assembly containing designer controllers</param>
        public static void Activate(Type controllerAssemblyType)
        {
            Activate(controllerAssemblyType, null);
        }

        /// <summary>
        /// Activate design mode with specific options
        /// </summary>
        /// <param name="controllerAssemblyType">A type in the assembly containing designer controllers</param>
        /// <param name="options">Options for running in design mode</param>
        public static void Activate(Type controllerAssemblyType, DesignModeOptions options)
        {
            if (controllerAssemblyType == null) throw new ArgumentNullException("controllerAssemblyType");

            var opts = (options != null) ? options.Clone() : DesignModeOptions.Defaults;

            var infoBuilder = new DesignTimeInfoBuilder(controllerAssemblyType, opts);
            DesignTimeInfo info = infoBuilder.BuildInfo();

            RouteTable.Routes.Clear();

            RouteTable.Routes.IgnoreRoute("favicon.ico");
            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            RouteTable.Routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "_Design", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            ControllerBuilder.Current.SetControllerFactory(new DesignTimeControllerFactory(info));
        }
    }
}
