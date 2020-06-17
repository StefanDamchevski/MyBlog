using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Repository
{
    public class BlogCommentRepository : IBlogCommentRepository
    {
        public MyBlogsContext Context { get; set; }
        public BlogCommentRepository(MyBlogsContext context)
        {
            Context = context;
        }

        public void Add(BlogComment blogComment)
        {
            Context.BlogComments.Add(blogComment);
            Context.SaveChanges();
        }

        public List<BlogComment> GetAll()
        {
            return Context.BlogComments
                .Include(x => x.User)
                .Include(x => x.Blog)
                .ToList();
        }

        public BlogComment GetById(int id)
        {
            return Context.BlogComments
                .Include(x => x.User)
                .Include(x => x.Blog)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(BlogComment blogComment)
        {
            Context.BlogComments.Update(blogComment);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            BlogComment blogComment = new BlogComment()
            {
                Id = id,
            };

            Context.BlogComments.Remove(blogComment);
            Context.SaveChanges();
        }
    }
}