
using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Json;

using Newtonsoft.Json;
using R2G_Clientes.Shared;
using Android.App;
using Android.Content;
using Android.OS;
//using Android.Runtime;
//using Android.Views;
using Android.Widget;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace R2G_Clientes
{
	[Activity (Label = "PackageSelect", ParentActivity=typeof(MainMenu))]
	public class PackageSelect : Activity
	{
		HttpWebRequest wreq;
		HttpWebResponse wresp;
		Spinner spinner;
		ArrayAdapter adapter;
		int priceChoice;
		int itemselected;
		int amountofDays;
		String carsize;
		RadioButton rdio4;
		RadioButton rdio6;
		RadioButton rdio10;
		RadioButton rdio12;
		List<double> smalls= new List<double> () {37, 52.50, 82.50, 96};
		List<double> mediums = new List<double> () {39, 55.50, 57.50, 87.50, 102};
		List<double> larges = new List<double> () {43, 61.50, 97.50, 114.00};
		List<double> extras= new List<double>() {45, 64.50, 102.50, 120};
		double price;



		protected async override void OnCreate (Bundle bundle){
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.activity_packages);
			rdio4 = FindViewById<RadioButton> (Resource.Id.radioButton1);
			rdio6 = FindViewById<RadioButton> (Resource.Id.radioButton2);
			rdio10 = FindViewById<RadioButton> (Resource.Id.radioButton3);
			rdio12= FindViewById<RadioButton> (Resource.Id.radioButton4);
			Button submitbutt = FindViewById<Button> (Resource.Id.submitbutt);
			spinner = FindViewById<Spinner> (Resource.Id.spinner1);

			spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			adapter = ArrayAdapter.CreateFromResource (
				this, Resource.Array.cartypes, Android.Resource.Layout.SimpleSpinnerItem);

			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner.Adapter = adapter;
			spinner.Enabled = false;
			carsize = CarConnect.getCarSize ();


			submitbutt.Click += (sender, e) => {
				amountofDays = days();
				var subtent = new Intent (this, typeof(PurchaseDetails));
				subtent.PutExtra("days", amountofDays);
				subtent.PutExtra("price", price);
				StartActivity (subtent);
			};
			//spinny.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			//var adapter = ArrayAdapter.CreateFromResource (
			//	this, Resource.Array.cars, Android.Resource.Layout.SimpleSpinnerItem);

			//adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			//spinny.Adapter = adapter;
			// Create your application here
		}

		public int days(){
			int dayscount = 0;

			if (rdio4.Checked) {
				dayscount = 4;
				priceChoice = 0;
			} else if (rdio6.Checked) {
				dayscount = 6;
				priceChoice = 1;
			} else if (rdio10.Checked) {
				dayscount = 10;
				priceChoice = 2;
			} else if (rdio12.Checked) {
				dayscount = 12;
				priceChoice = 3;
			}

			return dayscount;
		}

		public double pricer(){

			if (carsize.Equals ("Small")) {
				price = smalls [priceChoice];
				rdio4.Text = 
			} else if (carsize.Equals ("Medium")) {
				price = mediums [priceChoice];
			} else if (carsize.Equals ("Large")) {
				price = larges [priceChoice];
			} else if (carsize.Equals ("Extra")) {
				price = extras [priceChoice];
			}

			return price;

		}
			

		private void spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e){
			Spinner spinner = (Spinner)sender;

			int selection = (int)spinner.GetItemIdAtPosition(e.Position);

			switch(selection){

			case 0:
				//rdio4.SetText (Resource.String.fourwashesSmall);
				//rdio6.SetText (Resource.String.eightwashesSmall);
				//rdio10.SetText (Resource.String.eightwashesSmall);
				//rdio12.SetText (Resource.String.twelvewashesSmall);
				break;
			case 1:
				//rdio4.SetText (Resource.String.fourwashesSmall);
				//rdio6.SetText (Resource.String.eightwashesSmall);
				//rdio10.SetText (Resource.String.eightwashesSmall);
				//rdio12.SetText (Resource.String.twelvewashesSmall);
				break;
			case 2:
				//rdio4.SetText (Resource.String.fourwashesSmall);
				//rdio6.SetText (Resource.String.eightwashesSmall);
				//rdio10.SetText (Resource.String.eightwashesSmall);
				//rdio12.SetText (Resource.String.twelvewashesSmall);
				break; 

			case 3:
				//rdio4.SetText (Resource.String.fourwashesSmall);
				//rdio6.SetText (Resource.String.eightwashesSmall);
				//rdio10.SetText (Resource.String.eightwashesSmall);
				//rdio12.SetText (Resource.String.twelvewashesSmall);
				break;
			}

			//string toast = string.Format ("The planet is {0}", spinner.GetItemAtPosition (e.Position));
			//Toast.MakeText (this, toast, ToastLength.Long).Show ();
		}

		public async Task<JsonValue> getcars(string url2){
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

	public class carsID{

	}

}

