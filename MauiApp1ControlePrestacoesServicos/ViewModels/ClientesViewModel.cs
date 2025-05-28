using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiApp1ControlePrestacoesServicos.Models;
using MauiApp1ControlePrestacoesServicos.Database;
using Microsoft.Maui.Controls;

namespace MauiApp1ControlePrestacoesServicos.ViewModels
{
    public class ClienteViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Cliente> Clientes { get; set; } = new();
        private Cliente _cliente = new();

        public Cliente ClienteAtual
        {
            get => _cliente;
            set
            {
                _cliente = value;
                OnPropertyChanged();
            }
        }

        public ICommand SalvarCommand { get; }
        public ICommand ExcluirCommand { get; }

        public ClienteViewModel()
        {
            SalvarCommand = new Command(async () => await SalvarCliente());
            ExcluirCommand = new Command<Cliente>(async (cli) => await ExcluirCliente(cli));

            _ = CarregarClientes();
        }

        private async Task CarregarClientes()
        {
            var lista = await App.Database.GetAllAsync<Cliente>();
            Clientes.Clear();
            foreach (var item in lista)
                Clientes.Add(item);
        }

        private async Task SalvarCliente()
        {
            await App.Database.SaveAsync(ClienteAtual);
            ClienteAtual = new Cliente();
            await CarregarClientes();
        }

        private async Task ExcluirCliente(Cliente cli)
        {
            await App.Database.DeleteAsync(cli);
            await CarregarClientes();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
