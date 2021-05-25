using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public IActionResult RecordPost(string title, string text,string img, string hashtag)
        {
            //dodavanje hashtaga u tabelu ukoliko već ne postoji
            Hashtag h1 = new Hashtag() { text = hashtag, referencedIn=new Collection<Post>() };
            if (hashtag!=null && hashtag!="")
            {
                if (_db.database.GetCollection<Hashtag>("hashtag").Find(a=>a.text==hashtag).CountDocuments()==0)
                {
                    _db.database.GetCollection<Hashtag>("hashtag").InsertOne(h1);
                }
            }
            Post p1 = new Post()
            {
                title = title,
                text = text,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
                hashtags = new Collection<Hashtag>(),
                images = new Collection<Image>(),
                reactions = new Collection<ReactionPost>(),
                user = new Models.User() { _id=HttpContext.GetLogiraniKorisnik().mongoUser.objId }
            };
            if (hashtag!=null && hashtag!="")
                p1.hashtags.Add(new Hashtag() { _id = h1._id });
            _db.database.GetCollection<Post>("post").InsertOne(p1);
            //osiguravanje konzistentnosti na obje strane
            if (hashtag!=null && hashtag!="")
            {
                var trenutniH = _db.database.GetCollection<Hashtag>("hashtag").Find(a => a._id == h1._id).FirstOrDefault();
                trenutniH.referencedIn.Add(new Post() { _id = p1._id });
                _db.database.GetCollection<Hashtag>("hashtag").FindOneAndReplace(a => a._id == h1._id, trenutniH);
            }
            Image i1 = new Image() { image_data = Encoding.ASCII.GetBytes(img), post = new Post() { _id = p1._id } };
            _db.database.GetCollection<Image>("image").InsertOne(i1);
            var trenutniPost = _db.database.GetCollection<Post>("post").Find(a => a._id == p1._id).FirstOrDefault();
            trenutniPost.images.Add(new Image() { _id = i1._id });
            _db.database.GetCollection<Post>("post").FindOneAndReplace(a => a._id == p1._id, trenutniPost);
            var trenutniUser = _db.database.GetCollection<User>("user").Find(a => a._id == HttpContext.GetLogiraniKorisnik().mongoUser.objId).FirstOrDefault();
            trenutniUser.posts.Add(new Post() { _id = trenutniPost._id });
            return Redirect("/Mongo/Index");

        }
    }
}
