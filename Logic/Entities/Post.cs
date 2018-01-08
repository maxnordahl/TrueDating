using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic
{
    public class Post : IEntity<int>
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("From")]
        public virtual string From_Id { get; set; }
        public virtual ApplicationUser From { get; set; }

        [ForeignKey("To")]
        public virtual string To_Id { get; set; }
        public virtual ApplicationUser To { get; set; }
    }
}