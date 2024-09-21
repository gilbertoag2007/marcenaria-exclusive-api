using MarcenariaExclusiveAPI.Models;
using MarcenariaExclusiveAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarcenariaExclusiveAPI.Controllers
{
    // Controller de Armario
    [ApiController]
    [Route("api/[controller]")]
    public class ArmarioController : ControllerBase
    {

        private readonly IArmarioService _armarioService;

        public ArmarioController(IArmarioService armarioService)
        {
            _armarioService = armarioService;
        }

        // Método GET para calcular o plano do armário
        [HttpPost("calcularPlanoArmario")]
        public IActionResult CalcularPlanoArmario([FromBody] MovelDTO movel)

        {

            if (!ModelState.IsValid)
            {
                // Extrai as mensagens de erro da validação
                var erros = ModelState.Values
                                       .SelectMany(v => v.Errors)
                                       .Select(e => e.ErrorMessage)
                                       .ToList();

                return BadRequest(erros);
            }

            PlanoDTO planoDTO = _armarioService.CalcularPlanoCorte(movel);

            // Processa o usuário aqui (por exemplo, salvar no banco de dados)
            return Ok(planoDTO);
        }

    }
}


