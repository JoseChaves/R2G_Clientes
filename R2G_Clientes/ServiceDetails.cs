
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
	[Activity (Label = "ServiceDetails")]			
	public class ServiceDetails : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_details);
			Button subButt = FindViewById<Button> (Resource.Id.submitButt);

			// Create your application here

			subButt.Click += (sender, e) => {
				var actintent=new Intent(this, typeof(DetailsChanged));
				StartActivity(actintent);
			};
		}
	}
}

