using System.Web.Mvc;

namespace Portal.CMS.Web.Areas.ThemeEditor
{
    public class ThemeEditorAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ThemeEditor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ThemeEditor_default",
                "ThemeEditor/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}