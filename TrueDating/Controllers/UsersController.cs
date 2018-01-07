using System;
using Logic;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace TrueDating.Controllers
{
    public class UsersController : BaseController
    {
        public async Task<ActionResult> SearchForUser(string searchString)
        {
            
            var users = from u in db.Users
                        select u;

            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.Nickname.Contains(searchString) && s.Hidden == false);
            }

            return View(await users.ToListAsync());
            
        }

        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();

            if(Request.IsAuthenticated)
            {
                
                var postList = new PostsController().ListPosts(userID);
                var postText = new List<string[]>();

                foreach(Post post in postList)
                {
                    ApplicationUser userFrom = db.Users.Find(post.From.Id);
                    string name = userFrom.Nickname;
                    string[] textList = new string[3] { name, post.Text, post.Date.ToString() };
                    postText.Add(textList);
                }
                ViewBag.List = postText;
                var user = db.Users.Where(x => x.Id == userID).SingleOrDefault() as ApplicationUser;
                return View(user);
            }
            else
            {
                return RedirectToAction("Register", "Account");
            }

         }

        public ActionResult UserInformation()
        {
            var information = db.Users.ToList();
            return View(information);
        }
        


    }
}