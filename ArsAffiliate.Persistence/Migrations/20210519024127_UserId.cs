using Microsoft.EntityFrameworkCore.Migrations;

namespace ArsAffiliate.Persistence.Migrations
{
    public partial class UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfdeecc7-baeb-4254-8fc0-9780b3989895");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0494d783-ee1b-441e-8291-493bee7da437", "09ab3d68-ed20-49b2-994a-39a745f5cdd0", "SuperAdmin", "SUPERADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0494d783-ee1b-441e-8291-493bee7da437");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cfdeecc7-baeb-4254-8fc0-9780b3989895", "85132246-17a7-49f3-8794-baf7e5c2bbff", "SuperAdmin", "SUPERADMIN" });
        }
    }
}
