using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiApp1ControlePrestacoesServicos.Models;
using Microsoft.Maui.Controls;

namespace MauiApp1ControlePrestacoesServicos.ViewModels
{
    public class CadastroAgendamentoViewModel : INotifyPropertyChanged
    {
        private Agendamento _agendamento = new();
        public Agendamento AgendamentoAtual
        {
            get => _agendamento;
            set { _agendamento = value; OnPropertyChanged(); }
        }

        public ICommand SalvarCommand { get; }

        public CadastroAgendamentoViewModel()
        {
            SalvarCommand = new Command(async () => await SalvarAgendamento());
        }

        private async Task SalvarAgendamento()
        {
            await App.Database.SaveAsync(AgendamentoAtual);
            AgendamentoAtual = new Agendamento();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}