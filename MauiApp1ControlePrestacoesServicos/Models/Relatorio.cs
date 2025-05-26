using SQLite;

namespace MauiApp1ControlePrestacoesServicos.Models
{
    public class Relatorio
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Descricao { get; set; }

        public string Detalhes { get; set; }
    }
}
