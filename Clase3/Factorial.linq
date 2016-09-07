<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>


 
BigInteger Factorial(int n)
{
  if (n == 1)
    return 1;
    
  return n * Factorial(n-1);
}


void Main()
{
  int n = 20;
  BigInteger x = Factorial(n);
  
  Console.WriteLine("El factorial de {0} es {1}", n, x);
}

