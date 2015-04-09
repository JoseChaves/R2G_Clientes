
using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;

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

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_car_register);
			Button save = FindViewById<Button> (Resource.Id.saveButt);
			Button editbutt = FindViewById<Button> (Resource.Id.editButt);

			// Create your application here

			save.Click += async (sender, e) => {
				string uray= registerUser();
				JsonValue jval= await requester (uray);
				var tent=new Intent(this,typeof(CarChanged));
				StartActivity(tent);
			};

			editbutt.Click += (sender, e) => {
				
			};

		}

		private async Task<JsonValue> requester(string url2){
			wreq = (HttpWebRequest)HttpWebRequest.Create (new Uri (url2));
			wreq.ContentType = "application/json";
			wreq.Method = "GET";

			using (WebResponse response = await wreq.GetResponseAsync ()) {
				using (Stream stream = response.GetResponseStream ()) {
					JsonValue jsondoc = await Task.Run (() => System.Json.JsonObject.Load (stream));
					Console.Out.Write ("Response, {0} ", jsondoc.ToString ());
					Toast.MakeText (this, "Registrado Exitosamente", ToastLength.Long).Show ();
					return jsondoc;
				}
			}
		}

		public string registerUser(){

			Uri url3;

			string url = "http://ps413027.dreamhost.com:8080/rapidtoREST/service/cars/add";

			EditText plate = FindViewById<EditText> (Resource.Id.editText1);
			EditText make = FindViewById<EditText> (Resource.Id.editText2);
			EditText model = FindViewById<EditText> (Resource.Id.editText3);
			EditText color = FindViewById<EditText> (Resource.Id.editText4);
			EditText comments = FindViewById<EditText> (Resource.Id.editText5);
			CheckBox starter = FindViewById<CheckBox> (Resource.Id.checkBox1);
			CheckBox ender = FindViewById<CheckBox> (Resource.Id.checkBox2);
			CheckBox specials = FindViewById<CheckBox> (Resource.Id.checkBox3);
			System.Json.JsonObject json = new System.Json.JsonObject ();
			int endnot;
			int startnot;

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
				WebUtility.UrlEncode (plate.Text) + "&color=" + WebUtility.UrlEncode (color.Text) + "&startnot=" + startnot + "&endnot=" + endnot + "&comments=" + WebUtility.UrlEncode (comments.Text) + "&owner=" + "2";

			//	Toast.MakeText (this, url2, ToastLength.Long).Show ();
			return url2;
		}

	}
}

