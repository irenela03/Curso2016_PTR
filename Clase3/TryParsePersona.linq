<Query Kind="Program">
  <Reference>F:\CURSO_2016_01\src\Clases_1_a_6\Utiles\bin\Debug\Utiles.dll</Reference>
  <Namespace>Utiles</Namespace>
</Query>


public class Persona
{
  public string Nombre { get; set; }
  public DateTime Nacimiento { get; set; }
  public int Documento { get; set; }
}

void Main()
{
  Persona p1, p2;

  //  p1 deberia contener un valor correcto
  //  p2 deberia contener null

  if (TryParsePersona("Homero Simpson; 01/10/1960 ; 188758789", out p1))
  {
    Console.WriteLine("p1 creada con exito");
    p1.Dump();
  }
  else
  {
    Console.WriteLine("Error al crear p1 --> {0}", p1);
  }
  
  if (TryParsePersona("Abraham Simpson; 01/10/1860 ; 758789", out p2))
  {
    Console.WriteLine("p2 creada con exito");
    p1.Dump();
  }
  else
  {
    Console.WriteLine("Error al crear p2 --> {0}", p2);
  }
}


//  observar el primer error que pone: debo asignar result!!
//  una vez que pongo result, ahi me da el error que tengo que retornar un bool tambien
//
public bool TryParsePersona(string input, out Persona result)
{
  bool exito = false;
  
  result = null;

  //  procesamos la cadena para ver si tiene las tres partes que permitan la creacion de una nueva Persona
  //
  if (input.Campos() == 3)
  {
    string nombre, fecha, dni;
    
    nombre = input.GetCampo(1);
    fecha = input.GetCampo(2);
    dni = input.GetCampo(3);

    if (nombre != null && fecha != null && dni != null)
    {
      int docTemp;
      DateTime fecTemp;

      if (Int32.TryParse(dni, out docTemp) && DateTime.TryParse(fecha, out fecTemp)) 
      {
        //  validamos los datos puntuales...
        if (docTemp > 1000000 && fecTemp >= new DateTime(1890, 1, 1))
        {
          result = new Persona();
          result.Nombre = nombre;
          result.Documento = docTemp;
          result.Nacimiento = fecTemp;
          
          exito = true;
        }
      }
    }
  }
  
  return exito;
}

