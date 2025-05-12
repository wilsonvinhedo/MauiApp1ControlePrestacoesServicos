using Microsoft.Maui.Controls;
using MauiApp1ControlePrestacoesServicos.Database;

namespace MauiApp1ControlePrestacoesServicos
{
    public partial class App : Application
    {
        public static MauiApp1ControlePrestacoesServicos.Database.DatabaseHelper Database { get; private set; }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell(); // Isso define o AppShell como a página inicial
            Database = new MauiApp1ControlePrestacoesServicos.Database.DatabaseHelper();
            _ = Database.InitializeAsync();
        }
    }
}