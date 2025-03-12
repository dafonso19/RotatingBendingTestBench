using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotatingBendingTestBench.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestSimulator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSimulator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TestSimulatorId = table.Column<int>(type: "INTEGER", nullable: false),
                    RotationSpeedSetpoint = table.Column<double>(type: "REAL", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestData_TestSimulator_TestSimulatorId",
                        column: x => x.TestSimulatorId,
                        principalTable: "TestSimulator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TestSequenceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RotationSpeed = table.Column<double>(type: "REAL", nullable: false),
                    StressLevel = table.Column<double>(type: "REAL", nullable: false),
                    Temperature = table.Column<double>(type: "REAL", nullable: false),
                    TestSimulatorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestResult_TestSimulator_TestSimulatorId",
                        column: x => x.TestSimulatorId,
                        principalTable: "TestSimulator",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestData_TestSimulatorId",
                table: "TestData",
                column: "TestSimulatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TestResult_TestSimulatorId",
                table: "TestResult",
                column: "TestSimulatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestData");

            migrationBuilder.DropTable(
                name: "TestResult");

            migrationBuilder.DropTable(
                name: "TestSimulator");
        }
    }
}
