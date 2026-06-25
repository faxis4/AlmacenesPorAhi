using AlmacenesPorAhi.Views;
using Microsoft.Maui.Controls;

namespace AlmacenesPorAhi;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(ProductoListPage), typeof(ProductoListPage));
        Routing.RegisterRoute(nameof(ProductoFormPage), typeof(ProductoFormPage));
        Routing.RegisterRoute(nameof(ProductoDetailPage), typeof(ProductoDetailPage));
        Routing.RegisterRoute(nameof(ClienteListPage), typeof(ClienteListPage));
        Routing.RegisterRoute(nameof(ClienteFormPage), typeof(ClienteFormPage));
        Routing.RegisterRoute(nameof(ClienteDetailPage), typeof(ClienteDetailPage));
    }
}
