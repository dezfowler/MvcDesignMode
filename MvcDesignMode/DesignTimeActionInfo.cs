using System.Reflection;

namespace MvcDesignMode
{
    class DesignTimeActionInfo
    {
        public MethodInfo ActionMethodInfo { get; set; }
        public string Description { get; set; }
    }
}