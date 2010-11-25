using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcDesignMode
{
    class DesignTimeControllerFactory : DefaultControllerFactory
    {
        private static readonly Type DesignTimeControllerType = typeof (DesignTimeController);
        
        internal DesignTimeInfo Info;

        public DesignTimeControllerFactory(DesignTimeInfo info)
        {
            Info = info;
        }
        
        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            if (requestContext.RouteData.GetRequiredString("controller").Equals("_Design", StringComparison.OrdinalIgnoreCase))
            {
                return DesignTimeControllerType;
            }

            return Info.DesignerControllers
                .Where(p => p.Name.Equals(controllerName, StringComparison.OrdinalIgnoreCase))
                .Select(p => p.ControllerType).FirstOrDefault();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == DesignTimeControllerType)
            {
                return new DesignTimeController(this);
            }
            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}