<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Namespace>System.Windows</Namespace>
</Query>


/*

  Agregamos una interface 
  Una nueva clase que utiliza esta interface
  
*/
public class Persona
{
  public string Nombre { get; private set; }
  public Point Ubicacion { get; private set; }

  public Persona(string nombre)
  {
    Nombre = nombre;
  }

  public void IrHasta(Point destino)
  {
    Point origen = Ubicacion;
    Ubicacion = destino;
    Console.WriteLine("Persona: {0} fue desde ( {1} , {2} ) hasta ( {3} ; {4} )",
      Nombre, origen.X, origen.Y, Ubicacion.X, Ubicacion.Y);
  }
}

public class Obrero : Persona
{
  public Obrero(string nombre) : base(nombre) { }

  public void Trabajar(Point donde)
  {
    IrHasta(donde);
    //
    Console.WriteLine("Obrero {0} - Estoy trabajando en {1} {2}",
      Nombre, donde.X, donde.Y);
  }
}

//  vamos a crear un obrero especializado...
public class Carpintero : Obrero, ICarpintero
{
  public string Skill { get; private set; }

  public Carpintero(string nombre) : base(nombre)
  {
    Skill = "calificado";
  }

  public decimal Presupuesto(string tipoObra)
  {
    return 3000M;
  }

  public void Construir(Point donde, string tipoObra)
  {
    Trabajar(donde);
    Console.WriteLine("Carpintero --> ICarpintero: Estoy haciendo un {0} y me sale perfecto!", tipoObra);
  }

  /*
    Con new le decimos al compilador que este metodo oculta al de Obrero
    De otro modo nos daria un warning
  */
  new public void Trabajar(Point donde)
  {
    IrHasta(donde);
    //
    Console.WriteLine("Carpintero: {0} - Estoy trabajando en ( {1} , {2} )",
      Nombre, donde.X, donde.Y);
  }
}

public class Manitas : Persona, ICarpintero
{
  public string Skill { get; private set; }

  public Manitas(string nombre) : base(nombre) 
  {
    Skill = "amateur";
  }

  public decimal Presupuesto(string tipoObra)
  {
    return 1500M;
  }

  public void Construir(Point donde, string tipoObra)
  {
    Console.WriteLine("Manitas --> ICarpintero: Estoy haciendo un {0} y me sale....mas o menos..." , tipoObra);
  }

}

/*
  Definimos la interface
*/
public interface ICarpintero
{
  string Skill { get; }
  decimal Presupuesto(string tipoObra);
  void Construir(Point donde, string tipoObra);
}

public class Constructora
{
  private ICarpintero _worker;

  public bool Contratar(ICarpintero worker)
  {
    bool contratado = false;

    switch (worker.Skill)
    {
      case "calificado":
        if (worker.Presupuesto("placard") <= 3000)
        {
          _worker = worker;
          contratado = true;
        }
        else
          Console.WriteLine("No se contrata. Precio excesivo para un calificado");
        break;

      case "amateur":
        if (worker.Presupuesto("placard") <= 1500)
        {
          _worker = worker;
          contratado = true;
        }
        else
          Console.WriteLine("No se contrata. Precio excesivo para un amateur");
        break;

      default:
        Console.WriteLine("No se contrata. Perfil no adecuado.");
        break;
    }
    return contratado;
  }

  public void HacerPlacard(Point donde)
  {
    if (_worker != null)
    {
      _worker.Construir(donde, "placard");
    }
    else
      Console.WriteLine("No se puede hacer porque no se contrato ningun trabajador!!");
  }
}

void Main()
{
  Constructora builder = new Constructora();
  Persona homer = new Persona("Homero");
  Carpintero marge = new Carpintero("Marge");
  Manitas ned = new Manitas("Flanders");

  //  que le pasamos a Contratar? una Persona? un Obrero?
  //  builder.Contratar(marge)

  if (builder.Contratar(marge))
    Console.WriteLine("{0} CONTRATADO!!!", marge.Nombre);

  if (builder.Contratar(ned))
    Console.WriteLine("{0} CONTRATADO!!!", ned.Nombre);

  builder.HacerPlacard(new Point(200, 150));
}


