﻿using MarcenariaExclusive.API.Domain.Exceptions;
using MarcenariaExclusiveAPI.Application.Interfaces;
using MarcenariaExclusiveAPI.Domain.Entities;


namespace MarcenariaExclusiveAPI.Infrastructure.Services
{
    public class ArmarioService : IArmarioService
    {

        public void CalcularPlanoCorte( Armario armario)
        {

            Console.WriteLine("CHEGOU NO SERVICE.");
          //  throw new DimensoesException(" AS ESPECIFICAÇÕES ESTÃO FORA DE UMA PROPORÇÃO RAZOAVEL PARA O PROJETO");

PlanoCorte planoCorte = new PlanoCorte();
planoCorte.Armario = armário;

planoCorte.Pecas.add(
 new Peca(armario.Largura, armário.Altura, Espessura.Milimetros15,2 FinalidadePeca.Lateral));

planoCorte.Pecas.add(
new Peca(armario.Largura -3, armário.Altura, Espessura.Milimetros15,1 FinalidadePeca.Base));// redução de 3cm por conta da espessura das duas peças laterais

planoCorte.Pecas.add(
 new Peca(armario.Largura -3, armário.Altura, Espessura.Milimetros15,1 FinalidadePeca.Topo));// redução de 3cm por conta da espessura das duas peças laterais

planoCorte.Pecas.add(
 new Peca(armario.Largura, 7, Espessura.Milimetros15,1 FinalidadePeca.AcabamentoInferior));

planoCorte.Pecas.add(
new Peca(armario.Largura, 7, Espessura.Milimetros15,1 FinalidadePeca.AcabamentoSuperior));

planoCorte.Pecas.add(
new Peca(armario.Largura, armario.Altura, Espessura.Milimetros6,1 FinalidadePeca.Fundo));

int quantidadeDivisaoNivel = armario.Niveis.Count -1;// define quantidade de chapas para separar um nível de outro.


double alturaUtil = CalcularAlturaNivel(armario.Altura -14, nível.PercentualEspaco);  // desconta 14 centímetros da altura dos acabamentos inferiores e superiores.

foreach (var nivel in armario.Niveis)


if (quantidadeDivisaoNivel > 1){ 

if(nivel.numeroNivel <> 1 &&
 nivel.numeroNivel <> quantidadeDivisaoNivel)
{

planoCorte.Pecas.add(
 new Peca(armario.Largura -3, armário.Altura, Espessura.Milimetros15,1 FinalidadePeca.DivisaoNivel));// redução de 3cm por conta da espessura das duas peças laterais
}

Double alturaNivel = CalcularAlturaNivel(alturaUtil, nível.PercentualEspaco) - 1.5; // desconta 1,5 cm da chapa que é a divisão de nivel

if (nivel.QuantidadeDivisoes <> null && nivel.QuantidadeDivisoes > 0 )

{

for (int i =0;i < nivel.QuantidadeDivisoes; i++ )
{
planoCorte.Pecas.add(
 new Peca(armario.Profundidade, alturaNivel - 1.5, Espessura.Milimetros15,1 FinalidadePeca.DivisaoInterna));// redução de 3cm por conta da espessura das duas peças laterais

}

}

if (nivel.QuantidadePortas <> null && nivel.QuantidadePortas > 0)
{


}






}

} eles{


Double alturaNivel = CalcularAlturaNivel(armario.Altura, nível.PercentualEspaco);

}





}





        }

/// <summary>
/// Calcula a altura de um nível dentro do armário com base na altura total e no percentual de espaço utilizado.
/// </summary>
/// <param name="alturaArmario">A altura total do armário em centímetros.</param>
/// <param name="percentualEspaco">O percentual de espaço ocupado pelo nível dentro do armário.</param>
/// <returns>A altura correspondente do nível em centímetros.</returns>
public double CalcularAlturaNivel(int alturaArmario, double percentualEspaco)
{
    return (alturaArmario * percentualEspaco / 100);
}


        private void CalcularPecasLaterais(Armario armario)
        {
            // Calcula os niveis do armario
        }


    }
}
