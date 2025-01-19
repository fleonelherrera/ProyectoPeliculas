using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIRest.Migrations
{
    /// <inheritdoc />
    public partial class AgregarPeliculas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "IdPelicula", "Director", "FechaEstreno", "Sinopsis", "Titulo" },
                values: new object[,]
                {
                    { 1, "Joss Whedon", new DateTime(2025, 1, 18, 21, 40, 59, 116, DateTimeKind.Local).AddTicks(5014), "bla bla", "Los Vengadores" },
                    { 2, "Mike Newell", new DateTime(2025, 1, 18, 21, 40, 59, 116, DateTimeKind.Local).AddTicks(5023), "bla bla bla", "Harry Potter y el caliz de fuego" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "IdPelicula",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "IdPelicula",
                keyValue: 2);
        }
    }
}
