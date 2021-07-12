using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResourcePlacementAPI.Migrations
{
    public partial class AddDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_M_CustomerUsers",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PicName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_M_CustomerUsers", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "tb_M_Employees",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NIK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_M_Employees", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "tb_M_Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_M_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "tb_M_Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_M_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "tb_M_Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerUsersEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CustomerUsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_M_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_tb_M_Projects_tb_M_CustomerUsers_CustomerUsersEmail",
                        column: x => x.CustomerUsersEmail,
                        principalTable: "tb_M_CustomerUsers",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_M_Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_M_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_tb_M_Accounts_tb_M_CustomerUsers_Email",
                        column: x => x.Email,
                        principalTable: "tb_M_CustomerUsers",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_M_Accounts_tb_M_Employees_Email",
                        column: x => x.Email,
                        principalTable: "tb_M_Employees",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_M_Participants",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectsProjectId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_M_Participants", x => x.ParticipantId);
                    table.ForeignKey(
                        name: "FK_tb_M_Participants_tb_M_Projects_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "tb_M_Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_M_ProjectSkills",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_M_ProjectSkills", x => new { x.ProjectsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_tb_M_ProjectSkills_tb_M_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "tb_M_Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_M_ProjectSkills_tb_M_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "tb_M_Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_M_AccountRoles",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    AccountsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_M_AccountRoles", x => new { x.AccountsId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_tb_M_AccountRoles_tb_M_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "tb_M_Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_M_AccountRoles_tb_M_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "tb_M_Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_M_ParticipantSkills",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false),
                    ParticipantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_M_ParticipantSkills", x => new { x.ParticipantsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_tb_M_ParticipantSkills_tb_M_Participants_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "tb_M_Participants",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_M_ParticipantSkills_tb_M_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "tb_M_Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_M_AccountRoles_RolesId",
                table: "tb_M_AccountRoles",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_M_Accounts_Email",
                table: "tb_M_Accounts",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tb_M_Participants_ProjectsProjectId",
                table: "tb_M_Participants",
                column: "ProjectsProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_M_ParticipantSkills_SkillsId",
                table: "tb_M_ParticipantSkills",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_M_Projects_CustomerUsersEmail",
                table: "tb_M_Projects",
                column: "CustomerUsersEmail");

            migrationBuilder.CreateIndex(
                name: "IX_tb_M_ProjectSkills_SkillsId",
                table: "tb_M_ProjectSkills",
                column: "SkillsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_M_AccountRoles");

            migrationBuilder.DropTable(
                name: "tb_M_ParticipantSkills");

            migrationBuilder.DropTable(
                name: "tb_M_ProjectSkills");

            migrationBuilder.DropTable(
                name: "tb_M_Accounts");

            migrationBuilder.DropTable(
                name: "tb_M_Roles");

            migrationBuilder.DropTable(
                name: "tb_M_Participants");

            migrationBuilder.DropTable(
                name: "tb_M_Skills");

            migrationBuilder.DropTable(
                name: "tb_M_Employees");

            migrationBuilder.DropTable(
                name: "tb_M_Projects");

            migrationBuilder.DropTable(
                name: "tb_M_CustomerUsers");
        }
    }
}
