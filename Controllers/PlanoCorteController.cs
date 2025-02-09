using AutoMapper;
using MarcenariaExclusiveAPI.DTO;
using MarcenariaExclusiveAPI.Models;
using MarcenariaExclusiveAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MarcenariaExclusiveAPI.Controllers
{
    // Controller de Armario
    [ApiController]
    [Route("api/[controller]")]
    public class PlanoCorteController : ControllerBase
    {

        private readonly IArmarioService _armarioService;
        private readonly IMapper _mapper;

        public PlanoCorteController(IArmarioService armarioService, IMapper mapper )
        {
            _armarioService = armarioService;
            _mapper  = mapper;
        }

        // Método GET para gerar o plano de corte a partir das esdpecificaçõe do armario
        [HttpPost("gerar")]
        [ProducesResponseType(typeof(ArmarioDto), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [SwaggerOperation("gerarPlanoCorte")]
        public IActionResult GeraPlanoCorte([FromBody] ArmarioDto armarioDto)

        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna os erros de validação
            }


            Console.WriteLine("CHEGOU NO CONTROLLER");
            Armario armario = ConverterArmarioDtoParaModelo(armarioDto);
            Console.WriteLine("DTO CONVERTIDO PARA MODELO'");

            return Ok(armario);
        }

        // Converte uma classe ArmarioDto para classe modelo Armario
        private Armario ConverterArmarioDtoParaModelo(ArmarioDto armarioDto)
        {
            return _mapper.Map<Armario>(armarioDto);
        }






    }
}


