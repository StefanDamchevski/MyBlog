using System.ComponentModel.DataAnnotations;

namespace MyBlog.ViewModels
{
    public class ModifyUserModel
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
    }
}
