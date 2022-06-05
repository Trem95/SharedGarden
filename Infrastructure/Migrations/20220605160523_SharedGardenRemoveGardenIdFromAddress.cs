using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SharedGardenRemoveGardenIdFromAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Garden_GardenId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_GardenId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "GardenId",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Garden_AddressId",
                table: "Garden",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Garden_Address_AddressId",
                table: "Garden",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garden_Address_AddressId",
                table: "Garden");

            migrationBuilder.DropIndex(
                name: "IX_Garden_AddressId",
                table: "Garden");

            migrationBuilder.AddColumn<int>(
                name: "GardenId",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Address_GardenId",
                table: "Address",
                column: "GardenId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Garden_GardenId",
                table: "Address",
                column: "GardenId",
                principalTable: "Garden",
                principalColumn: "Id");
        }
    }
}
