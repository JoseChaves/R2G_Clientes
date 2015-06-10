// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Rapid2Go_iOS
{
	[Register ("PaymentViewController")]
	partial class PaymentViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnCash { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnCreditCard { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnDeposit { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnTransfer { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnCash != null) {
				btnCash.Dispose ();
				btnCash = null;
			}
			if (btnCreditCard != null) {
				btnCreditCard.Dispose ();
				btnCreditCard = null;
			}
			if (btnDeposit != null) {
				btnDeposit.Dispose ();
				btnDeposit = null;
			}
			if (btnTransfer != null) {
				btnTransfer.Dispose ();
				btnTransfer = null;
			}
		}
	}
}
