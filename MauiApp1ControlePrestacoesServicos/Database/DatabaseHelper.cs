using SQLite;
using MauiApp1ControlePrestacoesServicos.Models;
using System.IO;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace MauiApp1ControlePrestacoesServicos.Database
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
            await _database.CreateTableAsync<Relatorio>();
        }

        // Métodos genéricos
        public Task<List<T>> GetAllAsync<T>() where T : new() => _database.Table<T>().ToListAsync();
        public Task<int> SaveAsync<T>(T item) where T : new() => _database.InsertOrReplaceAsync(item);
        public Task<int> DeleteAsync<T>(T item) where T : new() => _database.DeleteAsync(item);

        // Métodos específicos
        public Task<List<Cliente>> GetClientesAsync() => _database.Table<Cliente>().ToListAsync();
        public Task<int> SaveClienteAsync(Cliente item) => _database.InsertOrReplaceAsync(item);
        public Task<int> DeleteClienteAsync(Cliente item) => _database.DeleteAsync(item);

        public Task<List<Servico>> GetServicosAsync() => _database.Table<Servico>().ToListAsync();
        public Task<int> SaveServicoAsync(Servico item) => _database.InsertOrReplaceAsync(item);
        public Task<int> DeleteServicoAsync(Servico item) => _database.DeleteAsync(item);

        public Task<List<Agendamento>> GetAgendamentosAsync() => _database.Table<Agendamento>().ToListAsync();
        public Task<int> SaveAgendamentoAsync(Agendamento item) => _database.InsertOrReplaceAsync(item);
        public Task<int> DeleteAgendamentoAsync(Agendamento item) => _database.DeleteAsync(item);

        public Task<List<Financeiro>> GetFinanceirosAsync() => _database.Table<Financeiro>().ToListAsync();
        public Task<int> SaveFinanceiroAsync(Financeiro item) => _database.InsertOrReplaceAsync(item);
        public Task<int> DeleteFinanceiroAsync(Financeiro item) => _database.DeleteAsync(item);

        public Task<List<Relatorio>> GetRelatoriosAsync() => _database.Table<Relatorio>().ToListAsync();
        public Task<int> SaveRelatorioAsync(Relatorio item) => _database.InsertOrReplaceAsync(item);
        public Task<int> DeleteRelatorioAsync(Relatorio item) => _database.DeleteAsync(item);

        // Implementação dos métodos internos que estavam lançando exceção
        internal async Task<IEnumerable> GetItemsAsync<T>() where T : new()
        {
            return await _database.Table<T>().ToListAsync();
        }

        internal async Task SaveItemAsync(Cliente cliente)
        {
            await _database.InsertOrReplaceAsync(cliente);
        }

        internal async Task DeleteItemAsync(Cliente cliente)
        {
            await _database.DeleteAsync(cliente);
        }

        internal async Task SaveItemAsync(Servico servico)
        {
            await _database.InsertOrReplaceAsync(servico);
        }

        internal async Task DeleteItemAsync(Servico servico)
        {
            await _database.DeleteAsync(servico);
        }

        internal async Task SaveItemAsync(Agendamento agendamento)
        {
            await _database.InsertOrReplaceAsync(agendamento);
        }

        internal async Task DeleteItemAsync(Agendamento agendamento)
        {
            await _database.DeleteAsync(agendamento);
        }

        internal async Task SaveItemAsync(Financeiro financeiro)
        {
            await _database.InsertOrReplaceAsync(financeiro);
        }

        internal async Task DeleteItemAsync(Financeiro financeiro)
        {
            await _database.DeleteAsync(financeiro);
        }

        internal async Task SaveItemAsync(Relatorio relatorio)
        {
            await _database.InsertOrReplaceAsync(relatorio);
        }

        internal async Task DeleteItemAsync(Relatorio relatorio)
        {
            await _database.DeleteAsync(relatorio);
        }
    }
}
