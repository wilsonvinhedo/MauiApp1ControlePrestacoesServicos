namespace MauiApp1ControlePrestacoesServicos.Models
{
    public class Relatorio
    {
        internal DateTime DataGeracao;
        internal string Detalhes;

        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public decimal TotalEntradas { get; set; }
        public decimal TotalSaidas { get; set; }
        public decimal Saldo { get; set; }
        public string Descricao { get; internal set; }
    }
}
