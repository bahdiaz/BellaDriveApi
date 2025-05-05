using System.ComponentModel.DataAnnotations;

namespace BellaDriveApi
{
    public class Carro
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Modelo { get; set; }

        [Required]
        public string Marca { get; set; }

        public int Ano { get; set; }

        public decimal ValorDiaria { get; set; }
    }
}