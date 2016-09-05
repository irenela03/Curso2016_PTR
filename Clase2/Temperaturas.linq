<Query Kind="Program">
  <Reference Relative="CSV.dll">F:\CURSO_2016_01\src\Clase2\CSV.dll</Reference>
  <Namespace>CSV</Namespace>
</Query>


/*
  Recordar agregar la referencia  con F4 al assembly CSV.dll
  Luego, en [Additional Namespace Imports] incorporar el namespace CSV
  
  CSVFile dispone de dos propiedades
  
  int Lineas      --> retorna la cantidad total de lineas del archivo (ojo, alguna puede estar vacia!!)
  int MaxColumnas --> retorna la cantidad maxima de columnas de cualquier linea del archivo
                      podemos suponer que todas las lineas contienen la misma cantidad de columnas
  
  CSVFile tiene un metodo
  
  string LeerCampo(int fila, int columna) --> retorna el valor texto en la posicion que le pasamos. Tanto fila 
                                              como columna empiezan desde la posicion 1 (uno) o sea no hay fila
                                              ni columna CERO
*/

const string NOMBRE_COLUMNA = "Mean TemperatureC";

void Main()
{
  //  paso 1: encontrar el numero de columna que contiene el dato de [Mean TemperatureC] --> no hardcodearlo!!!
  //          los nombres de las columnas estan en la fila #1
  //  paso 2: iterar desde
  
  FileInfo fi = new FileInfo(@"F:\CURSO_2016_01\src\Clase2\Clima en Rosario.csv");

  //  solo avanzamos si el archivo existe
  //
  if (fi.Exists)
  {
    int columnaDatos;
    int dias;
    int filaActual, filaTempMin, filaTempMax;
    float tempMin, tempMax, tempAcum;
    DateTime fechaTempMin, fechaTempMax;
    
    CSVFile csv = new CSVFile(fi);
    
    //  para debug...
    //  Console.WriteLine("Cantidad de lineas: {0}", csv.Lineas);
    //  Console.WriteLine("Cantidad de columnas: {0}", csv.MaxColumnas);
    
    //  buscar columna de datos
    columnaDatos = 1;
    bool encontrado = false;
    while (columnaDatos <= csv.MaxColumnas && !encontrado)
    {
      if (csv.LeerCampo(1, columnaDatos) == NOMBRE_COLUMNA)
        encontrado = true;
      else
        columnaDatos++;
    }

    if (encontrado)
    {
      //  debug
      //  Console.WriteLine("[{0}] encontrado en la columna #{1}", NOMBRE_COLUMNA, columnaDatos);
      
      //  recorre el archivo acumulando y comparando
      //
      tempMax = float.MinValue;     //  por que esto??
      tempMin = float.MaxValue;
      tempAcum = 0.0F;
      
      filaTempMax = filaTempMin = 0;
      filaActual = 2;
      dias = 0;
      while (filaActual <= csv.Lineas)
      {
        string sTemp = csv.LeerCampo(filaActual, columnaDatos);
        
        if (sTemp != null)
        {
          float fTemp = float.Parse(sTemp);

          tempAcum += fTemp;
          
          //  recien aca incremento los dias porque sume al acumulado!
          dias++;
          
          if (fTemp > tempMax)
          {
            tempMax = fTemp;
            filaTempMax = filaActual;
          }
          if (fTemp < tempMin)
          {
            tempMin = fTemp;
            filaTempMin = filaActual;
          }
        }
        filaActual++;
      }
      //  obtengo las fechas reales y las transformo
      fechaTempMin = DateTime.Parse(csv.LeerCampo(filaTempMin, 1));
      fechaTempMax = DateTime.Parse(csv.LeerCampo(filaTempMax, 1));
      //
      Console.WriteLine("FIN DEL PROCESO\n");

      Console.WriteLine("Promedio de temperatura MEDIA del año: {0:F2} C\n", tempAcum / dias);
      
      Console.WriteLine("Temperatura MEDIA maxima y minima");
      Console.WriteLine("MAXIMA fue de {0:F2} C y se produjo el {1:dd/MM}", tempMax, fechaTempMax);
      Console.WriteLine("MINIMA fue de {0:F2} C y se produjo el {1:dd/MM}", tempMin, fechaTempMin);
    }
    else
      Console.WriteLine("El nombre de columna no existe");
  }
  else
    Console.WriteLine("El archivo no existe!!!");
}

