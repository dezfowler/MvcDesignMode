using System.Web.Mvc;

namespace MvcDesignMode
{
    class DesignTimeView : IView
    {
        public ViewPage ViewPage { get; set; }
        
        public void Render(ViewContext viewContext, System.IO.TextWriter writer)
        {
            ViewPage.RenderView(viewContext);
        }
    }
}