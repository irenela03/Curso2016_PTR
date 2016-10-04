using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ConsoleApplication1
{
    public class Ejercicio_1
    {
        public static void EjecutarEjercicio1()
        {
            DateTime fecha = DateTime.Today;
            Console.WriteLine("Fines de semana del año {0}", fecha.Year);

            DateTime inicio = new DateTime(fecha.Year, 1, 1);
            String txtInicio = inicio.ToShortDateString();

            DateTime fin = new DateTime(fecha.Year, 12, 31);
            String txtFin = fin.ToShortDateString();

            Console.WriteLine("Fecha inicio {0} y fecha fin {1}", txtInicio, txtFin);

          

#region Comentarios

           /* bool bisiesto = DateTime.IsLeapYear(fecha.Year);
            int diasDelAnio =0;
            int diasFeb = 0;

            if (bisiesto)
            {
                diasDelAnio = 366;
                diasFeb = 29;
            }               
            else
            {
                diasDelAnio = 365;
                diasFeb = 28;
            }*/

#endregion

            int i = 0;
            DateTime temporal = inicio;
            while (temporal <= fin)
            {
                //Console.WriteLine("Entró al While");
                //Console.WriteLine(temporal.DayOfWeek);

                if (temporal.DayOfWeek == DayOfWeek.Saturday)
                {
                    i++;
                    string dia = "Sábado";
                    int mesNro = temporal.Month;
                    string txtMes = getNombreMes(mesNro);
                    //  Console.WriteLine("Fin de semana #{0} - {1} {2} de {3}  ", i,dia,temporal.Day,txtMes);
                    Console.WriteLine("Fin de semana #{0} - {1:dddd} {1:dd} de {1:MMMM}  ", i, temporal);

        }
                temporal = temporal.AddDays(1);

                if(temporal.DayOfWeek == DayOfWeek.Sunday && temporal <= fin)
                {
                    string dia = "Domingo";
                    int mesNro = temporal.Month;
                    string txtMes = getNombreMes(mesNro);
                    Console.WriteLine("Fin de semana #{0} - {1} {2} de {3}  ", i, dia, temporal.Day, txtMes);
                }

            }
            Console.ReadKey();
            Console.ReadKey();
            Console.ReadKey();

        }

        private static string getNombreMes(int mesNro)
        {
            try
            {
                DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
                string nombreMes = formatoFecha.GetMonthName(mesNro);

                return nombreMes;
            }
            catch
            {
                return "No se encontró el mes";
            }
        }
    }
}
