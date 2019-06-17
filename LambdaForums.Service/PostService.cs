using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LambdaForums.Data;
using LambdaForums.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LambdaForums.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Post GetById(int id)
        {
            return _context.Posts.Where(post => post.Id == id)
                .Include(post => post.User)
                .Include(post => post.Replies).ThenInclude(reply => reply.User)
                .Include(post => post.Forum)
                .First();
            //throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts
                .Include(post => post.User)
                .Include(post => post.Replies).ThenInclude(reply => reply.User)
                .Include(post => post.Forum);
        }

        public IEnumerable<Post> GetFilteredPosts(Forum forum, string searchQuery)
        {
            //Tutorial implementation:
            //return String.IsNullOrEmpty(searchQuery) 
            //    ? forum.Posts
            //    : forum.Posts.Where(post 
            //        => post.Title.Contains(searchQuery) 
            //        || post.Content.Contains(searchQuery));

            //My:
            return String.IsNullOrEmpty(searchQuery)
                ? forum.Posts
                : forum.Posts.Where(post
                    => post.Title.ToLower().Contains(searchQuery.ToLower())
                       || post.Content.ToLower().Contains(searchQuery.ToLower()));
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            return GetAll().Where(post 
                => post.Title.ToLower().Contains(searchQuery.ToLower()) 
                || post.Content.ToLower().Contains(searchQuery.ToLower()));
        }

        public IEnumerable<Post> GetPostsByForum(int id)
        {
            //Return all posts from a specific forum
            return _context.Forums
                .First(forum => forum.Id == id).Posts;
        }

        public IEnumerable<Post> GetLatestPosts(int postsNumber)
        {
            return GetAll().OrderByDescending(post => post.Created).Take(postsNumber);
        }

        public async Task Add(Post post)
        {
            //_context.Add(post); //This line was used in the tutorial.
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public Task AddReply(PostReply reply)
        {
            throw new NotImplementedException();
        }
    }
}
