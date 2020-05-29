using MyBlog.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Service.Interfaces
{
    public interface IBlogService
    {
        List<Blog> GetAll();
        Blog GetById(int id);
        void Add(Blog blog);
        List<Blog> GetByTitle(string title);
        Blog GetBlogDetails(int id);
    }
}
