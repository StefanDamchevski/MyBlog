using System;

namespace MyBlog.ViewModels
{
    public class BlogModifyModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? DateCreated { get; set; }
        public int Views { get; set; }
    }
}
