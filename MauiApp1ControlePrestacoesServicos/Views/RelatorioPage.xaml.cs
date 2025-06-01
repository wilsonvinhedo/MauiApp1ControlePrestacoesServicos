using MauiApp1ControlePrestacoesServicos.Models;

namespace MauiApp1ControlePrestacoesServicos.Views
{
    public partial class RelatorioPage : ContentPage
    {
        public RelatorioPage()
        {
            InitializeComponent();
            LoadRelatorio();
        }

        private async void LoadRelatorio()
        {
            try
            {
                // Pega todos os serviços cadastrados no banco
                var servicos = await App.Database.GetItemsAsync<Servico>();
                relatorioCollection.ItemsSource = servicos;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Erro ao carregar relatório: {ex.Message}", "OK");
            }
        }
    }
}
