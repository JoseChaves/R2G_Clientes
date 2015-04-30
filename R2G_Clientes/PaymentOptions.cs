
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
	[Activity (Label = "@string/paymentoptions", ParentActivity=typeof(PurchaseDetails)) ]			
	public class PaymentOptions : Activity
	{
		string startT, endT, address, seldays, comments;
		int days;
		double price;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.activity_payment_options);
			Button googleWbutt = FindViewById < Button > (Resource.Id.googlePayment);
			Button creditPaybutt = FindViewById<Button> (Resource.Id.creditCard);
			Button bankdeps = FindViewById<Button> (Resource.Id.bankDeposit);
			Button achbutt = FindViewById<Button> (Resource.Id.achdeposit);
			Button cash = FindViewById<Button> (Resource.Id.cash);

			//googleWbutt.click este lanza api.. Pendiente

			startT = Intent.GetStringExtra ("startT");
			price = Intent.GetDoubleExtra ("price", 0);
			days = Intent.GetIntExtra ("days", 0);
			address = Intent.GetStringExtra ("address");
			endT = Intent.GetStringExtra ("endT");
			seldays = Intent.GetStringExtra ("selDays");
			comments = Intent.GetStringExtra ("comments");

			creditPaybutt.Click += (sender, e) => {
				var cardsend=new Intent(this, typeof(CreditCardPayment));
				//StartActivity(cardsend);
				AlertDialog.Builder dialogo = new AlertDialog.Builder (this);
				AlertDialog men = dialogo.Create();
				men.SetTitle (Resource.String.notyet);
				men.SetMessage ("Esta Funcion No está Disponible por el momento.");
				men.SetButton ("Ok",delegate(object send, DialogClickEventArgs er) {
					men.Dismiss();
				});
				men.Show ();
			};

			bankdeps.Click += (sender, e) => {
				//var banktent = new Intent(this, typeof(BankPayment));
				//banktent.PutExtra("dep", 1);
				//StartActivity(banktent);
				AlertDialog.Builder dialogo = new AlertDialog.Builder (this);
				AlertDialog men = dialogo.Create();
				men.SetTitle (Resource.String.notyet);
				men.SetMessage (GetString(Resource.String.notavailable));
				men.SetButton ("Ok",delegate(object send, DialogClickEventArgs er) {
					men.Dismiss();
				});
				men.Show ();
			};

			achbutt.Click += (sender, e) => {
				//var achtent=new Intent(this, typeof(BankPayment));
				//achtent.PutExtra("dep", 2);
				//StartActivity(achtent);
				AlertDialog.Builder dialogo = new AlertDialog.Builder (this);
				AlertDialog men = dialogo.Create();
				men.SetTitle (Resource.String.notyet);
				men.SetMessage ("Esta Funcion No está Disponible por el momento.");
				men.SetButton ("Ok",delegate(object send, DialogClickEventArgs er) {
					men.Dismiss();
				});
				men.Show ();
			};

			cash.Click += (sender, e) => {
				var intent2 = new Intent(this, typeof(Cash));
				intent2.PutExtra("price", price);
				intent2.PutExtra("days", days);
				intent2.PutExtra("address", address);
				intent2.PutExtra("selDays", seldays);
				intent2.PutExtra("startT", startT);
				intent2.PutExtra("endT", endT);
				intent2.PutExtra("comments", comments);
				StartActivity(intent2);
			};

			// Create your application here
		}
	}
}

