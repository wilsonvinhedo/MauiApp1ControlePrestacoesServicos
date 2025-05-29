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
            var relatorio = await App.Database.GetItemsAsync<Relatorio>();
            relatorioCollection.ItemsSource = relatorio;
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
            LoadRelatorio();
        }

        private async void OnDeleteRelatorio(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var relatorio = swipeItem.BindingContext as Relatorio;

            if (relatorio != null)
            {
                await App.Database.DeleteItemAsync(relatorio);
                LoadRelatorio();
            }
        }
    }
}
