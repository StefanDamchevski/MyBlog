using System;
using System.ComponentModel.DataAnnotations;

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
        public virtual Blog Blog { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [Required]
        public bool IsApproved { get; set; }
    }
}