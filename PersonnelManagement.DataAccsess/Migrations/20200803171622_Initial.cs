using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonnelManagement.DataAccsess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Personnels",
                columns: table => new
                {
                    PersonnelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    LastName = table.Column<string>(maxLength: 200, nullable: false),
                    UserName = table.Column<string>(maxLength: 200, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfRecuitment = table.Column<DateTime>(type: "datetime", nullable: false),
                    EmploymentendDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    JobId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnels", x => x.PersonnelId);
                    table.ForeignKey(
                        name: "FK_Personnels_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnels_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "jobRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    JobId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobRoles_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedOn", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), "White Inc" },
                    { 2, new DateTime(2019, 12, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Stokes" },
                    { 3, new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 8, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Little-Kling" },
                    { 4, new DateTime(2020, 4, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 5, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Berge-Zieme" },
                    { 5, new DateTime(2020, 4, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Harber" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "CreatedOn", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 6, new DateTime(2020, 2, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Texas werewolves" },
                    { 5, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 5, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Maine kangaroos" },
                    { 4, new DateTime(2019, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Massachusetts goblins" },
                    { 2, new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Connecticut rabbits" },
                    { 1, new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Colorado bears" },
                    { 3, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Alaska oracles" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "CreatedOn", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 5, new DateTime(2020, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 4, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Kamren Gulgowski" },
                    { 1, new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Utc), "Dimitri Johns" },
                    { 2, new DateTime(2020, 5, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 5, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Reina O'Kon" },
                    { 3, new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Tiffany Dibbert" },
                    { 4, new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 6, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Rocky Kirlin" },
                    { 6, new DateTime(2020, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Eric Kreiger" }
                });

            migrationBuilder.InsertData(
                table: "Personnels",
                columns: new[] { "PersonnelId", "CreatedOn", "DateOfRecuitment", "DepartmentId", "EmploymentendDate", "JobId", "LastName", "ModifiedOn", "Name", "Password", "Salary", "Token", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Hayes", new DateTime(2020, 7, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Neal", "Mr.", 2500.15m, null, "Product Branding Specialist" },
                    { 7, new DateTime(2019, 8, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 14, 0, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Sawayn", new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Donnell", "Miss", 17501.05m, null, "Principal Solutions Specialist" },
                    { 9, new DateTime(2019, 8, 13, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Nienow", new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Merritt", "Mrs.", 22501.35m, null, "District Response Facilitator" },
                    { 6, new DateTime(2019, 12, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 7, 5, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Ondricka", new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Sebastian", "Mr.", 15000.90m, null, "National Communications Executive" },
                    { 3, new DateTime(2020, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 8, 9, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Ullrich", new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Laila", "Mr.", 7500.45m, null, "Direct Accounts Engineer" },
                    { 5, new DateTime(2020, 4, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 13, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Utc), 5, "Christiansen", new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Natasha", "Dr.", 12500.75m, null, "Dynamic Functionality Analyst" },
                    { 8, new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Utc), 5, "Vandervort", new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Utc), "Annamarie", "Mr.", 20001.20m, null, "Human Functionality Assistant" },
                    { 2, new DateTime(2020, 7, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 5, 30, 0, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Utc), 6, "Baumbach", new DateTime(2020, 3, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Melisa", "Dr.", 5000.30m, null, "Future Implementation Liaison" },
                    { 4, new DateTime(2020, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Utc), 6, "Kunde", new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Helena", "Miss", 10000.60m, null, "Dynamic Tactics Analyst" }
                });

            migrationBuilder.InsertData(
                table: "jobRoles",
                columns: new[] { "Id", "CreatedOn", "JobId", "ModifiedOn", "RoleId" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 7, 16, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2020, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 5, new DateTime(2020, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), 5, new DateTime(2020, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 1, new DateTime(2020, 6, 3, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2020, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 4, new DateTime(2020, 5, 12, 0, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2020, 5, 9, 0, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 6, new DateTime(2020, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), 6, new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4 },
                    { 3, new DateTime(2020, 7, 26, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Utc), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_jobRoles_JobId",
                table: "jobRoles",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_jobRoles_RoleId",
                table: "jobRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_DepartmentId",
                table: "Personnels",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_JobId",
                table: "Personnels",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jobRoles");

            migrationBuilder.DropTable(
                name: "Personnels");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
