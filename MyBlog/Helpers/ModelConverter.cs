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
                IsApproved = blog.IsApproved,
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
                BlogLikes = blog.BlogLikes
                                .Select(x => ConvertToBlogLikesModel(x))
                                .ToList(),
            };
        }

        private static BlogLikeModel ConvertToBlogLikesModel(BlogLike x)
        {
            return new BlogLikeModel
            {
                Id = x.Id,
                Status = x.Status,
                BlogId = x.BlogId,
                UserId = x.UserId,
            };
        }

        public static BlogCommentModel ConvertToBlogCommentModel(BlogComment blogComment)
        {
            return new BlogCommentModel
            {
                Comment = blogComment.Comment,
                DateCreated = blogComment.DateCreated,
                Username = blogComment.User.Username,
                IsApproved = blogComment.IsApproved,
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
                IsApproved = blog.IsApproved,
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
                IsAdmin = user.IsAdmin,
            };
        }
        public static ModifyUserModel ConvertToModifyUserModel(User user)
        {
            return new ModifyUserModel
            {
                Id = user.Id,
                Username = user.Username,
                IsAdmin = user.IsAdmin,
            };
        }
        public static UserDetailsModel ConvertToUserDetailsModel(User user)
        {
            return new UserDetailsModel
            {
                Id = user.Id,
                Username = user.Username,
                IsAdmin = user.IsAdmin,
            };
        }
        public static ModifyCommentOverviewModel ConvertToModifyCommentOverviewModel(BlogComment blogComment)
        {
            return new ModifyCommentOverviewModel
            {
                Id = blogComment.Id,
                Comment = blogComment.Comment,
                Username = blogComment.User.Username,
                IsApproved = blogComment.IsApproved,
            };
        }
        public static ModifyCommentModel ConvertToModifyCommentModel(BlogComment blogComment)
        {
            return new ModifyCommentModel
            {
                Id = blogComment.Id,
                Comment = blogComment.Comment,
            };
        }
    }
}