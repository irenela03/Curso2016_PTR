<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Namespace>System.Windows</Namespace>
</Query>

/*
  Define el comportamiento basico de cualquier persona
  
  - Una ubicacion
  - Un nombre (visualizacion)
  - La posibilidad de moverse de un lugar a otro

*/
public class Persona 
{
  public string Nombre ;
  public Point Ubicacion ;  //  Point es un punto del espacio R2

  public Persona(string nombre)
  {
    Nombre = nombre;
    //
    //  tengo que ajustar el valor de Ubicacion? ==> NO
    //  por que? porque los campos de una instancia se inicializan en el momento de llamar a new
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