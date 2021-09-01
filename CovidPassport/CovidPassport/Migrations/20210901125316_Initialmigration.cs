using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidPassport.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    HouseNumber = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    StreetName = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Postcode = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "HealthCentre",
                columns: table => new
                {
                    HealthCentreID = table.Column<int>(type: "int", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCentre", x => x.HealthCentreID);
                    table.ForeignKey(
                        name: "FK__HealthCen__Addre__2B3F6F97",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    Surname = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NoOfVaccines = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    DOB = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK__Person__AddressI__286302EC",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passport",
                columns: table => new
                {
                    PassportID = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    HealthCentreID = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passport", x => x.PassportID);
                    table.ForeignKey(
                        name: "FK__Passport__Health__2F10007B",
                        column: x => x.HealthCentreID,
                        principalTable: "HealthCentre",
                        principalColumn: "HealthCentreID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Passport__Person__2E1BDC42",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthCentre_AddressID",
                table: "HealthCentre",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Passport_HealthCentreID",
                table: "Passport",
                column: "HealthCentreID");

            migrationBuilder.CreateIndex(
                name: "IX_Passport_PersonID",
                table: "Passport",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressID",
                table: "Person",
                column: "AddressID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passport");

            migrationBuilder.DropTable(
                name: "HealthCentre");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
