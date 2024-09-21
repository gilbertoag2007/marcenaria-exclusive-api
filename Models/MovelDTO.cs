using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MarcenariaExclusiveAPI.Models
{
    public class MovelDTO
    {
        [Range(40, 230, ErrorMessage = "A altura deve ser igual ou maior que 40 e igual ou menor que 230.")]
        public int Altura { get; set; }

        [Range(40, 100, ErrorMessage = "A altura deve ser igual ou maior que 40 e igual ou menor que 100.")]
        public int Largura { get; set; }

        [Range(30, 60, ErrorMessage = "A altura deve ser igual ou maior que 30 e igual ou menor que 60.")]
        public int Profundidade { get; set; }

        [Range(1, 6, ErrorMessage = "O tipo do movel deve estar entre 1 e 6")]
        public int Tipo { get; set; }

        // Atributos específicos da classe Armario

        [Range(0, 4, ErrorMessage = "A quantidade de prateleiras deve entre 0 e 4.")]
        public int QuantidadePrateleiras { get; set; }

        [Range(0, 1, ErrorMessage = "A quantidade de prateleiras deve entre 0 e 1.")]
        public int QuantidadeDivisoesInternas { get; set; }

        [Required(ErrorMessage = "O campo Possui Acabamento Inferior é obrigatório.")]
        public bool PossuiAcabamentoInferior { get; set; }

        [Required(ErrorMessage = "O campo Possui Acabamento Superior é obrigatório.")]
        public bool PossuiAcabamentoSuperior { get; set; }

        [Range(1, 2, ErrorMessage = "A quantidade de prateleiras deve entre 0 e 1.")]
        public int QuantidadePortas { get; set; }

        [Range(1, 2, ErrorMessage = "A quantidade de gavetas deve entre 0 e 1.")]
        public int QuantidadeGavetas { get; set; }

        public double ProporcaoPorta { get; set; }

        public double ProporcaoGaveta { get; set; }

        [Required(ErrorMessage = "O campo Estilo é obrigatório.")]
        public EstiloArmario Estilo { get; set; }

    }

}

