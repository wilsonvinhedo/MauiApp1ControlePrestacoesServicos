using System.Threading.Tasks;
using MauiApp1ControlePrestacoesServicos.Database;

namespace ControlePrestacoesServicos
{
    public partial class App : Application
    {
        public static DatabaseHelper Database { get; private set; }
        public App()
        {
            InitializeComponent();
            Database = new DatabaseHelper();
            // Inicializa o banco (pode ser aguardado conforme necessidade)
            Task.Run(async () => await Database.InitializeAsync());
            MainPage = new AppShell();
        }
    }
}
