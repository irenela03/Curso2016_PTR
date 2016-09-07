<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\System.Windows.Input.Manipulations.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\UIAutomationProvider.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\UIAutomationTypes.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\ReachFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationUI.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\System.Printing.dll</Reference>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Media.Imaging</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
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
  Persona homero, marge;
  
  homero = new Persona("Homero");
  marge = new Persona("Marge");
  
  
}

public static class RealWorld
{
  private static Canvas _mundo;
  private static OutputPanel _panel;

  private static Ellipse circulo = new Ellipse();

  static RealWorld()
  {
    _mundo = new Canvas();
    _panel = PanelManager.DisplayWpfElement(_mundo, "El Mundo Real");
  }

  public static void ShowCircle()
  {
    circulo.Fill = Brushes.Blue;
    circulo.Width = 20;
    circulo.Height = 20;
    //  _mundo.Children.Add(circulo);

    //circulo.SetValue(Canvas.TopProperty, 50.0);
    //circulo.SetValue(Canvas.LeftProperty, 100.0);
    Image imagen = new Image();
    imagen.Source = new BitmapImage(new Uri("pack://application:,,,/Utiles;component/images/homero.png"));
    imagen.Width = 90;
    _mundo.Children.Add(imagen);
  }

  public static void MoverCircle()
  {
    circulo.SetValue(Canvas.TopProperty, 100.0);
    circulo.SetValue(Canvas.LeftProperty, 200.0);
  }
}