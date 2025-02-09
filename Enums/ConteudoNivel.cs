using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace MarcenariaExclusiveAPI.Enums
{

    public enum ConteudoNivel // Enum que define o conteúdo de cada nivel do movel
    {

        Portas, // apenas portas 
        PortasPrateleirasInternas, // portas e prateleiras internas
        Gavetas, 
        VazadoComFundo, // Espaço sem portas, gavetas ou prateleiras internas, mas com fundo
        VazadoSemFundo // Espaço sem portas, gavetas ou prateleiras internas, mas sem fundo

    }
}
