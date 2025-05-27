using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiAppControlePrestacoesServicos.Models;
using MauiAppControlePrestacoesServicos.Database;
using Microsoft.Maui.Controls;

namespace MauiAppControlePrestacoesServicos.ViewModels
{
    public class RelatorioViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Relatorio> Relatorios { get; set; } = new();
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

        public ICommand GerarRelatorioCommand { get; } // Comando específico para gerar relatórios
        public ICommand ExcluirCommand { get; }

        public RelatorioViewModel()
        {
            GerarRelatorioCommand = new Command(async () => await GerarRelatorio());
            ExcluirCommand = new Command<Relatorio>(async (rel) => await ExcluirRelatorio(rel));

            _ = CarregarRelatorios();
        }

        private async Task CarregarRelatorios()
        {
            var lista = await App.Database.GetAllAsync<Relatorio>();
            Relatorios.Clear();
            foreach (var item in lista)
                Relatorios.Add(item);
        }

        private async Task GerarRelatorio()
        {
            // Lógica específica para gerar um relatório (ex: preencher dados calculados)
            RelatorioAtual.DataGeracao = DateTime.Now; // Exemplo: define a data atual

            await App.Database.SaveAsync(RelatorioAtual);
            RelatorioAtual = new Relatorio(); // Reseta o formulário
            await CarregarRelatorios();
        }

        private async Task ExcluirRelatorio(Relatorio rel)
        {
            await App.Database.DeleteAsync(rel);
            await CarregarRelatorios();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}