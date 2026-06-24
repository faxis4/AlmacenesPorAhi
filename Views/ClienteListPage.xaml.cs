using AlmacenesPorAhi.ViewModels;
using Microsoft.Maui.Controls;

namespace AlmacenesPorAhi.Views;

public partial class ClienteListPage : ContentPage
{
    private readonly ClienteListViewModel _vm;

    public ClienteListPage(ClienteListViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.CargarCommand.ExecuteAsync(null);
    }
}
