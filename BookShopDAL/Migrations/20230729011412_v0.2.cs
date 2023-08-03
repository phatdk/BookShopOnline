using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShopDAL.Migrations
{
    public partial class v02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Brand_Id_Brand",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Author_Id_Parents",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Publisher_Id_Parents",
                table: "Image");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Book_Id_Brand",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "Birth",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Author");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Publisher",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Author",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Birth",
                table: "Author",
                type: "varchar(13)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Author",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_Id_Brand",
                table: "Book",
                column: "Id_Brand");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Brand_Id_Brand",
                table: "Book",
                column: "Id_Brand",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Author_Id_Parents",
                table: "Image",
                column: "Id_Parents",
                principalTable: "Author",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Publisher_Id_Parents",
                table: "Image",
                column: "Id_Parents",
                principalTable: "Publisher",
                principalColumn: "Id");
        }
    }
}
