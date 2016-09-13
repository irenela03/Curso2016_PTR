<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Namespace>System.Windows</Namespace>
</Query>

/*
  
  Cambiamos campos por propiedades
  Para cumplir con el encapsulamiento...
  Observar que el seteo es privado
  
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

void Main()
{
  Persona homer = new Persona("Homero");
  Persona marge = new Persona("Marge");

  homer.IrHasta(new Point(100, 200));
  marge.IrHasta(new Point(300, 300));

  homer.IrHasta(new Point(400, 400));
}

// Define other methods and classes here
