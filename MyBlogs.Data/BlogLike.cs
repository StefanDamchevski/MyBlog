using System;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Data
{
    public class BlogLike
    {
        public int Id { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
