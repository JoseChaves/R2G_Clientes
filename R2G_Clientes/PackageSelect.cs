
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
	[Activity (Label = "PackageSelect")]			
	public class PackageSelect : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.activity_packages);

			Button submitbutt = FindViewById<Button> (resource.id.submitbutt);
			Spinner spinny = FindViewById<Spinner> (Resource.Id.spinner1);

			spinny.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource (
				this, Resource.Array.cars, Android.Resource.Layout.SimpleSpinnerItem);

			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinny.Adapter = adapter;
			// Create your application here
		}

		private void spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e){
			Spinner spinner = (Spinner)sender;
			RadioButton rdio4 = FindViewById<RadioButton> (Resource.Id.radioButton1);
			RadioButton rdio8 = FindViewById<RadioButton> (Resource.Id.radioButton2);
			RadioButton rdio12 = FindViewById<RadioButton> (Resource.Id.radioButton3);
			int selection = (int)spinner.GetItemIdAtPosition(e.Position);

			switch(selection){

			case 0:
				//rdio4.SetText (Resource.String.fourwashesSmall);
				//rdio8.SetText (Resource.String.eightwashesSmall);
				//rdio12.SetText (Resource.String.twelvewashesSmall);
				break;
			case 1:
			//	rdio4.SetText (Resource.String.fourwashesMed);
			//	rdio8.SetText (Resource.String.eightwashesMed);
			//	rdio12.SetText (Resource.String.twelvewashesMed);
				break;
			case 2:
			///	rdio4.SetText (Resource.String.fourwashesBig);
			//	rdio8.SetText (Resource.String.eightwashesBig);
			//	rdio12.SetText (Resource.String.twelvewashesBig);
				break; 
			}

			//string toast = string.Format ("The planet is {0}", spinner.GetItemAtPosition (e.Position));
			//Toast.MakeText (this, toast, ToastLength.Long).Show ();
		}
	}
}

