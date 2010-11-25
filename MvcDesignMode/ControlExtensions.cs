using System.Linq;

namespace MvcDesignMode
{
    public static class ControlExtensions
    {
        public static System.Web.UI.Control AddControls(this System.Web.UI.Control control, params System.Web.UI.Control[] children)
        {
            children.All(c => { control.Controls.Add(c); return true; });
            return control;
        }
    }
}