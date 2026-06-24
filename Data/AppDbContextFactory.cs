using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AlmacenesPorAhi.Data;

/// <summary>
/// Fabrica usada por las herramientas de EF Core en tiempo de diseno.
/// Permite ejecutar Add-Migration y Update-Database sin iniciar la app MAUI.
/// </summary>
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory();

        // Si el comando se ejecuta desde la carpeta de la solucion, buscamos
        // tambien dentro de la carpeta del proyecto MAUI.
        if (!File.Exists(Path.Combine(basePath, "appsettings.json")))
        {
            var possibleProjectPath = Path.Combine(basePath, "AlmacenesPorAhi");
            if (File.Exists(Path.Combine(possibleProjectPath, "appsettings.json")))
                basePath = possibleProjectPath;
        }

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var connectionString = configuration.GetConnectionString("SqlServer")
            ?? throw new InvalidOperationException("No se encontro la cadena de conexion 'SqlServer' en appsettings.json.");

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }
}
