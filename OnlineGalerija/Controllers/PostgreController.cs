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
        [HttpPost]
        public async Task<IActionResult> Comment(Comment vm)
        {
                var comment = new Comment
                {
                    Id = vm.Id,
                    Text = vm.Text,
                    PostId = vm.PostId,
                    UserId = vm.UserId,
                    CreatedAt = DateTime.Now,
                    
                };
            if (comment.Id > 0)
            {
                _db.Comments.Update(comment);
            }
            else
            {
                _db.Comments.Add(comment);
            }            
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
                

            
        }
        [HttpGet]
        public IActionResult Comment(int id)
        {
            var viewModel = _db.Comments.Where(p => p.Id == id).FirstOrDefault();
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var komentar = await _db.Comments.FindAsync(id);
            _db.Comments.Remove(komentar);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Like(int id)
        {
            var reaction = new UserReactionComment
            {
                CommentId = id,
                ReactionId = 1,
                UserId = 1,

            };
            if (_db.UserReactionComments.Contains(reaction))
            {
                _db.UserReactionComments.Update(reaction);
            }
            else 
            {
                _db.UserReactionComments.Add(reaction);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");



        }
        [HttpGet]
        public async Task<IActionResult> Dislike(int id)
        {
            var reaction = new UserReactionComment
            {
                CommentId = id,
                ReactionId = 2,
                UserId = 1,

            };
            if (_db.UserReactionComments.Contains(reaction))
            {
                _db.UserReactionComments.Update(reaction);
            }
            else
            {
                _db.UserReactionComments.Add(reaction);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");



        }
        [HttpGet]
        public async Task<IActionResult> PostLike(int id)
        {
            var reaction = new UserReactionPost
            {
                PostId = id,
                ReactionId = 1,
                UserId = 1,

            };
            if (_db.UserReactionPosts.Contains(reaction))
            {
                _db.UserReactionPosts.Update(reaction);
            }
            else
            {
                _db.UserReactionPosts.Add(reaction);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");



        }
        [HttpGet]
        public async Task<IActionResult> PostDislike(int id)
        {
            var reaction = new UserReactionPost
            {
                PostId = id,
                ReactionId = 2,
                UserId = 1,

            };
            if (_db.UserReactionPosts.Contains(reaction))
            {
                _db.UserReactionPosts.Update(reaction);
            }
            else
            {
                _db.UserReactionPosts.Add(reaction);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");



        }
    }
}
