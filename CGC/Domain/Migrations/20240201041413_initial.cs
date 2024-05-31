using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CGC.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriptor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Avatar_Href = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Links_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rev = table.Column<int>(type: "int", nullable: false),
                    Fields_SystemAreaPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fields_SystemTeamProject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fields_SystemIterationPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fields_SystemWorkItemType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fields_SystemState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fields_SystemReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fields_SystemCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fields_SystemCreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Fields_SystemChangedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fields_SystemChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Fields_SystemAssignedToId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Fields_SystemCommentCount = table.Column<int>(type: "int", nullable: true),
                    Fields_SystemTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fields_CommonStateChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fields_CommonPriority = table.Column<int>(type: "int", nullable: true),
                    Fields_CommonSeverity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fields_CommonValueArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fields_TCMReproSteps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkItem_User_Fields_SystemAssignedToId",
                        column: x => x.Fields_SystemAssignedToId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkItem_User_Fields_SystemChangedById",
                        column: x => x.Fields_SystemChangedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkItem_User_Fields_SystemCreatedById",
                        column: x => x.Fields_SystemCreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_Fields_SystemAssignedToId",
                table: "WorkItem",
                column: "Fields_SystemAssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_Fields_SystemChangedById",
                table: "WorkItem",
                column: "Fields_SystemChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_Fields_SystemCreatedById",
                table: "WorkItem",
                column: "Fields_SystemCreatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "WorkItem");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
