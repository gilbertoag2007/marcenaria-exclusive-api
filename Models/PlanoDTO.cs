using System.ComponentModel.DataAnnotations;

namespace MarcenariaExclusiveAPI.Models
{
    public class PlanoDTO
    {

        public PecaDTO Base { get; set; }
        public PecaDTO Topo { get; set; }
        public PecaDTO Laterais { get; set; }
        public PecaDTO Fundo { get; set; }
        public PecaDTO AcabamentoSuperior { get; set; }
        public PecaDTO AcabamentoInferior { get; set; }
        public PecaDTO Prateleiras { get; set; }
        public PecaDTO Gavetas { get; set; }
        public PecaDTO Portas { get; set; }


    }
}
