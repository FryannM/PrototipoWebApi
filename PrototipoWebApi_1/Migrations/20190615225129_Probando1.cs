using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrototipoWebApi_1.Migrations
{
    public partial class Probando1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Cli_I_Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cli_V_Nombre_1 = table.Column<string>(type: "varchar(30)", nullable: true),
                    Cli_V_Nombre_2 = table.Column<string>(type: "varchar(30)", nullable: true),
                    Cli_V_Apellido_1 = table.Column<string>(type: "varchar(30)", nullable: true),
                    Cli_V_Apellido_2 = table.Column<string>(type: "varchar(30)", nullable: true),
                    Cli_V_CedulaRnc = table.Column<string>(type: "varchar(30)", nullable: true),
                    Cli_V_email = table.Column<string>(type: "varchar(30)", nullable: true),
                    Cli_V_Telefono = table.Column<string>(type: "varchar(30)", nullable: true),
                    Pro_I_Codigo = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Cli_I_Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradors",
                columns: table => new
                {
                    Col_I_Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Col_V_Cedula = table.Column<string>(type: "varchar(20)", nullable: true),
                    Col_V_Nombre_1 = table.Column<string>(type: "varchar(11)", nullable: true),
                    Col_V_Nombre_2 = table.Column<string>(type: "varchar(20)", nullable: true),
                    Col_V_Apellido_1 = table.Column<string>(type: "varchar(20)", nullable: true),
                    Col_V_Apellido_2 = table.Column<string>(type: "varchar(20)", nullable: true),
                    Col_C_Sexo = table.Column<string>(type: "char(1)", nullable: false),
                    Col_D_Fecha_Nacimiento = table.Column<DateTime>(nullable: false),
                    Dep_I_Codigo = table.Column<int>(nullable: false),
                    Pos_I_Codigo = table.Column<int>(nullable: false),
                    Col_B_Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradors", x => x.Col_I_Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    Pro_I_Codigo = table.Column<int>(nullable: false),
                    Pro_V_Descripcion = table.Column<string>(type: "varchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.Pro_I_Codigo);
                    table.ForeignKey(
                        name: "FK_Proyectos_Clientes_Pro_I_Codigo",
                        column: x => x.Pro_I_Codigo,
                        principalTable: "Clientes",
                        principalColumn: "Cli_I_Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Dep_I_Codigo = table.Column<int>(nullable: false),
                    Dep_V_Descripcion = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Dep_I_Codigo);
                    table.ForeignKey(
                        name: "FK_Departamentos_Colaboradors_Dep_I_Codigo",
                        column: x => x.Dep_I_Codigo,
                        principalTable: "Colaboradors",
                        principalColumn: "Col_I_Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posicion",
                columns: table => new
                {
                    Pos_I_Codigo = table.Column<int>(nullable: false),
                    Pos_V_Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posicion", x => x.Pos_I_Codigo);
                    table.ForeignKey(
                        name: "FK_Posicion_Colaboradors_Pos_I_Codigo",
                        column: x => x.Pos_I_Codigo,
                        principalTable: "Colaboradors",
                        principalColumn: "Col_I_Codigo",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Posicion");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Colaboradors");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
