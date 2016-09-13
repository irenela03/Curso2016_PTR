<Query Kind="Program">
  <Reference Relative="CSV.dll">F:\CURSO_2016_01\src\Resoluciones\Ana Laura\CSV.dll</Reference>
  <Namespace>CSV</Namespace>
</Query>

void Main()
{
    string fileName =@"F:\CURSO_2016_01\src\Resoluciones\Ana Laura\Clima en Rosario.csv";
    FileInfo fi = new FileInfo(fileName);

    if (fi.Exists)
    {
        Console.WriteLine("El tamaño dela rchivo es {0} bytes y fue creado el {1}", fi.Length, fi.CreationTime);
		CSVFile archivoClima = new CSVFile(fi);
	    int nroColMeanTemp = encontrarColumna(archivoClima, "Mean TemperatureC");
		
		if(nroColMeanTemp!=0)
		{
			//Console.WriteLine("Número columna de Mean TemperatureC :"+nroColMeanTemp);
			calcularPromedio(archivoClima, nroColMeanTemp);
		}
		else
		{
			Console.WriteLine("No encontró la columna de temperatura promedio");
		}
		int nroColFechaTemp = encontrarColumna(archivoClima, "ART");
		if(nroColFechaTemp!=0)
		{
			int nroColTempMax = encontrarColumna(archivoClima, "Max TemperatureC");
			if(nroColTempMax!=0)
			{
				//Console.WriteLine("Número columna de Temperatura Máxima:"+nroColTempMax);
				buscarTempMax(archivoClima, nroColTempMax, nroColFechaTemp);
			}
			else
			{
				Console.WriteLine("No encontró la columna de temperatura máxima");
			}
			
			int nroColTempMin = encontrarColumna(archivoClima, "Min TemperatureC");
			if(nroColTempMin!=0)
			{
				//Console.WriteLine("Número columna de Temperatura Máxima:"+nroColTempMin);
				buscarTempMin(archivoClima, nroColTempMin,nroColFechaTemp);
			
			}
			else
			{
				Console.WriteLine("No encontró la columna de temperatura mínima");
			}
		
		}
		else
		{
			Console.WriteLine("No se encontró la columna fecha");
		}
		
    }
    else
	{
        Console.WriteLine("El archivo no existe");
		
	}
	
}

 int encontrarColumna(CSVFile archivoClima, string cadena)
{
	int i;
	for(i=1; i<= archivoClima.MaxColumnas; i++)
	{
		
		string nombre = archivoClima.LeerCampo(1,i);
		//Console.WriteLine("Nombre Columna: "+nombre);
		if(nombre.Equals(cadena))
			{
				
				return i;
				break;
			}
	}
	return i=0;
}
void calcularPromedio(CSVFile archivoClima, int nroColMeanTemp)
{
   int i;
   //float max=0;
   float valor =0.0F;
   float acum = 0.0F;
   int cantLineas = archivoClima.Lineas;
   //DateTime fechaMaximoValor;
   
   for(i=2; i<=cantLineas; i++)
   	{
		String dato = archivoClima.LeerCampo(i,nroColMeanTemp);
		if(dato!=null)
		{
			valor = float.Parse(dato);
			acum += valor;
		}
		
	}
   	float promedio = acum/cantLineas;
	//promedio.ToString(".0");
	 Math.Round(promedio, 1);
	Console.WriteLine("PRomedio: {0}", Math.Round(promedio, 1));
}
void buscarTempMin(CSVFile archivoClima, int nroColTempMin, int nroColFechaTemp)
{
	int i;
	float min=99999;
	int cantLineas = archivoClima.Lineas;
	DateTime fechaMinimoValor = DateTime.Now;
	for(i=2; i<=cantLineas; i++)
	 {
	 	String dato = archivoClima.LeerCampo(i,nroColTempMin);
		if(dato!=null)
		{
			float valor = float.Parse(dato);
			if(valor < min)
			{
				min = valor;
				string fecha = archivoClima.LeerCampo(i, nroColFechaTemp);
				fechaMinimoValor = DateTime.Parse(fecha);
				
			}
	
		}
	 }
	 Console.WriteLine("EL minimo valor es {0} y fue observado el día {1}", min, fechaMinimoValor.ToShortDateString());
	
}

void buscarTempMax(CSVFile archivoClima, int nroColTempMax, int nroColFechaTemp)
{
	int i;
	float max=0;
	int cantLineas = archivoClima.Lineas;
	DateTime fechaMaximoValor = DateTime.Now;
	for(i=2; i<=cantLineas; i++)
	 {
	 	String dato = archivoClima.LeerCampo(i,nroColTempMax);
		if(dato!=null)
		{
			float valor = float.Parse(dato);
			if(valor > max)
			{
				max = valor;
				string fecha = archivoClima.LeerCampo(i, nroColFechaTemp);
				fechaMaximoValor = DateTime.Parse(fecha);
				
			}
	
		}
	 }
	 string maxTemp =max.ToString();
	 Console.WriteLine("EL minimo valor es {0} y fue observado el día {1}", max, fechaMaximoValor.ToShortDateString());
	
}