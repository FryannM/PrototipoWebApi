using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrototipoWebApi_1.Migrations
{
    public partial class AgregandoEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.AddColumn<int>(
                name: "TeamColaboratorId",
                table: "Team",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamColaboratorId",
                table: "Colaboradors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeamColaborators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProyectoPro_I_Codigo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamColaborators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamColaborators_Proyectos_ProyectoPro_I_Codigo",
                        column: x => x.ProyectoPro_I_Codigo,
                        principalTable: "Proyectos",
                        principalColumn: "Pro_I_Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Team_TeamColaboratorId",
                table: "Team",
                column: "TeamColaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradors_TeamColaboratorId",
                table: "Colaboradors",
                column: "TeamColaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamColaborators_ProyectoPro_I_Codigo",
                table: "TeamColaborators",
                column: "ProyectoPro_I_Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradors_TeamColaborators_TeamColaboratorId",
                table: "Colaboradors",
                column: "TeamColaboratorId",
                principalTable: "TeamColaborators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_TeamColaborators_TeamColaboratorId",
                table: "Team",
                column: "TeamColaboratorId",
                principalTable: "TeamColaborators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradors_TeamColaborators_TeamColaboratorId",
                table: "Colaboradors");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_TeamColaborators_TeamColaboratorId",
                table: "Team");

            migrationBuilder.DropTable(
                name: "TeamColaborators");

            migrationBuilder.DropIndex(
                name: "IX_Team_TeamColaboratorId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Colaboradors_TeamColaboratorId",
                table: "Colaboradors");

            migrationBuilder.DropColumn(
                name: "TeamColaboratorId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "TeamColaboratorId",
                table: "Colaboradors");

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.id);
                });
        }
    }
}
