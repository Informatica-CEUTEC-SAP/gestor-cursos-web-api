using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestorCursos.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEstudiante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    DepartamentoId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Estudiantes",
                columns: new[] { "Id", "DepartamentoId", "Email", "FechaNacimiento", "Nombre" },
                values: new object[,]
                {
                    { new Guid("1fd151d4-7623-4f7e-b4e9-c72bd313f5be"), new Guid("d8bc6149-5282-4f49-87bb-7f02603721f8"), "maria.lopez@example.com", new DateOnly(1995, 8, 20), "María López" },
                    { new Guid("dcc43a5f-c2a5-431d-9b5f-6d0791fdd3a0"), new Guid("bfbd6728-01f4-48f7-850c-eca831b2fb32"), "juan.perez@example.com", new DateOnly(1990, 5, 15), "Juan Pérez" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiantes");
        }
    }
}
