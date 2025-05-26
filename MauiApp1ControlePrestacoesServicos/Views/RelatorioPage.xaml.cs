using MauiApp1ControlePrestacoesServicos.Models;

namespace MauiApp1ControlePrestacoesServicos.Views
{
    public partial class RelatoriosPage : ContentPage
    {
        public RelatoriosPage()
        {
            InitializeComponent();
            LoadRelatorios();
        }

        private async void LoadRelatorios()
        {
            var relatorios = await App.Database.GetItemsAsync<Relatorio>();
            relatoriosCollection.ItemsSource = relatorios;
        }

        private async void OnAddRelatorio(object sender, EventArgs e)
        {
            var relatorio = new Relatorio
            {
                Descricao = descricaoEntry.Text,
                Detalhes = detalhesEntry.Text
            };

            await App.Database.SaveItemAsync(relatorio);
            descricaoEntry.Text = detalhesEntry.Text = string.Empty;
            LoadRelatorios();
        }

        private async void OnDeleteRelatorio(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var relatorio = swipeItem.BindingContext as Relatorio;

            if (relatorio != null)
            {
                await App.Database.DeleteItemAsync(relatorio);
                LoadRelatorios();
            }
        }
    }
}
