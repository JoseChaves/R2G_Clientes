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
	[Register ("CashViewController")]
	partial class CashViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnAddress { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnListo { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblOrderDetails { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnAddress != null) {
				btnAddress.Dispose ();
				btnAddress = null;
			}
			if (btnListo != null) {
				btnListo.Dispose ();
				btnListo = null;
			}
			if (lblOrderDetails != null) {
				lblOrderDetails.Dispose ();
				lblOrderDetails = null;
			}
		}
	}
}
