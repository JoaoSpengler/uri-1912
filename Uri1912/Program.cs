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
            while (true)
            {
                string firstLine = Console.ReadLine();
                string[] firstVariable = firstLine.Split(' ');
                long valorArea = Convert.ToInt64(firstVariable[1]);
                long numberStrips = Convert.ToInt64(firstVariable[0]);

                if (numberStrips == 0 && valorArea == 0)
                {
                    break;
                }
                else
                {
                    string secondLine = Console.ReadLine();
                    string[] secondVariable = secondLine.Split(' ');
                    List<string> paperStrips = new List<string>();
                    paperStrips.AddRange(secondVariable);
                    List<long> paperRange = paperStrips.ConvertAll<long>(long.Parse);

                    paperRange.Sort();
                    paperRange.Reverse();

                    long expectedArea = 0;
                    long totalArea = paperRange.Sum();
                    long maxStrip = 0;
                    double cutHere = 0;


                    if (totalArea < valorArea)
                    {
                        Console.WriteLine("-.-");
                    }
                    else if (totalArea == valorArea)
                    {
                        Console.WriteLine(":D");
                    }
                    else
                    {
                        while (expectedArea < valorArea)
                        {
                            long rest = 0;
                            double test = 0;
                            long needCut = 0;
                            long equalsStrips = 0;
                            for (int strip = 0; strip < paperRange.Count; strip++)
                            {

                                if (strip == 0)
                                {
                                    equalsStrips += 1;
                                    maxStrip = paperRange[0];
                                    paperRange[strip] = (maxStrip - 1);
                                }
                                else if (paperRange[strip] == maxStrip)
                                {
                                    equalsStrips += 1;
                                    paperRange[strip] = (maxStrip - 1);
                                }
                            }
                            expectedArea += equalsStrips;
                            if (expectedArea > valorArea)
                            {
                                rest = expectedArea - valorArea;
                                needCut = (totalArea - rest);
                                test = (totalArea - needCut);
                                double equalsCut = Convert.ToDouble(equalsStrips);
                                cutHere = (test / equalsCut);
                                maxStrip = paperRange[0];
                            }
                            maxStrip = paperRange[0];

                        }
                        string finalCut = String.Format("{0:N4}", maxStrip + cutHere);
                        Console.WriteLine("{0}", finalCut);
                    }
                }
            }
        }
    }
}
