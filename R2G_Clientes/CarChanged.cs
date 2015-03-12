
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
	[Activity (Label = "CarChanged", ParentActivity=typeof(CarRegistration))]			
	public class CarChanged : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_car_detail_change);

			Button save = FindViewById<Button> (Resource.Id.save);


			// Create your application here

			save.Click += (sender, e) => {
				var inte=new Intent(this, typeof(CarRegistration));
				StartActivity(inte);
			};
		}
	}
}

