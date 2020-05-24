using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBlog.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [MaxLength (200)]
        public string ImageUrl { get; set; }
        [Required]
        [MaxLength (5000)]
        public string Text { get; set; }
    }
}
