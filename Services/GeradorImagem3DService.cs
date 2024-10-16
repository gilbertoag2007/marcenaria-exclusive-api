using Retangulo3D;
using System.Drawing;
using System.IO.Compression;
using System.IO;

namespace MarcenariaExclusiveAPI.Services
{
    public class GeradorImagem3DService : IGeradorImagemService
    {

        byte[] imagemGerada;

        public byte[] gerarProjeto3D()
        {

            int larguraContainer = 1200;
            int alturaContainer = 1200;

            int alturaMovel = 180;
            int LarguraMovel = 60;
            int ProfundidadeMovel = 40;

            int escala = 5;
            int pontoInicialX = (larguraContainer / 4) - ((LarguraMovel * escala) / 2);
            int pontoInicialY = 50;
            int espessuraPeca = 7;
            int inclinacao = 30;

            int QuantidadeDivisoes = 2;
            int QuantidadePortas = 2;
            int escalaReduzida = escala / 2;
            Boolean possuiAcabamentoSuperior = true;
            Boolean possuiAcabamentoInferior = true;


            List<Peca3D> pecas = new List<Peca3D>();



            //  Peca3D topo = ProjetarPecaHorizontal(false, LarguraMovel, ProfundidadeMovel, pontoInicialX, pontoInicialY - espessuraPeca, escala, espessuraPeca, inclinacao);


            Peca3D lateralDireita = ProjetarPecaVertical(true, alturaMovel, ProfundidadeMovel, pontoInicialX + (LarguraMovel * escala), pontoInicialY, escala, espessuraPeca, inclinacao);

            Peca3D lateralEsquerda = ProjetarPecaVertical(true, alturaMovel, ProfundidadeMovel, pontoInicialX, pontoInicialY, escala, espessuraPeca, inclinacao);

            Peca3D Prateleira1 = ProjetarPecaHorizontal(true, LarguraMovel, ProfundidadeMovel, pontoInicialX, pontoInicialY + 50, escala, espessuraPeca, inclinacao);
            Peca3D Prateleira2 = ProjetarPecaHorizontal(true, LarguraMovel, ProfundidadeMovel, pontoInicialX, pontoInicialY + 150, escala, espessuraPeca, inclinacao);
            Peca3D Prateleira3 = ProjetarPecaHorizontal(true, LarguraMovel, ProfundidadeMovel, pontoInicialX, pontoInicialY + 250, escala, espessuraPeca, inclinacao);


            Peca3D Divisao1 = ProjetarPecaVertical(true, alturaMovel, ProfundidadeMovel, pontoInicialX + ((LarguraMovel * escala) / QuantidadeDivisoes + 1), pontoInicialY, escala, espessuraPeca, inclinacao);

            Peca3D Porta1 = ProjetarPorta(LarguraMovel, alturaMovel, ProfundidadeMovel, pontoInicialX + (ProfundidadeMovel + escala) + inclinacao + espessuraPeca, pontoInicialY + inclinacao - (espessuraPeca / 2), escala, espessuraPeca, inclinacao, QuantidadePortas, Lado.Direito, possuiAcabamentoSuperior, possuiAcabamentoInferior);
            Peca3D Porta2 = ProjetarPorta(LarguraMovel, alturaMovel, ProfundidadeMovel, pontoInicialX + (ProfundidadeMovel + escala) + inclinacao + espessuraPeca + ((LarguraMovel * escala) / QuantidadePortas) - 1, pontoInicialY + inclinacao - (espessuraPeca / 2), escala, espessuraPeca, inclinacao, QuantidadePortas, Lado.Esquerdo, possuiAcabamentoSuperior, possuiAcabamentoInferior);




            pecas.Add(lateralDireita);
            pecas.Add(Prateleira2);
            pecas.Add(Prateleira3);
            //  pecas.Add(Porta1); 


            //  pecas.Add(topo);
            //  pecas.Add(Porta1);
            //  pecas.Add(Porta2);

            Peca3D baseMovel;
            Peca3D AcabamentoInferior;

            int posicaoInicialXAcabamento = pontoInicialX + (ProfundidadeMovel * escalaReduzida);

            if (possuiAcabamentoInferior)
            {


                int posicaoInicialYBase = pontoInicialY + inclinacao + (alturaMovel * escala) - (8 * escala) - espessuraPeca;

                baseMovel = ProjetarPecaHorizontal(false, LarguraMovel, ProfundidadeMovel, pontoInicialX, posicaoInicialYBase, escala, espessuraPeca, inclinacao);
                pecas.Add(baseMovel);
                AcabamentoInferior = ProjetarAcabamento(LarguraMovel, alturaMovel, ProfundidadeMovel, posicaoInicialXAcabamento, posicaoInicialYBase, escala, espessuraPeca, inclinacao, QuantidadePortas);
                pecas.Add(AcabamentoInferior);



            }
            else
            {

                baseMovel = ProjetarPecaHorizontal(false, LarguraMovel, ProfundidadeMovel, pontoInicialX, pontoInicialY + (alturaMovel * escala), escala, espessuraPeca, inclinacao);
                pecas.Add(baseMovel);


            }

            Peca3D topo;
            Peca3D AcabamentoSuperior;

            if (possuiAcabamentoSuperior)
            {
                topo = ProjetarPecaHorizontal(true, LarguraMovel, ProfundidadeMovel, pontoInicialX, pontoInicialY + (8 * escalaReduzida), escala, espessuraPeca, inclinacao);
                pecas.Add(topo);
                pecas.Add(lateralEsquerda);
                AcabamentoSuperior = ProjetarAcabamento(LarguraMovel, alturaMovel, ProfundidadeMovel, posicaoInicialXAcabamento, pontoInicialY + inclinacao, escala, espessuraPeca, inclinacao, QuantidadePortas);
                pecas.Add(AcabamentoSuperior);

            }
            else
            {
                pecas.Add(lateralEsquerda);
                topo = ProjetarPecaHorizontal(false, LarguraMovel, ProfundidadeMovel, pontoInicialX, pontoInicialY - espessuraPeca, escala, espessuraPeca, inclinacao);
                pecas.Add(topo);
            }

            pecas.Add(Porta1);
            pecas.Add(Porta2);

            Peca3D gaveta1 = ProjetarGavetas(LarguraMovel, alturaMovel, ProfundidadeMovel, posicaoInicialXAcabamento, pontoInicialY + inclinacao + ((alturaMovel * escala) - ((alturaMovel * escala) / 10)), escala, espessuraPeca, inclinacao, QuantidadePortas);
            pecas.Add(gaveta1);

            imagemGerada = gerarImagens(pecas, larguraContainer, alturaContainer);


            return imagemGerada;

        }


