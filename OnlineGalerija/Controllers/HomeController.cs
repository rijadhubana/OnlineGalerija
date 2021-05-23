using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using OnlineGalerija.Models;
using Newtonsoft.Json;
using OnlineGalerija.PostgresModels;

namespace OnlineGalerija.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private mongoDbContext _mongoDbContext;
        private postgresDbContext _postgresDbContext;

        public HomeController(ILogger<HomeController> logger, postgresDbContext dbContext)
        {
            _logger = logger;
            _mongoDbContext = new mongoDbContext();
            _postgresDbContext = dbContext;
        }

        public IActionResult Index()
        {
            //OnlineGalerija.Helper.Methods.ExecuteCreation(_dbContext);
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
