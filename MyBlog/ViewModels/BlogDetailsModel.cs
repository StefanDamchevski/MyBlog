using MyBlog.Service.Dto;
using System;
using System.Collections.Generic;

namespace MyBlog.ViewModels
{
    public class BlogDetailsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? DateCreated { get; set; }
        public int Views { get; set; }
        public List<BlogCommentModel> BlogComments { get; set; }
        public SidebarData SidebarData { get; set; }
        public List<BlogLikeModel> BlogLikes { get; set; }
        public BlogLikeStatus LikeStatus { get; set; }
    }
}