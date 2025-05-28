using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiApp1ControlePrestacoesServicos.Models;
using MauiApp1ControlePrestacoesServicos.Database;
using Microsoft.Maui.Controls;

namespace MauiApp1ControlePrestacoesServicos.ViewModels
{
    public class CadastroFinanceiroViewModel : INotifyPropertyChanged
    {
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

        public ObservableCollection<string> Tipos { get; set; } = new() { "Receita", "Despesa" };

        public ICommand SalvarCommand { get; }

        public CadastroFinanceiroViewModel()
        {
            SalvarCommand = new Command(async () => await SalvarFinanceiro());
        }

        private async Task SalvarFinanceiro()
        {
            await App.Database.SaveAsync(FinanceiroAtual);
            FinanceiroAtual = new Financeiro();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