        private byte[] gerarImagens(List<Peca3D> pecas, int larguraContainer, int alturaContainer)
        {


            using (Bitmap bmp = new Bitmap(1200, 1200))
            {
                // Crie o objeto Graphics para desenhar no Bitmap
                using (Graphics g = Graphics.FromImage(bmp))
                {


                    // Limpe o fundo da imagem com cor branca
                    g.Clear(Color.Linen);

                    // Defina a caneta para desenhar as linhas
                    Pen canetaCinza = new Pen(Color.Gray, 1);
                    Pen canetaBranca = new Pen(Color.White, 1);

                    Brush brushFrente = new SolidBrush(Color.FromArgb(255, 192, 192, 192));  // Azul sólido
                    Brush brushTopo = new SolidBrush(Color.FromArgb(255, 192, 192, 192)); // Verde sólido
                    Brush brushLateral = new SolidBrush(Color.FromArgb(255, 255, 255, 255));    // Vermelho sólido
                    Brush brushHorizontal = new SolidBrush(Color.FromArgb(255, 255, 255));


                    foreach (Peca3D peca in pecas)
                    {
                        if (peca.SuperficieExterna.Length > 0)
                        {
                            g.DrawPolygon(canetaCinza, peca.SuperficieExterna);
                        }

                        if (peca.SuperficieInterna.Length > 0)
                        {
                            g.DrawPolygon(canetaCinza, peca.SuperficieInterna);
                        }

                        if (peca.BordaSuperior.Length > 0)
                        {
                            g.DrawPolygon(canetaCinza, peca.BordaSuperior);
                        }

                        if (peca.BordaFrontal.Length > 0)
                        {
                            g.DrawPolygon(canetaCinza, peca.BordaFrontal);
                        }

                        if (peca.SuperficieExterna.Length > 0)
                        {
                            g.FillPolygon(brushLateral, peca.SuperficieExterna);
                        }

                        if (peca.SuperficieInterna.Length > 0)
                        {
                            g.FillPolygon(brushLateral, peca.SuperficieInterna);
                        }

                        if (peca.BordaSuperior.Length > 0)
                        {
                            g.FillPolygon(brushTopo, peca.BordaSuperior);
                        }

                        if (peca.BordaFrontal.Length > 0)
                        {
                            g.FillPolygon(brushTopo, peca.BordaFrontal);
                        }

                        if (peca.Macanetas.Length > 0)
                        {
                            foreach (var macaneta in peca.Macanetas)
                            {
                                g.DrawEllipse(canetaCinza, macaneta.X, macaneta.Y, macaneta.Largura, macaneta.Altura);
                                g.FillEllipse(brushTopo, macaneta.X, macaneta.Y, macaneta.Largura, macaneta.Altura);
                            }
                        }

                    }

                    Console.WriteLine("Imagem 'retangulo3d.png' criada com sucesso!");

                    // Salva a imagem em memória
                    using (var memoryStream = new MemoryStream())
                    {
                        bmp.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png); // Salva como PNG

                        // Agora vamos criar o ZIP contendo a imagem em memória
                        using (var zipStream = new MemoryStream())
                        {
                            using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
                            {
                                // Adiciona a imagem ao arquivo ZIP
                                var zipEntry = archive.CreateEntry("planoCorte.png", CompressionLevel.Fastest);

                                using (var entryStream = zipEntry.Open())
                                {
                                    memoryStream.Seek(0, SeekOrigin.Begin);
                                    memoryStream.CopyTo(entryStream); // Copia a imagem para o ZIP
                                }
                            }

                            // Retorna o arquivo ZIP como um array de bytes
                            zipStream.Seek(0, SeekOrigin.Begin);
                            // return File(zipStream.ToArray(), "application/zip", "cubo.zip");

                            return zipStream.ToArray();
                        }
                    }

                }
            }

        }

