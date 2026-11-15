using System.Linq.Expressions;
using System.Net;

namespace mpalloS6.Views;

public partial class vAgrergarEstudiante : ContentPage
{
	public vAgrergarEstudiante()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient(); //
            var parametros = new System.Collections.Specialized.NameValueCollection(); //
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

            cliente.UploadValues("http://192.168.56.1:8080/ws_estudiante/estudiante_ws.php", "POST", parametros);
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Alerta", "Error " + ex.Message, "OK");
        }
    }

    private void btnCancelar_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}