<Query Kind="Expression" />

//  
//  Ejemplos de expresiones con LINQPad
//

//  Ejemplo 1: seno hiperbolico de 3
//  Resultado: 10,017874927409901898974593619466
//
//  (Math.Exp(3) - Math.Exp(-3)) / 2


//  Ejemplo 2: seno hiperbolico de 3 usando la funcion incorporada
//  Resultado: 10,017874927409901898974593619466
//
//  Math.Sinh(3)

//  Ejemplo 3: resultado de una expresion logica (retorna verdadero o falso)
//  Resultado: TRUE ==> porque 1 NO es igual a 2 pero como 7 es mayor que 5 el OR hace que la expresion completa sea TRUE
//
//  1 == 2 || 7 > 5

//  Resultado: TRUE 
//
//  Math.PI > Math.E && Math.Sign(Math.Log10(0.22)) < 0

//  Usar Dump() para visualizar un resultado intermedio
//
//  Math.PI > Math.E && Math.Sign(Math.Log10(0.22)).Dump() < 0

//  Ejemplo 4: una expresion de cadena
//  Resultado: "a,M"
//
//  "----Hola--,-Mundo ".Replace("-", "").Substring(3, 3) 