using System.ComponentModel.DataAnnotations;

namespace MyBlog.ViewModels
{
    public class ModifyCommentModel
    {
        public int Id { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}