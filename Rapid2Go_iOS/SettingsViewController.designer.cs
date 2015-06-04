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
	[Register ("SettingsViewController")]
	partial class SettingsViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnSignOut { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnSignOut != null) {
				btnSignOut.Dispose ();
				btnSignOut = null;
			}
		}
	}
}
