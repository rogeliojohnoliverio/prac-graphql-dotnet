﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practicegraphql.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentGrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("7841bc1b-cb1a-4db6-aaf7-bbed27c2ed49"),
                column: "Grade",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Students");
        }
    }
}
