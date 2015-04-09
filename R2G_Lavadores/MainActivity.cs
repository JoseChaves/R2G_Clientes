using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using R2G_Clientes.Shared;
using System.Json;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
 


namespace R2G_Lavadores
{
	[Activity (Label = "R2G_Lavadores", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		string url;
		ListView et;
		IListAdapter ila;

		protected override void OnCreate (Bundle bundle)
		{

			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			Button butt = FindViewById<Button> (Resource.Id.button1);
			//et = FindViewById<EditText> (Resource.Id.editText1);
			url = "http://ps413027.dreamhost.com:8080/rapidtoREST/service/orders/lav/1";


			butt.Click += async (sender, e) => {
				JsonValue json = await FetchAsync(url);
				ParseAndDisplay(json);
			};	
		}

		public async Task<JsonValue> FetchAsync(string url){

			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (url));

			request.ContentType = "application/json";
			request.Method = "GET";

			using (WebResponse response = await request.GetResponseAsync ()) {

				using (Stream stream = response.GetResponseStream ()) {

					JsonValue jsondoc = await Task.Run (() => System.Json.JsonArray.Load (stream));
					Console.Out.Write ("Response, {0} ", jsondoc.ToString ());
					//Toast.MakeText (this, "Conexion Establecida" + jsondoc.ToString(), ToastLength.Long).Show ();
				
					return jsondoc;
				}
			}
		}

		private void ParseAndDisplay (JsonValue json)
		{
			OrderData order = JsonConvert.DeserializeObject<OrderData> (json.ToString ());
			var tempList=new [] {new {PhoneNumber=order["PhoneNumber"]}}.ToList();
			ArrayAdapter arry;

			arry.Add;

			/* ("ID De la Orden: " + order.orderID) +
			 ("Dirección de la órden: " + order.addrs) +
				("Ventana de Tiempo: de " + order.starth + " a " + order.endh )+
				("Automóvil: " + order.carModel + " " + order.color + " Placa: " + order.licenseplate)+
			("Comentarios de la órden: " + order.CarComments)+
			("Dias para el Servicio: " + order.orderDays)+
			("Paquete Contratado: " + order.pack);*/

		} }
			

public class OrderData
{
	public IList<int> orderID { get; set; }
	public IList<string> name { get; set; }
	public IList<string> addrs { get; set; }
	public IList<int> starth { get; set; }
	public IList<int> endh { get; set; }
	public IList<string> carModel { get; set; }
	public IList<string> licenseplate{ get; set; }
	public IList<string> color { get; set; }
	public IList<string> CarComments { get; set; }
	public IList<string> orderDays{ get; set; }
	public IList<int> pack{ get; set; }
}

}


