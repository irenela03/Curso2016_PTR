using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Servicios;
using Entidades;

namespace OMB_Desktop.Views
{
  /// <summary>
  /// Interaction logic for LoginControl.xaml
  /// </summary>
  public partial class LoginControl : UserControl
  {
    public event EventHandler<Usuario> LoginOK;

    public LoginControl()
    {
      InitializeComponent();
    }

    private void LoginUser(object sender, RoutedEventArgs e)
    {
      SecurityServices seg = new SecurityServices();

      //  validar que usuario y password tengan contenido
      Usuario user = seg.LoginUsuario(txtUsuario.Text, txtPassword.Password);
      if (user != null)
      {
        MessageBox.Show("Usuario correctamente logueado!!!");
        //  TODO: usuario o sesion?
        if (LoginOK != null)
          LoginOK(this, user);
      }
      else
        MessageBox.Show("Error en Login!!! Pruebe de nuevo!!");
    }
  }
}
