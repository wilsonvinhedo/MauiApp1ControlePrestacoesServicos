using SQLite;
using MauiAppControlePrestacoesServicos.Models;
using System.IO;
using System.Threading.Tasks;

namespace MauiAppControlePrestacoesServicos.Database
{
    public class DatabaseHelper
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseHelper()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "controleprestacoes.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _ = InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            await _database.CreateTableAsync<Cliente>();
            await _database.CreateTableAsync<Servico>();
            await _database.CreateTableAsync<Agendamento>();
            await _database.CreateTableAsync<Financeiro>();
        }

        // CRUD GENÉRICO
        public Task<List<T>> GetAllAsync<T>() where T : new()
            => _database.Table<T>().ToListAsync();

        public Task<int> SaveAsync<T>(T item) where T : new()
            => _database.InsertOrReplaceAsync(item);

        public Task<int> DeleteAsync<T>(T item) where T : new()
            => _database.DeleteAsync(item);
    }
}
