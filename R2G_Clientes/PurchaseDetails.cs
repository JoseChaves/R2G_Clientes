
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
//using Android.Runtime;
//using Android.Views;
using Android.Widget;

namespace R2G_Clientes
{
	[Activity (Label = "@string/details", ParentActivity=typeof(PackageSelect))]			
	public class PurchaseDetails : Activity
	{
		string size;
		double price;
		int days;
		EditText locs;
		CheckBox mon, tue, wed, thur, fri, sat, sun;
		EditText startT, endT, comments;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.activity_purchase_details);
			Button submitButt = FindViewById<Button> (Resource.Id.submitButt);
			locs = FindViewById<EditText> (Resource.Id.editText1);
			mon = FindViewById<CheckBox> (Resource.Id.checkBox1);
			tue = FindViewById<CheckBox> (Resource.Id.checkBox2);
			wed = FindViewById<CheckBox> (Resource.Id.checkBox3);
			thur = FindViewById<CheckBox> (Resource.Id.checkBox4);
			fri = FindViewById<CheckBox> (Resource.Id.checkBox5);
			sat = FindViewById<CheckBox> (Resource.Id.checkBox6);
			sun = FindViewById<CheckBox> (Resource.Id.checkBox7);
			startT = FindViewById<EditText> (Resource.Id.editText2);
			endT = FindViewById<EditText> (Resource.Id.editText3);
			comments = FindViewById<EditText> (Resource.Id.editText4);

			price = Intent.GetDoubleExtra ("price", 0);
			days = Intent.GetIntExtra ("days", 0);

			submitButt.Click+= (sender, e) => {
				var subtent = new Intent (this, typeof(PaymentOptions));
				subtent.PutExtra("price", price);
				subtent.PutExtra("days", days);
				subtent.PutExtra("address", locs.Text);
				subtent.PutExtra("selDays", daysFS());
				subtent.PutExtra("startT", startT.Text);
				subtent.PutExtra("endT", endT.Text);
				subtent.PutExtra("comments", comments.Text);
				StartActivity(subtent);
			};
		}

		public string daysFS(){
			string selectedDays = " ";
			if (mon.Checked) {
				selectedDays = selectedDays + "Mon ";
			}

			if (tue.Checked) {
				selectedDays = selectedDays + "Tue ";
			}

			if (wed.Checked) {
				selectedDays = selectedDays + "Wed ";
			}

			if (thur.Checked) {
				selectedDays = selectedDays + "Thur ";
			}

			if (fri.Checked) {
				selectedDays = selectedDays + "Fri ";
			}

			if (sat.Checked) {
				selectedDays = selectedDays + "Sat ";
			}

			if (sun.Checked) {
				selectedDays = selectedDays + "Sun ";
			}

			return selectedDays;
		}
	}
}

