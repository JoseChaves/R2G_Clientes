
using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Text;

using Newtonsoft.Json;

using System.Threading.Tasks;

using Android.App;
using Android.OS;
using Android.Widget;
using RestSharp;

namespace R2G_Clientes
{
	[Activity (Label = "@string/history", ParentActivity=typeof(MainMenu))]			
	public class ServiceHistory : Activity
	{
		public RestClient client;
		//Declaroamos nuestras variables que utilizaremos
		public ArrayAdapter<Datos_Usuarios> adapter;
		//List<Datos_Usuarios> listausuarios = new List<Datos_Usuarios> ();
		//ListView LvLIsta;
		TextView tv1;
		TextView tv2;
		TextView tv3;
		TextView tv4;
		TextView tv5;
		TextView tv6;
		TextView tv7;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.activity_service_history);
			//LvLIsta = FindViewById<ListView> (Resource.Id.listView1);
			Button load = FindViewById<Button> (Resource.Id.load);

			tv1= FindViewById<TextView> (Resource.Id.textView1);
			tv2= FindViewById<TextView> (Resource.Id.textView2);
			tv3= FindViewById<TextView> (Resource.Id.textView3);
			tv4= FindViewById<TextView> (Resource.Id.textView4);
			tv5= FindViewById<TextView> (Resource.Id.textView5);
			tv6= FindViewById<TextView> (Resource.Id.textView6);
			tv7= FindViewById<TextView> (Resource.Id.textView7);
			client = new RestClient ("http://192.168.1.107:8080/rapidtoREST/service");
			//adapter = new ArrayAdapter<Datos_Usuarios>(this, Android.Resource.Layout.SimpleListItem1);
			//LvLIsta.Adapter = adapter;

			string url = "http://192.168.1.107:8080/rapidtoREST/service/orders/2";

			// Create your application here

			load.Click += async (sender, e) => {

				JsonValue json = await FetchAsync(url);
				//listausuarios = new List<Datos_Usuarios>();
				//MetodoGet();
				//ParseAndDisplay(json);
				Toast.MakeText(this, json.ToString(), ToastLength.Long).Show();

			};
			//declaramos el evento de click en listview para mostrar informacion extra en un toast
			/////LvLIsta.ItemClick += lvlista_ItemClick;
			// Create your application here
		}

		private async Task<JsonValue> FetchAsync(string url){

			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (url));
			request.ContentType = "application/json";
			request.Method = "GET";

			using (WebResponse response = await request.GetResponseAsync ()) {
				using (Stream stream = response.GetResponseStream ()) {
					JsonValue jsondoc= await Task.Run(() => System.Json.JsonObject.Load(stream));
					Console.Out.Write("Response, {0} ", jsondoc.ToString());
					//Toast.MakeText (this, "Conexion Establecida" + jsondoc.ToString(), ToastLength.Long).Show ();
						return jsondoc;
				}
			}
	
		}

		void lvlista_ItemClick (object sender, AdapterView.ItemClickEventArgs e)
		{
			//toast para mostrar informacion extra de la mostrada
		//	Android.Widget.Toast.MakeText(this, listausuarios[e.Position].Email + " " + listausuarios[e.Position].Telefono, Android.Widget.ToastLength.Short).Show();;

		}
		public void MetodoGet()
		{
			//limpiamos nuestro adaptador
			adapter.Clear ();
			//hacemos nuestro request donde declaramos que metodo vamos a utilizar
			var request = new RestRequest ("/orders", Method.GET);
			//ejecutamos el metodo para que nos devuelva todo la informacion y la mostramos en nuestro listview
			var resultado = client.Execute<List<Datos_Usuarios>> (request).Data;
			foreach (Datos_Usuarios x in resultado) {
				Datos_Usuarios datos = new Datos_Usuarios ();
				datos.Id_Persona = x.Id_Persona;
				datos.Nombre = x.Nombre;
				datos.Paterno = x.Paterno;
				datos.Materno = x.Materno;
				datos.Telefono = x.Telefono;
				datos.Email = x.Email;
				datos.Direccion = x.Direccion;
				datos.Edad = x.Edad;
				adapter.Add (x.Nombre + " " + x.Paterno + " " + x.Materno);
		//listausuarios.Add (datos);

			}
		}
		private void ParseAndDisplay (JsonValue json)
		{
			// Get the weather reporting fields from the layout resource:

			ServiceHistory order = JsonConvert.DeserializeObject<ServiceHistory> (json.ToString ());

			// Extract the array of name/value results for the field name "weatherObservation". 
			//JsonValue order = json["orderid"];

			// Extract the "stationName" (location string) and write it to the location TextBox:
			tv1.Text = order["orderID"];
			tv2.Text = order ["addrs"];
			tv3.Text = order ["starth"] + " a " + order ["endh"];
			tv4.Text = order ["comments"];
			tv5.Text = order ["carModel"] + " " + order ["color"] + " " + order ["licenseplate"];
			tv6.Text = order ["carComments"];
			tv7.Text = order ["orderDays"];


		} }
	
	//Entidad de los datos que vamos a usar.
	public class Datos_Usuarios
	{
		public int Id_Persona { get; set; }
		public string Nombre { get; set; }
		public string Paterno { get; set; }
		public string Materno { get; set; }
		public string Telefono { get; set; }
		public string Email { get; set; }
		public string Direccion { get; set; }
		public double Edad { get; set; }
	}
}
