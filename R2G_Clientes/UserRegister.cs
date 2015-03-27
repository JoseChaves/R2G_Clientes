
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Json;
using System.IO;

using Android.App;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RestSharp;
//using R2G_Clientes.Shared.DBConnection;

namespace R2G_Clientes
{
	[Activity (Label = "@string/register", ParentActivity=typeof(MainActivity))]			
	public class UserRegister : Activity
	{
		public RestClient cliente;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_user_register);
			Button regButt = FindViewById<Button> (Resource.Id.button1);
			cliente = new RestClient ("http://192.168.1.107:8080/rapidtoREST/service");

 			// Create your application here
			regButt.Click += (sender, e) => {
			//	registerUser();
				var intent = new Intent(typeof(MainMenu));
				StartActivity(intent);
			};
		}

		public void registerUser(){

			HttpWebRequest wreq;
			HttpWebResponse wresp;
			string url = "http://ps413027.dreamhost.com:8080/rapidtoREST/service/user/add";

			EditText name = FindViewById<EditText> (Resource.Id.editText1);
			EditText email = FindViewById<EditText> (Resource.Id.editText2);
			EditText password = FindViewById<EditText> (Resource.Id.editText3);
			EditText phone = FindViewById<EditText> (Resource.Id.editText4);
			EditText addr = FindViewById<EditText> (Resource.Id.editText5);
			EditText waddr = FindViewById<EditText> (Resource.Id.editText6);
			EditText wemail = FindViewById<EditText> (Resource.Id.editText7);
			EditText wphone = FindViewById<EditText> (Resource.Id.editText8);
			int iphone = Convert.ToInt32(phone.Text.ToString());
			int iwphone = Convert.ToInt32(wphone.Text.ToString());

			System.Json.JsonObject json = new System.Json.JsonObject ();

			json.Add ("usern", name.Text.ToString ());
			json.Add ("email", email.Text);
			json.Add ("password", password.Text);
			json.Add ("uaddr", addr.Text);
			json.Add ("wphone", iwphone);
			json.Add ("phone", iphone);
			json.Add ("waddr", waddr.Text);
			json.Add ("wemail", wemail.Text);

			wreq = (HttpWebResponse)HttpWebRequest.Create (url);
			wreq.ContentType = "application/json";
			wreq.Method = "POST";
			wreq.Accept = "application/json";
		

			/*AlertDialog.Builder dialogo = new AlertDialog.Builder (this);
			AlertDialog men = dialogo.Create();
			men.SetTitle ("Metodo Post");
			men.SetMessage ("Guardado Correctamente");
			men.Show ();*/


		} 
			
		}

	public class userData{
		public string name { get; set; }
		public string addrs{ get; set; }
		public string pssword{ get; set; }
		public int phone{ get; set; }
		public string email{ get; set; }
		public string waddrs{ get; set; }
		public string wemail { get; set; }
		public int wphone{ get; set; }
	}
	}

