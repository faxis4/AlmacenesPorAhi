using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlmacenesPorAhi.Migrations
{
    /// <inheritdoc />
    public partial class SemillaClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Apellido", "Direccion", "Email", "Estado", "FechaRegistro", "Nombre", "NumeroDocumento", "Telefono", "TipoDocumento" },
                values: new object[,]
                {
                    { 1, "Gonzalez", "Av. Siempre Viva 742, Santiago", "maria.gonzalez@correo.cl", "Activo", new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria", "12.345.678-9", "+56 9 1234 5678", "RUT" },
                    { 2, "Muñoz", "Calle Los Olivos 154, Valparaiso", "carlos.munoz@correo.cl", "Activo", new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos", "23.456.789-0", "+56 9 2345 6789", "RUT" },
                    { 3, "Lopez", "Pasaje El Sol 890, Concepcion", "ana.lopez@correo.cl", "Activo", new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana", "34.567.890-1", "+56 9 3456 7890", "DNI" },
                    { 4, "Ramirez", null, null, "Inactivo", new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro", "45.678.901-2", "+56 9 4567 8901", "RUT" },
                    { 5, "Torres", "Av. Del Mar 321, Viña del Mar", "sofia.torres@correo.cl", "Activo", new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofia", "PT-123456", "+56 9 5678 9012", "Pasaporte" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
