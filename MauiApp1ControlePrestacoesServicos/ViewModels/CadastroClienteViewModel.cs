using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiApp1ControlePrestacoesServicos.Models;
using MauiApp1ControlePrestacoesServicos.Database;
using Microsoft.Maui.Controls;

namespace MauiApp1ControlePrestacoesServicos.ViewModels
{
    public class CadastroClienteViewModel : INotifyPropertyChanged
    {
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

        public CadastroClienteViewModel()
        {
            SalvarCommand = new Command(async () => await SalvarCliente());
        }

        private async Task SalvarCliente()
        {
            await App.Database.SaveAsync(ClienteAtual);
            ClienteAtual = new Cliente(); // Limpa formulário
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
