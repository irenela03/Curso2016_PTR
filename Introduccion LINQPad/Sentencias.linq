<Query Kind="Statements" />


/*

  Ejemplo de una serie de sentencias o "snippet" de codigo
  
  Observar que el comentario de este estilo puede abarcar mas de una linea
  
  El codigo no necesita estar organizado o estructurado en funciones

*/

string nombre;
int horaActual;

Console.WriteLine("Por favor ingresar su nombre...");
nombre = Console.ReadLine();
horaActual = DateTime.Now.Hour;

//  Probar que pasa si cambio
//    horaActual = 10;
//    horaActual = 16;
//    horaActual = 22;

if (horaActual <= 12)
  Console.WriteLine("Buenos dias, {0} son las {1:t}", nombre, DateTime.Now);
else 
{
  if (horaActual < 20)
    Console.WriteLine($"Buenas tardes, {nombre} son las {DateTime.Now:t}");
  else
    Console.WriteLine($"Buenas noches, {nombre} son las {DateTime.Now:t}");
}
