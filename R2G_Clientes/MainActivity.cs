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


namespace R2G_Clientes
{
	[Activity (Label = "R2G_Clientes", MainLauncher=true,  Icon = "@drawable/rapilogo", Theme="@android:style/Theme.Holo.Light.NoActionBar.TranslucentDecor")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			Button signInbutt = FindViewById<Button> (Resource.Id.signIn);
			Button registerButt = FindViewById<Button> (Resource.Id.register);


			signInbutt.Click += (sender, e) => {
				var intent1=new Intent(this, typeof(MainMenu));
				StartActivity(intent1);
			};

			registerButt.Click += (sender, e) => {
				var intent2=new Intent(this, typeof(UserRegister));
				StartActivity(intent2);
			};


		}


}
}

