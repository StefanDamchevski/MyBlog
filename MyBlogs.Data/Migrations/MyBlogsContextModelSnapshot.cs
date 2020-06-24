﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBlog.Data;

namespace MyBlog.Data.Migrations
{
    [DbContext(typeof(MyBlogsContext))]
    partial class MyBlogsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyBlog.Data.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<bool>("IsApproved");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("Views");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("MyBlog.Data.BlogComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogId");

                    b.Property<string>("Comment")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated");

                    b.Property<bool>("IsApproved");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("UserId");

                    b.ToTable("BlogComments");
                });

            modelBuilder.Entity("MyBlog.Data.BlogLike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<bool>("Status");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("UserId");

                    b.ToTable("BlogLikes");
                });

            modelBuilder.Entity("MyBlog.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyBlog.Data.BlogComment", b =>
                {
                    b.HasOne("MyBlog.Data.Blog", "Blog")
                        .WithMany("BlogComments")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyBlog.Data.User", "User")
                        .WithMany("BlogComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyBlog.Data.BlogLike", b =>
                {
                    b.HasOne("MyBlog.Data.Blog", "Blog")
                        .WithMany("BlogLikes")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyBlog.Data.User", "User")
                        .WithMany("BlogLikes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
