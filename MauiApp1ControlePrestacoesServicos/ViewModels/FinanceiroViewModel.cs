using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiApp1ControlePrestacoesServicos.Models;
using MauiApp1ControlePrestacoesServicos.Database;
using Microsoft.Maui.Controls;

namespace MauiApp1ControlePrestacoesServicos.ViewModels
{
    public class FinanceiroViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Financeiro> Financeiros { get; set; } = new();
        private Financeiro _financeiro = new();

        public Financeiro FinanceiroAtual
        {
            get => _financeiro;
            set
            {
                _financeiro = value;
                OnPropertyChanged();
            }
        }

        public ICommand SalvarCommand { get; }
        public ICommand ExcluirCommand { get; }

        public FinanceiroViewModel()
        {
            SalvarCommand = new Command(async () => await SalvarFinanceiro());
            ExcluirCommand = new Command<Financeiro>(async (financ) => await ExcluirFinanceiro(financ));

            _ = CarregarFinanceiros();
        }

        private async Task CarregarFinanceiros()
        {
            var lista = await App.Database.GetAllAsync<Financeiro>();
            Financeiros.Clear();
            foreach (var item in lista)
                Financeiros.Add(item);
        }

        private async Task SalvarFinanceiro()
        {
            await App.Database.SaveAsync(FinanceiroAtual);
            FinanceiroAtual = new Financeiro();
            await CarregarFinanceiros();
        }

        private async Task ExcluirFinanceiro(Financeiro financ)
        {
            await App.Database.DeleteAsync(financ);
            await CarregarFinanceiros();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}