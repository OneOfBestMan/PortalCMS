using Portal.CMS.Services.Themes;
using Portal.CMS.Web.Architecture.ActionFilters;
using Portal.CMS.Web.Areas.ThemeEditor.ViewModels.AppDrawer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Portal.CMS.Web.Areas.ThemeEditor.Controllers
{
    public class AppDrawerController : Controller
    {
        private readonly IThemeService _themeService;

        public AppDrawerController(IThemeService themeService)
        {
            _themeService = themeService;
        }

        [HttpGet, AdminFilter(ActionFilterResponseType.Page)]
        public async Task<ActionResult> Index()
        {
            var model = new AppDrawerViewModel
            {
                Themes = await _themeService.GetAsync(),
                Fonts = new List<Entities.Entities.Font>()
            };

            model.Fonts.AddRange(model.Themes.Select(x => x.TextFont));
            model.Fonts.AddRange(model.Themes.Select(x => x.TitleFont));

            return View(model);
        }
    }
}