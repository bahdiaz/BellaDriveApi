using Microsoft.AspNetCore.Mvc;
using BellaDriveApi.Data;
using BellaDriveApi.Models;

namespace BellaDriveApi.Controllers
{
    [ApiController]
    [Route("api/simulacoes")]
    public class SimulacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SimulacoesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("calcular")]
        public IActionResult CalcularSimulacao([FromBody] LocacaoRequest request)
        {
            var carro = _context.Carros.Find(request.CarroId);
            if (carro == null)
                return NotFound("Ops! Não encontramos esse carro na nossa frota 💁");

            int dias = (request.DataFim - request.DataInicio).Days;
            if (dias <= 0)
                return BadRequest("Por favor, verifique as datas da sua simulação 😊");

            decimal subtotal = dias * carro.ValorDiaria;
            decimal desconto = 0;

            if (dias >= 7) desconto = 0.10m;
            else if (dias >= 3) desconto = 0.05m;

            decimal valorFinal = Math.Round(subtotal * (1 - desconto), 2);
            subtotal = Math.Round(subtotal, 2);

            var response = new LocacaoResponse
            {
                Carro = carro.Modelo,
                Marca = carro.Marca,
                DataInicio = request.DataInicio,
                DataFim = request.DataFim,
                ValorDiaria = Math.Round(carro.ValorDiaria, 2),
                Subtotal = subtotal,
                Desconto = $"{desconto * 100}%",
                ValorFinal = valorFinal
            };

            return Ok(response);
        }
    }
}
