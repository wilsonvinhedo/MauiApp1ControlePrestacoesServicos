using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiAppControlePrestacoesServicos.Models;
using MauiAppControlePrestacoesServicos.Database;
using Microsoft.Maui.Controls;

namespace MauiAppControlePrestacoesServicos.ViewModels
{
    public class ServicoViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Servico> Servicos { get; set; } = new();
        private Servico _servico = new();

        public Servico ServicoAtual
        {
            get => _servico;
            set
            {
                _servico = value;
                OnPropertyChanged();
            }
        }

        public ICommand SalvarCommand { get; }
        public ICommand ExcluirCommand { get; }

        public ServicoViewModel()
        {
            SalvarCommand = new Command(async () => await SalvarServico());
            ExcluirCommand = new Command<Servico>(async (serv) => await ExcluirServico(serv));

            _ = CarregarServicos();
        }

        private async Task CarregarServicos()
        {
            var lista = await App.Database.GetAllAsync<Servico>();
            Servicos.Clear();
            foreach (var item in lista)
                Servicos.Add(item);
        }

        private async Task SalvarServico()
        {
            await App.Database.SaveAsync(ServicoAtual);
            ServicoAtual = new Servico();
            await CarregarServicos();
        }

        private async Task ExcluirServico(Servico serv)
        {
            await App.Database.DeleteAsync(serv);
            await CarregarServicos();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}