        public static Peca3D ProjetarPecaVertical(Boolean ehInterno, int altura = 180, int profundidade = 40, int inicialX = 100, int iniciaY = 10, int escalaAmpliacao = 5, int espessura = 10, int inclinacaoPeca = 50)
        {
            Peca3D retorno = new Peca3D();
            int escalaReduzida = escalaAmpliacao / 2;

            Point PontoAEsquerdo;
            Point PontoBEsquerdo;
            Point PontoCEsquerdo;
            Point PontoDEsquerdo;

            if (ehInterno)
            {

                PontoAEsquerdo = new Point(inicialX, iniciaY);  // Lateral Esquerda Superior Externa
                PontoBEsquerdo = new Point((inicialX + profundidade * escalaReduzida), iniciaY + inclinacaoPeca); // Lateral Esquerda Inferior Externa
                PontoCEsquerdo = new Point(inicialX + (profundidade * escalaReduzida), iniciaY + (altura * escalaAmpliacao) + inclinacaoPeca); // Lateral Esquerda Inferior Externa
                PontoDEsquerdo = new Point(inicialX, iniciaY + (altura * escalaAmpliacao));  // Lateral Direita Inferior Externa


            }
            else
            {

                PontoAEsquerdo = new Point(inicialX, iniciaY - espessura);  // Lateral Esquerda Superior Externa
                PontoBEsquerdo = new Point((inicialX + profundidade * escalaReduzida), iniciaY + inclinacaoPeca - espessura); // Lateral Esquerda Inferior Externa
                PontoCEsquerdo = new Point(inicialX + (profundidade * escalaReduzida), iniciaY + (altura * escalaAmpliacao) + inclinacaoPeca + espessura); // Lateral Esquerda Inferior Externa
                PontoDEsquerdo = new Point(inicialX, iniciaY + (altura * escalaAmpliacao) + espessura);  // Lateral Direita Inferior Externa
            }

            Point[] lateralEsquerda = { PontoAEsquerdo, PontoBEsquerdo, PontoCEsquerdo, PontoDEsquerdo };

            retorno.SuperficieExterna = lateralEsquerda;

            Point PontoADireito = new Point(PontoAEsquerdo.X + espessura, PontoAEsquerdo.Y);  // Lateral Esquerda Superior Externa
            Point PontoBDireito = new Point(PontoBEsquerdo.X + espessura, PontoBEsquerdo.Y); // Lateral Esquerda Inferior Externa
            Point PontoCDireito = new Point(PontoCEsquerdo.X + espessura, PontoCEsquerdo.Y); // Lateral Esquerda Inferior Externa
            Point PontoDDireito = new Point(PontoDEsquerdo.X + espessura, PontoDEsquerdo.Y);  // Lateral Direita Inferior Externa

            Point[] lateralDireita = { PontoADireito, PontoBDireito, PontoCDireito, PontoDDireito };

            retorno.SuperficieInterna = lateralDireita;

            Point[] bordaSuperior = { PontoAEsquerdo, PontoADireito, PontoBDireito, PontoBEsquerdo };

            retorno.BordaSuperior = bordaSuperior;

            Point[] bordaFrontal = { PontoBEsquerdo, PontoBDireito, PontoCDireito, PontoCEsquerdo };

            retorno.BordaFrontal = bordaFrontal;

            return retorno;

        }

