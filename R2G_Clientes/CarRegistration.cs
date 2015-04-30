
using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;

using R2G_Clientes.Shared;

using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace R2G_Clientes
{
	[Activity (Label = "CarRegistration", ParentActivity=typeof(MainMenu))]			
	public class CarRegistration : Activity
	{
		HttpWebRequest wreq;
		HttpWebResponse wresp;
		EditText plate;
		EditText make;
		EditText model;
		EditText color;
		EditText comments;
		CheckBox starter;
		CheckBox ender;
		CheckBox specials;
		Spinner spinner;
		String selectedItem;
		ArrayAdapter adapter;
		int size;
		cars2 carData;
		cars car;


		protected async override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_car_register);
			Button save = FindViewById<Button> (Resource.Id.saveButt);
			Button editbutt = FindViewById<Button> (Resource.Id.editButt);

			// Create your application here

			plate = FindViewById<EditText> (Resource.Id.editText1);
			make = FindViewById<EditText> (Resource.Id.editText2);
			model = FindViewById<EditText> (Resource.Id.editText3);
			color = FindViewById<EditText> (Resource.Id.editText4);
			comments = FindViewById<EditText> (Resource.Id.editText5);
			starter = FindViewById<CheckBox> (Resource.Id.checkBox1);
			ender = FindViewById<CheckBox> (Resource.Id.checkBox2);
			specials = FindViewById<CheckBox> (Resource.Id.checkBox3);
			spinner = FindViewById<Spinner> (Resource.Id.spinner1);

			spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			adapter = ArrayAdapter.CreateFromResource (
				this, Resource.Array.cartypes, Android.Resource.Layout.SimpleSpinnerItem);

			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner.Adapter = adapter;

			try{
			string urlload = getCarsURL ();
			JsonValue jval1 = await requester (urlload);
				carsParse (jval1);
				CarConnect.dataAccess(car.carID, car.carsize);
			}catch(Exception e ){
				
			}

			save.Click += async (sender, e) => {
				string uray= registerUser();
				JsonValue jval= await requester (uray);
				parser(jval);
				if(carData.success.Equals("true")){
					Toast.MakeText(this, "guardado con exito",ToastLength.Long);
					CarConnect.dataAccess(carData.carid, carData.carsize);
				
				Toast.MakeText (this, "Registrado Exitosamente", ToastLength.Long).Show ();
					var tent=new Intent(this,typeof(CarChanged));}
					//StartActivity(tent);}
					else{
						Toast.MakeText(this, "Fallido", ToastLength.Long);
					}
			};

			editbutt.Click += (sender, e) => {
				
			};

		}

		public void parser(JsonValue json){
			carData = JsonConvert.DeserializeObject<cars2> (json.ToString ());
		}


		private void spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			switch(e.Position){
				case 0:
					selectedItem = "Small";
					break;
			case 1:
				selectedItem = "Medium";
				break;
			case 2:
				selectedItem = "Large";
				break;
			case 3:
				selectedItem = "Extra";
				break;
			}
			//selectedItem = spinner.GetItemAtPosition (e.Position).ToString();
			//return selectedItem;
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

		public string registerUser(){

		//	Uri url3;

			string url = "http://ps413027.dreamhost.com:8080/rapidtoREST/service/cars/add";

			//System.Json.JsonObject json = new System.Json.JsonObject ();
			int endnot;
			int startnot;
			int specnot;

			if (specials.Checked) {
				specnot = 1;
			} else {
				specnot = 0;
			}


			if (starter.Checked) {
				startnot = 1;
			} else {
				startnot = 0;
			}


			if (ender.Checked) {
				endnot = 1;
			} else {
				endnot = 9;
			}

			/*json.Add ("usern", name.Text.ToString ());
			json.Add ("email", email.Text);
			json.Add ("password", pswd);
			json.Add ("uaddr", addr.Text);
			json.Add ("wphone", iwphone);
			json.Add ("phone", iphone);
			json.Add ("waddr", waddr.Text);
			json.Add ("wemail", wemail.Text);*/


			string url2 = url + "?make=" + WebUtility.UrlEncode (make.Text) + "&model=" + WebUtility.UrlEncode (model.Text) + "&plate=" +
				WebUtility.UrlEncode (plate.Text) + "&color=" + 
				WebUtility.UrlEncode (color.Text) + "&startnot=" + 
				startnot + "&endnot=" + endnot + "&comments=" + 
				WebUtility.UrlEncode (comments.Text) + "&owner=" + DataConnect.getUserID() + "&carsize=" + WebUtility.UrlDecode(selectedItem);

			//	Toast.MakeText (this, url2, ToastLength.Long).Show ();
			return url2;
		}

		public string getCarsURL(){
			string url = "http://ps413027.dreamhost.com:8080/rapidtoREST/service/cars/owner/";
			string url2 = url + DataConnect.getUserID ();
			return url2;
		}

		public void carsParse(JsonValue json){
			car = JsonConvert.DeserializeObject<cars> (json.ToString());

			make.Text = car.make;
			model.Text = car.model;
			color.Text = car.color;
			plate.Text = car.plate;
			comments.Text = car.comments;
			if (car.carsize.Equals ("Small")) {
				size = 0;
			}else {
				if(car.carsize.Equals("Medium")){
					size= 1;
				}else {
					if(car.carsize.Equals("Large")){
						size = 2;
					}else 
						if(car.carsize.Equals("Extra")){
							size = 3;
						}
					}
				}
			spinner.SetSelection (size);

			if (car.startnot == 1) {
				starter.Checked = true;
			}

			if (car.endnot == 1) {
				ender.Checked = true;
			}

		}

		/*public List<cars> parse(JsonValue json){
			List<cars> cars2;
			cars cars1 = JsonConvert.DeserializeObject<cars> (json.ToString ());
			cars2.Add(new cars() {cars1.carID, });
			return cars2;

		}*/

		public void parse(JsonValue json){

			var carss = JsonConvert.DeserializeObject<DataStore> (json.ToString());




		}
	}

	public class DataStore{

		public List<cars> cars { get; set; }
 
	}


	public class cars{

		public int carID{ get; set; }
		public int startnot{ get; set; }
		public int endnot{ get; set;}
		public int owner{ get; set; }
		public string plate{ get; set; }
		public string make{get;set;}
		public string color{ get; set; }
		public string model{ get; set; }
		public string comments{ get; set; }
		public string carsize{ get; set; }

	}
	
	public class cars2{
		public int carid{ get; set; }
		public string success{ get; set; }
		public string carsize{ get; set; }
	}
}

