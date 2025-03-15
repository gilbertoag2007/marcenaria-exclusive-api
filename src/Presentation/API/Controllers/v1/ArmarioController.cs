

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
            Armario armario = ConverterArmarioParaModelo(armarioDto);
            PlanoCorteDto planoCorteDto = _armarioService.CalcularPlanoCorte(armario);
            Console.WriteLine("DTO CONVERTIDO PARA MODELO'");

            return Ok(planoCorteDto);



        }

        private Armario ConverterArmarioParaModelo(ArmarioDto armarioDto)
        {
            Armario armario = new Armario();
            armario.Email = armarioDto.Email;
            armario.NomeProjeto = armarioDto.NomeProjeto;
            armario.Altura = armarioDto.Altura;
            armario.Largura = armarioDto.Largura;
            armario.Profundidade = armarioDto.Profundidade;
            armario.PossuiAcabamentoInferior = armarioDto.PossuiAcabamentoInferior;
            armario.PossuiAcabamentoSuperior = armarioDto.PossuiAcabamentoSuperior;
            armario.Portas = ConverterPortasDtoParaModelo(armarioDto); 
            armario.Niveis = ConverterNiveisParaModelo(armarioDto.Niveis);
            return armario;
        }


        private List<Nivel> ConverterNiveisParaModelo(List<NivelDto> listaNivelDto)
        {
            List<Nivel> niveis = new List<Nivel>();

            foreach (var nivelDto in listaNivelDto)
            {
                Nivel nivel = new Nivel
                {
                    NumeroNivel = nivelDto.NumeroNivel,
                    AlturaNivel = nivelDto.AlturaNivel,
                    ConteudoNivel = nivelDto.ConteudoNivel,
                    QuantidadePrateleiras = nivelDto.QuantidadePrateleiras ?? 0,
                    QuantidadeGavetas = nivelDto.QuantidadeGavetas ?? 0,
                    QuantidadeDivisoes = nivelDto.QuantidadeDivisoes ?? 0,
                    PossuiFundo = nivelDto.PossuiFundo
                };
                niveis.Add(nivel);
            }

            return niveis;
        }
        private List<Porta> ConverterPortasDtoParaModelo(ArmarioDto armarioDto)
        {
            List<Porta> portas = new List<Porta>();

            foreach (var portaDto in armarioDto.Portas)
            {
                for (int i = 0; i < portaDto.QuantidadePortas; i++)
                {
                    Porta porta = new Porta();
                    porta.Altura = _armarioService.CalcularAlturaPorta(armarioDto, portaDto);
                    porta.Largura = _armarioService.CalcularLarguraPorta(armarioDto.Largura, portaDto);
                    porta.NiveisCobertura = portaDto.NiveisCobertura;

                    portas.Add(porta);
                }

               
            }

            return portas;
        }


    } 


}