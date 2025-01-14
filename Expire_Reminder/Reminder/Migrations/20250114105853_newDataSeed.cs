using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reminder.Migrations
{
    /// <inheritdoc />
    public partial class newDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "detailsDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    leftDays = table.Column<int>(type: "int", nullable: true),
                    totalDay = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailsDb", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detailsDb");
        }
    }
}
