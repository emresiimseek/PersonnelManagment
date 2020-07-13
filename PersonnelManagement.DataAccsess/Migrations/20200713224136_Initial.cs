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
                    { 1, new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc), "Hoppe and Sporer" },
                    { 2, new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Boyer-Aufderhar" },
                    { 3, new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Parker and Lehner" },
                    { 4, new DateTime(2019, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Barrows and Haag" },
                    { 5, new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Durgan-Beatty" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "CreatedOn", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 6, new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 7, 29, 0, 0, 0, 0, DateTimeKind.Utc), "South Dakota exorcists" },
                    { 5, new DateTime(2019, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Utc), "New York goblins" },
                    { 4, new DateTime(2020, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Illinois ants" },
                    { 2, new DateTime(2020, 5, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), "Vermont elves" },
                    { 1, new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Arizona werewolves" },
                    { 3, new DateTime(2020, 2, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 6, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Iowa ogres" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "CreatedOn", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 5, new DateTime(2019, 8, 13, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Delfina Carroll" },
                    { 1, new DateTime(2019, 8, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Verna Nitzsche" },
                    { 2, new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Marcus Runolfsdottir" },
                    { 3, new DateTime(2019, 11, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 5, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Emilio Bayer" },
                    { 4, new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Lindsey Kuphal" },
                    { 6, new DateTime(2019, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Makenzie Hills" }
                });

            migrationBuilder.InsertData(
                table: "Personnels",
                columns: new[] { "PersonnelId", "CreatedOn", "DateOfRecuitment", "DepartmentId", "EmploymentendDate", "JobId", "LastName", "ModifiedOn", "Name", "Salary" },
                values: new object[,]
                {
                    { 5, new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2019, 7, 24, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Gerlach", new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Roberto", 12500.75m },
                    { 8, new DateTime(2020, 3, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2020, 6, 17, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Crist", new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Natalia", 20001.20m },
                    { 9, new DateTime(2019, 8, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2019, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Cronin", new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Rosalee", 22501.35m },
                    { 1, new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 8, 29, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Beatty", new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Utc), "Jacey", 2500.15m },
                    { 4, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Yundt", new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Vance", 10000.60m },
                    { 3, new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Utc), 4, "Hickle", new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Luna", 7500.45m },
                    { 6, new DateTime(2019, 8, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2020, 5, 26, 0, 0, 0, 0, DateTimeKind.Utc), 4, "Labadie", new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Josiane", 15000.90m },
                    { 2, new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2020, 2, 9, 0, 0, 0, 0, DateTimeKind.Utc), 6, "Emmerich", new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Flavie", 5000.30m },
                    { 7, new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), 6, "Rippin", new DateTime(2019, 12, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Gabriella", 17501.05m }
                });

            migrationBuilder.InsertData(
                table: "jobRoles",
                columns: new[] { "Id", "CreatedOn", "JobId", "ModifiedOn", "RoleId" },
                values: new object[,]
                {
                    { 2, new DateTime(2019, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2020, 5, 19, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 5, new DateTime(2020, 3, 21, 0, 0, 0, 0, DateTimeKind.Utc), 5, new DateTime(2020, 4, 23, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 6, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), 6, new DateTime(2020, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 1, new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 3, new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 4, new DateTime(2020, 6, 18, 0, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Utc), 3 }
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
