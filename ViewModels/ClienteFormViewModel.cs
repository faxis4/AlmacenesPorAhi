using AlmacenesPorAhi.Helpers;
using AlmacenesPorAhi.Models;
using AlmacenesPorAhi.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace AlmacenesPorAhi.ViewModels;

[QueryProperty(nameof(ClienteId), "id")]
public partial class ClienteFormViewModel : ObservableObject
{
    private readonly IClienteService _service;

    private DateTime _fechaRegistro = DateTime.Now;

    public ClienteFormViewModel(IClienteService service)
    {
        _service = service;
    }

    public List<string> Generos { get; } = new() { "Mujer", "Hombre", "Otro" };
    public List<string> Estados { get; } = new() { "Activo", "Inactivo" };

    [ObservableProperty]
    private int clienteId;

    partial void OnClienteIdChanged(int value)
    {
        if (value > 0)
            _ = CargarClienteAsync(value);
    }

    public bool ModoLectura => false;
    public bool ModoEdicion => true;

    [ObservableProperty] private string rut = string.Empty;
    [ObservableProperty] private string nombre = string.Empty;
    [ObservableProperty] private string apellidoPaterno = string.Empty;
    [ObservableProperty] private string? apellidoMaterno;
    [ObservableProperty] private string genero = string.Empty;
    [ObservableProperty] private string? email;
    [ObservableProperty] private string? telefono;
    [ObservableProperty] private string? direccion;
    [ObservableProperty] private string? preferencias;
    [ObservableProperty] private string estado = "Activo";

    [ObservableProperty] private string titulo = "Nuevo Cliente";

    private async Task CargarClienteAsync(int id)
    {
        var c = await _service.ObtenerPorIdAsync(id);
        if (c is null) return;

        Rut = c.Rut;
        Nombre = c.Nombre;
        ApellidoPaterno = c.ApellidoPaterno;
        Genero = c.Genero;
        ApellidoMaterno = c.ApellidoMaterno;
        Email = c.Email;
        Telefono = c.Telefono;
        Direccion = c.Direccion;
        Preferencias = c.Preferencias;
        Estado = c.Estado;
        _fechaRegistro = c.FechaRegistro;
        Titulo = "Editar Cliente";
    }

    [RelayCommand]
    private async Task GuardarAsync()
    {
        if (string.IsNullOrWhiteSpace(Rut))
        {
            await Shell.Current.DisplayAlert("Validacion", "El RUT es obligatorio.", "Aceptar");
            return;
        }
        if (string.IsNullOrWhiteSpace(Nombre))
        {
            await Shell.Current.DisplayAlert("Validacion", "El nombre es obligatorio.", "Aceptar");
            return;
        }
        if (string.IsNullOrWhiteSpace(ApellidoPaterno))
        {
            await Shell.Current.DisplayAlert("Validacion", "El apellido paterno es obligatorio.", "Aceptar");
            return;
        }

        var cliente = new Cliente
        {
            Id = ClienteId,
            Rut = Rut.Trim(),
            Nombre = Nombre.Trim(),
            ApellidoPaterno = ApellidoPaterno.Trim(),
            Genero = Genero,
            ApellidoMaterno = ApellidoMaterno?.Trim(),
            Email = Email?.Trim(),
            Telefono = Telefono?.Trim(),
            Direccion = Direccion?.Trim(),
            Preferencias = Preferencias?.Trim(),
            Estado = Estado,
            FechaRegistro = ClienteId == 0 ? DateTime.Now : _fechaRegistro
        };

        try
        {
            if (ClienteId == 0)
                await _service.AgregarAsync(cliente);
            else
                await _service.ActualizarAsync(cliente);

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ErroresBaseDatos.Describir(ex), "Aceptar");
        }
    }

    [RelayCommand]
    private async Task CancelarAsync()
    {
        await Shell.Current.GoToAsync("..");
    }
}
