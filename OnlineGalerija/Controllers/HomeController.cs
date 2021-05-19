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

namespace OnlineGalerija.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private mongoDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _dbContext = new mongoDbContext();
        }

        public IActionResult Index()
        {
            //var test = _dbContext.database.GetCollection<Test>("test").Find<Test>(a=>a._id == "60a52b5cbd430955135f93b9").FirstOrDefault();
            //var test = _dbContext.database.GetCollection<Test>("test").Count(a=>a._id != "a");
            //var test = _dbContext.database.GetCollection<Test>("test").Find(a => true).ToList();
            var test = _dbContext.database.GetCollection<Niz>("niz").Find(a => true).ToList();
            string myNew = JsonConvert.SerializeObject(test);
            //Test rijadNovi = new Test() { name = "Rijad", surname = "Hubana" };
            //_dbContext.database.GetCollection<Test>("test").InsertOne(rijadNovi);
            return View("Index",myNew);
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
