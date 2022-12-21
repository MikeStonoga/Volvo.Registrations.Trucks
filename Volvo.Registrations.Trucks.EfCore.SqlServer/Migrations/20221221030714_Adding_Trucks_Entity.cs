using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddingTrucksEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Truck",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    manufacturingyear = table.Column<int>(name: "manufacturing_year", type: "int", nullable: false),
                    modelid = table.Column<Guid>(name: "model_id", type: "uniqueidentifier", nullable: false),
                    creationtime = table.Column<DateTime>(name: "creation_time", type: "datetime2", nullable: false),
                    lastmodificationtime = table.Column<DateTime>(name: "last_modification_time", type: "datetime2", nullable: true),
                    deletiontime = table.Column<DateTime>(name: "deletion_time", type: "datetime2", nullable: true),
                    isdeleted = table.Column<bool>(name: "is_deleted", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truck", x => x.id);
                    table.ForeignKey(
                        name: "FK_Truck_TruckModel_model_id",
                        column: x => x.modelid,
                        principalTable: "TruckModel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Truck_model_id",
                table: "Truck",
                column: "model_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Truck");
        }
    }
}
