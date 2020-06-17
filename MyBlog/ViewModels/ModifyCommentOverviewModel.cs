namespace MyBlog.ViewModels
{
    public class ModifyCommentOverviewModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string Username { get; set; }
        public bool IsApproved { get; set; }
    }
}