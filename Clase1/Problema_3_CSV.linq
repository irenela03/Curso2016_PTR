<Query Kind="Program">
  <Reference Relative="..\Clases_1_a_6\CSV\bin\Debug\CSV.dll">F:\CURSO_2016_01\src\Clases_1_a_6\CSV\bin\Debug\CSV.dll</Reference>
</Query>


void Main()
{
  FileInfo fi = new FileInfo(@"F:\CURSO_2016_01\src\Clase1\Clima en Rosario.csv");
  int fila, col;

  fila = 10;
  col = 8;
  
  if (fi.Exists)
  {
    Console.WriteLine($"Datos del archivo [{fi.FullName}]");
    Console.WriteLine($"Tamaño: {fi.Length}");
    Console.WriteLine($"Fecha/Hora de ultima modificacion: {fi.LastWriteTime}");
    
    CSV.CSVFile csv = new CSV.CSVFile(fi);

    Console.WriteLine($"Lineas: {csv.Lineas} ; Max Columnas: {csv.MaxColumnas}");
    Console.WriteLine($"Elemento en la posicion [{fila}, {col}] ==> {csv.LeerCampo(fila, col)}");
  }
  else
    Console.WriteLine("El archivo no existe!!");

}

