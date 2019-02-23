using System.Collections.Generic;
using System.Linq;
using LambdaForums.Data;
using LambdaForums.Data.Models;
using LambdaForums.Models.Forum;
using Microsoft.AspNetCore.Mvc;

namespace LambdaForums.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        private readonly IPost _postService;

        public ForumController(IForum forumService)
        {
            _forumService = forumService;
        }

        public IActionResult Index()
        {
            IEnumerable<ForumListingViewModel> forums = _forumService.GetAll()
                .Select(forum => new ForumListingViewModel {
                    Id = forum.Id,
                    Title = forum.Title,
                    Description = forum.Description
            });

            var model = new ForumIndexViewModel
            {
                ForumList = forums
            };

            return View(model);
        }

        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetById(id);
            //var posts = _postService.GetFilteredPosts(id)

            var postListings = 
        }
    }
}