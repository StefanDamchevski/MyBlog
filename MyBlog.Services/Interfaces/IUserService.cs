using MyBlog.Data;
using MyBlog.Service.Dto;
using System.Collections.Generic;

namespace MyBlog.Service.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        void Delete(int id);
        User GetById(int id);
        Response UpdateUser(int id, string username);
        Response Create(string username, string password);
        void GiveAdminRole(int id);
        void RemoveAdminRole(int id);
        void ChangePassword(int id, string password);
    }
}
