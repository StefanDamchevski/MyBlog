using MyBlog.Service.Dto;

namespace MyBlog.ViewModels
{
    public class OverviewViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int DaysCreated { get; set; }
        public int Views { get; set; }
        public bool IsApproved { get; set; }
        public SidebarData SidebarData { get; set; }
    }
}