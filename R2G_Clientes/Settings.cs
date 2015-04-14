
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

namespace R2G_Clientes
{
	[Activity (Label = "Settings", ParentActivity=typeof(MainMenu))]			
	public class Settings : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_settings);

			Button signout = FindViewById<Button> (Resource.Id.signout);
			Button signin  = FindViewById<Button> (Resource.Id.signin);
			Button callOffice = FindViewById<Button> (Resource.Id.callOfficeforChanges);
			// Create your application here

			signin.Click += (sender, e) => {
				var inte=new Intent(this, typeof(MainActivity));
				StartActivity(inte);
			};

			callOffice.Click += (sender, e) => {
				var uri = Android.Net.Uri.Parse ("tel:+5072039278");
				var inten=new Intent(Intent.ActionCall);
				inten.SetData(uri);
				StartActivity(inten);
			};
		}
	}
}

