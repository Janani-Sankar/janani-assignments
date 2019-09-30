using Microsoft.EntityFrameworkCore.Migrations;

namespace EventAPI.Migrations
{
    public partial class Intialrequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "catalog_hilo");

            migrationBuilder.CreateSequence(
                name: "category_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "events_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "eventtype_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "price_hilo",
                incrementBy: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "category_hilo");

            migrationBuilder.DropSequence(
                name: "events_hilo");

            migrationBuilder.DropSequence(
                name: "eventtype_hilo");

            migrationBuilder.DropSequence(
                name: "price_hilo");

            migrationBuilder.CreateSequence(
                name: "catalog_hilo",
                incrementBy: 10);
        }
    }
}
