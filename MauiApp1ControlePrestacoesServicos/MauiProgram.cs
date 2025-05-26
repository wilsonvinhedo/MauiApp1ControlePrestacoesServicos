using Microsoft.Extensions.Logging;
using MauiApp1ControlePrestacoesServicos.Database;

namespace MauiApp1ControlePrestacoesServicos;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Registrar o DatabaseHelper como um serviço singleton
        builder.Services.AddSingleton<DatabaseHelper>();

        // Registrar o AppShell como a página inicial
        builder.Services.AddSingleton<Shell>(s => new AppShell());

        return builder.Build();
    }
}