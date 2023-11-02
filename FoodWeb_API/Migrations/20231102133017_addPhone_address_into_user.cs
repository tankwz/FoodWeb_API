using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodWeb_API.Migrations
{
    /// <inheritdoc />
    public partial class addPhone_address_into_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PickupEmail",
                table: "OrderHead",
                newName: "PickupAddress");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PickupAddress",
                table: "OrderHead",
                newName: "PickupEmail");
        }
    }
}
