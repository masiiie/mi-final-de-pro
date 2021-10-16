using System;

namespace Weboo.ExamenABBE.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            ABBE<int> t1 = new ABBE<int>();

            t1.Inserta(4);
            t1.Inserta(3);
            t1.Inserta(8);
            t1.Inserta(5);
            t1.Inserta(2);

            foreach (var f in t1.FrecuenciaPorValor())
                Console.WriteLine("{0}: {1}", f.Valor, f.Cantidad);
            Console.WriteLine();

            // 2: 1
            // 3: 2
            // 4: 3
            // 5: 1
            // 8: 2



            ABBE<string> t2 = new ABBE<string>();

            t2.Inserta("c");
            foreach (var f in t2.FrecuenciaPorValor())
                Console.WriteLine("{0}: {1}", f.Valor, f.Cantidad);
            Console.WriteLine();

            // c: 1

            t2.Inserta("a");
            foreach (var f in t2.FrecuenciaPorValor())
                Console.WriteLine("{0}: {1}", f.Valor, f.Cantidad);
            Console.WriteLine();

            // a: 1
            // c: 2

            t2.Inserta("i");
            foreach (var f in t2.FrecuenciaPorValor())
                Console.WriteLine("{0}: {1}", f.Valor, f.Cantidad);
            Console.WriteLine();

            // a: 1
            // c: 3
            // i: 1

            t2.Inserta("o");
            foreach (var f in t2.FrecuenciaPorValor())
                Console.WriteLine("{0}: {1}", f.Valor, f.Cantidad);
            Console.WriteLine();

            // a: 1
            // c: 3
            // i: 2
            // o: 1

            t2.Inserta("n");
            foreach (var f in t2.FrecuenciaPorValor())
                Console.WriteLine("{0}: {1}", f.Valor, f.Cantidad);
            Console.WriteLine();

            // a: 1
            // c: 3
            // i: 2
            // o: 2
            // n: 1

            var m = new ABBE<string>();
            m.Inserta("a");
            m.Inserta("z");
            m.Inserta("K");
            foreach (var item in m.FrecuenciaPorValor())
            {
                Console.WriteLine(item.Valor+": "+item.Cantidad);
            }
            Console.WriteLine();
        }
    }
}
