using System;

namespace BellaDriveApi.Models
{
    public class LocacaoResponse
    {
        public string Carro { get; set; }
        public string Marca { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorDiaria { get; set; }
        public decimal Subtotal { get; set; }
        public string Desconto { get; set; }
        public decimal ValorFinal { get; set; }
    }
}