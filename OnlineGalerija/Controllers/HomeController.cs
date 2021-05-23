using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineGalerija.Models;
using OnlineGalerija.PostgresModels;
using System.Diagnostics;
using MongoDB.Driver;
using System.Linq;
using OnlineGalerija.ViewModels;
using OnlineGalerija.Helper;

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
        public LoggedUser napraviMongoKorisnika(Models.User user)
        {
            LoggedUser newL = new LoggedUser() { IsMongoUser = true, postgreUser = null, mongoUser = new MongoUser() };
            newL.mongoUser.objId = user._id; newL.mongoUser.mongoUser = user;
            return newL;
        }
        public LoggedUser napraviPostgreKorisnika(PostgresModels.User user)
        {
            LoggedUser newL = new LoggedUser() { IsMongoUser = false, mongoUser = null, postgreUser = new PostgreUser() };
            newL.postgreUser.userId = user.Id; newL.postgreUser.postgreUser = user;
            return newL;
        }
        public IActionResult MongoAuth(string username, string password)
        {
            var foundUser = _mongoDbContext.database.GetCollection<Models.User>("user").Find(a => a.username == username && a.passwordhash == password).FirstOrDefault();
            if (foundUser == null)
            {
                return View("MongoLogin", "Nevalidni kredencijali!");
            }
            else
            {
                HttpContext.SetLogiraniKorisnik(napraviMongoKorisnika(foundUser), false);
                return Redirect("/Mongo/Index");
            }
        }
        public IActionResult PostgreLogin()
        {
            return View("PostgreLogin", null);
        }
        public IActionResult MongoLogin()
        {
            return View("MongoLogin", null);
        }
        public IActionResult PostgreAuth(string username, string password)
        {
            //var foundUser = _mongoDbContext.database.GetCollection<PostgresModels.User>("user").Find(a => a.username == username && a.passwordhash == password).FirstOrDefault();
            var foundUser = _postgresDbContext.Users.Where(a => a.Username == username && a.PasswordHash == password).FirstOrDefault();
            if (foundUser == null)
            {
                return View("PostgreLogin", "Nevalidni kredencijali!");
            }
            else
            {
                HttpContext.SetLogiraniKorisnik(napraviPostgreKorisnika(foundUser), false);
                return Redirect("/Postgre/Index");
            }
        }
        public IActionResult Index()
        {
            //OnlineGalerija.Helper.Methods.ExecuteCreation(_mongoDbContext);
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
