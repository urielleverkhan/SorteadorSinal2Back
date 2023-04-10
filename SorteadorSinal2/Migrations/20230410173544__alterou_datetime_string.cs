using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SorteadorSinal2.Migrations
{
    public partial class _alterou_datetime_string : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VigenciaInicio",
                table: "Promocoes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "VigenciaFim",
                table: "Promocoes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "Nascimento",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nascimento",
                value: "15/03/1999");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nascimento",
                value: "11/12/1990");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nascimento",
                value: "25/03/2018");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nascimento",
                value: "06/06/1949");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Nascimento",
                value: "12/03/2000");

            migrationBuilder.UpdateData(
                table: "Promocoes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "VigenciaFim", "VigenciaInicio" },
                values: new object[] { "20/03/2023", "10/03/2023" });

            migrationBuilder.UpdateData(
                table: "Promocoes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "VigenciaFim", "VigenciaInicio" },
                values: new object[] { "05/03/2023", "01/03/2023" });

            migrationBuilder.UpdateData(
                table: "Promocoes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "VigenciaFim", "VigenciaInicio" },
                values: new object[] { "10/03/2023", "07/03/2023" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "VigenciaInicio",
                table: "Promocoes",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "VigenciaFim",
                table: "Promocoes",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Nascimento",
                table: "Clientes",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nascimento",
                value: new DateTime(1999, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nascimento",
                value: new DateTime(1990, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nascimento",
                value: new DateTime(2018, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nascimento",
                value: new DateTime(1949, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Nascimento",
                value: new DateTime(2000, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Promocoes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "VigenciaFim", "VigenciaInicio" },
                values: new object[] { new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Promocoes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "VigenciaFim", "VigenciaInicio" },
                values: new object[] { new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Promocoes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "VigenciaFim", "VigenciaInicio" },
                values: new object[] { new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
