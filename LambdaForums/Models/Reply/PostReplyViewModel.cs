using System;

namespace LambdaForums.Models.Reply
{
    public class PostReplyViewModel
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }
        public int AuthorRating { get; set; }
        public DateTime DateCreated { get; set; }
        public string ReplyContent { get; set; }

        public int PostId { get; set; }
    }
}
