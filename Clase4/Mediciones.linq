<Query Kind="Program">
  <Reference Relative="CSV.dll">F:\CURSO_2016_01\src\Clase4\CSV.dll</Reference>
  <Namespace>CSV</Namespace>
</Query>

public enum Campos
{ 
  Fecha = 1,
  TempMaxima,
  TempMedia,
  TempMinima
}

/*
  Parte 1
  Crear una clase que para modelar una medicion diaria de datos meteorologicos
*/

public class MedicionDiaria : IComparable<MedicionDiaria>
{
  public DateTime Fecha { get; set; }

  public float TemperaturaMinima { get; set; }

  public float TemperaturaMedia { get; set; }
  
  public float TemperaturaMaxima { get; set; }
  
  //  por conveniencia, usamos un ctor que acepte strings
  //
  public MedicionDiaria(string fecha, string tMin, string tMed, string tMax)
  {
    this.Fecha = DateTime.Parse(fecha);
    this.TemperaturaMinima = float.Parse(tMin);
    this.TemperaturaMedia = float.Parse(tMed);
    this.TemperaturaMaxima = float.Parse(tMax);
  }
  
  /*
    this.CompareTo(otro)  ==> 
    
    -1 --> this < otro
    +1 --> this > otro
     0 --> iguales
  */
  public int CompareTo(MedicionDiaria otro)
  {
    if (this.TemperaturaMedia == otro.TemperaturaMedia)
      return 0;
      
    if (this.TemperaturaMedia < otro.TemperaturaMedia)
      return -1;
    else
      return +1;
  }
}


/*
  Parte 2
  Armar una funcion que lea el archivo de datos del tiempo, los convierta a instancias de MedicionDiaria
  y genere una coleccion con estas instancias
  
  Pasamos la ruta del archivo como parametro
*/
public List<MedicionDiaria> ObtenerMediciones(string path)
{
  List<MedicionDiaria> lista = null; 
  FileInfo fi = new FileInfo(path);

  if (fi.Exists)
  {
    CSVFile csv = new CSVFile(fi);
    //  no vamos a buscar los nombres de las columnas...aunque si queremos podemos reutilizar el 
    //  codigo del ejercicio anterior
    //  Para simplificar hardcodeamos:
    //
    //  1 --> fecha de la toma
    //  2 --> temperatura maxima
    //  3 --> temperatura media
    //  4 --> temperatura minima
    //
    lista = new List<MedicionDiaria>();
    for (int linea = 2; linea <= csv.Lineas; linea++)
    {
      string fecha;

      if ((fecha = csv.LeerCampo(linea, (int)Campos.Fecha)) != null)
      {
        MedicionDiaria medicion = new MedicionDiaria( 
                                        fecha, 
                                        csv.LeerCampo(linea, (int)Campos.TempMinima),
                                        csv.LeerCampo(linea, (int)Campos.TempMedia),
                                        csv.LeerCampo(linea, (int)Campos.TempMaxima));
        lista.Add(medicion);
      }
    }
  }
    
  return lista;   //  por default es null...
}

/*
  Parte 4 
  Armar funciones que retornen pares de temperatura y fecha
*/
public Tuple<DateTime, float> TemperaturaMinima(List<MedicionDiaria> mediciones)
{
  return Tuple.Create<DateTime, float>(mediciones[0].Fecha, mediciones[0].TemperaturaMedia);
}

public Tuple<DateTime, float> TemperaturaMaxima(List<MedicionDiaria> mediciones)
{
  mediciones.Reverse();
  return Tuple.Create(mediciones[0].Fecha, mediciones[0].TemperaturaMedia);
}

void Main()
{
  List<MedicionDiaria> mediciones;
  
  mediciones = ObtenerMediciones(@"F:\CURSO_2016_01\src\Clase4\Clima en Rosario.csv");
  
  //mediciones.Dump();
  
  mediciones.Sort();
  
  //  mediciones.Dump();
  var minima = TemperaturaMinima(mediciones);
  
  Console.WriteLine("Temperatura media minima de {1:F2} grados el {0: dd 'de' MMMM}", minima.Item1, minima.Item2);
  
  var maxima = TemperaturaMaxima(mediciones);
  
  Console.WriteLine("Temperatura media MAXIMA de {1:F2} grados el {0: dd 'de' MMMM}", maxima.Item1, maxima.Item2);

  float total = 0.0F;
  foreach (var medicion in mediciones)
  {
    total += medicion.TemperaturaMedia;
  }
  
  Console.WriteLine("Promedio de temperaturas medias: {0:F2}", total / mediciones.Count);
}