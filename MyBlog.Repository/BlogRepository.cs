using MyBlog.Models;
using MyBlog.Repository.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyBlog.Repository
{
    public class BlogRepository : IBlogRepository
    {
        public void Add(Blog blog)
        {
            using (var cnn = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = MyBlog; Integrated Security = true"))
            {
                cnn.Open();

                var query = @"Insert into Blogs (Title, ImageUrl, Description, Text)
                                values(@Title, @ImageUrl, @Description, @Text)";

                var command = new SqlCommand(query, cnn);

                command.Parameters.AddWithValue("@Title", blog.Title);
                command.Parameters.AddWithValue("@ImageUrl", blog.ImageUrl);
                command.Parameters.AddWithValue("@Description", blog.Description);
                command.Parameters.AddWithValue("@Text", blog.Text);

                command.ExecuteNonQuery();
            }
        }
        public List<Blog> GetAll()
        {
            var result = new List<Blog>();
            using (var cnn = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = MyBlog; Integrated Security = true"))
            {
                cnn.Open();

                var query = "SELECT * FROM Blogs";

                var command = new SqlCommand(query, cnn);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var blog = new Blog();

                    blog.Id = reader.GetInt32(0);
                    blog.Title = reader.GetString(1);
                    blog.ImageUrl = reader.GetString(2);
                    blog.Description = reader.GetString(3);
                    blog.Text = reader.GetString(4);

                    result.Add(blog);
                }
            }
            return result;
        }
        public Blog GetById(int id)
        {
            Blog result = null;
            using (var cnn = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = MyBlog; Integrated Security = true"))
            {
                cnn.Open();

                var query = "SELECT * FROM Blogs where id = @Id";

                var command = new SqlCommand(query, cnn);

                command.Parameters.AddWithValue("@Id", id);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = new Blog();

                    result.Id = reader.GetInt32(0);
                    result.Title = reader.GetString(1);
                    result.ImageUrl = reader.GetString(2);
                    result.Description = reader.GetString(3);
                    result.Text = reader.GetString(4);
                }
            }
            return result;
        }
    }
}