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
  public string Nombre { get; set; }
  public Point Ubicacion { get; set; }

  public Persona(string nombre)
  {
    Nombre = nombre;
    //
    //  tengo que ajustar el valor de Ubicacion?
  }
  
  public void IrHasta(Point newPlace)
  {
    Ubicacion = newPlace;
  }
}

void Main()
{
}