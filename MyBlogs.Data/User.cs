﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Data
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        public List<BlogComment> BlogComments { get; set; }
        public List<BlogLike> BlogLikes { get; set; }
    }
}