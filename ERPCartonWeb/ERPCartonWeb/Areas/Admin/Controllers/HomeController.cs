using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPCartonWeb.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ERPCartonWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var email = User.GetSpecificClaim("Email");
            return View();
        }
    }
}