        public static Peca3D ProjetarPecaHorizontal(Boolean ehInterno, int largura = 60, int profundidade = 40, int inicialX = 100, int iniciaY = 10, int escalaAmpliacao = 5, int espessura = 10, int inclinacaoPeca = 50)
        {
            Peca3D PecaProjetada = new Peca3D();
            int escalaReduzida = escalaAmpliacao / 2;

            Point PontoASuperior;
            Point PontoBSuperior;
            Point PontoCSuperior;
            Point PontoDSuperior;

            if (ehInterno)
            {

                PontoASuperior = new Point(inicialX + espessura, iniciaY);
                PontoBSuperior = new Point(inicialX + (largura * escalaAmpliacao), iniciaY);
                PontoCSuperior = new Point(inicialX + (largura * escalaAmpliacao) + (profundidade * escalaReduzida), iniciaY + inclinacaoPeca);
                PontoDSuperior = new Point(inicialX + (profundidade * escalaReduzida) + espessura, iniciaY + inclinacaoPeca);
            }
            else
            {
                PontoASuperior = new Point(inicialX, iniciaY);
                PontoBSuperior = new Point(inicialX + (largura * escalaAmpliacao) + espessura, iniciaY);
                PontoCSuperior = new Point(inicialX + (largura * escalaAmpliacao) + (profundidade * escalaReduzida) + espessura, iniciaY + inclinacaoPeca);
                PontoDSuperior = new Point(inicialX + (profundidade * escalaReduzida), iniciaY + inclinacaoPeca);
            }



            Point[] baseSuperior = { PontoASuperior, PontoBSuperior, PontoCSuperior, PontoDSuperior };

            PecaProjetada.SuperficieInterna = baseSuperior;

            Point PontoAInferior = new Point(PontoASuperior.X, PontoASuperior.Y + espessura);
            Point PontoBInferior = new Point(PontoBSuperior.X, PontoBSuperior.Y + espessura);
            Point PontoCInferior = new Point(PontoCSuperior.X, PontoCSuperior.Y + espessura);
            Point PontoDInferior = new Point(PontoDSuperior.X, PontoDSuperior.Y + espessura);

            Point[] baseInferior = { PontoAInferior, PontoBInferior, PontoCInferior, PontoDInferior };

            PecaProjetada.SuperficieExterna = baseInferior;

            // borda frontal
            Point BordaAFrontal = PontoDSuperior;
            Point BordaBFrontal = PontoCSuperior;
            Point BordaCFrontal = PontoCInferior;
            Point BordaDFrontal = PontoDInferior;

            Point[] bordaFrontal = { BordaAFrontal, BordaBFrontal, BordaCFrontal, BordaDFrontal };

            PecaProjetada.BordaFrontal = bordaFrontal;


            // borda esquerda
            Point BordaAEsquerda = PontoASuperior;
            Point BordaBEsquerda = PontoDSuperior;
            Point BordaCEsquerda = PontoDInferior;
            Point BordaDEsquerda = PontoAInferior;

            Point[] bordaEsquerda = { BordaAEsquerda, BordaBEsquerda, BordaCEsquerda, BordaDEsquerda };

            PecaProjetada.BordaSuperior = bordaEsquerda;

            return PecaProjetada;


        }




