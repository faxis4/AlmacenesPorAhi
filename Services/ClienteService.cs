using System.Linq;
using AlmacenesPorAhi.Data;
using AlmacenesPorAhi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlmacenesPorAhi.Services;

public class ClienteService : IClienteService
{
    private readonly IDbContextFactory<AppDbContext> _dbFactory;

    public ClienteService(IDbContextFactory<AppDbContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<List<Cliente>> ObtenerTodosAsync()
    {
        using var db = await _dbFactory.CreateDbContextAsync();
        return await db.Clientes
            .AsNoTracking()
            .OrderBy(c => c.Nombre)
            .ThenBy(c => c.Apellido)
            .ToListAsync();
    }

    public async Task<Cliente?> ObtenerPorIdAsync(int id)
    {
        using var db = await _dbFactory.CreateDbContextAsync();
        return await db.Clientes.FindAsync(id);
    }

    public async Task AgregarAsync(Cliente cliente)
    {
        using var db = await _dbFactory.CreateDbContextAsync();
        db.Clientes.Add(cliente);
        await db.SaveChangesAsync();
    }

    public async Task ActualizarAsync(Cliente cliente)
    {
        using var db = await _dbFactory.CreateDbContextAsync();
        db.Clientes.Update(cliente);
        await db.SaveChangesAsync();
    }

    public async Task EliminarAsync(int id)
    {
        using var db = await _dbFactory.CreateDbContextAsync();
        var cliente = await db.Clientes.FindAsync(id);
        if (cliente is not null)
        {
            db.Clientes.Remove(cliente);
            await db.SaveChangesAsync();
        }
    }
}
