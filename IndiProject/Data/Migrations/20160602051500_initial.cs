using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndiProject.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Albums",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ApplicationUserId",
                table: "Albums",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_AspNetUsers_ApplicationUserId",
                table: "Albums",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_AspNetUsers_ApplicationUserId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ApplicationUserId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Albums");
        }
    }
}
