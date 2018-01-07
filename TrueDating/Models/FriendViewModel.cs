using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrueDating.Models
{
    public class FriendViewModel
    {
        public string Nickname { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public Gender Gender { get; set; }
        public IEnumerable<Gender> GenderList { get; set; }
        public byte[] Photo { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}