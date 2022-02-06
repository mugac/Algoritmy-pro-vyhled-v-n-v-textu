using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VyhledavaciAlgo
{
    internal class Program
    {
        public static int pocetChar = 256;
        static void Main(string[] args)
        {
            Search("jak", "Ahoj jak se mas", 101);
            Console.ReadLine();
        }

        static void Search(string patern, string text, int q)
        {
            int lenPat = patern.Length;
            int lenTex = text.Length;
            int hasPat = 0;
            int hasTex = 0;
            int i, j;
            int h = 1;

            for (i = 0; i < lenPat - 1; i++)
            {
                h = (h * pocetChar) % q;
            }

            for (i = 0; i < lenPat; i++)
            {
                hasPat = (pocetChar * hasPat + patern[i] )% q;
                hasTex = (pocetChar * hasTex + text[i] )% q;
            }

            for (i = 0; i <= lenTex - lenPat; i++)
            {
                if (hasTex == hasPat)
                {
                    for (j = 0; j < lenPat; j++)
                    {
                        if (text[i + j] != patern[j])
                        {
                            break;
                        }
                    }

                    if (j == lenPat)
                    {
                        Console.WriteLine("Patern byl nalezen na indexu " + i);
                    }

                    
                }
                if (i < lenTex - lenPat)
                {
                    hasTex = (pocetChar * (hasTex - text[i] * h) + text[i + lenPat] )% q;

                    if (hasTex < 0)
                    {
                        hasTex += q;
                    }
                }
            }

        }
    }
}
