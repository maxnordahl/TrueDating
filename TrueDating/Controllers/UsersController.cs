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
using System.IO;
using Microsoft.AspNet.Identity.Owin;

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

            var model = new ApplicationUser()
            {
                Nickname = user.Nickname,
                Gender = user.Gender,
                Photo = user.Photo,
                Age = user.Age,
                Id = user.Id,
                City = user.City
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

        public ActionResult SearchForUser(string searchString)
        {
            var users = from u in userRepository.GetAll().Where(x => x.Visibility == Visibility.Visible) select u;

            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(x => x.Nickname.Contains(searchString) && x.Visibility == Visibility.Visible);   
            }
            return View(users);
        }

        public FileContentResult UserPhotos()
        {
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();

                if (userId == null)
                {
                    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);

                    return File(imageData, "image/png");
                }
                var bdUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                var userImage = bdUsers.Users.Where(x => x.Id == userId).FirstOrDefault();
                return new FileContentResult(userImage.Photo, "image/jpeg");




            }
            else
            {
                string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);
                return File(imageData, "image/png");

            }

           
        }

        public ActionResult EditProfile()
        {
            var user = User.Identity.GetUserId();
            var applicationUser = userRepository.Get(user);

            UserEditViewModel editViewModel = new UserEditViewModel
            {
                Id = applicationUser.Id,
                City = applicationUser.City,
                Age = applicationUser.Age,
                Visibility = applicationUser.Visibility,
                Photo = applicationUser.Photo,
                Nickname = applicationUser.Nickname
            };

            return View(editViewModel);
        }
    }
}