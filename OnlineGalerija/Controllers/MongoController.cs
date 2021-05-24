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
            var viewModel = _db.database.GetCollection<Post>("post").Find(a => true).ToList();
            foreach (var x in viewModel)
            {
                foreach (var y in x.images)
                {
                    var trenutni = _db.database.GetCollection<Image>("image").Find(a => a._id == y._id).FirstOrDefault();
                    y.image_data = trenutni.image_data;
                    y.post = trenutni.post;
                }
                foreach (var y in x.hashtags)
                {
                    var trenutni = _db.database.GetCollection<Hashtag>("hashtag").Find(a => a._id == y._id).FirstOrDefault();
                    y.text = trenutni.text;
                    y.referencedIn = trenutni.referencedIn;
                }
                x.user = _db.database.GetCollection<User>("user").Find(a => a._id == x.user._id).FirstOrDefault();
            }
            return View("Index",viewModel);
        }
        public IActionResult AddPost()
        {
            return View("AddPost");
        }
        public IActionResult RecordPost()
        {
            return Redirect("/Mongo/Index");

        }
    }
}
