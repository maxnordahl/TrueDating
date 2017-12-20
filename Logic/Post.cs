namespace Logic
{
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual ApplicationUser From { get; set; }
        public virtual ApplicationUser To { get; set; }
    }
}