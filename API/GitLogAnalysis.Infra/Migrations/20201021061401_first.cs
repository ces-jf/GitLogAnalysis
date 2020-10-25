using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GitLogAnalysis.Infra.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_RELEASE_DATA",
                columns: table => new
                {
                    ID_RELEASE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FL_ACTIVE = table.Column<bool>(nullable: false, defaultValue: true),
                    DS_RELEASE_NAME = table.Column<string>(maxLength: 50, nullable: true),
                    NR_AUTHORS = table.Column<int>(nullable: false),
                    NR_COMMITS = table.Column<int>(nullable: false),
                    DT_INITIAL = table.Column<DateTime>(nullable: true),
                    DT_FINAL = table.Column<DateTime>(nullable: true),
                    NR_REMOVED_LINES = table.Column<int>(nullable: true),
                    NR_ADDED_LINES = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RELEASE_DATA", x => x.ID_RELEASE);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_RELEASE_DATA");
        }
    }
}
