using mpalloS6.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace mpalloS6.Views;

public partial class vEstudiante : ContentPage
{
	private const string Url = "http://192.168.56.1:8080/ws_estudiante/estudiante_ws.php";
	private readonly HttpClient _cliente = new HttpClient();
	private ObservableCollection<estudiante> _estudiante;

    public vEstudiante()
	{
		InitializeComponent();
		MostrarEstudiante();

    }

	public async void MostrarEstudiante()
	{
		var content = await _cliente.GetStringAsync(Url);
		List<estudiante> _mostrar = JsonConvert.DeserializeObject<List<estudiante>>(content);
		_estudiante = new ObservableCollection<estudiante>(_mostrar);
		listaEstudiante.ItemsSource = _estudiante;
	}

    private void btnAgregarEstudiante_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new vAgrergarEstudiante());
    }
}