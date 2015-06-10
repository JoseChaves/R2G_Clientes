using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Rapid2Go_iOS
{
	partial class DetailsViewController : UIViewController
	{
		public int pack { get; set;}
		public string size { get; set; }
		int pack2;
		string size2;
		string days="";
		string comments="";
		string address="";
		string start, end;

		public DetailsViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			pack2 = pack;
			size2 = size;



		//	UIAlertView alert = new UIAlertView ("TEST", pack.ToString () + pack2.ToString () + "\n " + size + size2, null, "ok", null);
			//alert.Show ();

			btnNext.TouchUpInside += (sender, e) => {
				switch(segDays.SelectedSegment){
				case 1:
					days= days+ "Mon ";
					break;
				case 2:
					days = days + "Tues	";
					break;
				case 3:
					days = days+ "Wed ";
					break;
				case 4:
					days= days + "Thur ";
					break;
				case 5:
					days = days + "Fri ";
					break;
				case 6:
					days = days + "Sat ";
					break;
				case 7:
					days = days + "Sun ";
					break;
				}

				comments = txtComments.Text;
				address = txtAddress.Text;
				start = txtStart.Text;
				end = txtFinish.Text;

			};

		}


		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			var paymentsVW = segue.DestinationViewController as PaymentViewController;
			paymentsVW.pack = pack2;
			paymentsVW.comments = comments;
			paymentsVW.address = address;
			paymentsVW.days = days;
			paymentsVW.start = start;
			paymentsVW.end = end;
		}



	}
}
