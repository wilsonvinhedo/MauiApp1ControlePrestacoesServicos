using MauiApp1ControlePrestacoesServicos.Models;

namespace MauiApp1ControlePrestacoesServicos.Views
{
    public partial class FinanceiroPage : ContentPage
    {
        public FinanceiroPage()
        {
            InitializeComponent();
            LoadFinanceiro();
        }

        private async void LoadFinanceiro()
        {
            var registros = await App.Database.GetItemsAsync<Financeiro>();
            financeiroCollection.ItemsSource = registros;
        }

        private async void OnAddFinanceiro(object sender, EventArgs e)
        {
            var financeiro = new Financeiro
            {
                Descricao = descricaoEntry.Text,
                Valor = decimal.TryParse(valorEntry.Text, out var valor) ? valor : 0,
                Data = dataPicker.Date,
                Pago = pagoSwitch.IsToggled
            };

            await App.Database.SaveItemAsync(financeiro);
            descricaoEntry.Text = valorEntry.Text = string.Empty;
            pagoSwitch.IsToggled = false;
            LoadFinanceiro();
        }

        private async void OnDeleteFinanceiro(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var registro = swipeItem.BindingContext as Financeiro;

            if (registro != null)
            {
                await App.Database.DeleteItemAsync(registro);
                LoadFinanceiro();
            }
        }
    }
}
