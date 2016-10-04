<Query Kind="Program" />

public delegate int Delegado(string arg);

void Main()
{
	Delegado midelegado = null;
  Delegado otrodelegado = (x) => {return x.Length; };
  
  midelegado += delegate(string s) { Console.WriteLine ("Primer delegado"); return s.Length; };
  midelegado += (y) => { Console.WriteLine ("Segundo delegado"); return y.Length + 10; };
  
  Console.WriteLine(midelegado("Enrique")); 
  Console.WriteLine(otrodelegado("Thedy")); 
}

// Define other methods and classes here

