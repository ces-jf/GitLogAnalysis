using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GitLogAnalysis.Infra.Migrations
{
    public partial class mysql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    ProjectName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Directory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_RELEASE_DATA",
                columns: table => new
                {
                    ID_RELEASE = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FL_ACTIVE = table.Column<bool>(nullable: false, defaultValue: true),
                    DS_RELEASE_NAME = table.Column<string>(maxLength: 50, nullable: true),
                    NR_AUTHORS = table.Column<int>(nullable: false),
                    NR_COMMITS = table.Column<int>(nullable: false),
                    DT_INITIAL = table.Column<DateTime>(type: "datetime", nullable: false),
                    DT_FINAL = table.Column<DateTime>(type: "datetime", nullable: false),
                    NR_REMOVED_LINES = table.Column<int>(nullable: true),
                    NR_ADDED_LINES = table.Column<int>(nullable: true),
                    ID_PROJECT = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RELEASE_DATA", x => x.ID_RELEASE);
                    table.ForeignKey(
                        name: "FK_TB_RELEASE_DATA_Project_ID_PROJECT",
                        column: x => x.ID_PROJECT,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_RELEASE_DATA_ID_PROJECT",
                table: "TB_RELEASE_DATA",
                column: "ID_PROJECT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_RELEASE_DATA");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
