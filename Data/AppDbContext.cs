using AlmacenesPorAhi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlmacenesPorAhi.Data;

// ============================================================================
// DbContext: AppDbContext
// ----------------------------------------------------------------------------
// Componente central de Entity Framework Core. Representa la sesion con la base
// de datos y traduce entre las clases C# (modelos) y las tablas de SQL Server.
// La configuracion del proveedor y la cadena de conexion se inyectan desde
// MauiProgram.cs, por lo que este contexto es independiente del motor.
// ============================================================================
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Tabla de productos.
    public DbSet<Producto> Productos => Set<Producto>();

    // Tabla de clientes.
    public DbSet<Cliente> Clientes => Set<Cliente>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Producto>().HasData(
            new Producto
            {
                Id = 1, Nombre = "Polera basica algodon", Descripcion = "Polera de algodon peinado, corte regular.",
                Categoria = "Poleras", Talla = "M", Color = "Blanco", Precio = 7990m, Stock = 25,
                Estado = "Activo", FechaRegistro = new DateTime(2024, 1, 15)
            },
            new Producto
            {
                Id = 2, Nombre = "Jeans recto clasico", Descripcion = "Jeans de mezclilla rigida, tiro medio.",
                Categoria = "Pantalones", Talla = "L", Color = "Azul", Precio = 19990m, Stock = 12,
                Estado = "Activo", FechaRegistro = new DateTime(2024, 2, 3)
            },
            new Producto
            {
                Id = 3, Nombre = "Chaqueta de cuero", Descripcion = "Chaqueta biker de cuero sintetico.",
                Categoria = "Abrigos", Talla = "L", Color = "Negro", Precio = 49990m, Stock = 5,
                Estado = "Activo", FechaRegistro = new DateTime(2024, 3, 20)
            },
            new Producto
            {
                Id = 4, Nombre = "Polera estampada", Descripcion = "Polera con estampado grafico edicion limitada.",
                Categoria = "Poleras", Talla = "S", Color = "Rojo", Precio = 9990m, Stock = 0,
                Estado = "Agotado", FechaRegistro = new DateTime(2024, 4, 10)
            },
            new Producto
            {
                Id = 5, Nombre = "Bufanda de lana", Descripcion = "Bufanda tejida, temporada anterior.",
                Categoria = "Accesorios", Talla = "M", Color = "Camel", Precio = 12990m, Stock = 8,
                Estado = "Descontinuado", FechaRegistro = new DateTime(2023, 11, 5)
            }
        );

        modelBuilder.Entity<Cliente>().HasData(
            new Cliente
            {
                Id = 1, Rut = "12.345.678-9", Nombre = "Maria", ApellidoPaterno = "Gonzalez",
                ApellidoMaterno = "Lopez", Telefono = "+56 9 1234 5678",
                Email = "maria.gonzalez@correo.cl", Direccion = "Av. Siempre Viva 742, Santiago",
                Preferencias = "Ropa de mujer, Accesorios",
                Estado = "Activo", FechaRegistro = new DateTime(2024, 1, 20)
            },
            new Cliente
            {
                Id = 2, Rut = "23.456.789-0", Nombre = "Carlos", ApellidoPaterno = "Muñoz",
                ApellidoMaterno = "Rojas", Telefono = "+56 9 2345 6789",
                Email = "carlos.munoz@correo.cl", Direccion = "Calle Los Olivos 154, Valparaiso",
                Preferencias = "Electronica, Deportes",
                Estado = "Activo", FechaRegistro = new DateTime(2024, 2, 14)
            },
            new Cliente
            {
                Id = 3, Rut = "34.567.890-1", Nombre = "Ana", ApellidoPaterno = "Lopez",
                Telefono = "+56 9 3456 7890",
                Email = "ana.lopez@correo.cl", Direccion = "Pasaje El Sol 890, Concepcion",
                Estado = "Activo", FechaRegistro = new DateTime(2024, 3, 8)
            },
            new Cliente
            {
                Id = 4, Rut = "45.678.901-2", Nombre = "Pedro", ApellidoPaterno = "Ramirez",
                Telefono = "+56 9 4567 8901",
                Estado = "Inactivo", FechaRegistro = new DateTime(2024, 4, 22)
            },
            new Cliente
            {
                Id = 5, Rut = "PT-123456", Nombre = "Sofia", ApellidoPaterno = "Torres",
                ApellidoMaterno = "Vargas", Telefono = "+56 9 5678 9012",
                Email = "sofia.torres@correo.cl", Direccion = "Av. Del Mar 321, Viña del Mar",
                Preferencias = "Libros, Musica",
                Estado = "Activo", FechaRegistro = new DateTime(2024, 5, 5)
            }
        );
    }
}
