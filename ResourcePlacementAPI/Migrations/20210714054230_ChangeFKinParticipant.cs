using Microsoft.EntityFrameworkCore.Migrations;

namespace ResourcePlacementAPI.Migrations
{
    public partial class ChangeFKinParticipant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_M_Participants_tb_T_Projects_ProjectId",
                table: "tb_M_Participants");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "tb_M_Participants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_M_Participants_tb_T_Projects_ProjectId",
                table: "tb_M_Participants",
                column: "ProjectId",
                principalTable: "tb_T_Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_M_Participants_tb_T_Projects_ProjectId",
                table: "tb_M_Participants");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "tb_M_Participants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_M_Participants_tb_T_Projects_ProjectId",
                table: "tb_M_Participants",
                column: "ProjectId",
                principalTable: "tb_T_Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
