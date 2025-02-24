using MarcenariaExclusive.API.Domain.Entities;
using Microsoft.OpenApi.Extensions;
using System.Collections.Generic;

namespace MarcenariaExclusive.API.Application.DTOs
{
    /// <summary>
    /// Classe DTO para representar o plano de corte de um armário.
    /// </summary>
    public class PlanoCorteDto
    {
        /// <summary>
        /// Nome ou descrição do projeto.
        /// </summary>
        public string NomeProjeto { get; set; }

        /// <summary>
        /// Tamanho total de peças em metros quadrados.
        /// </summary>
        public string TamanhoTotalPecasM2 { get; set; }

        /// <summary>
        /// Lista de peças que compõem o plano de corte.
        /// </summary>
        public List<PecaDto> Pecas { get; set; } = new List<PecaDto>();

        /// <summary>
        /// Lista de materiais para montagem do armário.
        /// </summary>
        public List<MaterialDto> Materiais { get; set; } = new List<MaterialDto>();

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="PlanoCorteDto"/>.
        /// </summary>
        public PlanoCorteDto() { }

        /// <summary>
        /// Construtor que recebe um objeto PlanoCorte como parâmetro.
        /// </summary>
        /// <param name="planoCorte">Objeto PlanoCorte.</param>
        public PlanoCorteDto(PlanoCorte planoCorte)
        {
            NomeProjeto = planoCorte.Armario.NomeProjeto;
            TamanhoTotalPecasM2 = $"{planoCorte.CalcularTamanhoTotalPecasM2():F2}";
            Pecas = planoCorte.Pecas.Select(p => new PecaDto
            {
                Dimensao = $"{p.Largura} cm x {p.Altura} cm",
                Espessura =  p.ObterDescricaoEspessura(),
                Quantidade = $"{p.Quantidade} peça{(p.Quantidade > 1 ? "s" : "")}",
                FinalidadePeca = p.FinalidadePeca.GetDisplayName()
            }).ToList();

            Materiais = planoCorte.Materiais.Select(m => new MaterialDto
            {
                QuantidadeMaterial = $"{m.Quantidade} - {m.TipoMaterial}{(m.Quantidade > 1 ? "s" : "")}"
               
            }).ToList();


        }

    }
}
