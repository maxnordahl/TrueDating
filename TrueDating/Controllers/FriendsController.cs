using Logic;
using Logic.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrueDating.Models;

namespace TrueDating.Controllers
{
    public class FriendsController : Controller
    {
        private UserRepository userRepository;
        private PostRepository postRepository;
        private FriendRepository friendRepository;

        public FriendsController()
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();

            userRepository = new UserRepository(applicationDbContext);
            postRepository = new PostRepository(applicationDbContext);
            friendRepository = new FriendRepository(applicationDbContext);
        }


        // GET: Friends
        public ActionResult Index(string id)
        {
            var user = userRepository.Get(User.Identity.GetUserId());
            if (user == null)
                return RedirectToAction("index");

            var model = new FriendViewModel
            {
                Id = user.Id,
                Photo = user.Photo,
                Age = user.Age,
                Gender = user.Gender,
                City = user.City,
                Nickname = user.Nickname
            };
            return View(model);
        }

        public ActionResult AcceptFriend(string id)
        {
            var requestFriend = userRepository.Get(id);
            var acceptFriend = userRepository.Get(User.Identity.GetUserId());

            var Friend = friendRepository.GetAll().Single(x => x.FriendFrom == requestFriend && x.FriendTo == acceptFriend);

            Friends friends = new Friends();
            {
                friends.FriendFrom = requestFriend;
                friends.FriendTo = acceptFriend;
            }

            friendRepository.Add(friends);
            friendRepository.Save();
            friendRepository.Delete(Friend.Id);
            friendRepository.Save();


            return View("Error");
        }

        public ActionResult DeclineFriend(string id)
        {

            var requestFriend = userRepository.Get(id);
            var acceptFriend = userRepository.Get(User.Identity.GetUserId());

            var Friend = friendRepository.GetAll().Single(x => x.FriendFrom == requestFriend && x.FriendTo == acceptFriend);

            friendRepository.Delete(Friend.Id);
            friendRepository.Save();
            

            return View("Error");
        }
    }
}
