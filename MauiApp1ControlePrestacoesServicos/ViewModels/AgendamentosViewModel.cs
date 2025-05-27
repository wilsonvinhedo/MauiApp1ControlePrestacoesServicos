using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiAppControlePrestacoesServicos.Models;
using MauiAppControlePrestacoesServicos.Database;
using Microsoft.Maui.Controls;

namespace MauiAppControlePrestacoesServicos.ViewModels
{
    public class AgendamentoViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Agendamento> Agendamentos { get; set; } = new();
        private Agendamento _agendamento = new();

        public Agendamento AgendamentoAtual
        {
            get => _agendamento;
            set
            {
                _agendamento = value;
                OnPropertyChanged();
            }
        }

        public ICommand SalvarCommand { get; }
        public ICommand ExcluirCommand { get; }

        public AgendamentoViewModel()
        {
            SalvarCommand = new Command(async () => await SalvarAgendamento());
            ExcluirCommand = new Command<Agendamento>(async (agend) => await ExcluirAgendamento(agend));

            _ = CarregarAgendamentos();
        }

        private async Task CarregarAgendamentos()
        {
            var lista = await App.Database.GetAllAsync<Agendamento>();
            Agendamentos.Clear();
            foreach (var item in lista)
                Agendamentos.Add(item);
        }

        private async Task SalvarAgendamento()
        {
            await App.Database.SaveAsync(AgendamentoAtual);
            AgendamentoAtual = new Agendamento();
            await CarregarAgendamentos();
        }

        private async Task ExcluirAgendamento(Agendamento agend)
        {
            await App.Database.DeleteAsync(agend);
            await CarregarAgendamentos();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}