using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrueDating.Models
{
    public class ProfileViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Nickname")]
        public string Nickname { get; set; }
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
        [Display(Name = "Image")]
        public byte[] Image { get; set; }
        [Display (Name = "City")]
        public string City { get; set; }


    }

    public class PostViewModel
    {
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Reciever { get; set; }
        public List<PostInfoViewModel> Posts { get; set; }
    }

    public class PostInfoViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Text")]
        public string Text { get; set; }
        [Display(Name = "Sender")]
        public ApplicationUser Sender { get; set; }

        [Display(Name = "Reciever")]
        public ApplicationUser Reciever { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }
    }
}