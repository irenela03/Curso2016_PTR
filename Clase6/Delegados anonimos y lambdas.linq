<Query Kind="Program" />


public Empleado[] empleados;

void Main()
{
  empleados = new Empleado[5];
  decimal incremento = 1.15M;
  
  for ( int i = 0 ; i < empleados.Length ; i++)
    empleados[i] = new Empleado();
  
  empleados.Dump();
  
  //  Action<Empleado> subirSalario = empleados[0].SubirSalario;
  
  //  Array.ForEach(empleados, subirSalario);
  
  //Array.ForEach(empleados, (Action<Empleado>)
  //  (delegate (Empleado e ) { e.Salario *= incremento; })
  //);
  
  Array.ForEach(empleados, (Empleado x) => x.Salario *= incremento);
  
  empleados.Dump();
}

public class Empleado
{
  public string Nombre { get; set; }
  public decimal Salario {get; set; }

  public Empleado()
  {
    Random rnd = new Random();
    
    Nombre = "Juan Pérez";
    Salario = rnd.Next(1000, 1500);
    Thread.Sleep(100);
  }
  
  public void SubirSalario(Empleado e)
  {
    e.Salario *= 1.15M;
  }
}

