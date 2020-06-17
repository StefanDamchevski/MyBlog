using System.Collections.Generic;

namespace MyBlog.Service.Dto
{
    public class SidebarData
    {
        public List<SidebarBlog> TopBlogs { get; set; }
        public List<SidebarBlog> RecentBlogs { get; set; }
    }
}