using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmacenesPorAhi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Productos");
        }
    }
}
