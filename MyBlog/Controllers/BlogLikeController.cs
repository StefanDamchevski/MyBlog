using Microsoft.AspNetCore.Mvc;
using MyBlog.Service.Interfaces;
using MyBlog.ViewModels;
using System;

namespace MyBlog.Controllers
{
    public class BlogLikeController : Controller
    {
        private IBlogLikeService BlogLikeService { get; set; }
        public BlogLikeController(IBlogLikeService blogLikeService)
        {
            BlogLikeService = blogLikeService;
        }
        public IActionResult AddLike([FromBody] LikeRequestModel model)
        {
            int userId = Convert.ToInt32(User.FindFirst("Id").Value);
            BlogLikeService.AddLike(model.Id, userId);
            return Ok();
        }

        public IActionResult RemoveLike([FromBody] LikeRequestModel model)
        {
            int userId = Convert.ToInt32(User.FindFirst("Id").Value);
            BlogLikeService.RemoveLike(model.Id, userId);
            return Ok();
        }

        public IActionResult AddDislike([FromBody] LikeRequestModel model)
        {
            int userId = Convert.ToInt32(User.FindFirst("Id").Value);
            BlogLikeService.AddDislike(model.Id, userId);
            return Ok();
        }

        public IActionResult RemoveDislike([FromBody] LikeRequestModel model)
        {
            int userId = Convert.ToInt32(User.FindFirst("Id").Value);
            BlogLikeService.RemoveLike(model.Id, userId);
            return Ok();
        }
    }
}