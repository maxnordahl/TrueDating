using System;
using Logic;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TrueDating.Controllers
{
    public class UsersController : BaseController
    {
        public async Task<ActionResult> Index(String searchString)
        {
            //var users = db.Users.ToList();
            var users = from u in db.Users
                        select u;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.Nickname.Contains(searchString));
            }

            return View(await users.ToListAsync());
            //return View(users);
        }

       
    }
}