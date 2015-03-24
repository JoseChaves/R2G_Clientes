
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
				registerUser();
			};
		}

		public void registerUser(){
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
			//string names = name.ToString ();

		//	R2G_Clientes.Shared.DBConnection.registerUser (name.Text, email.Text, iphone, iwphone, addr.Text, waddr.Text, password.Text, wemail.Text);

			R2G_Clientes.Shared.UserRegister usuarios = new R2G_Clientes.Shared.UserRegister ();

			usuarios.Nombre = name.ToString();
			usuarios.password = password.ToString();
			usuarios.waddrs = waddr.ToString();
			usuarios.phone = iphone;
			usuarios.Email = email.ToString();
			usuarios.Direccion = addr.ToString();
			usuarios.wphone = iwphone;
			usuarios.wemail = wemail.ToString ();
			//hacemos el request del metodo que POST para guardar los datos
			var request = new RestRequest("users/add", Method.POST);
			//asignamos el valor de nuestros datos puede ser en XML O JSON en nuestro caso usaremos json
			request.RequestFormat = DataFormat.Json;
			//agregamos la entidad con los valores asignado anteriormente
			request.AddBody(usuarios);
			//ejecutamos el request
			cliente.Execute (request);

			/*AlertDialog.Builder dialogo = new AlertDialog.Builder (this);
			AlertDialog men = dialogo.Create();
			men.SetTitle ("Metodo Post");
			men.SetMessage ("Guardado Correctamente");
			men.Show ();*/


		} 
			
		}
	}

