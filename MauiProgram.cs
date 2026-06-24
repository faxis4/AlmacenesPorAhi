using System.Reflection;
using AlmacenesPorAhi.Data;
using AlmacenesPorAhi.Services;
using AlmacenesPorAhi.ViewModels;
using AlmacenesPorAhi.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;   // AddSingleton, AddTransient, AddDbContextFactory, GetRequiredService
using Microsoft.Extensions.Logging;
using Microsoft.Maui;                              // tipos base de MAUI
using Microsoft.Maui.Controls.Hosting;            // UseMauiApp<App>
using Microsoft.Maui.Hosting;                     // MauiApp, MauiAppBuilder, ConfigureFonts

namespace AlmacenesPorAhi;

// ============================================================================
// MauiProgram: punto de entrada y configuracion de la aplicacion.
// ----------------------------------------------------------------------------
// CreateMauiApp() se ejecuta una sola vez al iniciar. Aqui se configura:
//   1. La app base y sus fuentes.
//   2. La lectura de appsettings.json (de donde sale la cadena de conexion).
//   3. El contexto de base de datos (SQL Server) con esa cadena.
//   4. La inyeccion de dependencia: repositorio, servicio, ViewModels y vistas.
//   5. La aplicacion de migraciones EF Core para crear/actualizar la BD.
// ============================================================================
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        // 1. Aplicacion base y fuentes.
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // 2. Lectura de la configuracion externa (appsettings.json).
        // El archivo viaja embebido en el ejecutable; se busca por el final de
        // su nombre para que funcione aunque cambie el espacio de nombres.
        var ensamblado = Assembly.GetExecutingAssembly();
        var nombreRecurso = ensamblado
            .GetManifestResourceNames()
            .FirstOrDefault(n => n.EndsWith("appsettings.json", StringComparison.OrdinalIgnoreCase));

        if (nombreRecurso is not null)
        {
            using var stream = ensamblado.GetManifestResourceStream(nombreRecurso);
            if (stream is not null)
                builder.Configuration.AddJsonStream(stream);
        }

        // Se obtiene la cadena de conexion de SQL Server desde la configuracion.
        var cadenaSqlServer = builder.Configuration.GetConnectionString("SqlServer") ?? string.Empty;

        // 3. Registro del contexto de base de datos (Entity Framework Core).
        // Se usa una fabrica de DbContext: crea un contexto nuevo y de corta
        // vida por operacion, lo recomendado para MAUI.
        builder.Services.AddDbContextFactory<AppDbContext>(options =>
        {
            options.UseSqlServer(cadenaSqlServer);
        });

        // 4. Inyeccion de dependencia.
        // Servicios de negocio (usan el DbContext a traves de la fabrica).
        builder.Services.AddSingleton<IProductoService, ProductoService>();
        builder.Services.AddSingleton<IClienteService, ClienteService>();

        // ViewModels (uno nuevo por navegacion).
        builder.Services.AddTransient<MainMenuViewModel>();
        builder.Services.AddTransient<ProductoListViewModel>();
        builder.Services.AddTransient<ProductoFormViewModel>();
        builder.Services.AddTransient<ClienteListViewModel>();
        builder.Services.AddTransient<ClienteFormViewModel>();

        // Vistas (al registrarlas, el contenedor les inyecta su ViewModel).
        builder.Services.AddTransient<MainMenuPage>();
        builder.Services.AddTransient<ProductoListPage>();
        builder.Services.AddTransient<ProductoFormPage>();
        builder.Services.AddTransient<ClienteListPage>();
        builder.Services.AddTransient<ClienteFormPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();

        // 5. Inicializacion de la base de datos mediante migraciones.
        // IMPORTANTE: si el modelo cambia, se debe generar una nueva migracion
        // con Add-Migration y luego EF Core la aplicara con Migrate().
        InicializarBaseDeDatos(app.Services);

        return app;
    }

    private static void InicializarBaseDeDatos(IServiceProvider services)
    {
        try
        {
            var factory = services.GetRequiredService<IDbContextFactory<AppDbContext>>();
            using var db = factory.CreateDbContext();

            // NO usar EnsureCreated() cuando el proyecto trabaja con migraciones.
            // Migrate() crea la base si no existe y aplica solo las migraciones pendientes
            // registradas en la tabla __EFMigrationsHistory.
            db.Database.Migrate();
        }
        catch (Exception ex)
        {
            // Si la conexion o la migracion falla, se registra en la consola de depuracion.
            // La app no se cae: las pantallas muestran el error de forma controlada.
            System.Diagnostics.Debug.WriteLine(
                $"[Inicializacion BD] No se pudo migrar/conectar la base de datos: {ex.Message}");
        }
    }
}
