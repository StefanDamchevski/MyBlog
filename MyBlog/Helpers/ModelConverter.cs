using MyBlog.Data;
using MyBlog.ViewModels;
using System;

namespace MyBlog.Helpers
{
    public static class ModelConverter
    {
        public static OverviewViewModel OverviewModelConvert(Blog blog)
        {
            return new OverviewViewModel
            {
                Id = blog.Id,
                Title = blog.Title,
                ImageUrl = blog.ImageUrl,
                Views = blog.Views,
                DaysCreated = DateTime.Now.Subtract(blog.DateCreated.Value).Days,
            };
        }
        public static BlogDetailsModel ConvertToDetailsModel(Blog blog)
        {
            return new BlogDetailsModel
            {
                Id = blog.Id,
                Title = blog.Title,
                ImageUrl = blog.ImageUrl,
                Description = blog.Description,
                Views = blog.Views,
                DateCreated = blog.DateCreated,
            };
        }
        public static Blog ConvertFromBlogCreateModel(BlogCreateModel blogCreate)
        {
            return new Blog
            {
                Title = blogCreate.Title,
                ImageUrl = blogCreate.ImageUrl,
                Description = blogCreate.Description,
            };
        }
        public static ModifyOverviewModel ConvertToModifyOverviewModel(Blog blog)
        {
            return new ModifyOverviewModel
            {
                Id = blog.Id,
                Title = blog.Title,
            };
        }
        public static BlogModifyModel ConvertToBlogModifyModel(Blog blog)
        {
            return new BlogModifyModel
            {
                Id = blog.Id,
                Title = blog.Title,
                ImageUrl = blog.ImageUrl,
                Description = blog.Description,
                Views = blog.Views,
                DateCreated = blog.DateCreated,
            };
        }
        public static Blog ConvertFromBlogModifyModel(BlogModifyModel blogModify)
        {
            return new Blog
            {
                Id = blogModify.Id,
                Title = blogModify.Title,
                ImageUrl = blogModify.ImageUrl,
                Description = blogModify.Description,
                Views = blogModify.Views,
                DateCreated = blogModify.DateCreated,
            };
        }
    }
}