        public static Peca3D ProjetarPorta(int largura = 60, int altura = 180, int profundidade = 60, int inicialX = 100, int iniciaY = 10, int escalaAmpliacao = 5, int espessura = 10, int inclinacaoPeca = 50, int quantidadePortas = 2, Lado ladoMacaneta = Lado.Direito, Boolean possuiAcabamentoSuperior = false, Boolean possuiAcabamentoInferior = false)
        {
            Peca3D PecaProjetada = new Peca3D();
            int escalaReduzida = escalaAmpliacao / 2;
            int larguraPorta = (largura * escalaAmpliacao) / quantidadePortas;

            Point PontoATraseiro;
            Point PontoBTraseiro;

            if (possuiAcabamentoSuperior)
            {
                PontoATraseiro = new Point(inicialX, iniciaY + (8 * escalaAmpliacao) + espessura); // Lateral Esquerda Inferior Externa
                PontoBTraseiro = new Point(inicialX + larguraPorta, iniciaY + (8 * escalaAmpliacao) + espessura);

            }
            else
            {

                PontoATraseiro = new Point(inicialX, iniciaY); // Lateral Esquerda Inferior Externa
                PontoBTraseiro = new Point(inicialX + larguraPorta, iniciaY);
            }

            //    Point PontoBTraseiro = new Point(inicialX + larguraPorta, iniciaY); // Lateral Esquerda Inferior Externa
            //    Point PontoCTraseiro = new Point(inicialX + larguraPorta, iniciaY + (altura * escalaAmpliacao) + (2* espessura));

            Point PontoCTraseiro;
            Point PontoDTraseiro;

            if (possuiAcabamentoInferior)
            {
                PontoCTraseiro = new Point(inicialX + larguraPorta, iniciaY + (altura * escalaAmpliacao) + espessura - (8 * escalaAmpliacao) - espessura);
                PontoDTraseiro = new Point(inicialX, iniciaY + (altura * escalaAmpliacao) + espessura - (8 * escalaAmpliacao) - espessura);

            }
            else
            {
                PontoCTraseiro = new Point(inicialX + larguraPorta, iniciaY + (altura * escalaAmpliacao) + espessura);
                PontoDTraseiro = new Point(inicialX, iniciaY + (altura * escalaAmpliacao) + espessura);

            }



            Point[] SuperficieTraseira = { PontoATraseiro, PontoBTraseiro, PontoCTraseiro, PontoDTraseiro };

            PecaProjetada.SuperficieExterna = SuperficieTraseira;

            Point PontoAFrontal = new Point(PontoATraseiro.X + (espessura / 2), PontoATraseiro.Y + (espessura / 2));
            Point PontoBFrontal = new Point(PontoBTraseiro.X + (espessura / 2), PontoBTraseiro.Y + (espessura / 2));
            Point PontoCFrontal = new Point(PontoCTraseiro.X + (espessura / 2), PontoCTraseiro.Y);
            Point PontoDFrontal = new Point(PontoDTraseiro.X + (espessura / 2), PontoDTraseiro.Y);

            Point[] SuperficieFrontal = { PontoAFrontal, PontoBFrontal, PontoCFrontal, PontoDFrontal };

            PecaProjetada.SuperficieInterna = SuperficieFrontal;

            // borda frontal
            Point BordaASuperior = PontoATraseiro;
            Point BordaBSuperior = PontoBTraseiro;
            Point BordaCSuperior = PontoBFrontal;
            Point BordaDSuperior = PontoAFrontal;

            Point[] bordaSuperior = { BordaASuperior, BordaBSuperior, BordaCSuperior, BordaDSuperior };

            PecaProjetada.BordaFrontal = bordaSuperior;


            // borda esquerda
            Point BordaAEsquerda = PontoATraseiro;
            Point BordaBEsquerda = PontoAFrontal;
            Point BordaCEsquerda = PontoDFrontal;
            Point BordaDEsquerda = PontoDTraseiro;

            Point[] bordaEsquerda = { BordaAEsquerda, BordaBEsquerda, BordaCEsquerda, BordaDEsquerda };

            PecaProjetada.BordaSuperior = bordaEsquerda;




            Macaneta3D macaneta = new Macaneta3D();

            if (ladoMacaneta == Lado.Direito)
            {
                macaneta.X = PontoBFrontal.X - 20;
                macaneta.Y = PontoBFrontal.Y + (PontoCFrontal.Y - PontoBFrontal.Y) / 2;
                macaneta.Largura = 15;
                macaneta.Altura = 15;

            }
            else // esquerda
            {
                macaneta.X = PontoAFrontal.X + 20;
                macaneta.Y = PontoBFrontal.Y + (PontoCFrontal.Y - PontoBFrontal.Y) / 2;
                macaneta.Largura = 15;
                macaneta.Altura = 15;

            }


            Macaneta3D[] macanetas = { macaneta };

            PecaProjetada.Macanetas = macanetas;


            return PecaProjetada;


        }

