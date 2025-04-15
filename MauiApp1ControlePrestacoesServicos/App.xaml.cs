using MauiApp1ControlePrestacoesServicos.Database;
using System.Threading.Tasks;

namespace MauiApp1ControlePrestacoesServicos
{
    public partial class App : Application
    {
        public static DatabaseHelper Database { get; private set; }

        public App()
        {
            InitializeComponent();
        }

        public async Task InitializeAsync()
        {
            // Inicializa o banco de dados
            Database = new DatabaseHelper();
            await Database.InitializeAsync();

            // Não precisa mais atribuir MainPage aqui
            // A inicialização visual será feita no método CreateWindow()
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            return new Window(new MainPage());
        }
    }
}

