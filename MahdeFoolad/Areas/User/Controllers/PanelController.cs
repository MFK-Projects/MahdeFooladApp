using Microsoft.AspNetCore.Mvc;

namespace MahdeFoolad.Areas.User.Controllers
{
    [Area("User")]
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
