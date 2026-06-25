using AlmacenesPorAhi.Models;
using AlmacenesPorAhi.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace AlmacenesPorAhi.ViewModels;

[QueryProperty(nameof(ProductoId), "id")]
public partial class ProductoDetailViewModel : ObservableObject
{
    private readonly IProductoService _service;

    public ProductoDetailViewModel(IProductoService service)
    {
        _service = service;
    }

    [ObservableProperty]
    private int productoId;

    partial void OnProductoIdChanged(int value)
    {
        if (value > 0)
            _ = CargarProductoAsync(value);
    }

    [ObservableProperty] private string nombre = string.Empty;
    [ObservableProperty] private string? descripcion;
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Emoji))]
    private string categoria = string.Empty;
    [ObservableProperty] private string talla = string.Empty;
    [ObservableProperty] private string color = string.Empty;
    [ObservableProperty] private decimal precio;
    [ObservableProperty] private int stock;
    [ObservableProperty] private string estado = string.Empty;
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TieneImagen))]
    private string? imagenUrl;

    [ObservableProperty] private string titulo = "Producto";

    public bool TieneImagen => !string.IsNullOrWhiteSpace(ImagenUrl);

    public string Emoji => Categoria?.ToLower() switch
    {
        "poleras" => "👕",
        "pantalones" => "👖",
        "abrigos" => "🧥",
        "accesorios" => "🧣",
        "zapatos" => "👟",
        "gorras" => "🧢",
        "vestidos" => "👗",
        "trajes" => "👔",
        "deportes" => "⚽",
        _ => "🛍️"
    };

    private async Task CargarProductoAsync(int id)
    {
        var p = await _service.ObtenerPorIdAsync(id);
        if (p is null) return;

        Nombre = p.Nombre;
        Descripcion = p.Descripcion;
        Categoria = p.Categoria;
        Talla = p.Talla;
        Color = p.Color;
        Precio = p.Precio;
        Stock = p.Stock;
        Estado = p.Estado;
        ImagenUrl = p.ImagenUrl;
        Titulo = p.Nombre;
    }

    [RelayCommand]
    private async Task VolverAsync()
    {
        await Shell.Current.GoToAsync("..");
    }
}
