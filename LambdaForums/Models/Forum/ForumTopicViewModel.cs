using System.Collections.Generic;
using LambdaForums.Models.Post;

namespace LambdaForums.Models.Forum
{
    public class ForumTopicViewModel
    {
        public ForumListingViewModel Forum { get; set; }
        public IEnumerable<PostListingViewModel> Posts { get; set; }

    }
}
