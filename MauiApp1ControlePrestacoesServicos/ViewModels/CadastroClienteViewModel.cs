using MauiApp1ControlePrestacoesServicos.Models;
using MauiApp1ControlePrestacoesServicos.Database;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MauiApp1ControlePrestacoesServicos.ViewModels
{
    public class CadastroClienteViewModel : BaseViewModel
    {
        private readonly DatabaseHelper _databaseHelper;

        public ObservableCollection<Cliente> Clientes { get; set; } = new ObservableCollection<Cliente>();

        private Cliente _clienteSelecionado;
        public Cliente ClienteSelecionado
        {
            get => _clienteSelecionado;
            set
            {
                _clienteSelecionado = value;
                if (_clienteSelecionado != null)
                {
                    Nome = _clienteSelecionado.Nome;
                    Telefone = _clienteSelecionado.Telefone;
                    Email = _clienteSelecionado.Email;
                }
                OnPropertyChanged();
            }
        }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set { _nome = value; OnPropertyChanged(); }
        }

        private string _telefone;
        public string Telefone
        {
            get => _telefone;
            set { _telefone = value; OnPropertyChanged(); }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public ICommand SalvarCommand { get; }
        public ICommand ExcluirCommand { get; }

        public CadastroClienteViewModel()
        {
            _databaseHelper = new DatabaseHelper();
            SalvarCommand = new Command(async () => await SalvarClienteAsync());
            ExcluirCommand = new Command(async () => await ExcluirClienteAsync());

            _ = CarregarClientesAsync();
        }

        public async Task CarregarClientesAsync()
        {
            var lista = await _databaseHelper.GetClientesAsync();
            Clientes.Clear();
            foreach (var cliente in lista)
            {
                Clientes.Add(cliente);
            }
        }

        public async Task SalvarClienteAsync()
        {
            if (string.IsNullOrWhiteSpace(Nome) || string.IsNullOrWhiteSpace(Telefone) || string.IsNullOrWhiteSpace(Email))
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Preencha todos os campos.", "OK");
                return;
            }

            Cliente cliente;

            if (ClienteSelecionado != null && ClienteSelecionado.Id > 0)
            {
                // Atualizar cliente existente
                cliente = ClienteSelecionado;
                cliente.Nome = Nome;
                cliente.Telefone = Telefone;
                cliente.Email = Email;
            }
            else
            {
                // Criar novo cliente
                cliente = new Cliente
                {
                    Nome = Nome,
                    Telefone = Telefone,
                    Email = Email
                };
            }

            await _databaseHelper.SaveClienteAsync(cliente);
            await CarregarClientesAsync();

            // Limpa os campos
            Nome = Telefone = Email = string.Empty;
            ClienteSelecionado = null;
        }

        public async Task ExcluirClienteAsync()
        {
            if (ClienteSelecionado != null)
            {
                await _databaseHelper.DeleteClienteAsync(ClienteSelecionado);
                await CarregarClientesAsync();

                Nome = Telefone = Email = string.Empty;
                ClienteSelecionado = null;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "Selecione um cliente para excluir.", "OK");
            }
        }
    }
}
