<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
</Query>


public class Persona
{
  public Guid ID { get; set; }
  public string Nombre { get; set; }
  public DateTime Nacimiento { get; set; }
  public Documento Documento { get; set; }
}

public enum TipoDocumento
{
  DNI,
  Libreta_Civica,
  Libreta_Enrolamiento,
  Pasaporte,
  Cedula
}

public class Documento
{
  public TipoDocumento Tipo { get; set; }
  public string Numero { get; set; }
}


public List<Persona> sujetos = new List<Persona>()
{
  new Persona {
    ID = Guid.NewGuid(), Nombre = "Homer Simpson", Nacimiento = DateTime.Parse("12/05/1952"),
    Documento = new Documento { Tipo = TipoDocumento.DNI, Numero = "14564879" }
  },
  new Persona {
    ID = Guid.NewGuid(), Nombre = "Marge Bouvier", Nacimiento = DateTime.Parse("19/03/1954"),
    Documento = new Documento { Tipo = TipoDocumento.Libreta_Civica, Numero = "14564879" }
  },
  new Persona {
    ID = Guid.NewGuid(), Nombre = "Lisa Simpson", Nacimiento = DateTime.Parse("09/05/1981"),
    Documento = new Documento { Tipo = TipoDocumento.Pasaporte, Numero = "21654987" }
  }
};

void Main()
{
  //  queremos formatear la lista de Personas para enviarlo a traves de un servicio web...
  //  usamos el formato JSON, muy popular desde hace tiempo
  //
  //  mostrar los elementos de la lista de sujetos...
  //
  //  sujetos.Dump();

  //  presionar F4 para abrir las propiedades de la consulta
  //  seleccionar la opcion NuGet para buscar librerias externas
  //  buscar Json.Net e incluirlo en la consulta

  Console.WriteLine(JsonConvert.SerializeObject(sujetos, Newtonsoft.Json.Formatting.Indented));
}

