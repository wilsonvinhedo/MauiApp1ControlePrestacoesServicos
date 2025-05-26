using MauiApp1ControlePrestacoesServicos.Models;

namespace MauiApp1ControlePrestacoesServicos.Views
{
    public partial class ClientesPage : ContentPage
    {
        public ClientesPage()
        {
            InitializeComponent();
            LoadClientes();
        }

        private async void LoadClientes()
        {
            var clientes = await App.Database.GetItemsAsync<Cliente>();
            clientesCollection.ItemsSource = clientes;
        }

        private async void OnAddCliente(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nomeEntry.Text))
            {
                var cliente = new Cliente
                {
                    Nome = nomeEntry.Text,
                    Telefone = telefoneEntry.Text
                };

                await App.Database.SaveItemAsync(cliente);
                nomeEntry.Text = telefoneEntry.Text = string.Empty;
                LoadClientes();
            }
        }

        private async void OnDeleteCliente(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var cliente = swipeItem.BindingContext as Cliente;

            if (cliente != null)
            {
                await App.Database.DeleteItemAsync(cliente);
                LoadClientes();
            }
        }
    }
}
