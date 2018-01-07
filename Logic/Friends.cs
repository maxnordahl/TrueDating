using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Logic
{
    public class Friends : IdentityUser
    {
        public string id { get; set; }
        public ApplicationUser Friend { get; set; }
        public ApplicationUser Friend1 { get; set; }
    }

    public class FriendRequest : IdentityUser
    {
        public string id { get; set; }
        public ApplicationUser From { get; set; }
        public ApplicationUser To { get; set; }
    }
}
