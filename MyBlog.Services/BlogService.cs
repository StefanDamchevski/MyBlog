using MyBlog.Data;
using MyBlog.Repository.Interfaces;
using MyBlog.Service.Dto;
using MyBlog.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Services
{
    public class BlogService : IBlogService
    {
        private IBlogRepository BlogRepository { get; set; }
        public BlogService(IBlogRepository blogRepository)
        {
            BlogRepository = blogRepository;
        }
        public void Add(Blog blog)
        {
            blog.IsApproved = false;
            BlogRepository.Add(blog);
        }
        public List<Blog> GetByTitle(string title)
        {
           return BlogRepository.GetByTitle(title);
        }
        public Blog GetById(int id)
        {
            return BlogRepository.GetById(id);
        }
        public List<Blog> GetAll()
        {
            return BlogRepository.GetAll();
        }
        public Blog GetBlogDetails(int id)
        {
            Blog blog = BlogRepository.GetById(id);
            blog.Views += 1;
            BlogRepository.Update(blog);
            return blog;
        }
        public void Delete(int id)
        {
            BlogRepository.Delete(id);
        }

        public void UpdateBlog(Blog blog)
        {
            BlogRepository.Update(blog);
        }

        public void Approve(int id)
        {
            Blog blog = BlogRepository.GetById(id);
            blog.IsApproved = true;
            BlogRepository.Update(blog);
        }
        public SidebarData GetSidebarData()
        {
            List<Blog> blogs = BlogRepository.GetAll();

            List<SidebarBlog> topBlogs = GetTopBlogs(blogs);

            List<SidebarBlog> recentBlogs = GetRecentBlogs(blogs);

            SidebarData sidebarData = AddToSidebarData(topBlogs, recentBlogs);

            return sidebarData;
        }
        //Add Top and Recent Blogs To SidebarData
        private SidebarData AddToSidebarData(List<SidebarBlog> topBlogs, List<SidebarBlog> recentBlogs)
        {
            SidebarData sidebarData = new SidebarData();
            sidebarData.RecentBlogs = recentBlogs;
            sidebarData.TopBlogs = topBlogs;
            return sidebarData;
        }
        //GetTopBlogs
        private static List<SidebarBlog> GetTopBlogs(List<Blog> blogs)
        {
            return blogs.OrderByDescending(x => x.Views)
                .Take(5)
                .Select(x => new SidebarBlog
                {
                    Id = x.Id,
                    Views = x.Views,
                    Title = x.Title,
                    DateCreated = x.DateCreated,
                    IsApproved = x.IsApproved,
                })
                .ToList();
        }
        //GetRecentBlogs
        private static List<SidebarBlog> GetRecentBlogs(List<Blog> blogs)
        {
            return blogs.OrderByDescending(x => x.DateCreated)
                .Take(5)
                .Select(x => new SidebarBlog
                {
                    Id = x.Id,
                    Views = x.Views,
                    Title = x.Title,
                    DateCreated = x.DateCreated,
                    IsApproved = x.IsApproved,
                })
                .ToList();
        }
    }
}