using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp1ControlePrestacoesServicos.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nomePropriedade = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
        }
    }
}
