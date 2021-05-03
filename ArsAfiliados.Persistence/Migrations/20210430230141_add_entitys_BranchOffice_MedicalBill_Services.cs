using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArsAfiliados.Persistence.Migrations
{
    public partial class add_entitys_BranchOffice_MedicalBill_Services : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BranchOffices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOffices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalBills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCost = table.Column<decimal>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalBills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    PercentCovers = table.Column<int>(nullable: false),
                    BranchOfficeId = table.Column<int>(nullable: false),
                    MedicalBillId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_BranchOffices_BranchOfficeId",
                        column: x => x.BranchOfficeId,
                        principalTable: "BranchOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_MedicalBills_MedicalBillId",
                        column: x => x.MedicalBillId,
                        principalTable: "MedicalBills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_BranchOfficeId",
                table: "Services",
                column: "BranchOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_MedicalBillId",
                table: "Services",
                column: "MedicalBillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "BranchOffices");

            migrationBuilder.DropTable(
                name: "MedicalBills");
        }
    }
}
