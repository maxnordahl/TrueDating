using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Logic
{
    public class Friends : IEntity<int>
    {
        public int Id { get; set; }

        [ForeignKey("FriendFrom")]
        public virtual string FriendFrom_Id { get; set; }
        public virtual ApplicationUser FriendFrom { get; set; }

        [ForeignKey("FriendTo")]
        public virtual string FriendTo_Id { get; set; }
        public virtual ApplicationUser FriendTo { get; set; }

        public FriendStatus FriendStatus { get; set;}

    }

    public enum FriendStatus
    {
        Pending,
        Approved
    }
}
