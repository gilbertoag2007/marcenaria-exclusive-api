using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retangulo3D
{
    public class Macaneta3D
    {

        // Atributos
        public int X { get; set; }
        public int Y { get; set; }
        public int Largura { get; set; }
        public int Altura { get; set; }

        // Construtor padrão
        public Macaneta3D()
        {
            X = 0;
            Y = 0;
            Largura = 0;
            Altura = 0;
        }

        // Construtor com parâmetros
        public Macaneta3D(int x, int y, int largura, int altura)
        {
            X = x;
            Y = y;
            Largura = largura;
            Altura = altura;
        }


    }
}
