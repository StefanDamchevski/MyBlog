using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Data
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCreated { get; set; }
        public int Views { get; set; }
        public List<BlogComment> BlogComments { get; set; }
        [Required]
        public bool IsApproved { get; set; }
        public List<BlogLike> BlogLikes { get; set; }
    }
}
