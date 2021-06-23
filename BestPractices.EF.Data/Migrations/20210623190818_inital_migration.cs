using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BestPractices.EF.Data.Migrations
{
    public partial class inital_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    TeacherRank = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    StudentRank = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "StudentRank", "TeacherId" },
                values: new object[] { new Guid("b5303b5b-2be8-4c65-bb43-92b0bafdd006"), "Bob", 1, null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "StudentRank", "TeacherId" },
                values: new object[] { new Guid("a002720c-8828-46b4-ba61-1d633c2610eb"), "Alice", 2, null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "StudentRank", "TeacherId" },
                values: new object[] { new Guid("e5494a6c-3d81-4e8e-948e-286c36f16e92"), "Jack", 3, null });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name", "TeacherRank" },
                values: new object[] { new Guid("e98287b2-4f0b-4aad-a907-0f86615016ca"), "MrBob", 1 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name", "TeacherRank" },
                values: new object[] { new Guid("677a15d9-ce06-43a1-8e29-ac273b130e34"), "MrsAlice", 2 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name", "TeacherRank" },
                values: new object[] { new Guid("cb3456a7-e71f-4b33-b3ef-8f68f0d77753"), "MrJack", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeacherId",
                table: "Students",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
