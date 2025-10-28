using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateFKShipingPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_TbShipments_ShipingPackgingId",
                table: "TbShipments",
                column: "ShipingPackgingId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbShipments_TbShipingPackges_ShipingPackgingId",
                table: "TbShipments",
                column: "ShipingPackgingId",
                principalTable: "TbShipingPackges",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbShipments_TbShipingPackges_ShipingPackgingId",
                table: "TbShipments");

            migrationBuilder.DropIndex(
                name: "IX_TbShipments_ShipingPackgingId",
                table: "TbShipments");
        }
    }
}
