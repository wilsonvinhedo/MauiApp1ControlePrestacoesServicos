using MauiApp1ControlePrestacoesServicos.Database;

namespace MauiApp1ControlePrestacoesServicos
{
    public partial class App : Application
    {
        public static DatabaseHelper Database { get; private set; }

        public App()
        {
            InitializeComponent();

            Database = new DatabaseHelper();
            Database.InitializeAsync().Wait();  // Garante que o banco esteja pronto

            MainPage = new AppShell();  // Página inicial
        }
    }
}
