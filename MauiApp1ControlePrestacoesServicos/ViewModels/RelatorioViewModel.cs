using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MauiApp1ControlePrestacoesServicos.Models;

namespace MauiApp1ControlePrestacoesServicos.ViewModels
{
    public class RelatorioViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Servico> Servicos { get; set; } = new();

        public RelatorioViewModel()
        {
            _ = CarregarServicosAsync();
        }

        private async Task CarregarServicosAsync()
        {
            var lista = await App.Database.GetServicosAsync();
            Servicos.Clear();
            foreach (var servico in lista)
                Servicos.Add(servico);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string nome = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
    }
}
