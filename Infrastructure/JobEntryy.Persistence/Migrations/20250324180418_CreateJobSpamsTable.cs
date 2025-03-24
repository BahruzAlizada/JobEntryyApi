using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobEntryy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateJobSpamsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSalaries");

            migrationBuilder.CreateTable(
                name: "JobSpams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobId = table.Column<Guid>(type: "uuid", nullable: false),
                    Reason = table.Column<int>(type: "integer", nullable: false),
                    SpamDescription = table.Column<string>(type: "text", nullable: true),
                    ReportedByEmail = table.Column<string>(type: "text", nullable: false),
                    ReportedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSpams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSpams_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobSpams_JobId",
                table: "JobSpams",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSpams");

            migrationBuilder.CreateTable(
                name: "JobSalaries",
                columns: table => new
                {
                    IsSalaryHidden = table.Column<bool>(type: "boolean", nullable: false),
                    Salary = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
