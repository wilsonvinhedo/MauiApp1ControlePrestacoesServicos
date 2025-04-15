using MauiApp1ControlePrestacoesServicos.Database;
using Microsoft.Maui.LifecycleEvents;

namespace MauiApp1ControlePrestacoesServicos
{
    public partial class App : Application
    {
        public static DatabaseHelper? Database { get; private set; }

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new MainPage());
            return window;
        }

        public async Task InitializeAsync()
        {
            Database = new DatabaseHelper();
            await Database.InitializeAsync();
        }
    }
}
using MauiApp1ControlePrestacoesServicos.Database;
using Microsoft.Maui.LifecycleEvents;

namespace MauiApp1ControlePrestacoesServicos
{
    public partial class App : Application
    {
        public static DatabaseHelper? Database { get; private set; }

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new MainPage());
            return window;
        }

        public async Task InitializeAsync()
        {
            Database = new DatabaseHelper();
            await Database.InitializeAsync();
        }
    }
}
