using System;

namespace MyBlog.ViewModels
{
    public class BlogCommentModel
    {
        public string Comment { get; set; }
        public string Username { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsApproved { get; set; }
    }
}
