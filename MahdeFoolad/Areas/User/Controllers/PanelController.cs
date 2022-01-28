using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using SharedFrameWork.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace MahdeFoolad.Areas.User.Controllers
{
    [Area("User")]
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult Reports()
        {

            return new JsonResult(string.Empty);
        }
    }




}
