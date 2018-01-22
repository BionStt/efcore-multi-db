using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MultiDb.Two.Migrations
{
    public partial class navproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserLecture_UserId",
                table: "UserLecture",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLecture_User_UserId",
                table: "UserLecture",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLecture_User_UserId",
                table: "UserLecture");

            migrationBuilder.DropIndex(
                name: "IX_UserLecture_UserId",
                table: "UserLecture");
        }
    }
}
