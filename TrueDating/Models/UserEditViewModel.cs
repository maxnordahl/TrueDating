using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logic;

namespace TrueDating.Models
{
    public class UserEditViewModel
    {
        public string Id { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public byte[] Photo { get; set; }
        public Visibility Visibility { get; set; }
    }
}