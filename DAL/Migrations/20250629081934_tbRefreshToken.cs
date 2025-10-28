using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class tbRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "TbRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbRefreshTokens", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbRefreshTokens");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbSetting");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbSetting");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbSetting");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbSetting");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbSetting");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Log");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Log",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
