using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddReadlists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Readlists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readlists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReadlistItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReadlistId = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadlistItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadlistItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReadlistItems_Readlists_ReadlistId",
                        column: x => x.ReadlistId,
                        principalTable: "Readlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReadlistItems_BookId",
                table: "ReadlistItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadlistItems_ReadlistId",
                table: "ReadlistItems",
                column: "ReadlistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReadlistItems");

            migrationBuilder.DropTable(
                name: "Readlists");
        }
    }
}
