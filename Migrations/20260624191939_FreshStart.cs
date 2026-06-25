using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlmacenesPorAhi.Migrations
{
    /// <inheritdoc />
    public partial class FreshStart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rut = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Preferencias = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Talla = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "ApellidoMaterno", "ApellidoPaterno", "Direccion", "Email", "Estado", "FechaRegistro", "Genero", "Nombre", "Preferencias", "Rut", "Telefono" },
                values: new object[,]
                {
                    { 1, "Lopez", "Gonzalez", "Av. Siempre Viva 742, Santiago", "maria.gonzalez@correo.cl", "Activo", new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Maria", "Ropa de mujer, Accesorios", "12.345.678-9", "+56 9 1234 5678" },
                    { 2, "Rojas", "Muñoz", "Calle Los Olivos 154, Valparaiso", "carlos.munoz@correo.cl", "Activo", new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Carlos", "Electronica, Deportes", "23.456.789-0", "+56 9 2345 6789" },
                    { 3, null, "Lopez", "Pasaje El Sol 890, Concepcion", "ana.lopez@correo.cl", "Activo", new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Ana", null, "34.567.890-1", "+56 9 3456 7890" },
                    { 4, null, "Ramirez", null, null, "Inactivo", new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Pedro", null, "45.678.901-2", "+56 9 4567 8901" },
                    { 5, "Vargas", "Torres", "Av. Del Mar 321, Viña del Mar", "sofia.torres@correo.cl", "Activo", new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Sofia", "Libros, Musica", "PT-123456", "+56 9 5678 9012" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Categoria", "Color", "Descripcion", "Estado", "FechaRegistro", "ImagenUrl", "Nombre", "Precio", "Stock", "Talla" },
                values: new object[,]
                {
                    { 1, "Poleras", "Blanco", "Polera de algodon peinado, corte regular.", "Activo", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Polera basica algodon", 7990m, 25, "M" },
                    { 2, "Pantalones", "Azul", "Jeans de mezclilla rigida, tiro medio.", "Activo", new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jeans recto clasico", 19990m, 12, "L" },
                    { 3, "Abrigos", "Negro", "Chaqueta biker de cuero sintetico.", "Activo", new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chaqueta de cuero", 49990m, 5, "L" },
                    { 4, "Poleras", "Rojo", "Polera con estampado grafico edicion limitada.", "Agotado", new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Polera estampada", 9990m, 0, "S" },
                    { 5, "Accesorios", "Camel", "Bufanda tejida, temporada anterior.", "Descontinuado", new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bufanda de lana", 12990m, 8, "M" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
