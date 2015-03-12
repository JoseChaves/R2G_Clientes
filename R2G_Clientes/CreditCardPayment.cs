
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using R2G_Clientes.Shared;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace R2G_Clientes
{
	[Activity (Label = "CreditCardPayment")]			
	public class CreditCardPayment : Activity
	{
		bool isValid=false;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_payment_credit_card);
			EditText ccNumb = FindViewById<EditText> (Resource.Id.editText1);
			Button done = FindViewById<Button> (Resource.Id.button1);
			TextView tv = FindViewById<TextView> (Resource.Id.textView1);
			// Create your application here

			done.Click += (sender, e) => {
				isValid = R2G_Clientes.Shared.Payments.check(ccNumb.Text);
				if(isValid == true){
					tv.Text="Is Valid";
					isValid= false;
				}else{
					tv.Text="is Not Valid";
				}
			};

		}
	}
}

