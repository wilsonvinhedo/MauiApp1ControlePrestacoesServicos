using MauiApp1ControlePrestacoesServicos.Models;
using MauiApp1ControlePrestacoesServicos.ViewModels;

namespace MauiApp1ControlePrestacoesServicos.Views;

public partial class ClientesPage : ContentPage
{
    private readonly ClientesViewModel ViewModel;

    public ClientesPage() // ✅ Construtor correto: não tem tipo de retorno!
    {
        InitializeComponent();
        ViewModel = new ClientesViewModel();
        BindingContext = ViewModel;
    }

    private async void OnExcluirClicked(object sender, EventArgs e)
    {
        if (clientesCollection.SelectedItem is Cliente clienteSelecionado)
        {
            await ViewModel.ExcluirCliente(clienteSelecionado);
        }
    }
}
