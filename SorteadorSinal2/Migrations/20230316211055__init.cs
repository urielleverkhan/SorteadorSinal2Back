using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SorteadorSinal2.Migrations
{
    public partial class _init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Telefone = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Cpf = table.Column<string>(nullable: false),
                    Nascimento = table.Column<DateTime>(nullable: false),
                    Cidade = table.Column<string>(nullable: false),
                    Estado = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promocoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    VigenciaInicio = table.Column<DateTime>(nullable: false),
                    VigenciaFim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    Login = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCliente = table.Column<int>(nullable: false),
                    ClientesId = table.Column<int>(nullable: true),
                    IdPromocao = table.Column<int>(nullable: false),
                    PromocoesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participantes_Clientes_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Participantes_Promocoes_PromocoesId",
                        column: x => x.PromocoesId,
                        principalTable: "Promocoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vencedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCliente = table.Column<int>(nullable: false),
                    ClientesId = table.Column<int>(nullable: true),
                    IdPromocao = table.Column<int>(nullable: false),
                    PromocoesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vencedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vencedores_Clientes_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vencedores_Promocoes_PromocoesId",
                        column: x => x.PromocoesId,
                        principalTable: "Promocoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Cidade", "Cpf", "Estado", "Nascimento", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, "Rio preto", "222.222.222-22", "Sp", new DateTime(1999, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maricota da Silva", "11 99222221" },
                    { 2, "Rio preto", "222.222.222-22", "Sp", new DateTime(1990, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jose pereira", "11 99222222" },
                    { 3, "Rio preto", "222.222.222-22", "Sp", new DateTime(2018, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joao Costa", "11 99222223" },
                    { 4, "Rio preto", "222.222.222-22", "Sp", new DateTime(1949, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Larisa casablanca", "11 99222224" },
                    { 5, "Rio preto", "222.222.222-22", "Sp", new DateTime(2000, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joana camargo", "11 99222225" }
                });

            migrationBuilder.InsertData(
                table: "Participantes",
                columns: new[] { "Id", "ClientesId", "IdCliente", "IdPromocao", "PromocoesId" },
                values: new object[,]
                {
                    { 7, null, 1, 3, null },
                    { 6, null, 4, 3, null },
                    { 4, null, 1, 2, null },
                    { 5, null, 5, 1, null },
                    { 2, null, 4, 2, null },
                    { 1, null, 2, 2, null },
                    { 3, null, 2, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Promocoes",
                columns: new[] { "Id", "Nome", "VigenciaFim", "VigenciaInicio" },
                values: new object[,]
                {
                    { 1, "Churrascaria boi feliz", new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Funeraria cliente agradecido", new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Fabrica de gelos escorrega", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "Senha" },
                values: new object[,]
                {
                    { 1, "naira", "Naira Danile", "123456" },
                    { 2, "josi", "Josiane bueno", "654321" }
                });

            migrationBuilder.InsertData(
                table: "Vencedores",
                columns: new[] { "Id", "ClientesId", "IdCliente", "IdPromocao", "PromocoesId" },
                values: new object[,]
                {
                    { 2, null, 4, 2, null },
                    { 1, null, 2, 2, null },
                    { 3, null, 4, 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_ClientesId",
                table: "Participantes",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_PromocoesId",
                table: "Participantes",
                column: "PromocoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Vencedores_ClientesId",
                table: "Vencedores",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_Vencedores_PromocoesId",
                table: "Vencedores",
                column: "PromocoesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participantes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Vencedores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Promocoes");
        }
    }
}
