using SQLite;
using System;

namespace MauiApp1ControlePrestacoesServicos.Models
{
    public class Financeiro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public bool Pago { get; set; }
    }
}
