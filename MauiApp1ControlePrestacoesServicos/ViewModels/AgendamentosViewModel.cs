using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiApp1ControlePrestacoesServicos.Models;

namespace MauiApp1ControlePrestacoesServicos.ViewModels
{
    public class AgendamentosViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Agendamento> Agendamentos { get; set; } = new();
        private Agendamento _agendamento = new();

        public Agendamento AgendamentoAtual
        {
            get => _agendamento;
            set { _agendamento = value; OnPropertyChanged(); }
        }

        public ICommand SalvarCommand { get; }
        public ICommand ExcluirCommand { get; }

        public AgendamentosViewModel()
        {
            SalvarCommand = new Command(async () => await Salvar());
            ExcluirCommand = new Command<Agendamento>(async (age) => await Excluir(age));
            _ = Carregar();
        }

        private async Task Carregar()
        {
            var lista = await App.Database.GetAllAsync<Agendamento>();
            Agendamentos.Clear();
            foreach (var item in lista)
                Agendamentos.Add(item);
        }

        private async Task Salvar()
        {
            await App.Database.SaveAsync(AgendamentoAtual);
            AgendamentoAtual = new Agendamento();
            await Carregar();
        }

        private async Task Excluir(Agendamento age)
        {
            await App.Database.DeleteAsync(age);
            await Carregar();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
