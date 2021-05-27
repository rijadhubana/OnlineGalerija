using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineGalerija.Helper;
using OnlineGalerija.PostgresModels;

namespace OnlineGalerija.Controllers
{
    [Authorization(false, true)]
    public class PostgreController : Controller
    {
        private postgresDbContext _db;
        public PostgreController(postgresDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //primjer pristupanja login sesiji
            //var logiraniKorisnik = HttpContext.GetLogiraniKorisnik();
            //string userNameSurname = logiraniKorisnik.postgreUser.postgreUser.NameSurname;
            var viewModel = _db.Posts.ToList();
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Post(int id)
        {
            var viewModel = _db.Posts.Include(p => p.Comments).Where(p => p.Id == id).FirstOrDefault();
            return View(viewModel);
        }
    }
}
