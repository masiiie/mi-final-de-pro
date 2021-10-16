using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.ApareandoPatrones
{
    public static class Examen
    {
        public static int CantidadCoincidencias(string patron, string cadena)
        {
            var diccionario = ConstruirDiccionario(cadena);
            return Coincidencias(0, cadena, 0, patron, diccionario);
        }
        public static void Coincidencias()
        {
            Console.WriteLine("Cadena");
            var cadena = Console.ReadLine();
            Console.WriteLine("Patron");
            var patron = Console.ReadLine();
            var dicci = ConstruirDiccionario(cadena);
            Console.WriteLine(Coincidencias(0, cadena, 0, patron, dicci));
        }
        static int Coincidencias(int pos, string cadena, int poscadena, string patron, Dictionary<char, Tuple<int, int>> comodines)
        {
            if (poscadena == cadena.Length && pos == patron.Length) return 1;
            else
            {
                int sol = 0;
                if (pos < patron.Length && comodines.Keys.Contains(patron[pos]))
                {
                    int min = comodines[patron[pos]].Item1;
                    int max = comodines[patron[pos]].Item2;
                    for (int j = min; j < max + 1; j++)
                    {
                        int posf = poscadena + j;
                        if (posf <= cadena.Length && posf > -1) sol += Coincidencias(pos + 1, cadena, posf, patron, comodines);
                    }
                }
                else
                {
                    if (pos < patron.Length && poscadena < cadena.Length && patron[pos] == cadena[poscadena]) sol += Coincidencias(pos + 1, cadena, poscadena + 1, patron, comodines);
                }
                return sol;
            }
        }
        static Dictionary<char, Tuple<int, int>> ConstruirDiccionario(string cadena)
        {
            var comodines = new Dictionary<char, Tuple<int, int>>();
            comodines.Add('!', new Tuple<int, int>(1, 1));
            comodines.Add('?', new Tuple<int, int>(0, 1));
            comodines.Add('*', new Tuple<int, int>(0, cadena.Length));
            comodines.Add('+', new Tuple<int, int>(1, cadena.Length));
            return comodines;
        }
    }
}
