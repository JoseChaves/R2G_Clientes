using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Net;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Json;
using System.Threading.Tasks;
using System.IO;

using R2G_Clientes.Shared;

namespace R2G_Clientes
{
	[Activity (Label = "Cash", NoHistory = true)]			
	public class Cash : Activity
	{
		TextView ordersumm;
		HttpWebRequest wreq;
		JsonValue jval;
		String url;
		String addrs;
		String seldays;
		String shours;
		String ehours;
		String comments;
		double price;
		int days;
		Order order;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_cash);
			// Create your application here

			Button mapplz = FindViewById<Button> (Resource.Id.showme);
			Button goHome = FindViewById<Button> (Resource.Id.getmehome);
			ordersumm = FindViewById<TextView> (Resource.Id.textView2);

			addrs = Intent.GetStringExtra ("address");
			days = Intent.GetIntExtra ("days", 0);
			seldays = Intent.GetStringExtra ("selDays");
			shours = Intent.GetStringExtra ("startT");
			ehours = Intent.GetStringExtra ("endT");
			price = Intent.GetDoubleExtra ("price", 0);
			comments = Intent.GetStringExtra ("comments");
			ordersumm.Text = string.Format ("Paquete de {0} dias - ${1} \n Direccion {2} \n Días {3} \n Hora de Inicio {4} \n Hora de Finalizado {5} \n Comentarios extra \n {6}", days, price, addrs, seldays, shours, ehours, comments);

			var geoUri=Android.Net.Uri.Parse("geo:8.975606,-79.534192?q=8.975606,-79.534192(Rapid2Go)");

			mapplz.Click += delegate {
				
				var intent=new Intent(Intent.ActionView, geoUri);
				StartActivity(intent);
			};

			goHome.Click += async (sender, e) =>{
				url = getURL();
				jval = await requester(url);
				parser(jval);
				OrderConnect.dataAccess(order.orderID);
				AlertDialog.Builder dialogo = new AlertDialog.Builder (this);
				AlertDialog men = dialogo.Create();
				men.SetTitle (Resource.String.confirmation );
				men.SetMessage (GetString(Resource.String.payplz));
				men.SetButton (GetString(Resource.String.takeme), delegate(object send, DialogClickEventArgs er) {
					//var geoUri=Android.Net.Uri.Parse("geo:8.975606,-79.534192?q=8.975606,-79.534192(Rapid2Go)");
					var intent2=new Intent(Intent.ActionView, geoUri);
					StartActivity(intent2);
					men.Dismiss();
				});
				men.SetButton2("Ok", delegate(object send, DialogClickEventArgs er){
					var intent2=new Intent(this, typeof(MainMenu));
					intent2.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
					StartActivity(intent2);
					men.Dismiss();
				});
				men.Show ();
			};
		}

		public void parser(JsonValue jval){
			order = JsonConvert.DeserializeObject<Order> (jval.ToString ());
				
		}

		public void button1(){
			var geoUri=Android.Net.Uri.Parse("geo:8.975606,-79.534192?q=8.975606,-79.534192(Rapid2Go)");
			var intent2=new Intent(Intent.ActionView, geoUri);
			StartActivity(intent2);
		}

		public void button2(){
			//
			var intent2=new Intent(this, typeof(MainMenu));
			intent2.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
			StartActivity(intent2);
		}

		public string getURL(){
			string baseurl = "http://ps413027.dreamhost.com:8080/rapidtoREST/service/orders/new";
			string requrl;
			int? userid = DataConnect.getUserID ();
			int carid = CarConnect.getCarID ();
			requrl = baseurl + "?orderAddr=" + WebUtility.UrlEncode(addrs) + "&startH=" + WebUtility.UrlEncode(shours) +  "&endH=" + WebUtility.UrlEncode(ehours) +
				"&orderComm=" + WebUtility.UrlEncode( comments) + "&userID=" + userid + "&carID=" + carid + "&days=" + WebUtility.UrlEncode(seldays) + 
				"&orderedPack=" + days;
			return requrl;

		}

		private async Task<JsonValue> requester(string url2){
			wreq = (HttpWebRequest)HttpWebRequest.Create (new Uri (url2));
			wreq.ContentType = "application/json";
			wreq.Method = "GET";

			using (WebResponse response = await wreq.GetResponseAsync ()) {
				using (Stream stream = response.GetResponseStream ()) {
					JsonValue jsondoc = await Task.Run (() => System.Json.JsonObject.Load (stream));
					Console.Out.Write ("Response, {0} ", jsondoc.ToString ());
					return jsondoc;
				}
			}
		}

	}

	public class Order{

		public string success{ get; set; }
		public int orderID{ get; set; }
	}
}

