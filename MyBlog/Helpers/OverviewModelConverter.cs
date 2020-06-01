using MyBlog.Data;
using MyBlog.ViewModels;
using System;

namespace MyBlog.Helpers
{
    public static class OverviewModelConverter
    {
        public static OverviewViewModel OverviewModelConvert(Blog blog)
        {
            var overviewModel = new OverviewViewModel
            {
                Id = blog.Id,
                Title = blog.Title,
                ImageUrl = blog.ImageUrl,
                Views = blog.Views,
                DaysCreated = DateTime.Now.Subtract(blog.DateCreated.Value).Days,
            };
            return overviewModel;
        }
    }
}
