using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSomeFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippimentCount",
                table: "TbSubscriptionPackages",
                newName: "ShipimentCount");

            migrationBuilder.RenameColumn(
                name: "ShippingTypeId",
                table: "TbShipments",
                newName: "ShipingTypeId");

            migrationBuilder.RenameColumn(
                name: "ShippingPackgingId",
                table: "TbShipments",
                newName: "ShipingPackgingId");

            migrationBuilder.RenameIndex(
                name: "IX_TbShipments_ShippingTypeId",
                table: "TbShipments",
                newName: "IX_TbShipments_ShipingTypeId");

            migrationBuilder.RenameColumn(
                name: "KilooGramRate",
                table: "TbSetting",
                newName: "KiloGramRate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShipimentCount",
                table: "TbSubscriptionPackages",
                newName: "ShippimentCount");

            migrationBuilder.RenameColumn(
                name: "ShipingTypeId",
                table: "TbShipments",
                newName: "ShippingTypeId");

            migrationBuilder.RenameColumn(
                name: "ShipingPackgingId",
                table: "TbShipments",
                newName: "ShippingPackgingId");

            migrationBuilder.RenameIndex(
                name: "IX_TbShipments_ShipingTypeId",
                table: "TbShipments",
                newName: "IX_TbShipments_ShippingTypeId");

            migrationBuilder.RenameColumn(
                name: "KiloGramRate",
                table: "TbSetting",
                newName: "KilooGramRate");
        }
    }
}
