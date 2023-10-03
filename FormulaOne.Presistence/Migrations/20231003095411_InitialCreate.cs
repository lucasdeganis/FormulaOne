using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FormulaOne.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullTeamName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Base = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TeamChief = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TechnicalChief = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Chassis = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PowerUnit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstTeamEntry = table.Column<int>(type: "int", nullable: false),
                    WorldChampionships = table.Column<int>(type: "int", nullable: false),
                    HighestRaceFinish = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PolePositions = table.Column<int>(type: "int", nullable: false),
                    FastestLaps = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.Sql(@"CREATE PROCEDURE GetUsersByUserAndPassword
                                (
                                    @UserName varchar(50),
                                    @Password varchar(50)
                                )
                                AS
                                BEGIN
                                    SELECT Id, FirstName, LastName, UserName, Role, NULL as Password
                                    FROM Users
                                    WHERE UserName = @UserName and Password = @Password
                                END");

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberCar = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drivers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CountryCode", "Created", "CreatedBy", "DateOfBirth", "LastModified", "LastModifiedBy", "LastName", "Name", "PlaceOfBirth" },
                values: new object[,]
                {
                    { new Guid("19867ba9-3b5d-4201-9f82-20a5948f200e"), "FI", new DateTime(2023, 10, 3, 9, 54, 11, 107, DateTimeKind.Utc).AddTicks(3472), "SYSTEM", new DateTime(1989, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Bottas", "Valtteri", "Nastola, Finland" },
                    { new Guid("269a2191-6e5e-41cc-b513-baa27c0e3dec"), "TH", new DateTime(2023, 10, 3, 9, 54, 11, 107, DateTimeKind.Utc).AddTicks(3465), "SYSTEM", new DateTime(1996, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Albon", "Alexander", "London, England" },
                    { new Guid("5772d1b1-3350-4b25-9030-ddfbbfa97fb8"), "ES", new DateTime(2023, 10, 3, 9, 54, 11, 107, DateTimeKind.Utc).AddTicks(3469), "SYSTEM", new DateTime(1981, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Alonso", "Fernando", "Oviedo, Spain" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Base", "Chassis", "Created", "CreatedBy", "FastestLaps", "FirstTeamEntry", "FullTeamName", "HighestRaceFinish", "LastModified", "LastModifiedBy", "PolePositions", "PowerUnit", "TeamChief", "TechnicalChief", "WorldChampionships" },
                values: new object[,]
                {
                    { new Guid("1019065f-7e90-4ede-b5fd-066ac97a59c1"), "Enstone, United Kingdom", "A523", new DateTime(2023, 10, 3, 9, 54, 11, 107, DateTimeKind.Utc).AddTicks(3413), "SYSTEM", 15, 1986, "BWT Alpine F1 Team", "1 (x21)", null, null, 20, "Renault", "Bruno Famin", "Matt Harman", 2 },
                    { new Guid("14d2a9ea-5a2b-4bd2-a9a1-263fa933f74c"), "Faenza, Italy", "AT04", new DateTime(2023, 10, 3, 9, 54, 11, 107, DateTimeKind.Utc).AddTicks(3410), "SYSTEM", 2, 1985, "Scuderia AlphaTauri", "1 (x2)", null, null, 1, "Honda RBPT", "Franz Tost", "Jody Egginton", 0 },
                    { new Guid("35e84bd7-808a-4e9d-acc9-2d9ef694e3df"), "Grove, United Kingdom", "FW45", new DateTime(2023, 10, 3, 9, 54, 11, 107, DateTimeKind.Utc).AddTicks(3433), "SYSTEM", 133, 1978, "Williams Racing", "1 (x114)", null, null, 128, "Mercedes", "James Vowles", "TBC", 9 },
                    { new Guid("66f3e058-0236-477c-8c0d-a742d2968923"), "Woking, United Kingdom", "MCL60", new DateTime(2023, 10, 3, 9, 54, 11, 107, DateTimeKind.Utc).AddTicks(3426), "SYSTEM", 163, 1966, "McLaren Formula 1 Team", "1 (x183)", null, null, 156, "Mercedes", "Andrea Stella", "Peter Prodromou / Neil Houldey", 8 },
                    { new Guid("9733c471-9473-4dce-8d86-d81e6453e100"), "Brackley, United Kingdom", "W14", new DateTime(2023, 10, 3, 9, 54, 11, 107, DateTimeKind.Utc).AddTicks(3429), "SYSTEM", 95, 1970, "Mercedes-AMG PETRONAS F1 Team", "1 (x116)", null, null, 129, "Mercedes", "Toto Wolff", "James Allison", 8 },
                    { new Guid("e1fc822f-10e8-4414-8a26-dd2f1f145c19"), "Kannapolis, United States", "VF-23", new DateTime(2023, 10, 3, 9, 54, 11, 107, DateTimeKind.Utc).AddTicks(3417), "SYSTEM", 2, 2016, "MoneyGram Haas F1 Team", "4 (x1)", null, null, 1, "Ferrari", "Guenther Steiner", "Simone Resta", 0 },
                    { new Guid("e5eeb102-e899-403c-8f11-44556b9d844e"), "Silverstone, United Kingdom", "AMR23", new DateTime(2023, 10, 3, 9, 54, 11, 107, DateTimeKind.Utc).AddTicks(3423), "SYSTEM", 1, 2018, "Aston Martin Aramco Cognizant F1 Team", "1 (x1)", null, null, 1, "Mercedes", "Mike Krack", "Dan Fallows", 0 },
                    { new Guid("fa9efe94-c385-46fe-8fbc-e0d683802f8e"), "Hinwil, Switzerland", "C43", new DateTime(2023, 10, 3, 9, 54, 11, 107, DateTimeKind.Utc).AddTicks(3405), "SYSTEM", 7, 1993, "Alfa Romeo F1 Team Stake", "1 (x1)", null, null, 1, "Ferrari", "Alessandro Alunni Bravi", "James Key", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "CreatedBy", "FirstName", "LastModified", "LastModifiedBy", "LastName", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("01ec3d63-b89c-4378-8585-47884150a91d"), new DateTime(2023, 10, 3, 9, 54, 11, 107, DateTimeKind.Utc).AddTicks(3226), "SYSTEM", null, null, null, null, "1234567890", "Admin", "Admin" },
                    { new Guid("7c3101e5-800c-4a31-80a7-64f52ea9e10d"), new DateTime(2023, 10, 3, 9, 54, 11, 107, DateTimeKind.Utc).AddTicks(3177), "SYSTEM", null, null, null, null, "1234567890", "User", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_PersonId",
                table: "Drivers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_TeamId",
                table: "Drivers",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.Sql(@"DROP PROCEDURE GetUsersByUserAndPassword");
        }
    }
}
