using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldPotentialRecordingsProcessor.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecordingSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordingSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessedDataSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordingSessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessedDataSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessedDataSets_RecordingSessions_RecordingSessionId",
                        column: x => x.RecordingSessionId,
                        principalTable: "RecordingSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Treatment = table.Column<int>(type: "int", nullable: false),
                    RecordingSessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rats_RecordingSessions_RecordingSessionId",
                        column: x => x.RecordingSessionId,
                        principalTable: "RecordingSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RawDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ch1Stim1 = table.Column<decimal>(type: "decimal(8,7)", nullable: false),
                    Ch1Stim2 = table.Column<decimal>(type: "decimal(8,7)", nullable: false),
                    Ch2Stim1 = table.Column<decimal>(type: "decimal(8,7)", nullable: false),
                    Ch2Stim2 = table.Column<decimal>(type: "decimal(8,7)", nullable: false),
                    Ch3Stim1 = table.Column<decimal>(type: "decimal(8,7)", nullable: false),
                    Ch3Stim2 = table.Column<decimal>(type: "decimal(8,7)", nullable: false),
                    Ch4Stim1 = table.Column<decimal>(type: "decimal(8,7)", nullable: false),
                    Ch4Stim2 = table.Column<decimal>(type: "decimal(8,7)", nullable: false),
                    TimeInterval = table.Column<int>(type: "int", nullable: false),
                    RecordingSessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RawDatas_RecordingSessions_RecordingSessionId",
                        column: x => x.RecordingSessionId,
                        principalTable: "RecordingSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessedDataSets_RecordingSessionId",
                table: "ProcessedDataSets",
                column: "RecordingSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rats_RecordingSessionId",
                table: "Rats",
                column: "RecordingSessionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RawDatas_RecordingSessionId",
                table: "RawDatas",
                column: "RecordingSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessedDataSets");

            migrationBuilder.DropTable(
                name: "Rats");

            migrationBuilder.DropTable(
                name: "RawDatas");

            migrationBuilder.DropTable(
                name: "RecordingSessions");
        }
    }
}
