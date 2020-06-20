using MyBlog.Data;
using MyBlog.Repository.Interfaces;
using MyBlog.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace MyBlog.Service
{
    public class BlogCommentService : IBlogCommentService
    {
        private IBlogCommentRepository BlogCommentRepository { get; set; }
        public BlogCommentService(IBlogCommentRepository blogCommentRepository)
        {
            BlogCommentRepository = blogCommentRepository;
        }
        public void Add(string comment, int blogId, int userId)
        {
            BlogComment blogComment = new BlogComment() 
            {
                Comment = comment,
                DateCreated = DateTime.Now,
                UserId = userId,
                BlogId = blogId,
                IsApproved = false,
            };
            BlogCommentRepository.Add(blogComment);
        }

        public List<BlogComment> GetAll()
        {
            return BlogCommentRepository.GetAll();
        }

        public void Approve(int id)
        {
            BlogComment blogComment = BlogCommentRepository.GetById(id);
            blogComment.IsApproved = true;
            BlogCommentRepository.Update(blogComment);
        }

        public void Delete(int id)
        {
            BlogCommentRepository.Delete(id);
        }

        public BlogComment GetById(int id)
        {
            return BlogCommentRepository.GetById(id);
        }

        public void Update(int id, string comment)
        {
            BlogComment blogComment = BlogCommentRepository.GetById(id);
            blogComment.Comment = comment;
            BlogCommentRepository.Update(blogComment);
        }
    }
}
