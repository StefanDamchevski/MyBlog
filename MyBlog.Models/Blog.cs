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
        [MaxLength (200)]
        public string Title { get; set; }
        [Required]
        [MaxLength (5000)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public int ResizeString()
        {
            if (Title.Length > 150 && Title.Length <= 200)
            {
                return Title.Length / 4;
            }
            else if(Title.Length > 100 && Title.Length <= 150)
            {
                return Title.Length / 2;
            }
            else
            {
                return Title.Length;
            }
        }
    }
}
