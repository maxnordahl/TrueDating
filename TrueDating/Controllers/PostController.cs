﻿using System;
using Logic;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrueDating.Models;
using System.Data.Entity;

namespace TrueDating.Controllers
{
    public class PostController : BaseController
    {


        // GET: Post
        public ActionResult Index(string id)
        {


            var posts = db.Posts.Where(x => x.To.Id == id).ToList();
            return View(new PostIndexViewModel { Id = id, Posts = posts });




        }
        public ActionResult Create(string id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Post post, string id)
        {


            var userName = User.Identity.Name;
            var user = db.Users.Single(x => x.UserName == userName);
            post.From = user;

            //var toUser = db.Users.Single(x => x.Id == id);
            //post.To = toUser;

            db.Posts.Add(post);

            db.SaveChanges();

            return RedirectToAction("Index", new { id = id });


        }
    }
        
        public class PostIndexViewModel
        {
            public string Id { get; set; }
            public ICollection<Post> Posts { get; set; }
        }
    
}
