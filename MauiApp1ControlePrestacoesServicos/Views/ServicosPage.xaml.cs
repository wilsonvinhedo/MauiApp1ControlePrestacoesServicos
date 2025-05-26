using MauiApp1ControlePrestacoesServicos.Models;

namespace MauiApp1ControlePrestacoesServicos.Views
{
    public partial class ServicosPage : ContentPage
    {
        public ServicosPage()
        {
            InitializeComponent();
            LoadServicos();
        }

        private async void LoadServicos()
        {
            var servicos = await App.Database.GetItemsAsync<Servico>();
            servicosCollection.ItemsSource = servicos;
        }

        private async void OnAddServico(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(descricaoEntry.Text))
            {
                var servico = new Servico
                {
                    Descricao = descricaoEntry.Text,
                    Valor = decimal.TryParse(valorEntry.Text, out var valor) ? valor : 0
                };

                await App.Database.SaveItemAsync(servico);
                descricaoEntry.Text = valorEntry.Text = string.Empty;
                LoadServicos();
            }
        }

        private async void OnDeleteServico(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var servico = swipeItem.BindingContext as Servico;

            if (servico != null)
            {
                await App.Database.DeleteItemAsync(servico);
                LoadServicos();
            }
        }
    }
}
