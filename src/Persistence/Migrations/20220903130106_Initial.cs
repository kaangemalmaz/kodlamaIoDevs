﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramingLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramingLanguages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProgramingLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Python" });

            migrationBuilder.InsertData(
                table: "ProgramingLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "C#" });

            migrationBuilder.InsertData(
                table: "ProgramingLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Java" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramingLanguages");
        }
    }
}
