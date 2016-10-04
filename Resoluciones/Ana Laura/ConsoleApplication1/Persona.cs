using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Persona
    {
        public Persona()
        {
        }

        public Persona(string nombre, DateTime fechaNacimiento, int nroDni)
        {
            this.nombre = nombre;
            this.fechaNacimiento = fechaNacimiento;
            this.nroDni = nroDni;



        }

        public DateTime fechaNacimiento { get; set; }
        public string nombre { get; set; }
        public int nroDni { get; set; }

        public static bool TryParsePersona(string strPersona, out Persona Resultado)
        {
            Persona p = new Persona();
            string[] cadena = strPersona.Split(';');
            if (cadena.Length == 3)
            {
                p.nombre = cadena[0];
                //fechaNacimiento = Convert.ToDateTime(cadena[1]);
                DateTime fecha = new DateTime();
                bool salida = DateTime.TryParse(cadena[1], out fecha);
                if (!salida)
                {
                    Console.WriteLine("La fecha no es válida");
                    Resultado = null;
                    return false;

                }

                DateTime fechaInicio = Convert.ToDateTime("01-01-1900");

                if (fechaInicio <= fecha && fecha <= DateTime.Today)
                {

                    p.fechaNacimiento = fecha;

                }
                else
                {
                    Console.WriteLine("La fecha no es válida");
                    Resultado = null;
                    return false;
                }


                int nro;
                salida = Int32.TryParse(cadena[2], out nro);

                if (!salida)
                {
                    Console.WriteLine("El nro. de documento no es válido");
                    Resultado = null;
                    return false;
                }

                if (nro > 0)
                {
                    p.nroDni = nro;
                }
                else
                {
                    Console.WriteLine("El nro. de documento no es válido");
                    Resultado = null;
                    return false;
                }
                
                Resultado = p;
                return true;
            }
            else
            {
                Resultado = null;
                return false;
            }


        }
    }
}
