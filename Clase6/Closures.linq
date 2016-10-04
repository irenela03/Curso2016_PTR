<Query Kind="Program" />

/*

  Ejemplo para demostrar las closures que tienen lugar cuando capturo variables con un 
  metodo anonimo o lambda

*/

//  un delegado es imprescindible siempre, para poder llamar al metodo o exp-L
public delegate int Capturador(int factor);

//  para que el ejemplo sea mas claro, vamos a crear un metodo que RETORNE un delegado
void Main()
{
  Capturador fun = CrearCapturador();
  
  //  tener en cuenta que no estoy llamando cada vez a CrearCapturador sino al delegado que se 
  //  genero en esta funcion...
  ///
  fun(40).Dump();
  Console.WriteLine ("--------");
  fun(20).Dump();
  Console.WriteLine ("--------");
  fun(30).Dump();
  Console.WriteLine ("--------");

  //  otro ejemplo...cuando las variables capturadas no estan donde deberian...
 
  foreach (var fn in CrearCapturadores(9))
    fn(1);
  
}

public Capturador CrearCapturador()
{
  int capturada = 100 ;
  
  return delegate(int x) { 
    Console.WriteLine("Antes rand: {0}", capturada); 
    capturada = capturada.NextInt();
    Console.WriteLine ("Despues rand: {0}", capturada);
    return x * capturada; 
   };
}

public Capturador[] CrearCapturadores(int x)
{
  Capturador[] resultados = new Capturador[x];
  
  for (int i = 0; i < x ; i++)
  {
    int innerVar = i;
    resultados[i] = xx => { Console.Write(innerVar); return 0; };
  }
  
  return resultados;
}

public static class Extensiones
{
  //  retorna un entero aleatorio que este entre 0 y el numero pasado
  public static int NextInt(this int src)
  {
    Random rnd = new Random();
    
    if (src == 0) 
      src = 100;
    return rnd.Next(src);
  }
}