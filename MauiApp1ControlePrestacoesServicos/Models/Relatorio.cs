namespace MauiAppControlePrestacoesServicos.Models
{
    public class Relatorio
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public decimal TotalEntradas { get; set; }
        public decimal TotalSaidas { get; set; }
        public decimal Saldo { get; set; }
    }
}
