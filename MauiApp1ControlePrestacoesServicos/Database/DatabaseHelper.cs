using MauiApp1ControlePrestacoesServicos.Models;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MauiApp1ControlePrestacoesServicos.Database
{
    public class DatabaseHelper
    {
        private SQLiteAsyncConnection _database;
        private readonly string _dbPath;

        public DatabaseHelper()
        {
            _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "controleprestacoes.db3");
        }

        public async Task InitializeAsync()
        {
            if (_database == null)
            {
                _database = new SQLiteAsyncConnection(_dbPath);
                await _database.CreateTableAsync<Cliente>();
                await _database.CreateTableAsync<Servico>();
                await _database.CreateTableAsync<Agendamento>();
                await _database.CreateTableAsync<Financeiro>();
                await _database.CreateTableAsync<Relatorio>();
            }
        }

        // CRUD Clientes
        public Task<int> AddClienteAsync(Cliente cliente) => _database.InsertAsync(cliente);
        public Task<List<Cliente>> GetClientesAsync() => _database.Table<Cliente>().ToListAsync();
        public Task<int> UpdateClienteAsync(Cliente cliente) => _database.UpdateAsync(cliente);
        public Task<int> DeleteClienteAsync(Cliente cliente) => _database.DeleteAsync(cliente);

        // CRUD Serviços (exemplo)
        public Task<int> AddServicoAsync(Servico servico) => _database.InsertAsync(servico);
        public Task<List<Servico>> GetServicosAsync() => _database.Table<Servico>().ToListAsync();
        public Task<int> UpdateServicoAsync(Servico servico) => _database.UpdateAsync(servico);
        public Task<int> DeleteServicoAsync(Servico servico) => _database.DeleteAsync(servico);

        // Faça o mesmo para Agendamento, Financeiro e Relatorio
    }
}
