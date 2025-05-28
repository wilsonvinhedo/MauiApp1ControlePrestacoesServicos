using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiApp1ControlePrestacoesServicos.Models;
using Microsoft.Maui.Controls;

namespace MauiApp1ControlePrestacoesServicos.ViewModels
{
    public class FinanceiroViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Financeiro> Lancamentos { get; set; } = new();
        private Financeiro _financeiro = new();

        public Financeiro LancamentoAtual
        {
            get => _financeiro;
            set { _financeiro = value; OnPropertyChanged(); }
        }

        public List<string> Tipos => new() { "Receita", "Despesa" };

        public ICommand SalvarCommand { get; }
        public ICommand ExcluirCommand { get; }

        public FinanceiroViewModel()
        {
            SalvarCommand = new Command(async () => await Salvar());
            ExcluirCommand = new Command<Financeiro>(async (fin) => await Excluir(fin));
            _ = Carregar();
        }

        private async Task Carregar()
        {
            var lista = await App.Database.GetAllAsync<Financeiro>();
            Lancamentos.Clear();
            foreach (var item in lista)
                Lancamentos.Add(item);
        }

        private async Task Salvar()
        {
            await App.Database.SaveAsync(LancamentoAtual);
            LancamentoAtual = new Financeiro();
            await Carregar();
        }

        private async Task Excluir(Financeiro fin)
        {
            await App.Database.DeleteAsync(fin);
            await Carregar();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
