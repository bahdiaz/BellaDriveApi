using System;

namespace BellaDriveApi.Models
{
    public class LocacaoRequest
    {
        public int CarroId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}