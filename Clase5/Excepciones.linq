<Query Kind="Program" />

void Main()
{

  try
  {
    Console.WriteLine ("try...");
    Metodo();
    Metodo1();
  }
  catch (MiPropiaExcepcion ex)
  {
    Console.WriteLine("MAIN (MiPropiaExcepcion) ==> {0} : {1}", ex.GetType().FullName, ex.Message);
  }
  catch (Exception ex)
  {
    Console.WriteLine("MAIN ==> {0} : {1}", ex.GetType().FullName, ex.Message);
  }
}

public void Metodo1()
{
  Console.WriteLine("Llegamos al Metodo 1");
}

public void Metodo()
{
  try
  {
    Console.WriteLine ("Metodo --> try...");
    throw new Exception("try --> Excepcion");
    Console.WriteLine ("Nunca se ejecuta");
  }
  catch (ApplicationException)
  {
    Console.WriteLine ("catch --> normal");
    Console.WriteLine ("Aca \"neutralizo\" ApplicationExcepcion desde try");
    throw new ApplicationException("catch --> AppException");
    Console.WriteLine ("catch --> FIN");
  }
  catch (Exception)
  {
    Console.WriteLine("catch --> normal");
    Console.WriteLine("Aca \"neutralizo\" Excepcion desde try");
    throw new ApplicationException("catch --> Exception");
    Console.WriteLine("catch --> FIN");
  }
  finally
  {
    Console.WriteLine ("finally --> normal...");
    //  tengo AppEx activa
    throw new MiPropiaExcepcion("finally --> MiPropiaExcepcion");
    Console.WriteLine ("finally --> FIN");
  }
}

public class MiPropiaExcepcion : System.Exception
{
  public MiPropiaExcepcion(string msg) : base(msg) {}
}