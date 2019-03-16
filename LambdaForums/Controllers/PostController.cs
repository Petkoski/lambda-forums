using System.Collections.Generic;
using System.Linq;
using LambdaForums.Data;
using LambdaForums.Data.Models;
using LambdaForums.Models.Post;
using LambdaForums.Models.Reply;
using Microsoft.AspNetCore.Mvc;

namespace LambdaForums.Controllers
{
    public class PostController : Controller
    {
        //Creating a constructor, so we can use DEPENDENCY INJECTION to pass-in our services to our PostController.
        private readonly IPost _postService; //private readonly field to store our PostService
        public PostController(IPost postService)
        {
            _postService = postService; //Assign the private field in our constructor.
        }

        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);
            var replies = BuildPostReplies(post.Replies);

            var model = new PostIndexViewModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorImageUrl = post.User.ProfileImageUrl,
                AuthorRating = post.User.Rating,
                DateCreated = post.Created,
                PostContent = post.Content,
                Replies = replies
            };

            return View(model);
        }

        private IEnumerable<PostReplyViewModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyViewModel
            {
                Id = reply.Id,
                AuthorName = reply.User.UserName,
                AuthorId = reply.User.Id,
                AuthorRating = reply.User.Rating,
                AuthorImageUrl = reply.User.ProfileImageUrl,
                DateCreated = reply.Created,
                ReplyContent = reply.Content
            });
        }
    }
}