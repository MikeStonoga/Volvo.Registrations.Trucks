using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddingTrucksModelsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TruckModel",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    creationtime = table.Column<DateTime>(name: "creation_time", type: "datetime2", nullable: false),
                    lastmodificationtime = table.Column<DateTime>(name: "last_modification_time", type: "datetime2", nullable: true),
                    deletiontime = table.Column<DateTime>(name: "deletion_time", type: "datetime2", nullable: true),
                    isdeleted = table.Column<bool>(name: "is_deleted", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckModel", x => x.id);
                });

            var now = DateTime.UtcNow;
            migrationBuilder.InsertData(
                table: "TruckModel",
                columns: new[] { "id", "creation_time", "deletion_time", "is_deleted", "last_modification_time", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("295fccad-1ca0-4012-a912-755221025f92"), new DateTime(2022, 12, 21, 2, 49, 58, 915, DateTimeKind.Utc).AddTicks(7528), null, false, null, "FH", now.Year },
                    { new Guid("59ba500e-14e9-47d2-bfcc-91145f4fa8ab"), new DateTime(2022, 12, 21, 2, 49, 58, 915, DateTimeKind.Utc).AddTicks(7660), null, false, null, "FM", now.Year },
                    { new Guid("9ccf557b-90b2-488d-88f3-ba34ba978221"), new DateTime(2022, 12, 21, 2, 49, 58, 915, DateTimeKind.Utc).AddTicks(7674), null, false, null, "FM", now.Year + 1 },
                    { new Guid("b847e486-8638-4e3e-ada9-95607ac7109f"), new DateTime(2022, 12, 21, 2, 49, 58, 915, DateTimeKind.Utc).AddTicks(7652), null, false, null, "FH", now.Year + 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TruckModel");
        }
    }
}
