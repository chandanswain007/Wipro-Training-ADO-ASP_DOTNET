using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrimeReportingSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LawEnforcementAgencies",
                columns: table => new
                {
                    AgencyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Jurisdiction = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawEnforcementAgencies", x => x.AgencyID);
                });

            migrationBuilder.CreateTable(
                name: "Suspects",
                columns: table => new
                {
                    SuspectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suspects", x => x.SuspectID);
                });

            migrationBuilder.CreateTable(
                name: "Victims",
                columns: table => new
                {
                    VictimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Victims", x => x.VictimID);
                });

            migrationBuilder.CreateTable(
                name: "Officers",
                columns: table => new
                {
                    OfficerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BadgeNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Rank = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AgencyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officers", x => x.OfficerID);
                    table.ForeignKey(
                        name: "FK_Officers_LawEnforcementAgencies_AgencyID",
                        column: x => x.AgencyID,
                        principalTable: "LawEnforcementAgencies",
                        principalColumn: "AgencyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IncidentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VictimID = table.Column<int>(type: "int", nullable: false),
                    SuspectID = table.Column<int>(type: "int", nullable: false),
                    AgencyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentID);
                    table.ForeignKey(
                        name: "FK_Incidents_LawEnforcementAgencies_AgencyID",
                        column: x => x.AgencyID,
                        principalTable: "LawEnforcementAgencies",
                        principalColumn: "AgencyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_Suspects_SuspectID",
                        column: x => x.SuspectID,
                        principalTable: "Suspects",
                        principalColumn: "SuspectID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_Victims_VictimID",
                        column: x => x.VictimID,
                        principalTable: "Victims",
                        principalColumn: "VictimID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evidence",
                columns: table => new
                {
                    EvidenceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationFound = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncidentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evidence", x => x.EvidenceID);
                    table.ForeignKey(
                        name: "FK_Evidence_Incidents_IncidentID",
                        column: x => x.IncidentID,
                        principalTable: "Incidents",
                        principalColumn: "IncidentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentID = table.Column<int>(type: "int", nullable: false),
                    ReportingOfficerID = table.Column<int>(type: "int", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportID);
                    table.ForeignKey(
                        name: "FK_Reports_Incidents_IncidentID",
                        column: x => x.IncidentID,
                        principalTable: "Incidents",
                        principalColumn: "IncidentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Officers_ReportingOfficerID",
                        column: x => x.ReportingOfficerID,
                        principalTable: "Officers",
                        principalColumn: "OfficerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evidence_IncidentID",
                table: "Evidence",
                column: "IncidentID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_AgencyID",
                table: "Incidents",
                column: "AgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_SuspectID",
                table: "Incidents",
                column: "SuspectID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_VictimID",
                table: "Incidents",
                column: "VictimID");

            migrationBuilder.CreateIndex(
                name: "IX_Officers_AgencyID",
                table: "Officers",
                column: "AgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_IncidentID",
                table: "Reports",
                column: "IncidentID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportingOfficerID",
                table: "Reports",
                column: "ReportingOfficerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evidence");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Officers");

            migrationBuilder.DropTable(
                name: "Suspects");

            migrationBuilder.DropTable(
                name: "Victims");

            migrationBuilder.DropTable(
                name: "LawEnforcementAgencies");
        }
    }
}
