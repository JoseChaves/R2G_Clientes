
using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Text;

using R2G_Clientes.Shared;

using Newtonsoft.Json;

using System.Threading.Tasks;
using Android.Content;
using Android.Runtime;
using Android.Views;
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
		public ArrayAdapter adapter;
		//List<Datos_Usuarios> listausuarios = new List<Datos_Usuarios> ();
		//ListView LvLIsta;

		Spinner spinner;
		System.Json.JsonArray jerry;
		int item;
		TextView tv2;
		TextView tv3;
		TextView tv4;
		TextView tv5;
		TextView tv6;
		TextView tv7;
		TextView tv8;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.activity_service_history);

			Button load = FindViewById<Button> (Resource.Id.load);
			spinner = FindViewById<Spinner> (Resource.Id.spinner1);
			tv2= FindViewById<TextView> (Resource.Id.textView2);
			tv3= FindViewById<TextView> (Resource.Id.textView3);
			tv4= FindViewById<TextView> (Resource.Id.textView4);
			tv5= FindViewById<TextView> (Resource.Id.textView5);
			tv6= FindViewById<TextView> (Resource.Id.textView6);
			tv7= FindViewById<TextView> (Resource.Id.textView7);
			tv8 = FindViewById<TextView> (Resource.Id.textView8);

			try{
			List<int> orders =new List<int>( OrderConnect.getAllOrders ());

			spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			adapter = new ArrayAdapter<int>( this, Android.Resource.Layout.SimpleSpinnerItem, orders);

			orders.ForEach (delegate(int orderID){
				//adapter.Remove(orderID);
				//adapter.Add (orderID);
				Console.WriteLine(orderID);
			});

			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner.Adapter = adapter;
			}catch{
			}
			//ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, lables);

			string url = "http://ps413027.dreamhost.com:8080/rapidtoREST/service/orders/";

			load.Click += async (sender, e) => {
				string url2 = urlbuilder(url);
				try{
				JsonValue json = await FetchAsync(url2);
				//listausuarios = new List<Datos_Usuarios>();
				//MetodoGet();
				ParseAndDisplay(json);
				}catch{
					AlertDialog.Builder dialogo = new AlertDialog.Builder (this);
					AlertDialog men = dialogo.Create();
					men.SetTitle (Resource.String.notyet);
					men.SetMessage ("Please Log In To Continue");
					men.SetButton ("Ok",delegate(object send, DialogClickEventArgs er) {
						men.Dismiss();
					});
					men.Show ();
				}
				//Toast.MakeText (this, "Conexion Establecida" + json.ToString(), ToastLength.Long).Show ();

			};
			//declaramos el evento de click en listview para mostrar informacion extra en un toast
			/////LvLIsta.ItemClick += lvlista_ItemClick;
			// Create your application here
		}

		public string urlbuilder(string url){
			string finalurl = url + item;
			return finalurl;
		}

		private void spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			item = Convert.ToInt32(spinner.GetItemAtPosition (e.Position).ToString());
			}

		public async void fillspinner(string url){
			JsonValue json = await FetchAsync(url);

			List<JsonValue> jsonString = new List<JsonValue>();
			jerry = (System.Json.JsonArray)json; 
			if (jerry != null) { 
				jsonString = jerry.ToList ();

				}

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
			

		private void ParseAndDisplay (JsonValue json)
		{
			OrderData1 order = JsonConvert.DeserializeObject<OrderData1> (json.ToString ());

			tv2.Text = (GetString(Resource.String.ordrID) + " " + order.orderID);
			tv3.Text = (GetString(Resource.String.address) + " " + order.addrs);
			tv4.Text = (GetString(Resource.String.timewindow) + " " + order.starth + " - " + order.endh );
			tv5.Text = (GetString(Resource.String.car) + order.carModel + " " + order.color + GetString(Resource.String.licenseplate) + order.licenseplate);
			tv6.Text = (GetString(Resource.String.orderComms)+ string.Format("\n") + order.CarComments);
			tv7.Text = (GetString(Resource.String.orderdays) + order.orderDays);
			tv8.Text = (GetString(Resource.String.orderPack) + order.pack);

		} }
	
	//Entidad de los datos que vamos a usar.
	public class OrderData1{
		
		public int orderID { get; set; }
		public string name { get; set; }
		public string addrs { get; set; }
		public int starth { get; set; }
		public int endh { get; set; }
		public string carModel { get; set; }
		public string licenseplate{ get; set; }
		public string color { get; set; }
		public string CarComments { get; set; }
		public string orderDays{ get; set; }
		public int pack{ get; set; }
	}

	public class oData{
		public int orderID{ get; set; }
	}
		
		
}
