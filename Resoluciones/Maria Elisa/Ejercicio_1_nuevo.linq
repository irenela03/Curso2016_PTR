<Query Kind="Program" />

void Main()
{
  DateTime fecha;
  //DateTime.TryParse("01/01/2016", out fecha);   //  BIEN PENSADO!
  
  //  Despues proba lo siguiente (en lugar del Parse):
    fecha = new DateTime(2016, 1, 1);
  //  es lo que dije el martes pasado de ctores en tipos por valor
  
  int cant_dias = 0;
  int semana = 1;

  Console.WriteLine("Fines de semana del año 2016");
  while (fecha.Year == 2016)
  {
    //  podes usar el || para comprobar el fin de semana y te ahorras el else if
    if (fecha.DayOfWeek == DayOfWeek.Saturday || fecha.DayOfWeek == DayOfWeek.Sunday)
    {
      //  podes usar los formatos de dia y mes largo MMMM para presentar la fecha sin tener que extraer 
      //  las partes que lo constituyen
      Console.WriteLine("Fin de Semana Número {0} - {1: dddd dd 'de' MMMMM}", semana, fecha);

      cant_dias += 1;

      //  control para no sumar dos veces el mismo fin de semana (solo sumamos cuando es domingo)
      if (fecha.DayOfWeek == DayOfWeek.Sunday)
        semana += 1;
    }
    fecha = fecha.AddDays(1);
  }

  Console.WriteLine("Cantidad de días que corresponden a fines de semana: {0} ", cant_dias);
}

// Define other methods and classes here