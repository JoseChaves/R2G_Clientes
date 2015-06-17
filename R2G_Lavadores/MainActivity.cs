using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.OS;
using System.Json;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using R2G_Clientes.Shared;
using Android.Widget;
using SQLite;


namespace R2G_Lavadores
{
	[Activity (Label = "R2G_Lavadores", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		string url;
		ListView et;
		IListAdapter ila;
		EditText pwd;
		EditText usr;
		int id = 0;
		OrderData od= new OrderData();

		protected override void OnCreate (Bundle bundle)
		{	

			try{
				id = DataConnect.getUserID ();
			}catch{
			//	id = null;
			}

				base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			Button butt = FindViewById<Button> (Resource.Id.btnLogIn);
			usr = FindViewById<EditText> (Resource.Id.editText1);
			pwd = FindViewById<EditText> (Resource.Id.editText2);
			Intent intent = new Intent (this, typeof(Menu));
			if (id != 0) {
				
				StartActivity (intent);
			}


			butt.Click += async (sender, e) => {
				url = urlbuilder();
				try{
				JsonValue json = await RequestHandler.FetchAsync(url);
				ParseAndDisplay(json);
				}catch{}
				if (od.login.Equals("true")){
					DataConnect.dataAccess(od.userID);
					StartActivity(intent);

				}else{
					
				}
				
			};	
		}

		public string urlbuilder(){
			string baseurl=	"http://ps413027.dreamhost.com:8080/rapidtoREST/users/login";
			string finalurl;

			finalurl = baseurl + "?usern=" + WebUtility.UrlEncode (usr.Text) + "&pwd=" + WebUtility.UrlEncode (HashBrown.hasher (pwd.Text));
			return finalurl;
		}

		private void ParseAndDisplay (JsonValue json)
		{
			od = JsonConvert.DeserializeObject<OrderData> (json.ToString ());


		} 
	}
			

public class OrderData
{
		public int userID { get; set; }
		public string login { get; set; }
}

}


