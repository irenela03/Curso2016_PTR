<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference Relative="..\..\Desktop\Utiles.dll">C:\Users\Equipo\Desktop\Utiles.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>Utiles</Namespace>
</Query>

public class Persona
{

public string Nombre;
public DateTime Fecha_Nac;
public int Documento;

   public Persona()
	{
	
	}

    public Persona(string nomb, DateTime fecha_nac, int doc)
	{
	Nombre = nomb;
	Fecha_Nac = fecha_nac;
	Documento = doc;
	}

}


void Main()
{
	Persona nueva_persona;
	string cadena;
	bool rdo;
    Console.WriteLine("Ingrese con el siguiente formato: nombre ; fecha de nacimiento ; documento");
	cadena = Console.ReadLine();
	rdo = TryParse(cadena, out nueva_persona);
	if(rdo == true)
	{
	Console.WriteLine("Datos Ingresados Correctamente. Nombre {0}, Fecha de Nacimiento {1}, Documento {2}", nueva_persona.Nombre, nueva_persona.Fecha_Nac.ToString("dd/MM/yyyy"), nueva_persona.Documento);
	}
	
}
bool TryParse(string strPersona, out Persona resultado)
{
   int cant_campos;
   cant_campos = strPersona.Campos(';');
   // validamos el ingreso de los 3 campos
   if(cant_campos != 3)
   {
   Console.WriteLine("La cadena ingresada no tiene la cantidad de campos correctos.");
   resultado = new Persona();
   return false;
   }
   // validamos que el campo fecha
   string campo_fecha;
   DateTime fecha_;
   campo_fecha = strPersona.GetCampo(2);
   if(DateTime.TryParse(campo_fecha, out fecha_) == false)
   {
   Console.WriteLine("El campo fecha no es válido.");
      resultado = new Persona();
   return false;
   }
   // validamos el numero de documento
   string campo_doc;
   int doc;
   campo_doc = strPersona.GetCampo(3);
   if(int.TryParse(campo_doc, out doc) == false)
   {
    Console.WriteLine("El campo documento no es válido.");
	   resultado = new Persona();
    return false;
   }
     
   string campo_nombre = strPersona.GetCampo(1);
   resultado = new Persona(campo_nombre, fecha_, doc);
   return true;
}

