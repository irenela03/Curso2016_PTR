using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Data;

namespace Servicios
{
  public class SecurityServices
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="pass"></param>
    public bool CrearUsuario(Usuario user, string pass)
    {
      bool result = true;
      OMBContext ctx = OMBContext.DB;

      try
      {
        //  forzamos hasta que no podamos cambiar la password...
        user.Enabled = false;
        user.Blocked = true;

        ctx.Usuarios.Add(user);
        ctx.SaveChanges();

        if (!ChangeUserPasswordInternal(user.Login, pass))
        {
          Console.WriteLine("No se pudo cambiar la password!!! Eliminando el usuario...");

          ctx.Usuarios.Remove(user);
          ctx.SaveChanges();

          result = false;
        }
        else
        {
          user.Enabled = true;
          user.Blocked = false;
          ctx.SaveChanges();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);

        result = false;
      }

      return result;
    }

    /// <summary>
    /// Este es el metodo que se llamara desde la UI para concretar el login del Usuario, a partir del ID y de la password
    /// El metodo retorna una instancia de Usuario, con el cual podriamos luego establecer una sesion
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public Usuario LoginUsuario(string login, string password)
    {
      //  TODO usar el metodo GetUserPasswordInternal para validar la password
      //  TODO setear los datos de ultimo login correcto o no, validar en la DB
      //  return null;
      return new Usuario();
    }

    /// <summary>
    /// Permite chequear ciertas reglas de negocio respecto a la validez del usuario
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public bool ValidarUsuario(Usuario user)
    {
      //  TODO verificar que el login no este repetido
      //  TODO Asegurar que no se generen dos usuarios para un mismo Empleado
      return true;
    }


    /// <summary>
    /// En una DB seria, este metodo podria ser un stored procedure
    /// </summary>
    /// <param name="login"></param>
    /// <param name="pass"></param>
    private bool ChangeUserPasswordInternal(string login, string pass)
    {
      bool result = true;

      try
      {
        OMBContext.DB.Database.ExecuteSqlCommand("update Usuarios set Password = @p1 where Login = @p0", login, pass);
      }
      catch (Exception ex)
      {
        result = false;
      }
      return result;
    }

    /// <summary>
    /// Lo mismo, en una DB deberiamos tener un stored que haga este proceso
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    private string GetUserPasswordInternal(string login)
    {
      string passTemp = null;
      try
      {
        passTemp = OMBContext.DB.Database
                    .SqlQuery<string>("select Password from Usuarios where Login = @p0", login)
                    .FirstOrDefault();
      }
      catch (Exception ex)
      {
        Console.WriteLine("No se puede recuperar la contraseña");
      }
      return null;
    }
  }
}
