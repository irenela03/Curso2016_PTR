using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string rta;
            Console.WriteLine("¿Ejecutar Ejercicio 1? s/n");
            rta = Console.ReadLine();
            if(rta=="s")
                Ejercicio_1.EjecutarEjercicio1();

            Console.WriteLine("¿Ejecutar Ejercicio 2? s/n");
            rta = Console.ReadLine();
            if (rta == "s")
                Ejercicio_2.EjecutarEjercicio2();

        }
    }
}
