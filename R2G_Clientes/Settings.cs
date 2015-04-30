
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using R2G_Clientes.Shared;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace R2G_Clientes
{
	[Activity (Label = "Settings" , ParentActivity=typeof(MainMenu))]			
	public class Settings : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_settings);

			Button signout = FindViewById<Button> (Resource.Id.save);
			Button signin  = FindViewById<Button> (Resource.Id.signin);
			Button callOffice = FindViewById<Button> (Resource.Id.callOfficeforChanges);
			Button officeaddrs = FindViewById<Button> (Resource.Id.signout);
			// Create your application here

			officeaddrs.Click += (sender, e) => {

				var geoUri=Android.Net.Uri.Parse("geo:8.975606,-79.534192?q=8.975606,-79.534192(Rapid2Go)");
				var intent2=new Intent(Intent.ActionView, geoUri);
				StartActivity(intent2);
			};

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

			signout.Click += (sender, e) => {
				string resp=DataConnect.deleteUser();
				string resp2= CarConnect.deleteCar();
				Toast.MakeText(this, resp,ToastLength.Short).Show();
			};
		}
	}
}

