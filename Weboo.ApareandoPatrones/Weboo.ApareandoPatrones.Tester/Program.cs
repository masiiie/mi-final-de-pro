using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.ApareandoPatrones.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Examen.CantidadCoincidencias("Hola Mundo", "Hola Mundo"));        // 1
            //Console.WriteLine(Examen.CantidadCoincidencias("Hola Mundo", "Hola Mundo!"));       // 0
            //Console.WriteLine(Examen.CantidadCoincidencias("?a?", "aa"));                       // 2
            //Console.WriteLine(Examen.CantidadCoincidencias("!+*", "abaa"));                     // 3
            //Console.WriteLine(Examen.CantidadCoincidencias("*?", ""));                          // 1
            //Console.WriteLine(Examen.CantidadCoincidencias("*?", "Otra cadena cualquiera"));    // 2

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine(Examen.CantidadCoincidencias("*+?","juego"));
            //Console.WriteLine(Examen.CantidadCoincidencias("?","juego"));
            //Console.WriteLine(Examen.CantidadCoincidencias("*","juego"));
            //Console.WriteLine(Examen.CantidadCoincidencias("*???+","juego"));
            //Console.WriteLine(Examen.CantidadCoincidencias("+",""));

            Examen.Coincidencias();
        }
    }
}
