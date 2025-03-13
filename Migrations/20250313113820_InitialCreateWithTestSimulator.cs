using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotatingBendingTestBench.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWithTestSimulator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestResult_TestSimulator_TestSimulatorId",
                table: "TestResult");

            migrationBuilder.DropColumn(
                name: "TestSequenceId",
                table: "TestResult");

            migrationBuilder.AlterColumn<int>(
                name: "TestSimulatorId",
                table: "TestResult",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResult_TestSimulator_TestSimulatorId",
                table: "TestResult",
                column: "TestSimulatorId",
                principalTable: "TestSimulator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestResult_TestSimulator_TestSimulatorId",
                table: "TestResult");

            migrationBuilder.AlterColumn<int>(
                name: "TestSimulatorId",
                table: "TestResult",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "TestSequenceId",
                table: "TestResult",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResult_TestSimulator_TestSimulatorId",
                table: "TestResult",
                column: "TestSimulatorId",
                principalTable: "TestSimulator",
                principalColumn: "Id");
        }
    }
}
