using MyBlog.Data;
using MyBlog.Service.Dto;
using System.Collections.Generic;

namespace MyBlog.Service.Interfaces
{
    public interface IBlogService
    {
        List<Blog> GetAll();
        Blog GetById(int id);
        void Add(Blog blog);
        List<Blog> GetByTitle(string title);
        Blog GetBlogDetails(int id);
        void Delete(int id);
        void UpdateBlog(Blog blog);
        void Approve(int id);
        SidebarData GetSidebarData();
    }
}
