namespace MarcenariaExclusiveAPI.Models
{
    // Classe Armario que implementa a interface IMovel
    public class Armario : IMovel
    {
        // Atributos da interface IMovel
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Profundidade { get; set; }
        public int Tipo { get; set; }

        // Atributos específicos da classe Armario
        public int QuantidadePrateleiras { get; set; }
        public int QuantidadeDivisoesInternas { get; set; }
        public bool PossuiAcabamentoInferior { get; set; }
        public bool PossuiAcabamentoSuperior { get; set; }
        public int QuantidadePortas { get; set; }
        public int QuantidadeGavetas { get; set; }
        public double ProporcaoPorta { get; set; }
        public double ProporcaoGaveta { get; set; }
        //  public EstiloArmario Estilo { get; set; }
        public int Estilo { get; set; } // Ajustar para funcionar com ENUM

        public Armario(MovelDTO movelDTO)
        {
            Altura = movelDTO.Altura;
            Largura = movelDTO.Largura;
            Profundidade = movelDTO.Profundidade;
            Tipo = movelDTO.Tipo;
            QuantidadePrateleiras = movelDTO.QuantidadePrateleiras;
            QuantidadeDivisoesInternas = movelDTO.QuantidadeDivisoesInternas;
            PossuiAcabamentoInferior = movelDTO.PossuiAcabamentoInferior;
            PossuiAcabamentoSuperior = movelDTO.PossuiAcabamentoSuperior;
            QuantidadePortas = movelDTO.QuantidadePortas;
            QuantidadeGavetas = movelDTO.QuantidadeGavetas;
            ProporcaoPorta = movelDTO.ProporcaoPorta;
            ProporcaoGaveta = movelDTO.ProporcaoGaveta;
            Estilo = movelDTO.Estilo;

        }


        // Implementação dos métodos da interface IMovel
        public Peca CalcularBase()
        {
            return new Peca(this.Profundidade, this.Largura, 15, 1);
        }

        public Peca CalcularTopo()
        {
            return new Peca(this.Profundidade, this.Largura, 15, 1);
        }

        public Peca CalcularLaterais()
        {
            int alturaCalculada = this.Altura - 3; // Desconto de 3cm por conta da espessura do topo e base
            return new Peca(this.Profundidade, alturaCalculada, 15, 2);
        }

        public Peca CalcularFundo()
        {
            return new Peca(this.Largura, this.Altura, 6, 1);
        }

        public Peca CalcularAcabamentoInferior()
        {
            if (PossuiAcabamentoInferior)
            {
                int acabamentoInferiorCalculado = this.Largura - 3; // remove 3 cm por conta da espessura das laterais
                return new Peca(acabamentoInferiorCalculado, 8, 15, 1);
            }
            return null;

        }

        public Peca CalcularAcabamentoSuperior()
        {
            if (PossuiAcabamentoSuperior)
            {

                return new Peca(this.Largura, 8, 15, 1);
            }
            return null;

        }

        public Peca CalcularPortas()
        {
            if (this.QuantidadePortas > 0)
            {

                return new Peca(1, 1, 15, this.QuantidadePortas);
            }
            return null;

        }


        public Peca CalcularGavetas()
        {
            if (this.QuantidadeGavetas > 0)
            {

                return new Peca(1, 1, 15, this.QuantidadeGavetas);
            }
            return null;

        }

        public Peca CalcularPrateleiras()
        {
            if (this.QuantidadePrateleiras > 0)
            {

                return new Peca(1, 1, 15, this.QuantidadePrateleiras);
            }
            return null;

        }

        // Método para exibir as informações do armário
        /*   public void ExibirDetalhes()
           {
               Console.WriteLine($"Armário do tipo {Tipo}:");
               Console.WriteLine($"Dimensões: {Altura}x{Largura}x{Profundidade} (Altura x Largura x Profundidade)");
               Console.WriteLine($"Prateleiras: {QuantidadePrateleiras}, Divisões Internas: {QuantidadeDivisoesInternas}");
               Console.WriteLine($"Portas: {QuantidadePortas} com proporção {ProporcaoPorta}, Gavetas: {QuantidadeGavetas} com proporção {ProporcaoGaveta}");
               Console.WriteLine($"Acabamento Superior: {PossuiAcabamentoSuperior}, Acabamento Inferior: {PossuiAcabamentoInferior}");
               Console.WriteLine($"Estilo: {Estilo}");
           }

           */


    }

}
