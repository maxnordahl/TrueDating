using Logic;
using Logic.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrueDating.Controllers
{
    public class FriendRequestsController : Controller
    {
        private UserRepository userRepository;
        private PostRepository postRepository;
        private FriendRepository friendRepository;

        public FriendRequestsController()
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();

            userRepository = new UserRepository(applicationDbContext);
            postRepository = new PostRepository(applicationDbContext);
            friendRepository = new FriendRepository(applicationDbContext);
        }
        // GET: FriendRequest
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SendFriendRequest(string id)
        {
            Friends friends = new Friends();
        
            var userName = User.Identity.Name;

            var from = userRepository.GetAll().Single(x => x.UserName.Equals(userName));
            friends.FriendFrom = from;
            var to = userRepository.GetAll().Single(x => x.Id.Equals(id));
            friends.FriendTo = to;

            var requests = friendRepository.GetAll();

            bool requestExists = false;

            foreach(var item in requests)
            {
                if(from.Id.Equals(item.FriendTo_Id) && to.Id.Equals(item.FriendFrom_Id) || from.Id.Equals(item.FriendFrom_Id) && to.Id.Equals(item.FriendTo_Id))
                {
                    requestExists = true;
                }
            }

            if(requestExists == false && friends.FriendStatus == FriendStatus.Pending)
            {
                friendRepository.Add(friends);

                
               
                friendRepository.Save();
                return View("Error"); 

            }


            return View();
        }

        [HttpGet]
        public ActionResult FriendsList()
        {

            var user = User.Identity.GetUserId();

            var alla = friendRepository.GetAll().Where(x => x.FriendFrom_Id == user && x.FriendStatus == FriendStatus.Approved);


            //var ownUser = User.Identity.GetUserId();

            //var userTo = friendRepository.GetAll().Where(x => x.FriendTo_Id == ownUser || x.FriendFrom_Id == ownUser);

            //var user = from a in userRepository.GetAll().Where(x => x.Id.Equals(userTo)) select a;





            //var userTo2 = friendRepository.GetAll().Where(x => x.FriendTo_Id == ownUser || x.FriendFrom_Id == ownUser);

            //var user2 = from a in userRepository.GetAll().Where(x => x.Id.Equals(userTo2)) select a;

            //var total = userTo.Concat(userTo2);

            return View(alla);
        }

        public ActionResult FriendRequests()
        {
            var ownUser = User.Identity.GetUserId();

            var userTo = friendRepository.GetAll().Where(x => x.FriendTo_Id == (ownUser)).Select(u => u.FriendFrom_Id);

            var user = from a in userRepository.GetAll().Where(x => x.Equals(userTo)) select a;


            return View(user.ToList());

            
        }

    }
}