using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Rapid2Go_iOS
{
	partial class PaymentViewController : UIViewController
	{
		public int pack{ get; set; }
		public string size{ get; set; }
		public string address{ get; set; }
		public string start{ get; set; }
		public string end{ get; set; }
		public string comments{ get; set; }
		public string days{ get; set; }

		public PaymentViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		}


		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);
		}

	}
}