        public static Peca3D ProjetarAcabamento(int largura = 60, int altura = 180, int profundidade = 60, int inicialX = 100, int iniciaY = 10, int escalaAmpliacao = 5, int espessura = 10, int inclinacaoPeca = 50, int quantidadePortas = 2)
        {

            Peca3D PecaProjetada = new Peca3D();

            int escalaReduzida = escalaAmpliacao / 2;
            // int larguraPorta = (largura * escalaAmpliacao) / quantidadePortas;

            Point PontoATraseiro;
            Point PontoBTraseiro;
            Point PontoCTraseiro;
            Point PontoDTraseiro;



            PontoATraseiro = new Point(inicialX, iniciaY); // Lateral Esquerda Inferior Externa
            PontoBTraseiro = new Point(inicialX + (largura * escalaAmpliacao), iniciaY); // Lateral Esquerda Inferior Externa

            PontoCTraseiro = new Point(inicialX + (largura * escalaAmpliacao), iniciaY + (8 * escalaReduzida) + inclinacaoPeca);
            PontoDTraseiro = new Point(inicialX, iniciaY + (8 * escalaReduzida) + inclinacaoPeca);






            Point[] SuperficieTraseira = { PontoATraseiro, PontoBTraseiro, PontoCTraseiro, PontoDTraseiro };

            PecaProjetada.SuperficieExterna = SuperficieTraseira;

            Point PontoAFrontal = new Point(PontoATraseiro.X + (espessura / 2), PontoATraseiro.Y + (espessura / 2));
            Point PontoBFrontal = new Point(PontoBTraseiro.X + (espessura / 2), PontoBTraseiro.Y + (espessura / 2));
            Point PontoCFrontal = new Point(PontoCTraseiro.X + (espessura / 2), PontoCTraseiro.Y);
            Point PontoDFrontal = new Point(PontoDTraseiro.X + (espessura / 2), PontoDTraseiro.Y);

            Point[] SuperficieFrontal = { PontoAFrontal, PontoBFrontal, PontoCFrontal, PontoDFrontal };

            PecaProjetada.SuperficieInterna = SuperficieFrontal;

            // borda frontal
            Point BordaASuperior = PontoATraseiro;
            Point BordaBSuperior = PontoBTraseiro;
            Point BordaCSuperior = PontoBFrontal;
            Point BordaDSuperior = PontoAFrontal;

            Point[] bordaSuperior = { BordaASuperior, BordaBSuperior, BordaCSuperior, BordaDSuperior };

            PecaProjetada.BordaFrontal = bordaSuperior;


            // borda esquerda
            Point BordaAEsquerda = PontoATraseiro;
            Point BordaBEsquerda = PontoAFrontal;
            Point BordaCEsquerda = PontoDFrontal;
            Point BordaDEsquerda = PontoDTraseiro;

            Point[] bordaEsquerda = { BordaAEsquerda, BordaBEsquerda, BordaCEsquerda, BordaDEsquerda };

            PecaProjetada.BordaSuperior = bordaEsquerda;

            return PecaProjetada;



        }


