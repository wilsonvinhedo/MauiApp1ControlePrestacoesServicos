namespace MauiAppControlePrestacoesServicos;

public partial class App : Application
{
    public static Database.DatabaseHelper Database { get; private set; }

    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
        Database = new Database.DatabaseHelper();
    }
}
