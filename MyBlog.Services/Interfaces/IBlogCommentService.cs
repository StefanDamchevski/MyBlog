using MyBlog.Data;
using System.Collections.Generic;

namespace MyBlog.Service.Interfaces
{
    public interface IBlogCommentService
    {
        void Add(string comment, int blogId, int userId);
        List<BlogComment> GetAll();
        void Approve(int id);
        void Delete(int id);
        BlogComment GetById(int id);
        void Update(int id, string comment);
    }
}
