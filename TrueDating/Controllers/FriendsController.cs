using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrueDating.Controllers
{
    public class FriendsController : BaseController
    {
        // GET: Friends
        public ActionResult Index(string id)
        {
            var user = db.Users.Where(x => x.Id == id);

            return View();
        }
    }
}