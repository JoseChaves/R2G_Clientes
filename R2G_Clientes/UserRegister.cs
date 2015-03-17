
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
	[Activity (Label = "UserRegister", ParentActivity=typeof(MainActivity))]			
	public class UserRegister : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_user_register);
			Button regButt = FindViewById<Button> (Resource.Id.button1);


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

			R2G_Clientes.Shared.DBConnection.registerUser (name.Text, email.Text, iphone, iwphone, addr.Text, waddr.Text, password.Text, wemail.Text);


		} 
			
		}
	}

