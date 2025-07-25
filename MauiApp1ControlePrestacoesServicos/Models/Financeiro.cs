﻿using SQLite;

namespace MauiApp1ControlePrestacoesServicos.Models
{
    public class Financeiro
    {
        internal bool Pago;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; } // "Entrada" ou "Saida"
        public string Descricao { get; set; }
    }
}
