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
	[Activity (Label = "Cash")]			
	public class Cash : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_cash);
			// Create your application here

			Button mapplz = FindViewById<Button> (Resource.Id.showme);
			Button goHome = FindViewById<Button> (Resource.Id.getmehome);

			mapplz.Click += delegate {
				var geoUri=Android.Net.Uri.Parse("geo:8.975606,-79.534192");
				var intent=new Intent(Intent.ActionView, geoUri);
				StartActivity(intent);
			};

			goHome.Click += (sender, e) =>{
				
				var intent2=new Intent(this, typeof(MainMenu));
				StartActivity(intent2);
			};
		}
	}
}

