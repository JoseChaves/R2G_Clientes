using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace R2G_Clientes
{
	[Activity (Label = "R2G_Clientes", MainLauncher = true, Icon = "@drawable/icon", Theme="@android:style/Theme.Holo.Light.NoActionBar.TranslucentDecor")]
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


