using System;
using System.Collections.Generic;
using System.Linq;
//using System.Net;
using System.Threading.Tasks;

using R2G_Clientes.Shared;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Auth0.SDK;
using Xamarin.Auth;
using Newtonsoft.Json;
using Android.Accounts;
//using System.Data.Common;
using System.Net;
using System.Json;
using System.IO;


namespace R2G_Clientes
{
	[Activity (Label = "Rapid2Go",  Icon = "@drawable/rapilogo", ParentActivity =typeof(Settings), NoHistory=true )]
	public class MainActivity : Activity
	{
		HttpWebRequest wreq;
		HttpWebResponse wresp;
		EditText user;
		EditText pwd;
		LoginData lg;
		R2G_Clientes.Shared.DataConnect dc;
		CarData cd;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			Button signInbutt = FindViewById<Button> (Resource.Id.signIn);
			Button registerButt = FindViewById<Button> (Resource.Id.register);
			lg  = new LoginData ();
			string verif = "true";
			cd = new CarData ();

			signInbutt.Click += async (sender, e) => {
				string uray= requestValid();
				JsonValue jval = await requester(uray);
				string parser = parse(jval);
				if ( verif.Equals(parser)){
					Toast.MakeText(this, Resource.String.loginSuccess, ToastLength.Short).Show();
					DataConnect.dataAccess(lg.userID);
					string caruray = "http://ps413027.dreamhost.com:8080/rapidtoREST/service/cars/onLogin/" + lg.userID;
					jval = await requester(caruray);
					parsemycar(jval);
					CarConnect.dataAccess(cd.carid, cd.carsize);
					var intent1=new Intent(this, typeof(MainMenu));
					intent1.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
					StartActivity(intent1);}
				else {
					Toast.MakeText(this, "Informacion erronea", ToastLength.Short).Show();
				}
			};

			registerButt.Click += (sender, e) => {
				var intent2=new Intent(this, typeof(UserRegister));
				StartActivity(intent2);
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
					//Toast.MakeText (this, "Bienvenido", ToastLength.Long).Show ();
					return jsondoc;
				}
			}
		}

		public string requestValid(){
			string baseurl = "http://ps413027.dreamhost.com:8080/rapidtoREST/service/users/login";

			user = FindViewById<EditText> (Resource.Id.editText1);
			pwd = FindViewById<EditText> (Resource.Id.editText2);

			string url = baseurl + "?usern=" + WebUtility.UrlEncode (user.Text) + "&pwd=" + WebUtility.UrlEncode (pwd.Text);

			return url;
		}

		private string parse(JsonValue json){
			lg = JsonConvert.DeserializeObject<LoginData> (json.ToString ());
		//	Toast.MakeText (this, "Bienvenido", ToastLength.Long).Show ();
			return lg.login;
		}

		private void parsemycar(JsonValue jval){
			cd = JsonConvert.DeserializeObject<CarData> (jval.ToString ());
		}

}

	public class LoginData{

		public int userID { get; set; }
		public string login { get; set; }

	}

	public class CarData{
		public int carid{ get; set; }
		public string success{ get; set; }
		public string carsize{ get; set; }
	}

}

