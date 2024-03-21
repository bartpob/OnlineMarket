using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCattegoryPropertyToAnnouncementEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AnnouncementCategoryId",
                table: "Announcements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_AnnouncementCategoryId",
                table: "Announcements",
                column: "AnnouncementCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Categories_AnnouncementCategoryId",
                table: "Announcements",
                column: "AnnouncementCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Categories_AnnouncementCategoryId",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_AnnouncementCategoryId",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "AnnouncementCategoryId",
                table: "Announcements");
        }
    }
}
