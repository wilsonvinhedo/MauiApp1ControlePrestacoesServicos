using MauiApp1ControlePrestacoesServicos.Models;

namespace MauiApp1ControlePrestacoesServicos.Views
{
    public partial class AgendamentosPage : ContentPage
    {
        public AgendamentosPage()
        {
            InitializeComponent();
            LoadAgendamentos();
        }

        private async void LoadAgendamentos()
        {
            var agendamentos = await App.Database.GetItemsAsync<Agendamento>();
            agendamentosCollection.ItemsSource = agendamentos;
        }

        private async void OnAddAgendamento(object sender, EventArgs e)
        {
            var agendamento = new Agendamento
            {
                ClienteId = int.TryParse(clienteIdEntry.Text, out var clienteId) ? clienteId : 0,
                ServicoId = int.TryParse(servicoIdEntry.Text, out var servicoId) ? servicoId : 0,
                Data = dataPicker.Date,
                Observacoes = obsEntry.Text
            };

            await App.Database.SaveItemAsync(agendamento);
            clienteIdEntry.Text = servicoIdEntry.Text = obsEntry.Text = string.Empty;
            LoadAgendamentos();
        }

        private async void OnDeleteAgendamento(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var agendamento = swipeItem.BindingContext as Agendamento;

            if (agendamento != null)
            {
                await App.Database.DeleteItemAsync(agendamento);
                LoadAgendamentos();
            }
        }
    }
}
