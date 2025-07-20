using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIRest.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCampoPortada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlPortada",
                table: "Peliculas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdPelicula",
                keyValue: 1,
                columns: new[] { "FechaEstreno", "UrlPortada" },
                values: new object[] { new DateTime(2025, 5, 4, 0, 18, 4, 772, DateTimeKind.Local).AddTicks(5648), "https://www.futuro.cl/wp-content/uploads/2019/03/avengers-endgame-poster.jpg" });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdPelicula",
                keyValue: 2,
                columns: new[] { "FechaEstreno", "UrlPortada" },
                values: new object[] { new DateTime(2025, 5, 4, 0, 18, 4, 772, DateTimeKind.Local).AddTicks(5670), "https://www.mubis.es/media/movies/1456/170565/harry-potter-y-el-caliz-de-fuego-l_cover.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlPortada",
                table: "Peliculas");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdPelicula",
                keyValue: 1,
                column: "FechaEstreno",
                value: new DateTime(2025, 1, 18, 21, 40, 59, 116, DateTimeKind.Local).AddTicks(5014));

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdPelicula",
                keyValue: 2,
                column: "FechaEstreno",
                value: new DateTime(2025, 1, 18, 21, 40, 59, 116, DateTimeKind.Local).AddTicks(5023));
        }
    }
}
