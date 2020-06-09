using MyBlog.Data;
using MyBlog.ViewModels;
using System;
using System.Linq;

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
                BlogComments = blog.BlogComments
                                .Select(x => ConvertToBlogCommentModel(x))
                                .ToList(),
            };
        }
        public static BlogCommentModel ConvertToBlogCommentModel(BlogComment blogComment)
        {
            return new BlogCommentModel
            {
                Comment = blogComment.Comment,
                DateCreated = blogComment.DateCreated,
                Username = blogComment.User.Username,
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
        public static ModifyUsersOverviewModel ConvertToModifyUsersOverviewModel(User user)
        {
            return new ModifyUsersOverviewModel
            {
                Id = user.Id,
                Username = user.Username,
            };
        }
        public static ModifyUserModel ConvertToModifyUserModel(User user)
        {
            return new ModifyUserModel
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                RepeatPassword = user.Password,
            };
        }
        public static User ConvertFromModifyUserModel(ModifyUserModel modifyUserModel)
        {
            return new User
            {
                Id = modifyUserModel.Id,
                Username = modifyUserModel.Username,
                Password = modifyUserModel.Password,
            };
        }
    }
}