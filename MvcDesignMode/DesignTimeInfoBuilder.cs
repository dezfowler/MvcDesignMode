using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace MvcDesignMode
{
    class DesignTimeInfoBuilder
    {
        private readonly Type _controllerAssemblyType;
        private readonly DesignModeOptions _options;

        public DesignTimeInfoBuilder(Type controllerAssemblyType, DesignModeOptions options)
        {
            if (controllerAssemblyType == null) throw new ArgumentNullException("controllerAssemblyType");
            if (options == null) throw new ArgumentNullException("options");
            _controllerAssemblyType = controllerAssemblyType;
            _options = options;
        }

        public DesignTimeInfo BuildInfo()
        {
            var info = new DesignTimeInfo
                       {
                           ControllerAssemblyType = _controllerAssemblyType, 
                           Options = _options
                       };

            info.DesignerControllers = info.ControllerAssemblyType.Assembly.GetTypes()
                // our designer controllers filter
                .Where(t => t.IsPublic && typeof(IController).IsAssignableFrom(t) && t.Name.EndsWith(info.Options.ControllerSuffix))
                // map to controller info objects
                .Select(t =>
                        {
                            string name = t.Name.Take(t.Name.Length - info.Options.ControllerSuffix.Length).Convert(c => new String(c.ToArray()));
                            return new DesignTimeControllerInfo
                                   {
                                       ControllerType = t,
                                       Name = name,
                                       Description = GetDescription(t) ?? name,
                                       ActionInfos = GetActionInfos(t),
                                   };
                        })
                .ToList();

            return info;
        }

        static IEnumerable<DesignTimeActionInfo> GetActionInfos(Type type)
        {
            return type.GetMethods()
                .Where(m => typeof(ActionResult).IsAssignableFrom(m.ReturnType))
                .Select(m => new DesignTimeActionInfo { Description = GetDescription(m) ?? m.Name, ActionMethodInfo = m })
                .ToList();
        }

        static string GetDescription(MemberInfo memberInfo)
        {
            return memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>().Select(d => d.Description).FirstOrDefault();
        }
    }
}