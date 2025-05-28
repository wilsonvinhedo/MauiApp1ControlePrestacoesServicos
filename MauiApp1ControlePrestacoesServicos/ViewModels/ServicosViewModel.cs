using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiApp1ControlePrestacoesServicos.Models;
using Microsoft.Maui.Controls;

namespace MauiApp1ControlePrestacoesServicos.ViewModels
{
    public class ServicosViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Servico> Servicos { get; set; } = new();
        private Servico _servico = new();

        public Servico ServicoAtual
        {
            get => _servico;
            set { _servico = value; OnPropertyChanged(); }
        }

        public ICommand SalvarCommand { get; }
        public ICommand ExcluirCommand { get; }

        public ServicosViewModel()
        {
            SalvarCommand = new Command(async () => await Salvar());
            ExcluirCommand = new Command<Servico>(async (serv) => await Excluir(serv));
            _ = Carregar();
        }

        private async Task Carregar()
        {
            var lista = await App.Database.GetAllAsync<Servico>();
            Servicos.Clear();
            foreach (var item in lista)
                Servicos.Add(item);
        }

        private async Task Salvar()
        {
            await App.Database.SaveAsync(ServicoAtual);
            ServicoAtual = new Servico();
            await Carregar();
        }

        private async Task Excluir(Servico serv)
        {
            await App.Database.DeleteAsync(serv);
            await Carregar();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
