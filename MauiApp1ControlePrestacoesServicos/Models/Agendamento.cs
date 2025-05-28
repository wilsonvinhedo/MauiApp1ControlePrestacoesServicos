using SQLite;

namespace MauiApp1ControlePrestacoesServicos.Models
{
    public class Agendamento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ServicoId { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
        public string Observacoes { get; internal set; }
    }
}
