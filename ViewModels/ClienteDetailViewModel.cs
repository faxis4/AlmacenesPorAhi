using AlmacenesPorAhi.Models;
using AlmacenesPorAhi.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace AlmacenesPorAhi.ViewModels;

[QueryProperty(nameof(ClienteId), "id")]
public partial class ClienteDetailViewModel : ObservableObject
{
    private readonly IClienteService _service;

    public ClienteDetailViewModel(IClienteService service)
    {
        _service = service;
    }

    [ObservableProperty]
    private int clienteId;

    partial void OnClienteIdChanged(int value)
    {
        if (value > 0)
            _ = CargarClienteAsync(value);
    }

    [ObservableProperty] private string rut = string.Empty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(NombreCompleto))]
    [NotifyPropertyChangedFor(nameof(Inicial))]
    private string nombre = string.Empty;
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(NombreCompleto))]
    private string apellidoPaterno = string.Empty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(NombreCompleto))]
    private string? apellidoMaterno;
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Emoji))]
    private string genero = string.Empty;
    [ObservableProperty] private string? email;
    [ObservableProperty] private string? telefono;
    [ObservableProperty] private string? direccion;
    [ObservableProperty] private string? preferencias;
    [ObservableProperty] private string estado = string.Empty;
    [ObservableProperty] private string titulo = "Cliente";

    public string NombreCompleto => $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}".Trim();

    public string Inicial => string.IsNullOrWhiteSpace(Nombre) ? "?" : Nombre[0].ToString();

    public string Emoji => Genero?.ToLower() switch
    {
        "mujer" => "👩",
        "hombre" => "👨",
        "otro" => "🧑",
        _ => "👤"
    };

    partial void OnGeneroChanged(string value) => OnPropertyChanged(nameof(Emoji));

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
        Titulo = c.NombreCompleto;
    }

    [RelayCommand]
    private async Task VolverAsync()
    {
        await Shell.Current.GoToAsync("..");
    }
}
