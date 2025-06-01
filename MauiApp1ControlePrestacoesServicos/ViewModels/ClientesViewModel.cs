using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiApp1ControlePrestacoesServicos.Models;
using Microsoft.Maui.Controls;

namespace MauiApp1ControlePrestacoesServicos.ViewModels
{
    public class ClientesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Cliente> Clientes { get; set; } = new();
        private Cliente _cliente = new();

        public Cliente ClienteAtual
        {
            get => _cliente;
            set { _cliente = value; OnPropertyChanged(); }
        }

        public ICommand SalvarCommand { get; }
        public ICommand ExcluirCommand { get; }

        public ClientesViewModel()
        {
            SalvarCommand = new Command(async () => await Salvar());
            ExcluirCommand = new Command<Cliente>(async (cli) => await Excluir(cli));
            _ = Carregar();
        }

        private async Task Carregar()
        {
            var lista = await App.Database.GetAllAsync<Cliente>();
            Clientes.Clear();
            foreach (var item in lista)
                Clientes.Add(item);
        }

        private async Task Salvar()
        {
            await App.Database.SaveAsync(ClienteAtual);
            ClienteAtual = new Cliente();
            await Carregar();
        }

        private async Task Excluir(Cliente cli)
        {
            await App.Database.DeleteAsync(cli);
            await Carregar();
        }

        internal async Task ExcluirCliente(Cliente clienteSelecionado)
        {
            if (clienteSelecionado == null) return;

            await App.Database.DeleteAsync(clienteSelecionado);
            await Carregar();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
