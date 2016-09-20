<Query Kind="Program">
  <Reference Relative="Curso2016_PTR-master\Clases_1_a_6\Utiles\bin\Debug\Utiles.dll">C:\Users\irene_000\Desktop\Curso2016_PTR-master\Clases_1_a_6\Utiles\bin\Debug\Utiles.dll</Reference>
  <Namespace>Utiles</Namespace>
</Query>

class Persona
{
	public string Nombre;
	public DateTime FechaNacimiento;
	public long Documento; 
	
	public Persona(string Nom, DateTime Fech, long Doc)
	{
		this.Nombre = Nom;
		this.FechaNacimiento = Fech;
		this.Documento = Doc;
	}
	
	        public static bool TryParsePersona(string strPersona, out Persona resultado)
        {
            string cadena = strPersona;
            int Camp = Utiles.Extensiones.Campos(cadena, ';');
            if (Camp == 3)
            {
                 DateTime dt;
                 if(!DateTime.TryParse(Utiles.Extensiones.GetCampo(cadena, 2, ';') ,out dt))
                {
                    Console.WriteLine("No es una fecha Valida");
                    resultado = new Persona("", dt, 1);
                    return false;
                }
				if(dt < DateTime.Parse("01/01/1900")) 
				{
				 Console.WriteLine("No es una fecha Valida");
                    resultado = new Persona("", dt, 1);
                    return false;
				}
                 long doc;
                 if (!long.TryParse(Utiles.Extensiones.GetCampo(cadena, 3, ';'), out doc))
                 {
                     Console.WriteLine("No es un documento valido");
                     resultado = new Persona("", dt, 1);
                     return false;
                 }
               
                string Nombre = Utiles.Extensiones.GetCampo(cadena,1,';' );
                resultado = new Persona(Nombre,dt, doc);

                return true;  
            
            }
            else
            {
                 resultado = new Persona("", DateTime.Today, 1);
                 return false;  

            }
         
        }
}

void Main()
{
	 string CadPersona = "Homero J Simpson ; 01/01/1960 ; 14879898";
     Persona P1;
    if(Persona.TryParsePersona(CadPersona, out P1))
	{
	 Console.WriteLine("P1 creada con exito a partir de ==> {0}", CadPersona);
	 P1.Dump();
	}
	else
	 Console.WriteLine("P1 fallo la creacion a partir de ==> {0}", CadPersona);
}


// Define other methods and classes here