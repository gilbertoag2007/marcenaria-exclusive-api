using Retangulo3D;
using System;
using System.Drawing;

public class Peca3D
{
    // Atributos
    public Point[] SuperficieExterna { get; set; }
    public Point[] SuperficieInterna { get; set; }
    public Point[] BordaSuperior { get; set; }
    public Point[] BordaFrontal { get; set; }
    public Macaneta3D[] Macanetas { get; set; } 


    // Construtor padrão (inicializa com arrays vazios)
    public Peca3D()
    {
        SuperficieExterna = new Point[0];
        SuperficieInterna = new Point[0];
        BordaFrontal = new Point[0];
        BordaSuperior = new Point[0];
        Macanetas = new Macaneta3D[0];

    }

    // Construtor com parâmetros (com BordaSuperior opcional)
    public Peca3D(Point[] superficieExterna, Point[] superficieInterna, Point[] bordaFrontal = null, Point[] bordaSuperior = null, Macaneta3D[] macanetas = null)
    {
        SuperficieExterna = superficieExterna ?? new Point[0];
        SuperficieInterna = superficieInterna ?? new Point[0];
        BordaFrontal = bordaFrontal ?? new Point[0];
        BordaSuperior = bordaSuperior ?? new Point[0]; // Se não for passado, será um array vazio
        Macanetas = macanetas ?? new Macaneta3D[0];
    }


}
