using MyBlog.Data;

namespace MyBlog.Repository.Interfaces
{
    public interface IUserRepository
    {
        User GetByUsername(string username);
    }
}
