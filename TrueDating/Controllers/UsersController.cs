using System;
using Logic;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrueDating.Controllers
{
    public class UsersController : BaseController
    {
        public ActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
        }
    }
}