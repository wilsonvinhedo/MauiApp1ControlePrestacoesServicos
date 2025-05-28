using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiApp1ControlePrestacoesServicos.Models;
using Microsoft.Maui.Controls;

namespace MauiApp1ControlePrestacoesServicos.ViewModels
{
    public class CadastroServicoViewModel : INotifyPropertyChanged
    {
        private Servico _servico = new();
        public Servico ServicoAtual
        {
            get => _servico;
            set { _servico = value; OnPropertyChanged(); }
        }

        public ICommand SalvarCommand { get; }

        public CadastroServicoViewModel()
        {
            SalvarCommand = new Command(async () => await SalvarServico());
        }

        private async Task SalvarServico()
        {
            await App.Database.SaveAsync(ServicoAtual);
            ServicoAtual = new Servico();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
