<Query Kind="Program" />

DateTime ahora;
DateTime fin;
int diasem;
int nrodia;
int finde;
int anio=DateTime.Now.Year;

void Main()
{
	DateTime ahora = new DateTime (anio,1,1);
	DateTime fin = new DateTime (anio,12,31);
	nrodia = (int)ahora.DayOfWeek;
	Console.WriteLine("Fines de semana del año {0}",ahora.Year);
	
	if (ahora.DayOfWeek==DayOfWeek.Sunday)
	{
		while(ahora <= fin)
    {
	    finde++;
	    Console.WriteLine("Fin de semana {3}: Domingo {0} de {2}", ahora.ToString("dd"), ahora.DayOfWeek,
        ahora.ToString("MMMM"),finde);
	    Console.WriteLine("Fin de semana {3}: {1} {0} de {2}", ahora.AddDays(6).ToString("dd"), 
        ahora.AddDays(6).DayOfWeek,ahora.AddDays(6).ToString("MMMM"),finde+1);
        
	    ahora=ahora.AddDays(7);
	 }
	}
	else
	{
	  while(ahora <= fin)
    {
      //  itera hasta encontrar un sabado 
  		if (ahora.DayOfWeek == DayOfWeek.Saturday)
    	{
        // ==> incrementa el # de fines de semana y muestra el sabado
      	finde++;
      	Console.WriteLine("Fin de semana {3}: Sabado {0} de {2}",
          ahora.ToString("dd"), ahora.DayOfWeek, ahora.ToString("MMMM"), finde);

        //  valida el caso que justo el sabado sea el ultimo dia del año...
        //  si no lo es, el dia siguiente (domingo) forma parte del mismo fin de semana)
        //  Usa AddDays(1) para apuntar al dia siguiente
        if (ahora!=fin) 
          Console.WriteLine("Fin de semana {3}: {1} {0} de {2}", 
            ahora.AddDays(1).ToString("dd"), ahora.AddDays(1).DayOfWeek, 
            ahora.AddDays(1).ToString("MMMM"), finde);
    	}
  	  ahora=ahora.AddDays(1);
	  }
	}
}

// Define other methods and classes here