using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace MvcDesignMode
{
    internal sealed class DesignTimeController : Controller
    {
        private readonly DesignTimeControllerFactory _designTimeControllerFactory;
        
        public DesignTimeController(DesignTimeControllerFactory designTimeControllerFactory)
        {
            _designTimeControllerFactory = designTimeControllerFactory;
        }

        public ActionResult Index()
        {
            var designHomePage = new ViewPage();
            designHomePage.AddControls(
                new HtmlGenericControl("html").AddControls(
                    new HtmlGenericControl("body").AddControls(
                        new HtmlGenericControl("h1"){InnerText = "MVC Design Mode"},
                        new HtmlGenericControl("ul").AddControls(
                            GetListItemsForActions()
                            )
                        )
                    )
                );
            
            return new ViewResult
                   {
                       View = new DesignTimeView
                              {
                                  ViewPage = designHomePage
                              }
                   };
        }

        private Control[] GetListItemsForActions()
        {
            return _designTimeControllerFactory.Info.DesignerControllers
                .Select(controllerInfo =>
                         new HtmlGenericControl("li") { InnerText = controllerInfo.Description }
                            .AddControls(
                                new HtmlGenericControl("ul").AddControls(
                                    controllerInfo.ActionInfos.Select(m => new HtmlGenericControl("li")
                                                               {
                                                                   InnerHtml = String.Format("<a href=\"/{0}/{1}\">{2}</a>", controllerInfo.Name, m.ActionMethodInfo.Name, m.Description),
                                                               }).ToArray()
                                    )
                            )
                        ).ToArray();
        }
    }
}