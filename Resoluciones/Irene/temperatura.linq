<Query Kind="Program">
  <Reference Relative="CSV.dll">&lt;MyDocuments&gt;\LINQPad Queries\Alumnos\Irene\CSV.dll</Reference>
  <Namespace>CSV</Namespace>
</Query>

void Main()
{
	int coltemperatura;
	bool encontrado = false;
	int filaActual;
	string diaMinimo, diamaximo;
	float tempMinima, tempmaxima, tempacumulada;
	DateTime Minima, Maxima;
	
	FileInfo fi = new FileInfo(@"C:\Users\u167055\Documents\LINQPad Queries\Alumnos\Irene\Clima en Rosario.csv");

	if (!fi.Exists)
	{
		Console.WriteLine("No existe el archivo");
		return;
		
	}
	CSVFile csv = new CSVFile(fi);
	//  Console.WriteLine($"Lineas: {csv.Lineas} ; Columnas: {csv.MaxColumnas}");
  Console.WriteLine("Lineas: {0} ; Columnas: {1}", csv.Lineas, csv.MaxColumnas);
	coltemperatura = 1;
	while (coltemperatura <= csv.MaxColumnas && !encontrado)
	{
		if (csv.LeerCampo(1, coltemperatura) == "Mean TemperatureC")
		encontrado = true;
		else
		     coltemperatura++;
	}
	if (!encontrado)
	{
		Console.WriteLine("No se encontro la columna temperatura media");
		return;
	
	}	
	tempmaxima = float.MinValue;
	tempMinima = float.MaxValue;
	tempacumulada = 0.0F ;
	filaActual = 2;
	diaMinimo = "";
	diamaximo = "";
	while (filaActual <= csv.Lineas-1)
	{
		float tempActual = 0.0F;
		string stempActual = csv.LeerCampo(filaActual, coltemperatura);
		tempActual = float.Parse(stempActual);
		if (stempActual != null)
		{
			tempacumulada += tempActual;

			if (tempActual > tempmaxima)
			{
				tempmaxima = tempActual;
				diamaximo = csv.LeerCampo(filaActual, 1);
			}
			if (tempActual < tempMinima)
			{
			tempMinima = tempActual;
			diaMinimo = csv.LeerCampo(filaActual, 1);
			}
					
		filaActual++;
		}
	}
	tempacumulada = tempacumulada / csv.Lineas;
	Minima = DateTime.Parse(diaMinimo);
	Maxima = DateTime.Parse(diamaximo);
/*  
	Console.WriteLine($"La temperatura media es {tempacumulada.ToString("N1")} ");
	Console.WriteLine($"La temperatura minima es {tempMinima.ToString("N1")} el dia {Minima.ToString("yyyy/MM/dd")}");
	Console.WriteLine($"La temperatura maxima es {tempmaxima.ToString("N1")} el dia {Maxima.ToString("yyyy/MM/dd")}");
*/
	Console.WriteLine("La temperatura media es {0} ", tempacumulada.ToString("N1"));
	Console.WriteLine("La temperatura minima es {0} el dia {1}", tempMinima.ToString("N1"), Minima.ToString("yyyy/MM/dd"));
	Console.WriteLine("La temperatura maxima es {0:N1} el dia {1:yyyy/MM/dd}", tempmaxima, Maxima);
}
