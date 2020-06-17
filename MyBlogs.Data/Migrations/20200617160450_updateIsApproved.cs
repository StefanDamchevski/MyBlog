﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.Data.Migrations
{
    public partial class updateIsApproved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Blogs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "BlogComments",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "BlogComments");
        }
    }
}
