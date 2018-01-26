using Portal.CMS.Services.Themes;
using Portal.CMS.Web.Architecture.Helpers;
using Portal.CMS.Web.Areas.ThemeEditor.ViewModels.Render;
using System.Web.Mvc;

namespace Portal.CMS.Web.Areas.ThemeEditor.Controllers
{
    public class RenderController : Controller
    {
        private readonly IThemeService _themeService;

        public RenderController(IThemeService themeService)
        {
            _themeService = themeService;
        }

        public ActionResult Index()
        {
            var model = new RenderViewModel
            {
                Theme = AsyncHelpers.RunSync(() => _themeService.GetDefaultAsync())
            };

            return View(model);
        }
    }
}