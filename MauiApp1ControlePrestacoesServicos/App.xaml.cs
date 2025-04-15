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

            MainPage = new MainPage(); // Cria a página principal
        }
    }
}
