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

namespace R2G_Clients.iOS
{
	[Register ("UsrLoginViewController")]
	partial class UsrLoginViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnLogIn { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtUserLogin { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnLogIn != null) {
				btnLogIn.Dispose ();
				btnLogIn = null;
			}
			if (txtUserLogin != null) {
				txtUserLogin.Dispose ();
				txtUserLogin = null;
			}
		}
	}
}
