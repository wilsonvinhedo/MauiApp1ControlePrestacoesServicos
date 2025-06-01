using MauiApp1ControlePrestacoesServicos.Models;

namespace MauiApp1ControlePrestacoesServicos.Views;

public partial class ClientesPage : ContentPage
{
    public ClientesPage()
    {
        InitializeComponent();
    }

    private async void OnExcluirClicked(object sender, EventArgs e)
    {
        if (clientesCollection.SelectedItem is Cliente clienteSelecionado)
        {
            if (BindingContext is ViewModels.ClientesViewModel vm)
            {
                await vm.ExcluirCliente(clienteSelecionado);
            }
        }
    }
}
