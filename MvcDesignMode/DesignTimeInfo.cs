using System;
using System.Collections.Generic;

namespace MvcDesignMode
{
    class DesignTimeInfo
    {
        public Type ControllerAssemblyType { get; set; }
        public List<DesignTimeControllerInfo> DesignerControllers { get; set; }
        public DesignModeOptions Options { get; set; }
    }
}
