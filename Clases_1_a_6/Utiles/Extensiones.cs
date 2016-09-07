using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiles
{
  public static class Extensiones
  {
    /// <summary>
    /// Dada una cadena que contiene separadores, retorna la cantidad de campos en la que queda particionada la cadena
    /// El separador por defecto es punto y coma
    /// </summary>
    /// <param name="src"></param>
    /// <param name="sep"></param>
    /// <returns></returns>
    public static int Campos(this string src, char sep = ';')
    {
      string[] campos = src.Split(sep);

      return campos.Length;
    }

    /// <summary>
    /// Dada una cadena que contiene separadores, permite retornar el sub-campo que corresponde al valor pasado (comenzando desde cero)
    /// Si el indice supera la cantidad de campos se retorna null
    /// El separador por defecto es el punto y coma
    /// </summary>
    /// <param name="src"></param>
    /// <param name="campo"></param>
    /// <param name="sep"></param>
    /// <returns></returns>
    public static string GetCampo(this string src, int campo, char sep = ';')
    {
      string[] campos = src.Split(sep);

      return campo <= campos.Length ? campos[campo-1] : null;
    }
  }
}
