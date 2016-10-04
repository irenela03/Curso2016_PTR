<Query Kind="Program">
  <Reference Relative="CSV.dll">F:\CURSO_2016_01\src\Clase5\CSV.dll</Reference>
  <Namespace>CSV</Namespace>
</Query>

/*
  Que ventajas tiene usar delegado?
  - puedo ampliar el espectro de las funciones (en el caso de un swith tengo que 
    cambiar el codigo)
  - puedo modificar la implementacion de las funciones, o sea los algoritmos...no
    dependen de mi modulo hacerlo
    
  PREDICADO
  - Un predicado no es otra cosa que un filtro que me permite validar cada elemento T
    con una condicion que impongo desde mi codigo
  - Lo verdaderamente interesante de los delegados es cuando me sirven para componer
    diferentes operaciones, por ejemplo primero convertir la lista a float, luego obtener
    una sublista de elementos que correspondan a una temporada determinada y por ultimo
    un agregado que me permita sacar el promedio de estos valores
*/

List<MedicionDiaria> mediciones ;

void Main()
{
  StatCalculator calc = new StatCalculator();

  mediciones = ObtenerMediciones(@"F:\CURSO_2016_01\src\Clase5\Clima en Rosario.csv");

  //  VERSION 1 --> SWITCH
  //  con la Moda
  //  float moda = calc.Aggregate(mediciones.ConvertAll(TemperaturaMedia), "moda");
  
  //  VERSION 2 --> DELEGATE
  var listaFloat = mediciones.ConvertAll(TemperaturaMedia);
  
  float moda = calc.Aggregate(listaFloat, Moda);
  Console.WriteLine ("La moda de los datos es: {0}", moda);

  float promedio = calc.Aggregate(listaFloat, Promedio);
  Console.WriteLine("El promedio de los datos es: {0:F2}", promedio);

  float varianza = calc.Aggregate(listaFloat, Varianza);
  Console.WriteLine("La varianza de los datos es: {0:F2}", varianza);

  float desvio = calc.Aggregate(listaFloat, DesvioStandard);
  Console.WriteLine("El desvio standard de los datos es: {0:F4}", desvio);

  //  por ultimo usamos una combinacion de
  //  - Predicate para filtrar las mediciones que correspondan al invierno
  //  - Converter para obtener las temperaturas minimas de estas mediciones
  //  - Delegate Promedio para calcular el valor medio de la muestra
  
  float promInvierno = calc
                        .Aggregate(mediciones
                                    .FindAll(DatosInvernales)
                                    .ConvertAll(TemperaturaMinima), 
                                  Promedio);
  Console.WriteLine("El promedio de las temperaturas minimas durante el invierno fue de: {0:F4} grados",
    promInvierno);

  /*
    RESULTADOS (validados con Excel..)
    
    La moda de los datos es: 19
    El promedio de los datos es: 17,98
    La varianza de los datos es: 41,02
    El desvio standard de los datos es: 6,4050
    El promedio de las temperaturas minimas durante el invierno fue de: 5,3370 grados
  
  */
}

/*
  Puedo cambiar este Converter<MedicionDiaria, float> de tal manera que en lugar de la 
  TemperaturaMedia me de la lista de las TemperaturasMinimas, por ejemplo...
*/
public float TemperaturaMedia(MedicionDiaria md)
{
  return md.TemperaturaMedia;
}

public float TemperaturaMinima(MedicionDiaria md)
{
  return md.TemperaturaMinima;
}

/*
  Un predicado que me permite decidir si la medicion corresponde al invierno
*/
public bool DatosInvernales(MedicionDiaria md)
{
  return 
    (md.Fecha.Month > 6 && md.Fecha.Month < 9) ||
    (md.Fecha.Month == 6 && md.Fecha.Day >= 21) ||
    (md.Fecha.Month == 9 && md.Fecha.Day < 21);
}

public class StatCalculator
{
/*
  //  VERSION 1 --> SWITCH
  public float Aggregate(List<float> dataset, string funcion)
  {
    float result = 0.0F;
    
    switch (funcion)
    {
      case "moda":
        result = Moda(dataset);
        break;
    }
    return result;
  }
*/

  //  VERSION 2 --> DELEGATE
  public float Aggregate(List<float> dataset, Func<List<float>, float> funcion)
  {
    return funcion(dataset);
  }
}


/*
  La moda es el valor que mas se repite de la fuente de datos
*/
public float Moda(List<float> datos)
{
  Dictionary<float, int> frecuencias = new Dictionary<float, int>();

  foreach (var num in datos)
  {
    if (frecuencias.ContainsKey(num))
      frecuencias[num]++;
    else
      frecuencias.Add(num, 1);
  }

  int maxValue = 0;
  float moda = 0.0F;

  foreach (var item in frecuencias)
  {
    if (item.Value > maxValue)
    {
      maxValue = item.Value;
      moda = item.Key;
    }
  }
  return moda;
}

public float Promedio(List<float> datos)
{
  float result = 0.0F;
  
  foreach (var item in datos)
    result += item;
    
  return result / datos.Count;
}

public float Varianza(List<float> datos)
{
  float promedio = Promedio(datos);
  float result = 0.0F;

  foreach (float item in datos)
  {
    result += (item - promedio) * (item - promedio);
  }
  return result / datos.Count;
}

public float DesvioStandard(List<float> datos)
{
  return (float)Math.Sqrt(Varianza(datos));
}

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