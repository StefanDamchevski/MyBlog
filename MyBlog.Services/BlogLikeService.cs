using MyBlog.Data;
using MyBlog.Repository.Interfaces;
using MyBlog.Service.Interfaces;
using System;

namespace MyBlog.Service
{
    public class BlogLikeService : IBlogLikeService
    {
        private IBlogLikeRepository BlogLikeRepository { get; set; }
        public BlogLikeService(IBlogLikeRepository blogLikeRepository)
        {
            BlogLikeRepository = blogLikeRepository;
        }
        public void AddLike(int blogId, int userId)
        {
            BlogLike like = BlogLikeRepository.Get(blogId, userId);
            if(like == null)
            {
                BlogLike blogLike = CreateNewLike(blogId, userId);
                BlogLikeRepository.Add(blogLike);
            }
            else
            {
                like.Status = true;
                BlogLikeRepository.Update(like);
            }
        }

        private static BlogLike CreateNewLike(int blogId, int userId)
        {
            BlogLike blogLike = new BlogLike();
            blogLike.Status = true;
            blogLike.UserId = userId;
            blogLike.BlogId = blogId;
            blogLike.DateCreated = DateTime.Now;
            return blogLike;
        }

        public void RemoveLike(int blogId, int userId)
        {
            BlogLike blogLike = BlogLikeRepository.Get(blogId, userId);
            BlogLikeRepository.Remove(blogLike);
        }

        public void AddDislike(int blogId, int userId)
        {
            BlogLike dislike = BlogLikeRepository.Get(blogId, userId);
            if(dislike == null)
            {
                BlogLike blogLike = CreateNewDislike(blogId, userId);
                BlogLikeRepository.Add(blogLike);
            }
            else
            {
                dislike.Status = false;
                BlogLikeRepository.Update(dislike);
            }
        }

        private BlogLike CreateNewDislike(int blogId, int userId)
        {
            BlogLike blogLike = new BlogLike();
            blogLike.Status = false;
            blogLike.UserId = userId;
            blogLike.BlogId = blogId;
            blogLike.DateCreated = DateTime.Now;
            return blogLike;
        }
    }
}