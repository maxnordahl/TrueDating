using System;
using Logic;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Logic.Repositories;
using TrueDating.Models;

namespace TrueDating.Controllers
{
    public class UsersController : Controller
    {
        private UserRepository userRepository;
        private PostRepository postRepository;
        private FriendRepository friendRepository;

        public UsersController()
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();

            userRepository = new UserRepository(applicationDbContext);
            postRepository = new PostRepository(applicationDbContext);
            friendRepository = new FriendRepository(applicationDbContext);
        }


        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();

            var user = userRepository.Get(userID);

            var model = new ProfileViewModel()
            {
                Nickname = user.Nickname,
                Gender = user.Gender,
                Image = user.Photo,
                Age = user.Age,
                Id = user.Id
            };


            return View(model);
         }

        public ActionResult Posts(string id)
        {
            var userID = User.Identity.GetUserId();

            var identity = userRepository.Get(userID);
            var user = userRepository.Get(id);

            var model = new PostViewModel()
            {
                Reciever = user,
                Sender = identity
            };


            var posts = postRepository.GetAllForUser(userID);
            model.Posts = posts.Select(post => new PostInfoViewModel()
            {
                Id = post.Id,
                Text = post.Text,
                Sender = post.From,
                Date = post.Date,

            }).ToList();


            return View(model);
        }

        public ActionResult Create(string id)
        {
            var reciever = userRepository.Get(id);
            return View();
        }


    }
}