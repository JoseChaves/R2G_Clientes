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
	[Register ("DetailsViewController")]
	partial class DetailsViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnNext { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISegmentedControl segDays { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtAddress { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtComments { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtFinish { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtStart { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnNext != null) {
				btnNext.Dispose ();
				btnNext = null;
			}
			if (segDays != null) {
				segDays.Dispose ();
				segDays = null;
			}
			if (txtAddress != null) {
				txtAddress.Dispose ();
				txtAddress = null;
			}
			if (txtComments != null) {
				txtComments.Dispose ();
				txtComments = null;
			}
			if (txtFinish != null) {
				txtFinish.Dispose ();
				txtFinish = null;
			}
			if (txtStart != null) {
				txtStart.Dispose ();
				txtStart = null;
			}
		}
	}
}
