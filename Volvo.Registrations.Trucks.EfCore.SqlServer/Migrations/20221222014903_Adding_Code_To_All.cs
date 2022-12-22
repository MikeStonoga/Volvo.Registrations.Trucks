using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddingCodeToAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "code",
                table: "TruckModel",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "code",
                table: "Truck",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "code",
                table: "DomainEvent",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_TruckModel_code",
                table: "TruckModel",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Truck_code",
                table: "Truck",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DomainEvent_code",
                table: "DomainEvent",
                column: "code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TruckModel_code",
                table: "TruckModel");

            migrationBuilder.DropIndex(
                name: "IX_Truck_code",
                table: "Truck");

            migrationBuilder.DropIndex(
                name: "IX_DomainEvent_code",
                table: "DomainEvent");

            migrationBuilder.DropColumn(
                name: "code",
                table: "TruckModel");

            migrationBuilder.DropColumn(
                name: "code",
                table: "Truck");

            migrationBuilder.DropColumn(
                name: "code",
                table: "DomainEvent");
        }
    }
}
