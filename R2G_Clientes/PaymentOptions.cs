
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
	[Activity (Label = "PaymentOptions", ParentActivity=typeof(PurchaseDetails)) ]			
	public class PaymentOptions : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.activity_payment_options);
			Button googleWbutt = FindViewById < Button > (Resource.Id.googlePayment);
			Button creditPaybutt = FindViewById<Button> (Resource.Id.creditCard);
			Button bankdeps = FindViewById<Button> (Resource.Id.bankDeposit);
			Button achbutt = FindViewById<Button> (Resource.Id.achdeposit);

			//googleWbutt.click este lanza api.. Pendiente

			creditPaybutt.Click += (sender, e) => {
				var cardsend=new Intent(this, typeof(CreditCardPayment));
				StartActivity(cardsend);
			};

			bankdeps.Click += (sender, e) => {
				var banktent = new Intent(this, typeof(BankPayment));
				banktent.PutExtra("dep", 1);
				StartActivity(banktent);
			};

			achbutt.Click += (sender, e) => {
				var achtent=new Intent(this, typeof(BankPayment));
				achtent.PutExtra("dep", 2);
				StartActivity(achtent);
			};

			// Create your application here
		}
	}
}

