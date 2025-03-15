using System.ComponentModel;

namespace MarcenariaExclusive.API.Domain.Enums
{
    /// <summary>
    /// Enumeração que define as diferentes finalidades das peças que compõem o móvel.
    /// </summary>
    public enum FinalidadePeca
    {
        /// <summary>
        /// Peça usada como base do móvel.
        /// </summary>
        [Description("base do armário")] 
        Base,

        /// <summary>
        /// Peça usada como topo do móvel.
        /// </summary>
        [Description("topo do armario")] 
        Topo,

        /// <summary>
        /// Peça usada como lateral direita do móvel.
        /// </summary>
        [Description("lateral direita")] 
        LateralDireita,

        /// <summary>
        /// Peça usada como lateral esquerda do móvel.
        /// </summary>
        [Description("lateral esquerda")]   
        LateralEsquerda,

        /// <summary>
        /// Peça usada como fundo do armário.
        /// </summary>
        [Description("fundo do armário")] 
        FundoArmario,

        /// <summary>
        /// Peça usada para acabamento.
        /// </summary>
        [Description("acabamento superior")] 
        AcabamentoSuperior,

        /// <summary>
        /// Peça usada para acabamento.
        /// </summary>
        [Description("acabamento inferior")] 
        AcabamentoInferior,

        /// <summary>
        /// Peça usada como divisão  vertical interna do móvel.
        /// </summary>
        [Description("divisão vertical interna")] 
        DivisaoVerticalInterna,

        /// <summary>
        /// Peça  vertical tipo prateleira usada para separar os níveis.
        /// </summary>
        [Description("divisão horizontal de nível")] 
        DivisaoHorizontalNivel,

        /// <summary>
        /// Peça usada como face da gaveta.
        /// </summary>
        [Description("face da gaveta")] 
        FaceGaveta,

        /// <summary>
        /// Peça usada como parte traseira da gaveta.
        /// </summary>
        [Description("traseira da gaveta")] 
        TraseiraGaveta,

        /// <summary>
        /// Peça usada como lateral da gaveta.
        /// </summary>
        [Description("lateral da gaveta")] 
        LateralGaveta,

        /// <summary>
        /// Peça usada como fundo da gaveta.
        /// </summary>
        [Description("fundo da gaveta")] 
        FundoGaveta,

        /// <summary>
        /// Peça usada como porta do armário.
        /// </summary>
        [Description("porta do armário")] 
        Porta,
        

        /// <summary>
        /// Peça usada como prateleira dentro do nível.
        /// </summary>
        [Description("prateleira")] 
        Prateleira


    }
}
