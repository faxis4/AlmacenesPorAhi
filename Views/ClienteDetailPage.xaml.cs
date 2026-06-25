using AlmacenesPorAhi.ViewModels;

namespace AlmacenesPorAhi.Views;

public partial class ClienteDetailPage : ContentPage
{
    public ClienteDetailPage(ClienteDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
