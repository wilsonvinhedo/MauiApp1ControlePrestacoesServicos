using SQLite;

namespace MauiAppControlePrestacoesServicos.Models
{
    public class Servico
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}
