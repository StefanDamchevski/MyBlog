using MyBlog.Service.Dto;
using System.Collections.Generic;

namespace MyBlog.ViewModels
{
    public class BlogOverviewData
    {
        public List<OverviewViewModel> BlogsOverview { get; set; }
        public SidebarData SidebarData { get; set; }
    }
}
