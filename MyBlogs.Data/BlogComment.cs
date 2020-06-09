using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBlog.Data
{
    public class BlogComment
    {
        public int Id { get; set; }
        [Required]
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }

        [Required]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
