using MyBlog.Data;
using System.Collections.Generic;

namespace MyBlog.Repository.Interfaces
{
    public interface IBlogCommentRepository
    {
        void Add(BlogComment blogComment);
        List<BlogComment> GetAll();
        BlogComment GetById(int id);
        void Update(BlogComment blogComment);
        void Delete(int id);
    }
}
