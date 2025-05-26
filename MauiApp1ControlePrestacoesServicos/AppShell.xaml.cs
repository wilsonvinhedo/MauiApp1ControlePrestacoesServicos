using MauiApp1ControlePrestacoesServicos.Views;
using Microsoft.Extensions.DependencyInjection;
using MauiApp1ControlePrestacoesServicos.Database;

namespace MauiApp1ControlePrestacoesServicos;

public partial class AppShell : Shell
{
    private readonly DatabaseHelper _database;

    public AppShell()
    {
        _database = MauiProgram.CreateMauiApp().Services.GetService<DatabaseHelper>();
        InitializeComponent();
        Routing.RegisterRoute(nameof(ClientesPage), typeof(ClientesPage));
        Routing.RegisterRoute(nameof(ServicosPage), typeof(ServicosPage));
        Routing.RegisterRoute(nameof(AgendamentosPage), typeof(AgendamentosPage));
        Routing.RegisterRoute(nameof(FinanceiroPage), typeof(FinanceiroPage));
        Routing.RegisterRoute(nameof(RelatorioPage), typeof(RelatorioPage));

        // Define a página inicial
        GoToAsync("//ClientesPage");
    }
}