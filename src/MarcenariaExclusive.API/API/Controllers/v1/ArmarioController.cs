
using MarcenariaExclusive.API.Application.DTOs;
using MarcenariaExclusive.API.Domain.Entities;
using MarcenariaExclusiveAPI.Application.DTOs;
using MarcenariaExclusiveAPI.Application.Interfaces;
using MarcenariaExclusiveAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MarcenariaExclusive.API.API.Controllers.v1
{
    // Controller de Armario
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ArmarioController : ControllerBase
    {

        private readonly IArmarioService _armarioService;
      


        public ArmarioController(IArmarioService armarioService)
        {
            _armarioService = armarioService;
     
        }

        // Método GET para gerar o plano de corte a partir das esdpecificaçõe do armario
        [HttpPost("CalcularPlanoCorte")]
        [ProducesResponseType(typeof(PlanoCorteDto), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult CalcularPlanoCorte([FromBody] ArmarioDto armarioDto)

        {

            Console.WriteLine("CHEGOU NO CONTROLLER");
            Armario armario = new Armario(armarioDto);
            PlanoCorte planoCorte = _armarioService.CalcularPlanoCorte(armario);
            PlanoCorteDto planoCorteDto = new PlanoCorteDto(planoCorte);
            Console.WriteLine("DTO CONVERTIDO PARA MODELO'");

            return Ok(planoCorteDto);



        }

       
    }


}


