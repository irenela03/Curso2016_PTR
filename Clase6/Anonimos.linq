<Query Kind="Program" />

/*

  Las tres maneras de invocar a un delegado...

*/
public delegate double Transformar(double x);

void Main()
{
  double[] orig = new double[] {2.0, 4.5, 5.5, 10.98};
  double[] dest = new double[orig.Length];
  
  //  1- pasar el nombre del método (reemplaza a new Transformar() )
  //  Transformer(arr, Cuadrado);
  //  Convertir(arr, null);
 
  for (int i = 0 ; i < orig.Length ; i++) 
  {
    Transformar f = ElegirFuncion(i);
    dest[i] = f(orig[i]);
  }
  
  
  
  //  2- usar un metodo anonimo (alternativa: new Transformar() )
  //  Transformer(arr, delegate(double x) {return Math.Sqrt(x);});
  //  Transformer(arr, new Transformar(delegate (double x) { return x*x; }));
  
  //  3- usar una expresión lambda (alternativa: evitar la inferencia de tipos)
  //Transformar cubo = x => Math.Pow(x, 3);
  
  //Transformer(arr, x => Math.Pow(x, 3) );  //  alternativa (x)
  orig.Dump();
  dest.Dump();
  
  //  UsaGenerico(arr, x => x 2.0 );
}

public void Convertir(double[] a, Transformar func)
{
  if (func != null)
  {
    for ( int i = 0 ; i < a.Length; i++ )
      a[i] = func(a[i]);  
  }
}

public double MultiplicarX2(double x)
{
  return x * 2;
}

public double Coseno(double x)
{
  return Math.Cos(x);
}

public double RaizCuadrada(double x)
{
  return Math.Sqrt(x);
}

public Transformar ElegirFuncion(int x)
{
  Transformar result;
  
  switch (x)
  {
    case 0:
      result = MultiplicarX2;
      break;
      
    case 1:
      result = Coseno;
      break;
      
    case 2:
      result = RaizCuadrada;
      break;
      
    case 3:
      result = Math.Cosh;
      break;
      
     default:
      result = Math.Abs;
      break;
  }
  return result;
}

public void UsaGenerico(double[] a, Action<double> accion)
{
  foreach (var x in a)
    accion(x);
}

public double Cuadrado(double x)
{
  return x*x;
}