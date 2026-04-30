using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "VendingMachines",
                newName: "WorkingHours");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "VendingMachines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Coordinates",
                table: "VendingMachines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "VendingMachines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "VendingMachines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "VendingMachines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Operator",
                table: "VendingMachines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentType",
                table: "VendingMachines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "VendingMachines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Timezone",
                table: "VendingMachines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkMode",
                table: "VendingMachines",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "VendingMachines");

            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "VendingMachines");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "VendingMachines");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "VendingMachines");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "VendingMachines");

            migrationBuilder.DropColumn(
                name: "Operator",
                table: "VendingMachines");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "VendingMachines");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "VendingMachines");

            migrationBuilder.DropColumn(
                name: "Timezone",
                table: "VendingMachines");

            migrationBuilder.DropColumn(
                name: "WorkMode",
                table: "VendingMachines");

            migrationBuilder.RenameColumn(
                name: "WorkingHours",
                table: "VendingMachines",
                newName: "Type");
        }
    }
}
