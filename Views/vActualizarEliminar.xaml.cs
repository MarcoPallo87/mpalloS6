using mpalloS6.Models;
using System.Net;
using System.Collections.Specialized;

namespace mpalloS6.Views;

public partial class vActualizarEliminar : ContentPage
{
    public vActualizarEliminar(estudiante datos)
    {
        InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre.ToString();
        txtApellido.Text = datos.apellido.ToString();
        txtEdad.Text = datos.edad.ToString();
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();

            string url = "http://192.168.56.1:8080/ws_estudiante/estudiante_ws.php" +
                         "?codigo=" + txtCodigo.Text +
                         "&nombre=" + txtNombre.Text +
                         "&apellido=" + txtApellido.Text +
                         "&edad=" + txtEdad.Text;

            cliente.UploadString(url, "PUT", "");
            DisplayAlertAsync("Éxito", "Estudiante actualizado", "OK");
            Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Alerta", "Error " + ex.Message, "OK");
        }
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        bool confirmar = await DisplayAlert("Confirmar", "¿Seguro que deseas eliminar?", "Sí", "No");
        if (!confirmar) return;

        try
        {
            WebClient cliente = new WebClient();
            string url = "http://192.168.56.1:8080/ws_estudiante/estudiante_ws.php?codigo=" + txtCodigo.Text;

            cliente.UploadString(url, "DELETE", "");
            DisplayAlertAsync("Éxito", "Estudiante eliminado", "OK");
            Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Alerta", "Error " + ex.Message, "OK");
        }
    }
}