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
	[Register ("PackSelectViewController")]
	partial class PackSelectViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnFour { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnSix { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnTen { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnTwelve { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnFour != null) {
				btnFour.Dispose ();
				btnFour = null;
			}
			if (btnSix != null) {
				btnSix.Dispose ();
				btnSix = null;
			}
			if (btnTen != null) {
				btnTen.Dispose ();
				btnTen = null;
			}
			if (btnTwelve != null) {
				btnTwelve.Dispose ();
				btnTwelve = null;
			}
		}
	}
}
