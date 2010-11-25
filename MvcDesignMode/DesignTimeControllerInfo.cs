using System;
using System.Collections.Generic;

namespace MvcDesignMode
{
    class DesignTimeControllerInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Type ControllerType { get; set; }
        public IEnumerable<DesignTimeActionInfo> ActionInfos { get; set; }
    }
}
