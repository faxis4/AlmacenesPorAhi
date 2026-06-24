using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmacenesPorAhi.Migrations
{
    /// <inheritdoc />
    public partial class ModeloClienteRubrica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroDocumento",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "TipoDocumento",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "Clientes",
                newName: "ApellidoPaterno");

            migrationBuilder.AddColumn<string>(
                name: "ApellidoMaterno",
                table: "Clientes",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Preferencias",
                table: "Clientes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rut",
                table: "Clientes",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApellidoMaterno", "Preferencias", "Rut" },
                values: new object[] { "Lopez", "Ropa de mujer, Accesorios", "12.345.678-9" });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApellidoMaterno", "Preferencias", "Rut" },
                values: new object[] { "Rojas", "Electronica, Deportes", "23.456.789-0" });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApellidoMaterno", "Preferencias", "Rut" },
                values: new object[] { null, null, "34.567.890-1" });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ApellidoMaterno", "Preferencias", "Rut" },
                values: new object[] { null, null, "45.678.901-2" });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ApellidoMaterno", "Preferencias", "Rut" },
                values: new object[] { "Vargas", "Libros, Musica", "PT-123456" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApellidoMaterno",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Preferencias",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Rut",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "ApellidoPaterno",
                table: "Clientes",
                newName: "Apellido");

            migrationBuilder.AddColumn<string>(
                name: "NumeroDocumento",
                table: "Clientes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoDocumento",
                table: "Clientes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NumeroDocumento", "TipoDocumento" },
                values: new object[] { "12.345.678-9", "RUT" });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NumeroDocumento", "TipoDocumento" },
                values: new object[] { "23.456.789-0", "RUT" });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NumeroDocumento", "TipoDocumento" },
                values: new object[] { "34.567.890-1", "DNI" });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "NumeroDocumento", "TipoDocumento" },
                values: new object[] { "45.678.901-2", "RUT" });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "NumeroDocumento", "TipoDocumento" },
                values: new object[] { "PT-123456", "Pasaporte" });
        }
    }
}
