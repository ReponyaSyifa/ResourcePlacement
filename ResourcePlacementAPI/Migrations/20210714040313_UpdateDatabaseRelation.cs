using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResourcePlacementAPI.Migrations
{
    public partial class UpdateDatabaseRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_M_CustomerUsers",
                columns: table => new
                {
                    CustomerUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PicName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_M_CustomerUsers", x => x.CustomerUserId);
                });

            migrationBuilder.CreateTable(
                name: "tb_M_Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NIK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_M_Employees", x => x.EmployeeId);
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
                name: "tb_T_Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_T_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_tb_T_Projects_tb_M_CustomerUsers_CustomerUserId",
                        column: x => x.CustomerUserId,
                        principalTable: "tb_M_CustomerUsers",
                        principalColumn: "CustomerUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_T_Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CustomerUserId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_T_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_tb_T_Accounts_tb_M_CustomerUsers_CustomerUserId",
                        column: x => x.CustomerUserId,
                        principalTable: "tb_M_CustomerUsers",
                        principalColumn: "CustomerUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_T_Accounts_tb_M_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tb_M_Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
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
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_M_Participants", x => x.ParticipantId);
                    table.ForeignKey(
                        name: "FK_tb_M_Participants_tb_T_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "tb_T_Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_tb_M_ProjectSkills_tb_M_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "tb_M_Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_M_ProjectSkills_tb_T_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "tb_T_Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_T_AccountRoles",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_T_AccountRoles", x => new { x.AccountId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_tb_T_AccountRoles_tb_M_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "tb_M_Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_T_AccountRoles_tb_T_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "tb_T_Accounts",
                        principalColumn: "AccountId",
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
                name: "IX_tb_M_Participants_ProjectId",
                table: "tb_M_Participants",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_M_ParticipantSkills_SkillsId",
                table: "tb_M_ParticipantSkills",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_M_ProjectSkills_SkillsId",
                table: "tb_M_ProjectSkills",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_T_AccountRoles_RolesId",
                table: "tb_T_AccountRoles",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_T_Accounts_CustomerUserId",
                table: "tb_T_Accounts",
                column: "CustomerUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_T_Accounts_EmployeeId",
                table: "tb_T_Accounts",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_T_Projects_CustomerUserId",
                table: "tb_T_Projects",
                column: "CustomerUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_M_ParticipantSkills");

            migrationBuilder.DropTable(
                name: "tb_M_ProjectSkills");

            migrationBuilder.DropTable(
                name: "tb_T_AccountRoles");

            migrationBuilder.DropTable(
                name: "tb_M_Participants");

            migrationBuilder.DropTable(
                name: "tb_M_Skills");

            migrationBuilder.DropTable(
                name: "tb_M_Roles");

            migrationBuilder.DropTable(
                name: "tb_T_Accounts");

            migrationBuilder.DropTable(
                name: "tb_T_Projects");

            migrationBuilder.DropTable(
                name: "tb_M_Employees");

            migrationBuilder.DropTable(
                name: "tb_M_CustomerUsers");
        }
    }
}
