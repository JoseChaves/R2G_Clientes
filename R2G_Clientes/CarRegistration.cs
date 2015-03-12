
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
	[Activity (Label = "CarRegistration", ParentActivity=typeof(MainMenu))]			
	public class CarRegistration : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_car_register);
			Button save = FindViewById<Button> (Resource.Id.saveButt);
			Button editbutt = FindViewById<Button> (Resource.Id.editButt);

			// Create your application here

			editbutt.Click += (sender, e) => {
				var tent=new Intent(this,typeof(CarChanged));
				StartActivity(tent);
			};

		}
	}
}

