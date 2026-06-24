using AlmacenesPorAhi.Helpers;
using AlmacenesPorAhi.Models;
using AlmacenesPorAhi.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace AlmacenesPorAhi.ViewModels;

[QueryProperty(nameof(ClienteId), "id")]
[QueryProperty(nameof(ModoLectura), "ver")]
public partial class ClienteFormViewModel : ObservableObject
{
    private readonly IClienteService _service;

    private DateTime _fechaRegistro = DateTime.Now;

    public ClienteFormViewModel(IClienteService service)
    {
        _service = service;
    }

    public List<string> TiposDocumento { get; } = new() { "RUT", "DNI", "Pasaporte", "Cedula" };
    public List<string> Estados { get; } = new() { "Activo", "Inactivo" };

    [ObservableProperty]
    private int clienteId;

    partial void OnClienteIdChanged(int value)
    {
        if (value > 0)
            _ = CargarClienteAsync(value);
    }

    [ObservableProperty]
    private bool modoLectura;

    partial void OnModoLecturaChanged(bool value)
    {
        if (value && ClienteId > 0)
            Titulo = "Ver Cliente";
    }

    public bool ModoEdicion => !ModoLectura;

    [ObservableProperty] private string nombre = string.Empty;
    [ObservableProperty] private string apellido = string.Empty;
    [ObservableProperty] private string? numeroDocumento;
    [ObservableProperty] private string? tipoDocumento;
    [ObservableProperty] private string? telefono;
    [ObservableProperty] private string? email;
    [ObservableProperty] private string? direccion;
    [ObservableProperty] private string estado = "Activo";

    [ObservableProperty] private string titulo = "Nuevo Cliente";

    private async Task CargarClienteAsync(int id)
    {
        var c = await _service.ObtenerPorIdAsync(id);
        if (c is null) return;

        Nombre = c.Nombre;
        Apellido = c.Apellido;
        NumeroDocumento = c.NumeroDocumento;
        TipoDocumento = c.TipoDocumento;
        Telefono = c.Telefono;
        Email = c.Email;
        Direccion = c.Direccion;
        Estado = c.Estado;
        _fechaRegistro = c.FechaRegistro;
        Titulo = "Editar Cliente";
    }

    [RelayCommand]
    private async Task GuardarAsync()
    {
        if (string.IsNullOrWhiteSpace(Nombre))
        {
            await Shell.Current.DisplayAlert("Validacion", "El nombre es obligatorio.", "Aceptar");
            return;
        }
        if (string.IsNullOrWhiteSpace(Apellido))
        {
            await Shell.Current.DisplayAlert("Validacion", "El apellido es obligatorio.", "Aceptar");
            return;
        }

        var cliente = new Cliente
        {
            Id = ClienteId,
            Nombre = Nombre.Trim(),
            Apellido = Apellido.Trim(),
            NumeroDocumento = NumeroDocumento?.Trim(),
            TipoDocumento = TipoDocumento,
            Telefono = Telefono?.Trim(),
            Email = Email?.Trim(),
            Direccion = Direccion?.Trim(),
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
