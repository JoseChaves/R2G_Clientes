
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
	[Activity (Label = "MainMenu")]			
	public class MainMenu : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.activity_menu);

			Button purch = FindViewById<Button> (Resource.Id.purchase);
			Button det = FindViewById<Button> (Resource.Id.details);
			Button carRegist = FindViewById<Button> (Resource.Id.cars);
			Button historu = FindViewById<Button> (Resource.Id.history);
			Button config = FindViewById<Button> (Resource.Id.config);

			// Create your application here

			purch.Click += (sender,e) =>{
				var purtent=new Intent(this, typeof(PackageSelect));
					StartActivity(purtent);
			};

			det.Click += (sender, e) => {
				var dettent=new Intent(this, typeof(ServiceDetails));
				StartActivity(dettent);

			};

			carRegist.Click += (sender, e) => {
				var cartent=new Intent(this, typeof(CarRegistration));
				StartActivity(cartent);
			};

			historu.Click += (sender, e) => {
				var histent=new Intent(this, typeof(CarRegistration));
				StartActivity(histent);
			};

			config.Click += (sender, e) => {
				var content=new Intent(this,typeof(Settings));
				StartActivity(content);
			};

		}
	}
}

