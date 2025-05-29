using MauiApp1ControlePrestacoesServicos.Database;

namespace MauiApp1ControlePrestacoesServicos;

public partial class App : Application
{
    private static DatabaseHelper? _database;
    public static DatabaseHelper Database => _database ??= new DatabaseHelper();

    public App()
    {
        InitializeComponent(); // Este método é gerado automaticamente
        MainPage = new AppShell();
    }
}