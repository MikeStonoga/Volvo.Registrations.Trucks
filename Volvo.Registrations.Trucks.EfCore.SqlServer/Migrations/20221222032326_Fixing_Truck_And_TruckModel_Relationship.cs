using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class FixingTruckAndTruckModelRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Truck_model_id",
                table: "Truck");

            migrationBuilder.CreateIndex(
                name: "IX_Truck_model_id",
                table: "Truck",
                column: "model_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Truck_model_id",
                table: "Truck");

            migrationBuilder.CreateIndex(
                name: "IX_Truck_model_id",
                table: "Truck",
                column: "model_id",
                unique: true);
        }
    }
}
