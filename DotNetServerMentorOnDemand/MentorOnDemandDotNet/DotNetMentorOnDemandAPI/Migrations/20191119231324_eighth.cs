using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetMentorOnDemandAPI.Migrations
{
    public partial class eighth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "IsPayment",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "IsRequest",
                table: "Notifications");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Notifications",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c2ea7550-d387-4b1d-af46-a6043ccbeba2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "65e633e1-f092-4899-951a-b9ec33346953");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "e7f33f97-d8b2-4855-803e-de9a627cb566");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Notifications");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPayment",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequest",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "310465f9-bff9-451f-8f6d-bbc827c7458c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "87d09ce4-bed1-4c02-a5f8-2fc656de3745");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "8a5c6e8c-2b42-4535-af3a-3d4b64c4b8ea");
        }
    }
}
