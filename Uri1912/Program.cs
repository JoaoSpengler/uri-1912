using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uri1912
{
	class Program
	{
		static void Main(string[] args)
		{
			while(true)
			{
				string primeiraLinha = Console.ReadLine();
				string[] primeirasVariaveis = primeiraLinha.Split(' ');
                int valorArea = Convert.ToInt32(primeirasVariaveis[1]);
                int numTiras = Convert.ToInt32(primeirasVariaveis[0]);

                if (numTiras != 0 && valorArea != 0)
				{
					string segundaLinha = Console.ReadLine();
					string[] segundaVariavel = segundaLinha.Split(' ');
					//logica de corte
					int somaTiras = 0;

                    for (int i = 0 ; i < numTiras ; i++)
					{
						somaTiras += Convert.ToInt32(segundaVariavel[i]);
					}
					if (somaTiras == valorArea) 
					{
						Console.WriteLine(":D"); 
					}
					else if (somaTiras < valorArea)
					{
						Console.WriteLine("-.-");
					}
					else
					{
                        //pode cortar
                        //logica do maior
                        int maior = 0;
                        int numMaior = 0;
                        int area = 0;
                        int alturaCorte = 0;
                        bool alturaQuebrada = false;
                        double maiorQuebrado = 0;

                        //int posicaoIguais[] = new int;
                        int iguais = 0;
                        while (valorArea > area)
                        {
                            for (int i = 0; i < numTiras ; i++)
                            {
                                if (i == 0)
                                {
                                    maior = Convert.ToInt32(segundaVariavel[i]);
                                    numMaior = i;
                                    iguais = 1;
                                }
                                else if (Convert.ToInt32(segundaVariavel[i]) > maior)
                                {
                                    maior = Convert.ToInt32(segundaVariavel[i]);
                                    numMaior = i;
                                    iguais = 1;
                                }
                                else if (Convert.ToInt32(segundaVariavel[i]) == maior)
                                {
                                    iguais += 1;
                                }
                            }
                            if (iguais > valorArea)
                            {
                                //logica dos quebrados
                                int areaRestante = valorArea - area;
                                int restoCorte = iguais - areaRestante;
                                double numTirasDouble = Convert.ToDouble(numTiras);
                                double restoDouble = Convert.ToDouble(restoCorte);
                                double tirasQuebradas = restoDouble / numTirasDouble;
                                string valorQuebrado = Convert.ToString(maior - tirasQuebradas);

                                for (int i = 0; i < numTiras; i++)
                                {
                                    if (maior == Convert.ToInt32(segundaVariavel[i]))
                                    {
                                        segundaVariavel[i] = valorQuebrado;
                                    }
                                }
                                area += iguais ;
                                alturaQuebrada = true;
                                maiorQuebrado = Convert.ToDouble(valorQuebrado);
                                //break;
                            }
                            else if (iguais == valorArea)
                            {
                                string novoValor = Convert.ToString(maior - 1);
                                for (int i = 0; i < numTiras; i++)
                                {
                                    if (maior == Convert.ToInt32(segundaVariavel[i]))
                                    {
                                        segundaVariavel[i] = novoValor;
                                    }
                                }
                                area += iguais;
                                maior -= 1;
                            }
                            else
                            {
                                string novoValor = Convert.ToString(maior - 1);
                                segundaVariavel[numMaior] = novoValor;
                                maior -= 1;
                                area += 1;
                            }
                        }
                        if(alturaQuebrada == false)
                        {
                            alturaCorte = maior;
                            Console.WriteLine("A altura do corte é: {0} cm", alturaCorte);
                        }
                        else
                        {
                            string alturaCorteQuebrada = String.Format( "{0:N4}", maiorQuebrado);
                            Console.WriteLine("A altura do corte é: {0} cm", alturaCorteQuebrada);
                        }
                    }
				}
				else
				{
					//se N = A = 0
					break;
				}
			}
		}
	}
}
