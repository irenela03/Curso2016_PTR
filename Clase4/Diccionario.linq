<Query Kind="Program" />


/*
  Si bien no lo vimos como parte del curso, existen un serie de clases utilizadas para leer y escribir
  "streams" que es un concepto mas abstracto que un archivo
  
  Un stream puede referirse a cualquier flujo de datos (binario, texto, comprimido, encriptado...) y que 
  podemos recibir por diferentes medios (file system, network, memoria...)
  
  Para simplificar en este caso usamos un descendiente de Stream

*/

void Main()
{
  if (File.Exists(@"F:\CURSO_2016_01\src\Clase4\Quijote.txt"))
  {
    using (StreamReader rdr = File.OpenText(@"F:\CURSO_2016_01\src\Clase4\Quijote.txt"))
    {
      while (!rdr.EndOfStream)
      {
        string linea = rdr.ReadLine();
        
        //  
        //  hacer lo que haga falta...linea por linea
        //
        //  Console.WriteLine(linea);
      }
    }
    
    //  aca ya leimos el archivo...y ademas esta cerrado
    //  procesamiento final y mostrar resultados
    
  }
  else
    Console.WriteLine("No existe el archivo de texto...");
}


