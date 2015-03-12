
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
	[Activity (Label = "ServiceHistory", ParentActivity=typeof(MainMenu))]			
	public class ServiceHistory : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.activity_service_history);
			Button load = FindViewById<Button> (Resource.Id.load);
			// Create your application here
		}
	}
}

