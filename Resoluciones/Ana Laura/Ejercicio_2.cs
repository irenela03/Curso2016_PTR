using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Ejercicio_2
    {
        public static void EjecutarEjercicio2()
        {
            Persona p = new Persona();
            char rta = 's';
            do
            {
                List<string> cadena = new List<string>();
                Console.WriteLine("Ingrese nombre y apellido de la persona");
                //Console.WriteLine("La cadena que ingrese debe tener el siguiente formato");
                //Console.WriteLine("Homero J Simpson ; 01/01/1960 ; 14879898");
                string nombre = Console.ReadLine();
                cadena.Add(nombre);

                Console.WriteLine("Ingrese fecha de nacimiento de la persona, dd/mm/aaaa");
                string fechaNacimiento = Console.ReadLine();
                cadena.Add(fechaNacimiento);
                Console.WriteLine("Ingrese nro. de documento de la persona");
                string nroDocumento = Console.ReadLine();
                cadena.Add(nroDocumento);

                string cadenaConcatenada = String.Join(";", cadena.ToArray());

                Console.WriteLine("La cadena concatenada es {0} ", cadenaConcatenada);
                
                if (Persona.TryParsePersona(cadenaConcatenada, out p))
                {
                    Console.WriteLine("El nombre es: {0}", p.nombre);
                    string txtFecha = p.fechaNacimiento.ToShortDateString();
                    Console.WriteLine("La fecha de nacimiento es: {0}", txtFecha);
                    Console.WriteLine("El nro de documento es: {0}", p.nroDni);

                }
                else
                {
                    Console.WriteLine("Los datos no tienen el formato correcto");
                    Console.WriteLine("¿Desea volver a ingresar los datos?");
                    rta = Console.ReadKey().KeyChar;
                    Console.ReadKey();
                }


            } while (p==null && rta=='s');
            
            

            Console.ReadKey();
            Console.ReadKey();



        }
    }
}
