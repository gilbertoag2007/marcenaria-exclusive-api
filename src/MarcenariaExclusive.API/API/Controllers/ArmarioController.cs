using AutoMapper;
using MarcenariaExclusiveAPI.Application.DTOs;
using MarcenariaExclusiveAPI.Application.Interfaces;
using MarcenariaExclusiveAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MarcenariaExclusive.API.API.Controllers
{
    // Controller de Armario
    [ApiController]
    [Route("api/[controller]")]
    public class ArmarioController : ControllerBase
    {

        private readonly IArmarioService _armarioService;
        private readonly IMapper _mapper;


        public ArmarioController(IArmarioService armarioService, IMapper mapper)
        {
            _armarioService = armarioService;
            _mapper = mapper;
        }

        // Método GET para gerar o plano de corte a partir das esdpecificaçõe do armario
        [HttpPost("calcularPlanoArmario")]
        [ProducesResponseType(typeof(ArmarioDto), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult CalcularPlanoArmario([FromBody] ArmarioDto armarioDto)

        {

            Console.WriteLine("CHEGOU NO CONTROLLER");
            Armario armario = ConverterArmarioDtoParaModelo(armarioDto);
            Console.WriteLine("DTO CONVERTIDO PARA MODELO'");

            _armarioService.CalcularPlanoCorte(armario);

            return Ok(armario);



        }

        // Converte uma classe ArmarioDto para classe modelo Armario
        private Armario ConverterArmarioDtoParaModelo(ArmarioDto armarioDto)
        {
            return _mapper.Map<Armario>(armarioDto);
        }


    }


}


