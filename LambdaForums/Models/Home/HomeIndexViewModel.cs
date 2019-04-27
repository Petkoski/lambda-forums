using System.Collections.Generic;
using LambdaForums.Models.Post;

namespace LambdaForums.Models.Home
{
    public class HomeIndexViewModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<PostListingViewModel> LatestPosts { get; set; }
    }
}
