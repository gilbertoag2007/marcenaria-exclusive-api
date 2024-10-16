using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO.Compression;


namespace MarcenariaExclusiveAPI.Controllers
{
    // Controller de Armario
    [ApiController]
    [Route("api/[controller]")]
    public class ImagemController : ControllerBase
    {



        [HttpGet("DownloadZip")]
        public IActionResult DownloadZip()
        {
            // Caminhos das imagens e do arquivo JSON que você quer incluir
            var imagePaths = new List<string>
    {
        Path.Combine(Directory.GetCurrentDirectory(), "images", "retangulo1.png"),
        Path.Combine(Directory.GetCurrentDirectory(), "images", "retangulo2.png"),
        Path.Combine(Directory.GetCurrentDirectory(), "images", "retangulo3.png")
    };

            // Conteúdo JSON que você quer incluir no arquivo ZIP
            var jsonContent = new
            {
                Message = "Este é um arquivo JSON exemplo",
                Data = new[] { "item1", "item2", "item3" }
            };

          //  var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "files", "data.json");

            // Serializa o objeto JSON em um arquivo JSON
         //   System.IO.File.WriteAllText(jsonFilePath, JsonConvert.SerializeObject(jsonContent));

            // Cria um MemoryStream para armazenar o conteúdo do ZIP
            using (var memoryStream = new MemoryStream())
            {
                using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    // Adiciona as imagens ao ZIP
                    foreach (var imagePath in imagePaths)
                    {
                        if (System.IO.File.Exists(imagePath))
                        {
                            var zipEntry = zipArchive.CreateEntry(Path.GetFileName(imagePath), CompressionLevel.Fastest);
                            using (var originalFileStream = new FileStream(imagePath, FileMode.Open))
                            using (var zipEntryStream = zipEntry.Open())
                            {
                                originalFileStream.CopyTo(zipEntryStream);
                            }
                        }
                    }

                    // Adiciona o arquivo JSON ao ZIP
                 //   var jsonEntry = zipArchive.CreateEntry("data.json", CompressionLevel.Fastest);
                 //   using (var jsonStream = System.IO.File.OpenRead(jsonFilePath))
                 //   using (var zipEntryStream = jsonEntry.Open())
                  //  {
                  //      jsonStream.CopyTo(zipEntryStream);
                  //  }
                }

                // Retorna o arquivo ZIP para o cliente
                return File(memoryStream.ToArray(), "application/zip", "images_and_data.zip");
            }
        }

    }
}

