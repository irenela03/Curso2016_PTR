<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Namespace>System</Namespace>
</Query>

void Main()
{
	DateTime fecha;
	DateTime.TryParse("01/01/2016", out fecha);
	int cant_dias = 0;
	int semana = 1;
	
	Console.WriteLine("Fines de semana del año 2016");
	while(fecha.Year == 2016)
	{
	
	if(fecha.DayOfWeek == DayOfWeek.Saturday)
	{
	Console.WriteLine("Fin de Semana Número {0} - Sabado {1} de {2} ", semana, fecha.Day, fecha.Month);
	cant_dias += 1;
	}
	else if(fecha.DayOfWeek == DayOfWeek.Sunday)
	{
	Console.WriteLine("Fin de Semana Número {0} - Domingo {1} de {2} ", semana, fecha.Day, fecha.Month);
	cant_dias += 1;
	semana += 1;
	}
	
	fecha = fecha.AddDays(1);
	}
	
	Console.WriteLine("Cantidad de días que corresponden a fines de semana: {0} ", cant_dias);
}

// Define other methods and classes here
