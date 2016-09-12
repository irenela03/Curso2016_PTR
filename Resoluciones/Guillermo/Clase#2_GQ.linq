<Query Kind="Program">
  <Reference Relative="Curso2016_PTR-master1\Curso2016_PTR-master\Clases_1_a_6\CSV\bin\Debug\CSV.dll">C:\Users\GQ\Desktop\curso_2016\Curso2016_PTR-master1\Curso2016_PTR-master\Clases_1_a_6\CSV\bin\Debug\CSV.dll</Reference>
  <Namespace>CSV</Namespace>
</Query>

void Main()
{
	FileInfo fi = new FileInfo(@"C:\Users\GQ\Desktop\curso_2016\Clima en Rosario.csv");
	if (fi.Exists)
  	{  
		CSV.CSVFile csv = new CSV.CSVFile(fi);
		Console.WriteLine($"Lineas: {csv.Lineas} ; Max Columnas: {csv.MaxColumnas}");
		int fila = 0;
		int col = 1;
				
		//Console.WriteLine($"Elemento en la posicion [1, 1] ==> {csv.LeerCampo(1, 3)}");
		
		while (csv.LeerCampo(fila, col) != "Mean TemperatureC" && fila <=1 && fila >=0 && col <= csv.MaxColumnas)
		{
			col++;
		}
		Console.WriteLine($"La columna Mean TemperatureC es la Nro: { col }");
		
		decimal TotalMeanTemp = 0;
		int TotalFila = 0;
		
		for (int f = 1 ; f < csv.Lineas; f++)
		{
			if (csv.LeerCampo(f, col) != "Mean TemperatureC")
			{
				//Console.WriteLine(csv.LeerCampo(f, col));
				TotalMeanTemp += Convert.ToInt32(csv.LeerCampo(f, col));
				TotalFila ++;
			}
						
		}
		//Console.WriteLine($"Total Temp: { TotalMeanTemp }, total filas { TotalFila }");
		decimal Promedio;
		Promedio = TotalMeanTemp / TotalFila;
		Console.WriteLine($"Temperatura Promedio: { Promedio.ToString("0.##") }; Total Temp: { TotalMeanTemp }, Cant. días: { TotalFila }");
		
		col = 1;
		while (csv.LeerCampo(fila, col) != "Max TemperatureC" && fila <=1 && fila >=0 && col <= csv.MaxColumnas)
		{
			col++;
		}
		Console.WriteLine($"La columna Max TemperatureC es la Nro: { col }");
		
		int filaMax = 1;
		int tempMax = 0;
		for (int f = 1 ; f < csv.Lineas; f++)
		{
			if (csv.LeerCampo(f, col) != "Max TemperatureC")
			{
				//Console.WriteLine(csv.LeerCampo(f, col));
				if (Convert.ToInt32(csv.LeerCampo(f, col)) > tempMax)
				{
					tempMax = Convert.ToInt32(csv.LeerCampo(f, col));
					filaMax = f;
				}
				
			}
						
		}
		
		Console.WriteLine($"La Temperatura Máxima fue de: { tempMax }, del día { csv.LeerCampo(filaMax, 1) }");
		
		col = 1;
		while (csv.LeerCampo(fila, col) != "Min TemperatureC" && fila <=1 && fila >=0 && col <= csv.MaxColumnas)
		{
			col++;
		}
		Console.WriteLine($"La columna Min TemperatureC es la Nro: { col }");
		
		int filaMim = 1;
		int tempMin = 0;
		for (int f = 1 ; f < csv.Lineas; f++)
		{
			if (csv.LeerCampo(f, col) != "Min TemperatureC")
			{
				//Console.WriteLine(csv.LeerCampo(f, col));
				if (Convert.ToInt32(csv.LeerCampo(f, col)) < tempMin)
				{
					tempMin = Convert.ToInt32(csv.LeerCampo(f, col));
					filaMim = f;
				}
				
			}
						
		}
		
		Console.WriteLine($"La Temperatura Mínima fue de: { tempMin }, del día { csv.LeerCampo(filaMim, 1) }");
		
  	}
	
}

// Define other methods and classes here
