<Query Kind="Program">
  <Connection>
    <ID>50847fd7-b2c6-4b33-9f74-74b592b7b9ef</ID>
    <Persist>true</Persist>
    <Server>ET-MOVIL\SQLExpress</Server>
    <Database>SO</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
	List<string> lista = new List<string>() { "123", "323", "45,98", "3232,76" }; 

  HashSet<Item> fkTable = new HashSet<Item>() {
    new Item() { FK ="123", Valor="Hola"},
    new Item() { FK ="e454", Valor="ffsfsdf"},
    new Item() { FK ="123", Valor="Mundo"},
    new Item() { FK ="67676", Valor="fdfsdfdsf"}
  };
  
/*
  lista.Dump();
  
  //  No es un metodo de extension para List
  //
  List<decimal> plata = lista
    .ConvertAll<decimal>( delegate(string s) { return decimal.Parse(s); });

  plata.Dump();
  
  //  lo mismo pero con lambdas
  //
  plata = lista.
    ConvertAll<decimal>( (s) => decimal.Parse(s) );

  plata.Dump();
*/

  //  Sum si es Linq (metodo de extension dentro de Linq)
  //
  //  decimal suma = lista.Sum<string>( (s) => decimal.Parse(s) );
  //  suma.Dump();

  
  //  si usamos interfaces, ConvertAll no existe y debemos usar Select
  //
/*  
  IList<string> ilista = lista;
  
  IEnumerable<decimal> result = ilista.Select (i => Decimal.Parse(i));
  result.Dump();

  //  y si queremos sumar solamente los que no tengan decimales
  //
  decimal suma1 = ilista
                    .Select(i => Decimal.Parse(i))
                    .Where(i => { Console.WriteLine ("Hola"); return Decimal.Truncate(i) == i ;})
                    .Sum ();
  //suma1.Dump();
 
  //  en query sintax --> numeros se necesita para "enganchar" los dos selects
  //
  
  suma1 = (from item in ilista 
            select Decimal.Parse(item) 
              into numeros
              where Decimal.Truncate(numeros) == numeros
              select numeros
          ).Sum();
  suma1.Dump();
*/
/*  
  //  Ver encadenamiento de orderby con select y por que se necesita into
  //
  var xx = (
    from p in lista 
      select p.Length 
      into pepe 
      orderby pepe descending 
      select pepe)
    .FirstOrDefault() ;
    
  var xxx = (
    from p in lista 
      orderby p.Length descending 
      select p.Length)
    .FirstOrDefault() ;
  
  Console.WriteLine(xx);
  Console.WriteLine(xxx);

  var yy = from it in lista where (it.Length > 3) select it;
  yy.Dump();
  
  lista.Dump();
*/  
/*
  //  
  //
  var zz = from outer in fkTable 
    join inner in lista on outer.FK equals inner
    select outer.Valor ;
  
  zz.Dump();
  Console.WriteLine(String.Join( " ", zz.ToArray<string>()));
  //  Console.WriteLine (zz.Join(" "));
*/
	//	Ojo: necesita la base de datos local de mi pc...
  var nombres = DIM_Centrals
                  .Join(
                  Definicion_SACs,
                  x => new { Ser=x.EBOS, Ctr=x.CENTRE },
                  y => new { Ser=y.EBOS, Ctr=y.RCRAT },
                  
                  (dc, ds) => new { 
                    dc.Descripcion, 
                    dc.Localidad, 
                    dc.EBOS, 
                    dc.CENTRE,
                    ds.SAC });
  nombres.Dump();
  

  var nombres1 = from dc in DIM_Centrals 
                    join ds in Definicion_SACs
                      on new { Ser=dc.EBOS, Ctr=dc.CENTRE } 
                        equals new { Ser=ds.EBOS, Ctr=ds.RCRAT }
                    select 
                      new {
                        dc.Descripcion,
                        dc.Localidad,
                        dc.EBOS,
                        dc.CENTRE,
                        ds.SAC
                      };
  nombres1.Dump();

}

// Define other methods and classes here

public class Item
{
  public string FK {get; set;}
  public string Valor {get; set;}
}

public static class Extension1
{
  public static string Join<T>(this IEnumerable<T> source, string separator)
  {
    StringBuilder sb = new StringBuilder();
    
    foreach (T elem in source)
      sb.AppendFormat("{0} {1}", elem.ToString(), separator);
    return sb.ToString();
  }
}