using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entidades;
using OMB_Desktop.Common;

namespace OMB_Desktop.ViewModels
{
  public class LoginViewModel : INotifyPropertyChanged, IDataErrorInfo
  {
    public event PropertyChangedEventHandler PropertyChanged;

    private string _password;
    private string _login;
    /*
    private Perfil _perfil;
    private ObservableCollection<Perfil> _perfiles;
    private Action<ActionRequest> _notify;
    */

    #region PROPIEDADES BINDEABLES

    /// <summary>
    /// Representa el ID de ingreso del usuario al sistema
    /// Validacion por excepcion...
    /// </summary>
    public string Login
    {
      get { return _login; }
      set
      {
        if (string.IsNullOrEmpty(value) || value.Length < 5)
          throw new ArgumentException("El Login debe ser un valor no vacio y de al menos 5 caracteres");

        _login = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// Contraseña que se tiene que usar para ingresar al sistema
    /// </summary>
    public string Password
    {
      private get
      {
        return _password;
      }
      set
      {
        _password = value;
        OnPropertyChanged();
      }
    }
/*
    public Perfil PerfilSeleccionado
    {
      get { return _perfil; }
      set
      {
        _perfil = value;
        OnPropertyChanged();
      }
    }

    public ObservableCollection<Perfil> Perfiles
    {
      get { return _perfiles; }
      set
      {
        _perfiles = value;
        OnPropertyChanged();
      }
    }
*/
    #endregion

    #region COMANDOS

    public ComandoSimple ComandoIngresar { get; set; }

    public ComandoSimple ComandoCancelar { get; set; }

    public ComandoSimple ComandoIngresarPerfil { get; set; }

    #endregion

    private Usuario Usuario { get; set; }

    public bool IsValid()
    {
      //  aqui el problema de tener que recorrer la coleccion de todas las propiedades que puedan producir error
      //  como en este caso es una sola, no es una complicacion
      foreach (var item in new[] { "Password" })
        if (!string.IsNullOrEmpty(this[item]))
          return false;
      return true;
    }
/*
    #region LANZADORES DE EVENTOS

    private void OnLoginError(string errMsg)
    {
      INotificationService serv = Context.Current.ServiceProvider.GetService(typeof(INotificationService)) as INotificationService;

      serv.Mensaje = errMsg;
      serv.Titulo = "ERROR IMPORTANTE";
      serv.Show();
    }

    #endregion
*/
    #region Implementacion IDataErrorInfo

    public string Error
    {
      get { return string.Empty; }
    }

    public string this[string propName]
    {
      get
      {
        switch (propName)
        {
          case "Password":
            if (string.IsNullOrWhiteSpace(_password) || _password.Length < 5)
              return "La password no puede estar vacia y debe ser de al menos 5 caracteres";
            else
              return string.Empty;
            break;
        }
        return string.Empty;
      }
    }

    #endregion

    protected void OnPropertyChanged([CallerMemberName] string propName = null)
    {
      if (PropertyChanged != null && propName != null)
        PropertyChanged(this, new PropertyChangedEventArgs(propName));
    }
  }
}
