<Query Kind="Program" />

void Main()
{
  string s = 
@"  polo ,r  tecnológico .x.y-z .xyz  rosario. rosario 
minusculas.
mayusculas.";
  
  Console.WriteLine ("[{0}]", s.PrimeraMayuscula() );
}


public static class Extensiones
{
  public static string PrimeraMayuscula(this string source)
  {
    char[] caracteres = source.ToCharArray();
    bool cambiar = true;    
    
    //  tengo que entrar considerando que el primer caracter posiblemente SEA una letra que tengo que cambiar

    for (int idx = 0 ; idx < caracteres.Length ; idx++)
    {
      char cActual = caracteres[idx];
      
      
        //Console.WriteLine (cambiar);
      //  si es un PUNTO, la siguiente letra (que no sea un signo) debe ir en mayuscula
      //
      if (cActual == '.')
        cambiar = true;   
      else
      {
        //  si es un espacio en blanco lo ignoro y sigo con el estado previo
        //
        if (!Char.IsWhiteSpace(cActual))
        {
          //  si es un signo de puntuacion, inmediatamente doy vuelta el estado de cambio (sabemos que no es 
          //  un punto)
          //
          if (Char.IsPunctuation(cActual))
            cambiar = false;
          else
          {
            //  cambiar me dice si antes hubo un caracter que no es una letra
            if (cambiar) 
            {
              caracteres[idx] = Char.ToUpper(cActual);
              cambiar = false;
            }
          }
        }
      }
    }
    return new string(caracteres);
  }
}