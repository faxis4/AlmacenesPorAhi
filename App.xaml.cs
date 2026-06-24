using Microsoft.Maui.Controls;            // Application

namespace AlmacenesPorAhi;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Establece el AppShell como contenido raiz de la ventana.
        MainPage = new AppShell();
    }
}
