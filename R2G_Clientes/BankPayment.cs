
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
	[Activity (Label = "BankPayment", ParentActivity=typeof(PaymentOptions))]			
	public class BankPayment : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);


			int dep = Intent.GetIntExtra ("dep", 1);

			if (dep == 1)
				SetContentView (Resource.Layout.activity_payment_bank_transaction);
			else
				SetContentView (Resource.Layout.activity_banki_ach);

			Button buttDone = FindViewById<Button> (Resource.Id.buttDone);


			// Create your application here
		}
	}
}

