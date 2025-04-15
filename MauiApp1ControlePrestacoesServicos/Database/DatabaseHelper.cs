using MauiApp1ControlePrestacoesServicos.Models;
using SQLite;
using System.IO;
using System.Threading.Tasks;

namespace MauiApp1ControlePrestacoesServicos.Database
{
    public class DatabaseHelper
    {
        private SQLiteAsyncConnection _database;
        private readonly string _dbPath;

        public DatabaseHelper()
        {
            // Definir o caminho do banco de dados SQLite
            _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "controleprestacoes.db3");
        }

        public async Task InitializeAsync()
        {
            if (_database == null)
            {
                // Inicializa a conexão com o banco de dados SQLite
                _database = new SQLiteAsyncConnection(_dbPath);

                // Cria as tabelas se não existirem
                await _database.CreateTableAsync<Cliente>();
                await _database.CreateTableAsync<Servico>();
                // Adicione aqui outras tabelas conforme necessário
            }
        }

        // Outros métodos para manipulação do banco de dados, como Insert, Update, etc.
    }
}
