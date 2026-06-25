using AlmacenesPorAhi.ViewModels;

namespace AlmacenesPorAhi.Views;

public partial class ProductoDetailPage : ContentPage
{
    public ProductoDetailPage(ProductoDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
