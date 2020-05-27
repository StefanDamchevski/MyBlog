using MyBlog.Models;
using MyBlog.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyBlog.Repository
{
    public class BlogRepository : IBlogRepository
    {
        public void Add(Blog blog)
        {
            blog.Date = DateTime.Now;

            using (var cnn = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = MyBlogs; Integrated Security = true"))
            {
                cnn.Open();

                var query = @"Insert into Blogs (Title, ImageUrl, Description, Date)
                                values(@Title, @ImageUrl, @Description, @Date)";

                var command = new SqlCommand(query, cnn);

                command.Parameters.AddWithValue("@Title", blog.Title);
                command.Parameters.AddWithValue("@ImageUrl", blog.ImageUrl);
                command.Parameters.AddWithValue("@Description", blog.Description);
                command.Parameters.AddWithValue("@Date", blog.Date);

                command.ExecuteNonQuery();
            }
        }
        public List<Blog> GetAll()
        {
            var result = new List<Blog>();
            using (var cnn = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = MyBlogs; Integrated Security = true"))
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
                    blog.Date = reader.GetDateTime(4);

                    result.Add(blog);
                }
            }
            return result;
        }
        public Blog GetById(int id)
        {
            Blog result = null;
            using (var cnn = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = MyBlogs; Integrated Security = true"))
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
                    result.Date = reader.GetDateTime(4);
                }
            }
            return result;
        }
        public List<Blog> GetByTitle(string title)
        {
            var result = new List<Blog>();

            using (var cnn = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = MyBlogs; Integrated Security = true"))
            {
                cnn.Open();

                var query = "SELECT * FROM Blogs";

                if (!string.IsNullOrEmpty(title))
                {
                    query = $"{query} where Title like @title";
                }

                var command = new SqlCommand(query, cnn);

                if (!string.IsNullOrEmpty(title))
                {
                    command.Parameters.AddWithValue("@title", $"%{title}%");
                }

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var blog = new Blog();

                    blog.Id = reader.GetInt32(0);
                    blog.Title = reader.GetString(1);
                    blog.ImageUrl = reader.GetString(2);
                    blog.Description = reader.GetString(3);
                    blog.Date = reader.GetDateTime(4);

                    result.Add(blog);
                }
            }
            return result;
        }
    }
}