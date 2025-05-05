using BellaDriveApi.Data;
using BellaDriveApi.DTOs;
using BellaDriveApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BellaDriveApi.Controllers
{
    /// <summary>
    /// Autor: [Seu Nome]
    /// Projeto CP2 - Locadora de Carros
    /// Controller responsável por calcular o valor da locação de carros.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LocacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocacoesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("calcular")]
        public async Task<IActionResult> CalcularLocacao([FromBody] LocacaoRequestDTO request)
        {
            // Verifica se a data final é maior que a data inicial
            if (request.DataFim <= request.DataInicio)
            {
                return BadRequest("A data de fim deve ser maior que a data de início.");
            }

            // Busca o carro no banco
            var carro = await _context.Carros.FindAsync(request.CarroId);
            if (carro == null)
            {
                return NotFound("Carro não encontrado.");
            }

            // Calcula a quantidade de dias
            int dias = (request.DataFim - request.DataInicio).Days;

            // Calcula o subtotal
            double subtotal = dias * carro.ValorDiaria;

            // Aplica regras de desconto
            double desconto = 0;
            if (dias >= 7)
                desconto = 0.10;
            else if (dias >= 3)
                desconto = 0.05;

            double valorFinal = subtotal * (1 - desconto);

            // Cria DTO de resposta
            var response = new LocacaoResponseDTO
            {
                Modelo = carro.Modelo,
                Marca = carro.Marca,
                DataInicio = request.DataInicio,
                DataFim = request.DataFim,
                ValorDiaria = carro.ValorDiaria,
                Subtotal = subtotal,
                Desconto = $"{desconto * 100}%",
                ValorFinal = valorFinal
            };

            return Ok(response);
        }
    }
}
