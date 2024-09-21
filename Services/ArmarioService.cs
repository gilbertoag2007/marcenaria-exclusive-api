using MarcenariaExclusiveAPI.Models;

namespace MarcenariaExclusiveAPI.Services
{
    public class ArmarioService: IArmarioService
    {

        public PlanoDTO CalcularPlanoCorte(MovelDTO movel) 
        {
            PlanoDTO planoDTO = new PlanoDTO();

            if (movel.Tipo == 1)// ARMARIO 
            { 
                Armario armario = new Armario(movel);
                planoDTO.Base = new PecaDTO(armario.CalcularBase());
                planoDTO.Topo = new PecaDTO(armario.CalcularTopo());
                planoDTO.Fundo = new PecaDTO(armario.CalcularFundo());
                planoDTO.Laterais = new PecaDTO(armario.CalcularLaterais());
                planoDTO.AcabamentoInferior = new PecaDTO(armario.CalcularAcabamentoInferior());
                planoDTO.AcabamentoSuperior = new PecaDTO(armario.CalcularAcabamentoSuperior());
                planoDTO.Gavetas = new PecaDTO(armario.CalcularGavetas());
                planoDTO.Portas = new PecaDTO(armario.CalcularPortas());
               
            }        
            
            return planoDTO;
        }


    }
}
