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

public class MedicionDiaria
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

void Main()
{
  List<MedicionDiaria> mediciones;
  
  mediciones = ObtenerMediciones(@"F:\CURSO_2016_01\src\Clase4\Clima en Rosario.csv");
  
  mediciones.Dump();
}

