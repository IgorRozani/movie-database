using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDatabase.Repository.Migrations
{
    public partial class FixReleaseDateType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReleaseDate",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