        public static Peca3D ProjetarGavetas(int largura = 60, int altura = 180, int profundidade = 60, int inicialX = 100, int iniciaY = 10, int escalaAmpliacao = 5, int espessura = 10, int inclinacaoPeca = 50, int quantidadePortas = 2)
        {

            Peca3D PecaProjetada = new Peca3D();

            int escalaReduzida = escalaAmpliacao / 2;

            Point PontoATraseiro;
            Point PontoBTraseiro;
            Point PontoCTraseiro;
            Point PontoDTraseiro;



            PontoATraseiro = new Point(inicialX, iniciaY); // Lateral Esquerda Inferior Externa
            PontoBTraseiro = new Point(inicialX + (largura * escalaAmpliacao), iniciaY); // Lateral Esquerda Inferior Externa

            PontoCTraseiro = new Point(inicialX + (largura * escalaAmpliacao), iniciaY + ((altura * escalaReduzida) / 10) + inclinacaoPeca);
            PontoDTraseiro = new Point(inicialX, iniciaY + ((altura * escalaReduzida) / 10) + inclinacaoPeca);






            Point[] SuperficieTraseira = { PontoATraseiro, PontoBTraseiro, PontoCTraseiro, PontoDTraseiro };

            PecaProjetada.SuperficieExterna = SuperficieTraseira;

            Point PontoAFrontal = new Point(PontoATraseiro.X + (espessura / 2), PontoATraseiro.Y + (espessura / 2));
            Point PontoBFrontal = new Point(PontoBTraseiro.X + (espessura / 2), PontoBTraseiro.Y + (espessura / 2));
            Point PontoCFrontal = new Point(PontoCTraseiro.X + (espessura / 2), PontoCTraseiro.Y);
            Point PontoDFrontal = new Point(PontoDTraseiro.X + (espessura / 2), PontoDTraseiro.Y);

            Point[] SuperficieFrontal = { PontoAFrontal, PontoBFrontal, PontoCFrontal, PontoDFrontal };

            PecaProjetada.SuperficieInterna = SuperficieFrontal;

            // borda frontal
            Point BordaASuperior = PontoATraseiro;
            Point BordaBSuperior = PontoBTraseiro;
            Point BordaCSuperior = PontoBFrontal;
            Point BordaDSuperior = PontoAFrontal;

            Point[] bordaSuperior = { BordaASuperior, BordaBSuperior, BordaCSuperior, BordaDSuperior };

            PecaProjetada.BordaFrontal = bordaSuperior;


            // borda esquerda
            Point BordaAEsquerda = PontoATraseiro;
            Point BordaBEsquerda = PontoAFrontal;
            Point BordaCEsquerda = PontoDFrontal;
            Point BordaDEsquerda = PontoDTraseiro;

            Point[] bordaEsquerda = { BordaAEsquerda, BordaBEsquerda, BordaCEsquerda, BordaDEsquerda };

            PecaProjetada.BordaSuperior = bordaEsquerda;

            return PecaProjetada;



        }

    }
}
