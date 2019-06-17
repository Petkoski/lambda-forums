using System.Collections.Generic;
using LambdaForums.Models.Post;

namespace LambdaForums.Models.Search
{
    public class SearchResultViewModel
    {
        public IEnumerable<PostListingViewModel> Posts { get; set; }
        public string SearchQuery { get; set; }
        public bool EmptySearchResults { get; set; }
    }
}
