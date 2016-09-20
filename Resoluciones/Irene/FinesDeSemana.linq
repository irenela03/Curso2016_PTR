<Query Kind="Program" />

void Main()
{
 	DateTime Fecha;
	Fecha = new DateTime(2016, 1, 1);
	int FinDeSemana;
	FinDeSemana = 1;
	int CantDias = 0;
	Console.WriteLine("Fines de semana del año {0}", Fecha.Year);
	while (Fecha.Year == 2016)
	{
		if (Fecha.DayOfWeek == DayOfWeek.Saturday)
		{
			Console.WriteLine("Fin de semana # {0} - Sábado {1:dd} de {2:MMM}", FinDeSemana, Fecha, Fecha);
			CantDias++;
		}
        else
        {
			if (Fecha.DayOfWeek == DayOfWeek.Sunday)
			{
				Console.WriteLine("Fin de semana # {0} - Sábado {1:dd} de {2:MMM}", FinDeSemana, Fecha, Fecha);
				CantDias++;
                FinDeSemana++;
			}
		
		}
		
		Fecha = Fecha.AddDays(1);
					
	}
	Console.WriteLine("Cantidad de dias que corresponden a fines de semana: {0}", CantDias);
 }


// Define other methods and classes here
