using MarcenariaExclusive.API.Domain.Exceptions;
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


if(nivel.QuantidadePortas == 1)
{
planoCorte.Pecas.add(
 new Peca(armario.Largura -1, alturaNivel - 1, Espessura.Milimetros15,1 FinalidadePeca.DivisaoInterna));// redução de 1cm na largura e altura para gerar um recuo de 0,5 centímetros em cada lado da porta.

}else


double larguraPorta =CalcularLarguraPorta(armário.Largura, nivel.QuantidadePorta); // largura de cada porta


planoCorte.Pecas.add(
 new Peca(larguraPorta, alturaNivel, Espessura.Milimetros15,nivel.QuantidadePorta, FinalidadePeca.PortaNivel));// redução de 1cm na largura e altura para gerar um recuo de 0,5 centímetros em cada lado da porta.


{


}

}






}

} eles{


Double alturaNivel = CalcularAlturaNivel(armario.Altura, nível.PercentualEspaco);

}





}





        }

// Calcula a largura de cada porta considerando a largura do armário e descontando 1 cm para dar um recuo de 0.5 cm em cada lado de casa porta.
public double CalcularLarguraPorta(int larguraArmario, int quantidadePortas){

return ((larguraArmario -1)/ quantidadePortas)- ((quantidadePortas -1) * 0.5)

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


        public List<Peças>  CalcularPecasGavetas(int alturaNivel, int larguraArmario,int quantidadeGavetas, int profundidade armário, Nivel nivel)
        {



 List<Pecas> pecasGavetas = new List<Pecas>();
// Faces das gavetas

// altura da face de cada gaveta
double alturaGaveta= alturaNivel / quantidadeGavetas;
           
   pecasGavetas.add(
 new Peca(larguraArmario -1, alturaGaveta, Espessura.Milimetros15,nivel.QuantidadeGavetas, FinalidadePeca.FaceGaveta));// redução de 1cm na largura de cada face da gaveta para gerar um recuo de 0,5 centímetros em cada.


// Laterais Gavetas

double alturaLateriasGavetas = alturaGaveta * 0.70;

int larguraLateralGaveta = armario.profundidade -1;

 pecasGavetas.add(
 new Peca( larguraLateralGaveta , alturaLateriasGavetas, Espessura.Milimetros15,nivel.QuantidadeGavetas * 2, FinalidadePeca.LateralGaveta));// redução de 1cm na largura da lateral e 30% na altura de cada lateral da gaveta.


int larguraTraseiraGaveta = larguraArmario -8;
// traseira gavetas

  pecasGavetas.add(
 new Peca(   larguraTraseiraGaveta , alturaLateriasGavetas, Espessura.Milimetros15,nivel.QuantidadeGavetas, FinalidadePeca.TraseiraGaveta));// redução de 3 cm correspondente  a espessura da lateral do armário e lateral da gaveta mais 1 cm do trilho para os dois lados da gaveta totalizando 8 cm.

// Fundo Gaveta
  pecasGavetas.add(
 new Peca(larguraTraseiraGaveta +3,   larguraLateralGaveta + 0.5 , Espessura.Milimetros6,nivel.QuantidadeGavetas, FinalidadePeca.TraseiraGaveta));


        }


    }
}
