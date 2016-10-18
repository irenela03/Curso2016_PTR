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
    /// Propiedad para retornar el ultimo mensaje de error cuando alguno de los metodos falla
    /// </summary>
    public string ErrorInfo { get; set; }

    /// <summary>
    /// Este metodo permite crear un usuario en la DB, usando los datos ingresados desde la UI mas la password
    /// Si no se puede crear, retornamos false y actualiza ErrorInfo
    /// </summary>
    /// <param name="user">Instancia ya creada de Usuario con los datos obligatorios y validos</param>
    /// <param name="pass">Contraseña en </param>
    public bool CrearUsuario(Usuario user, string pass)
    {
      bool result = true;
      OMBContext ctx = OMBContext.DB;

      if (!ValidarUsuario(user))
      {
        ErrorInfo = "No se pudo validar el usuario segun las reglas...";
        result = false;
      }
      else
      {
        try
        {
          //  Forzamos que el usuario no pueda hacer nada hasta setear la password...
          user.Enabled = false;
          user.Blocked = true;

          ctx.Usuarios.Add(user);
          ctx.SaveChanges();

          if (!ChangeUserPasswordInternal(user.Login, pass))
          {
            ErrorInfo = "No se pudo cambiar la password!!! Eliminando el usuario...";

            ctx.Usuarios.Remove(user);
            ctx.SaveChanges();

            result = false;
          }
          else
          {
            user.Enabled = true;
            user.Blocked = false;
            //
            //  Aca podriamos setear algun token para que el usuario valide su cuenta desde la web
            //  mas que nada pensando en MVC aunque no se aplicaria tal vez para un usuario interno
            //  (o sea asociado a un Empleado)
            //
            ctx.SaveChanges();
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);

          result = false;
        }
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
      Usuario result = null;
      OMBContext ctx = OMBContext.DB;
      result = ctx.Usuarios.Where(us => us.Login == login).FirstOrDefault();
            if (ValidateUserPasswordInternal(login, password))
            {
                result.LastSuccessLogin = DateTime.Now;
               ctx.SaveChanges();        
            }
            else
            {
                result.LastFailLogin = DateTime.Now;
                ctx.SaveChanges();
                result = null;
            }
      
           //  TODO Usar el metodo ValidateUserPasswordInternal para validar la combinacion user/password
      //  TODO Sabiendo que la combinacion es valida, obtenemos los datos del usuario desde EF como hariamos normalmente
      //  TODO Actualizar los datos de ultimo login correcto o no, guardar cambios!!
      return result;
    }

    /// <summary>
    /// Permite chequear ciertas reglas de negocio respecto a la validez del usuario
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    private bool ValidarUsuario(Usuario user)
    {
            OMBContext ctx = OMBContext.DB;
            Usuario Usuario = ctx.Usuarios.FirstOrDefault(us => us.Empleado.Legajo == user.Empleado.Legajo);
            if (Usuario != null)
            {
                return false;
            }
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
        //  TODO incorporar hashing de password para proteger la informacion del usuario
        OMBContext.DB.Database.ExecuteSqlCommand("update Usuarios set Password = @p1 where Login = @p0", login, pass);
      }
      catch (Exception ex)
      {
        result = false;
      }
      return result;
    }

    /// <summary>
    /// Permite validar contra la database la existencia de una combinacion valida de usuario-password
    /// Lo mismo, en una DB deberiamos tener un stored que haga este proceso
    /// </summary>
    /// <param name="login"></param>
    /// <param name="pass"></param>
    /// <returns></returns>
    private bool ValidateUserPasswordInternal(string login, string pass)
    {
      bool result = true;
      try
      {
        //  TODO incorporar hashing para comparar con la que obtenemos de la tabla
        int cuenta = OMBContext.DB.Database
                    .SqlQuery<int>("select count(*) from Usuarios where Login = @p0 and Password = @p1", login, pass)
                    .FirstOrDefault();

        if (cuenta == 0)
        {
          ErrorInfo = "No existe una combinacion valida de credenciales";
          result = false;
        }
      }
      catch (Exception ex)
      {
        //  TODO Lanzar excepcion???
        ErrorInfo = "Error al intentar acceder a la tabla de usuarios";
        result = false;
      }
      return result;
    }
  }
}
