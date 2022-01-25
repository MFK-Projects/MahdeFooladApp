using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MahdeFoolad.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "")]
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
