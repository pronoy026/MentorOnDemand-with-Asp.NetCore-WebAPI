using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetMentorOnDemandAPI.Migrations
{
    public partial class seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentEmail = table.Column<string>(nullable: true),
                    MentorSkillId = table.Column<int>(nullable: false),
                    IsStudent = table.Column<bool>(nullable: false),
                    IsMentor = table.Column<bool>(nullable: false),
                    IsPayment = table.Column<bool>(nullable: false),
                    IsRequest = table.Column<bool>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "130e6e35-f2b3-41b0-a84d-344b98261e6b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "d66489ef-ce01-472e-8368-f02817c8df67");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "b25941c2-98cf-49fd-87d2-cabbccad3b7c");
        }
    }
}
