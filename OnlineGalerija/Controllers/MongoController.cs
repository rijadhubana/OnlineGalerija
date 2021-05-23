using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using OnlineGalerija.Helper;
using OnlineGalerija.Models;

namespace OnlineGalerija.Controllers
{
    [Authorization(true, false)]
    public class MongoController : Controller
    {
        private mongoDbContext _db;
        public MongoController()
        {
            _db = new mongoDbContext();
        }
        public IActionResult Index()
        {
            //primjer pristupanja login sesiji
            //var logiraniKorisnik = HttpContext.GetLogiraniKorisnik();
            //string userNameSurname = logiraniKorisnik.mongoUser.mongoUser.namesurname;
            return View();
        }
    }
}
