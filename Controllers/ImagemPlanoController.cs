using MarcenariaExclusiveAPI.Models;
using MarcenariaExclusiveAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarcenariaExclusiveAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagemPlanoController: ControllerBase
    {
        private readonly IGeradorImagemService _geradorImagem3DService;

        public ImagemPlanoController(IGeradorImagemService geradorImagem3DService)
        {
            _geradorImagem3DService = geradorImagem3DService;
        }

        [HttpPost("GerarImagemPlanoCorte")]
        public IActionResult GerarImagemPlanoCorte([FromBody] MovelDTO movel)
        {

            if (!ModelState.IsValid)
            {
                // Extrai as mensagens de erro da validação
                var erros = ModelState.Values
                                       .SelectMany(v => v.Errors)
                                       .Select(e => e.ErrorMessage)
                                       .ToList();
                Console.WriteLine("IMAGEM DO PLANO NAO GERADA " + DateTime.Now);
                return BadRequest(erros);
            }

            Console.WriteLine("FORMULARIO "+ movel + DateTime.Now);

            byte[] imagemZipada = _geradorImagem3DService.gerarProjeto3D();
            return File(imagemZipada, "application/zip", "planoCorteImagem.zip");
        }




    }
}
