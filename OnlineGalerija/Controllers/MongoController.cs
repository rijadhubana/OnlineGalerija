using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineGalerija.Helper;

namespace OnlineGalerija.Controllers
{
    [Authorization(true, false)]
    public class MongoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
