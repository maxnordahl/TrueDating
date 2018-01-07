using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logic;
using System.Web.Mvc;

namespace TrueDating.Controllers
{
    public class PostsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        // GET: Post

        public void AddPost([FromBody] PostIndexViewModel model)
        {
            Post newPost = new Post();
            var from = db.Users.Single(x => x.Id == model.fromId);
            newPost.From = from;

            var to = db.Users.Single(x => x.Id == model.toId);
            newPost.To = to;

            newPost.Text = model.text;

            newPost.Date = DateTime.Now;

            db.Posts.Add(newPost);
            db.SaveChanges();
        }

        public List<Post> ListPosts(string id)
        { 
            var posts = db.Posts.Where(x => x.To.Id == id).ToList();
            return posts;
        }

        
        }

        public class PostIndexViewModel
        {
        public string fromId { get; set; }
        public string toId { get; set; }
        public string text { get; set; }
        public ICollection<Post> Posts { get; set; }
        }
    
}
