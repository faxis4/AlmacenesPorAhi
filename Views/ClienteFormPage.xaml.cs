using AlmacenesPorAhi.ViewModels;
using Microsoft.Maui.Controls;

namespace AlmacenesPorAhi.Views;

public partial class ClienteFormPage : ContentPage
{
    public ClienteFormPage(ClienteFormViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
