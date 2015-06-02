
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Json;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;
using R2G_Clientes.Shared;

namespace R2G_Clientes
{
	[Activity (Label = "@string/details", ParentActivity=typeof(MainMenu))]			
	public class ServiceDetails : Activity
	{
		HttpWebRequest wreq;
		HttpWebResponse wresp;
		Spinner spinner;
		ArrayAdapter adapter;
		int item;
		OrderData od;
		EditText e1;
		EditText e2;
		EditText e3;
		EditText e4;
		CheckBox c1;
		CheckBox c2;
		CheckBox c3;
		CheckBox c4;
		CheckBox c5;
		CheckBox c6;
		CheckBox c7;

		protected async override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_details);
			Button subButt = FindViewById<Button> (Resource.Id.submitButt);
			spinner = FindViewById<Spinner> (Resource.Id.spinner1);
			 e1 = FindViewById<EditText> (Resource.Id.editText1);
			 e2 = FindViewById<EditText> (Resource.Id.editText2);
			 e3 = FindViewById<EditText> (Resource.Id.editText3);
			e4 = FindViewById<EditText> (Resource.Id.editText4);
			c1 = FindViewById<CheckBox> (Resource.Id.checkBox1);
			c2 = FindViewById<CheckBox> (Resource.Id.checkBox2);
			c3 = FindViewById<CheckBox> (Resource.Id.checkBox3);
			c4 = FindViewById<CheckBox> (Resource.Id.checkBox4);
			c5 = FindViewById<CheckBox> (Resource.Id.checkBox5);
			c6 = FindViewById<CheckBox> (Resource.Id.checkBox6);
			c7 = FindViewById<CheckBox> (Resource.Id.checkBox7);

				
			od = new OrderData ();
			// Create your application her
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




			subButt.Click += (sender, e) => {
				var actintent=new Intent(this, typeof(DetailsChanged));
				StartActivity(actintent);
			};
		}

		private async void spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			item = Convert.ToInt32(spinner.GetItemAtPosition (e.Position).ToString());
			String url2 = urlbuilder();
			try{
				JsonValue jval = await requester (url2);
				parse(jval);
			}catch{
			}
		}

		public string urlbuilder(){
			string baseurl= "http://ps413027.dreamhost.com:8080/rapidtoREST/service/orders/";
			string finalurl = baseurl + item;

			return finalurl;
		}


		private async Task<JsonValue> requester(string url2){
			wreq = (HttpWebRequest)HttpWebRequest.Create (new Uri (url2));
			wreq.ContentType = "application/json";
			wreq.Method = "GET";

			using (WebResponse response = await wreq.GetResponseAsync ()) {
				using (Stream stream = response.GetResponseStream ()) {
					JsonValue jsondoc = await Task.Run (() => System.Json.JsonObject.Load (stream));
					Console.Out.Write ("Response, {0} ", jsondoc.ToString ());
					//Toast.MakeText (this, "Conexion Establecida" + jsondoc.ToString(), ToastLength.Long).Show ();
					return jsondoc;
				}
			}
		}

		public void parse(JsonValue jval){
			od = JsonConvert.DeserializeObject<OrderData> (jval.ToString ());
			e1.Text = od.addrs;
			e1.Enabled = false;
			e2.Text = od.starth.ToString()+":00";
			e3.Text = od.endh.ToString() + ":00";
			e4.Text = od.comments;

			if (od.orderDays.Contains ("Mon")) {
				c1.Checked = true;
			} else {
				c1.Checked = false;
			}

			if (od.orderDays.Contains ("Tue")) {
				c2.Checked = true;
			}else {
				c2.Checked = false;
			}

			if (od.orderDays.Contains ("Wed")) {
				c3.Checked = true;
			}else {
				c3.Checked = false;
			}

			if (od.orderDays.Contains ("Thur")) {
				c4.Checked = true;
			}else {
				c4.Checked = false;
			}

			if (od.orderDays.Contains ("Fri")) {
				c5.Checked = true;
			}else {
				c5.Checked = false;
			}

			if (od.orderDays.Contains ("Sat")) {
				c6.Checked = true;
			}else {
				c6.Checked = false;
			}

			if (od.orderDays.Contains ("Sun")) {
				c7.Checked = true;
			}else {
				c7.Checked = false;
			}

		}

	}

	public class OrderData{
		public int orderID{ get; set; }
		public string addrs{ get; set; }
		public string starth{ get; set; }
		public string endh{ get; set; }
		public string comments { get; set; }
		public string name{ set; get; }
		public string carModel{ get; set; }
		public string color{ get; set; }
		public string licenseplate{ get; set; }
		public string carComments{ get; set; }
		public string orderDays{ get; set; }
		public int pack{ get; set; }
	}
}

