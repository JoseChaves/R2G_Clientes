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
	[Activity (Label = "Rapid2Go",  Icon = "@drawable/rapilogo", Theme="@android:style/Theme.DeviceDefault.Light")]
	public class MainActivity : Activity
	{
		HttpWebRequest wreq;
		HttpWebResponse wresp;
		EditText user;
		EditText pwd;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			Button signInbutt = FindViewById<Button> (Resource.Id.signIn);
			Button registerButt = FindViewById<Button> (Resource.Id.register);


			signInbutt.Click += async (sender, e) => {
				string uray= requestValid();
				JsonValue jval = await requester(uray);
				var intent1=new Intent(this, typeof(MainMenu));
				StartActivity(intent1);
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
					Toast.MakeText (this, "Bienvenido", ToastLength.Long).Show ();
					return jsondoc;
				}
			}
		}

		public string requestValid(){
			string baseurl = "http://ps413027.dreamhost.com:8080/rapidtoREST/service/user/login";

			user = FindViewById<EditText> (Resource.Id.editText1);
			pwd = FindViewById<EditText> (Resource.Id.editText2);

			string url = baseurl + "?usern=" + WebUtility.UrlEncode (user.Text) + "&pwd=" + WebUtility.UrlEncode (pwd.Text);

			return url;
		}

}
}

