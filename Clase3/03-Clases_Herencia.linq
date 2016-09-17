<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Namespace>System.Windows</Namespace>
</Query>

/*

  Agregamos herencia
  Tengo que escribir un nuevo constructor (no se hereda)
  
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
    Console.WriteLine("{0} fue desde ( {1} , {2} ) hasta ( {3} ; {4} )",
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


void Main()
{
  Persona homer = new Persona("Homero");
  //  Persona marge = new Persona("Marge");
  Obrero marge = new Obrero("Marge");

  homer.IrHasta(new Point(100, 200));
  marge.IrHasta(new Point(20, 500));    //  Obrero puede usar comportamientos de Persona

  homer.IrHasta(new Point(400, 400));
  marge.Trabajar(new Point(300, 300));
}


