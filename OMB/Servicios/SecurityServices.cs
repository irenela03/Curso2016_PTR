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
    /// Este metodo permite crear un usuario en la DB, usando los datos ingresados desde la UI mas la password
    /// Si no se puede crear, retornamos false
    /// </summary>
    /// <param name="user">Instancia ya creada de Usuario con los datos obligatorios y validos</param>
    /// <param name="pass">Contraseña en </param>
    public bool CrearUsuario(Usuario user, string pass)
    {
      bool result = true;
      OMBContext ctx = OMBContext.DB;

      try
      {
        //  Forzamos que el usuario no pueda hacer nada hasta setear la password...
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
      return null;
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

    private string GetUserPasswordInternal(string login)
    {
      return null;
    }
  }
}
