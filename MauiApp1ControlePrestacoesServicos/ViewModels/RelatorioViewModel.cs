using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiApp1ControlePrestacoesServicos.Models;
using Microsoft.Maui.Controls;

namespace MauiApp1ControlePrestacoesServicos.ViewModels
{
    public class RelatorioViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Relatorio> Relatorio { get; set; } = new();
        private Relatorio _relatorio = new();

        public Relatorio RelatorioAtual
        {
            get => _relatorio;
            set
            {
                _relatorio = value;
                OnPropertyChanged();
            }
        }

        public ICommand GerarRelatorioCommand { get; }
        public ICommand ExcluirCommand { get; }

        public RelatorioViewModel()
        {
            GerarRelatorioCommand = new Command(async () => await GerarRelatorio());
            ExcluirCommand = new Command<Relatorio>(async (rel) => await ExcluirRelatorio(rel));

            _ = CarregarRelatorio();
        }

        private async Task CarregarRelatorio()
        {
            var lista = await App.Database.GetRelatoriosAsync();
            Relatorio.Clear();
            foreach (var item in lista)
                Relatorio.Add(item);
        }

        private async Task GerarRelatorio()
        {
            RelatorioAtual.DataGeracao = DateTime.Now;

            await App.Database.SaveRelatorioAsync(RelatorioAtual);
            RelatorioAtual = new Relatorio();
            await CarregarRelatorio();
        }

        private async Task ExcluirRelatorio(Relatorio rel)
        {
            await App.Database.DeleteRelatorioAsync(rel); // Este método precisa ser criado
            await CarregarRelatorio();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
