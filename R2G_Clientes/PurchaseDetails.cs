
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
	[Activity (Label = "PurchaseDetails")]			
	public class PurchaseDetails : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.activity_purchase_details);
			Button submitButt = FindViewById<Button> (Resource.Id.submitButt);

			submitButt.Click+= (sender, e) => {
				var subtent = new Intent (this, typeof(PaymentOptions));
				StartActivity(subtent);
			};
			// Create your application here
		}
	}
}

