using System.Diagnostics;
using System.Linq;
using LambdaForums.Data;
using LambdaForums.Data.Models;
using Microsoft.AspNetCore.Mvc;
using LambdaForums.Models;
using LambdaForums.Models.Forum;
using LambdaForums.Models.Home;
using LambdaForums.Models.Post;

namespace LambdaForums.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPost _postService;

        public HomeController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            var model = BuildHomeIndexViewModel();
            return View(model);
        }

        private HomeIndexViewModel BuildHomeIndexViewModel()
        {
            var latestPosts = _postService.GetLatestPosts(5);

            var posts = latestPosts.Select(post => new PostListingViewModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorName = post.User.UserName,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = GetForumListingForPost(post)
            });

            return new HomeIndexViewModel
            {
                LatestPosts = posts,
                SearchQuery = ""
            };
        }

        private ForumListingViewModel GetForumListingForPost(Post post)
        {
            var forum = post.Forum;

            return new ForumListingViewModel
            {
                Id = forum.Id,
                Title = forum.Title,
                ImageUrl  = forum.ImageUrl
            };
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
